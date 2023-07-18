using System;
using System.Collections.Generic;
using Beamable.Common;
using Beamable.Common.Api;
using Beamable.Common.Shop;
using Beamable.Go4.Nfc.Common;
using Beamable.Server;
using Beamable.Server.Api.Content;
using Beamable.Server.Api.Inventory;
using MongoDB.Driver;
using UnityEngine;
using Optional = Beamable.Common.Content.Optional;

namespace Beamable.Go4.Nfc.Microservices
{
    public class NfcPaymentService
    {
        private readonly IMicroserviceContentApi _content;
        private readonly MagTekService _magTekService;
        private readonly IStorageObjectConnectionProvider _storageProvider;
        private readonly NfcPaymentEventBatcher _batcher;
        private readonly IUserContext _userContext;

        public NfcPaymentService(
            IMicroserviceContentApi content, 
            MagTekService magTekService, 
            IStorageObjectConnectionProvider storageProvider,
            NfcPaymentEventBatcher batcher,
            IUserContext userContext)
        {
            _content = content;
            _magTekService = magTekService;
            _storageProvider = storageProvider;
            _batcher = batcher;
            _userContext = userContext;
        }

        private Promise<IMongoCollection<NfcPaymentDocument>> GetCollection() =>
            _storageProvider.PaymentStorageCollection<NfcPaymentDocument>();

        public async Promise<MagtekRefundResponse> RefundNfcPayment(string paymentId)
        {
            var collection = await GetCollection();
            var transaction = await collection.Find(x => x.Id == paymentId).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(transaction.paymentToken))
            {
                throw new MicroserviceException(400, "transaction not paid",
                    "there is no payment token for this transaction, so no refund can be given");
            }
            
            await _batcher.Add(new NfcPaymentEventDocument
            {
                customerTransactionId = transaction.customerTransactionId,
                eventType = NfcPaymentEventType.STARTED_FORCE_REFUND,
                message = "starting force refund",
                paymentId = paymentId,
                createdByGamerTag = _userContext.UserId
            });

            var res = await _magTekService.RefundPayment(transaction.paymentToken, transaction.amount);
            var resJson = JsonHack.ToJson(res);
            
            if (res.TransactionOutput?.IsTransactionApproved ?? false)
            {
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = transaction.customerTransactionId,
                    eventType = NfcPaymentEventType.FINISHED_FORCE_REFUND,
                    message = "finished force refund",
                    paymentId = paymentId,
                    data = resJson,
                    createdByGamerTag = _userContext.UserId
                });
                
                return new MagtekRefundResponse
                {
                    success = true,
                    message = "refunded"
                };
            }
            else
            {
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = transaction.customerTransactionId,
                    eventType = NfcPaymentEventType.FAILED_FORCE_REFUND,
                    message = "failed force refund",
                    paymentId = paymentId,
                    data = resJson,
                    createdByGamerTag = _userContext.UserId
                });
                
                return new MagtekRefundResponse
                {
                    success = false,
                    message = "refund failed"
                };
            }
        }

        public async Promise<MagtekFinishPaymentResponse> ForceFulfillNfcPayment(Func<long, IMicroserviceInventoryApi> playerInventoryFactory, string paymentId)
        {
            var collection = await GetCollection();
            var transaction = await collection.Find(x => x.Id == paymentId).FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new MicroserviceException(404, "transaction not found",
                    "no transaction exists with the given id");
            }

            var playerInventory = playerInventoryFactory(transaction.gamerTag);
            
            var fulfillment = await HandleFulfillment
            (
                customerTransactionId: transaction.customerTransactionId,
                paymentId: transaction.Id,
                listingId: transaction.beamableListingId,
                inventoryApi: playerInventory
            );
            transaction.fulfillmentStatus = NfcFulfillmentStatus.SUCCESS;
            if (!fulfillment.success)
            {
                transaction.fulfillmentStatus = NfcFulfillmentStatus.FAILED;
                return new MagtekFinishPaymentResponse
                {
                    status = MagtekFinishPaymentStatus.FULFILLMENT_FAILED,
                    success = false
                };
            }

            return new MagtekFinishPaymentResponse
            {
                status = MagtekFinishPaymentStatus.SUCCESS,
                success = true
            };

        }

        public async Promise<MagtekFinishPaymentResponse> FinishNfcPayment(IMicroserviceInventoryApi playerInventory, MagtekFinishPaymentRequest request)
        {
            var collection = await GetCollection();
            var transaction = await collection.FindOneAndUpdateAsync(
                // the filter finds a document that matches id, and has not started processing yet...
                filter: Builders<NfcPaymentDocument>.Filter.And(
                    Builders<NfcPaymentDocument>.Filter.Eq(x => x.Id, request.nfcPaymentId),
                    Builders<NfcPaymentDocument>.Filter.Eq(x => x.startedProcessing, false)),
                
                // and atomically updates the document to startProcessing=true, so that no other read operation will find it.
                update: Builders<NfcPaymentDocument>.Update.Set(x => x.startedProcessing, true));


            if (transaction == null)
            {
                throw new MicroserviceException(404, "transaction not found",
                    "the given transaction id either does not exist, or has already starting processing");
            }
            
            transaction.startedProcessing = true;

            try
            {
                transaction.paymentStatus = NfcPaymentStatus.PENDING;
                var payment = await HandlePayment(
                    transactionAmount: transaction.amount,
                    customerTransactionId: transaction.customerTransactionId,
                    transactionCryptogram: request.transactionCryptogram,
                    paymentId: transaction.Id
                );

                transaction.paymentToken = payment.paymentToken;
                transaction.paymentStatus = NfcPaymentStatus.SUCCESS;
                transaction.magTekTransactionId = payment.magTekTransactionId;
                if (!payment.success)
                {
                    transaction.paymentStatus = NfcPaymentStatus.FAILED;
                    return new MagtekFinishPaymentResponse
                    {
                        status = MagtekFinishPaymentStatus.PAYMENT_FAILED,
                        success = false
                    };
                }

                transaction.fulfillmentStatus = NfcFulfillmentStatus.PENDING;
                var fulfillment = await HandleFulfillment
                (
                    customerTransactionId: transaction.customerTransactionId,
                    paymentId: transaction.Id,
                    listingId: transaction.beamableListingId,
                    inventoryApi: playerInventory
                );
                transaction.fulfillmentStatus = NfcFulfillmentStatus.SUCCESS;
                if (!fulfillment.success)
                {
                    transaction.fulfillmentStatus = NfcFulfillmentStatus.FAILED;
                    return new MagtekFinishPaymentResponse
                    {
                        status = MagtekFinishPaymentStatus.FULFILLMENT_FAILED,
                        success = false
                    };
                }
                
                return new MagtekFinishPaymentResponse
                {
                    success = true,
                    status = MagtekFinishPaymentStatus.SUCCESS
                };
            }
            finally
            {
                transaction.updatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                await collection.ReplaceOneAsync(x => x.Id == transaction.Id, transaction);
            }
        }


        // public async Promise<MagtekFinishPaymentResponse> FinishNfcPayment(IMicroserviceInventoryApi playerInventory, MagtekFinishPaymentRequest request)
        // {
        //     var collection = await GetCollection();
        //     var transaction = await collection.FindOneAndUpdateAsync(
        //         // the filter finds a document that matches id, and has not started processing yet...
        //         filter: Builders<NfcPaymentDocument>.Filter.And(
        //             Builders<NfcPaymentDocument>.Filter.Eq(x => x.Id, request.nfcPaymentId),
        //             Builders<NfcPaymentDocument>.Filter.Eq(x => x.startedProcessing, false)),
        //         
        //         // and atomically updates the document to startProcessing=true, so that no other read operation will find it.
        //         update: Builders<NfcPaymentDocument>.Update.Set(x => x.startedProcessing, true));
        //
        //
        //     if (transaction == null)
        //     {
        //         throw new MicroserviceException(404, "transaction not found",
        //             "the given transaction id either does not exist, or has already starting processing");
        //     }
        //     
        //     // if the transaction is already fulfilled, then we should do nothing. It does not matter if it is paid or not, the customer has the goods already!
        //     if (transaction.hasProcessedFulfillment)
        //     {
        //         // TODO: if nothing sets startedProcessing back to false, then this is dead code, because how could the trasnaction be fulfilled if the only way to get to the if statement is have startedPorcessing=false ? 
        //         return new MagtekFinishPaymentResponse
        //         {
        //             success = true,
        //             message = "already fulfilled",
        //             customerTransactionId = transaction.customerTransactionId
        //         };
        //     }
        //
        //     try
        //     {
        //         // if the transaction is not paid, we need to pay first.
        //         if (!transaction.hasProcessedPayment)
        //         {
        //             var payment = await HandlePayment(
        //                 transactionAmount: transaction.amount,
        //                 customerTransactionId: transaction.customerTransactionId,
        //                 transactionCryptogram: request.transactionCryptogram,
        //                 paymentId: transaction.Id
        //             );
        //             transaction.hasProcessedPayment = payment.success;
        //             if (!payment.success)
        //             {
        //                 // if the payment failed, then return an error to the user.
        //                 return payment;
        //             }
        //         }
        //
        //         var fulfillment = await HandleFulfillment
        //         (
        //             customerTransactionId: transaction.customerTransactionId,
        //             paymentId: transaction.Id,
        //             listingId: transaction.beamableListingId,
        //             inventoryApi: playerInventory
        //         );
        //         transaction.hasProcessedFulfillment = fulfillment.success;
        //         return fulfillment;
        //     }
        //     finally
        //     {
        //         transaction.updatedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        //         await collection.ReplaceOneAsync(x => x.Id == transaction.Id, transaction);
        //     }
        // }


        public async Promise<MagtekBeginPaymentResponse> BeginNfcPayment(long gamerTag, MagtekBeginPaymentRequest request)
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            var listing = await _content.GetContent(request.listingRef);
            if (!IsValidListing(listing, out var reason))
            {
                throw new MicroserviceException(400, "invalid listing", reason);
            }
            
            var skuRef = new SKURef { Id = listing.price.symbol };
            var sku = await _content.GetContent(skuRef);
            var amount = sku.realPrice;

            var transactionId = Guid.NewGuid().ToString();
            
            var record = new NfcPaymentDocument
            {
                beamableListingId = listing.Id,
                beamableSkuId = sku.Id,
                amount = amount.ToString(),
                customerTransactionId = transactionId,
                gamerTag = gamerTag,
                createdAt = now,
                updatedAt = now
            };
            var collection = await GetCollection();
            
            await collection.InsertOneAsync(record);

            await _batcher.Add(new NfcPaymentEventDocument
            {
                createdAt = now,
                customerTransactionId = transactionId,
                eventType = NfcPaymentEventType.OPENED,
                message = "created",
                paymentId = record.Id,
                createdByGamerTag = _userContext.UserId
            });

            
            var response = new MagtekBeginPaymentResponse
            {
                nfcPaymentId = record.Id,
                skuRef = skuRef,
                listingRef = request.listingRef,
                amount = amount.ToString(),
                customerTransactionId = transactionId
            };
            
            return response;
        }

        class FulfillmentResult
        {
            public bool success;
            public string message;
        }
        
        async Promise<FulfillmentResult> HandleFulfillment(
            string customerTransactionId,
            string paymentId,
            string listingId,
            IMicroserviceInventoryApi inventoryApi)
        {
            var listing = await _content.GetContent<ListingContent>(new ListingRef { Id = listingId });


            try
            {
                
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.STARTING_FULFILL,
                    message = "fulfill-starting",
                    paymentId = paymentId,
                    createdByGamerTag = _userContext.UserId
                });


                await inventoryApi.Update(builder =>
                {
                    foreach (var offerCurr in listing.offer.obtainCurrency)
                    {
                        builder.CurrencyChange(offerCurr.symbol, offerCurr.amount);
                    }
                });
                
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.FINISHED_FULFILL,
                    message = "fulfill-finished",
                    paymentId = paymentId,
                    createdByGamerTag = _userContext.UserId
                });


                
                return new FulfillmentResult
                {
                    success = true,
                    message = "fulfilled",
                };
            }
            catch (Exception ex)
            {
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.FAILED_FULFILLMENT,
                    message = "failed-fulfillment",
                    data = JsonUtility.ToJson(ex),
                    paymentId = paymentId,
                    createdByGamerTag = _userContext.UserId
                });
                return new FulfillmentResult
                {
                    success = false,
                    message = "failed-fulfilled",
                };
            }

        }


        class PaymentResult
        {
            public bool success;
            public string message;
            public string magTekTransactionId;
            public string paymentToken;
        }
        
        async Promise<PaymentResult> HandlePayment(
            string customerTransactionId,
            string transactionCryptogram, 
            string transactionAmount, 
            string paymentId)
        {
            try
            {
                var paymentRequest = new MagtekPaymentRequest
                {
                    customerTransactionId = customerTransactionId,
                    transactionToken = transactionCryptogram,
                    amount = transactionAmount
                };
                
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.STARTING_CHARGE,
                    message = "charge-starting",
                    paymentId = paymentId,
                    createdByGamerTag = _userContext.UserId
                });

                
                var processResponse = await _magTekService.DoPayment(paymentRequest);
                var processResponseRawJson = JsonHack.ToJson(processResponse);
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.FINISHED_CHARGE,
                    message = "charge-finished",
                    paymentId = paymentId,
                    data = processResponseRawJson,
                    createdByGamerTag = _userContext.UserId
                });


                if (processResponse.TransactionOutput?.IsTransactionApproved ?? false) 
                {
                    return new PaymentResult
                    {
                        success = true,
                        magTekTransactionId = processResponse.MagTranID,
                        message = "paid",
                        paymentToken = processResponse.TransactionOutput.Token
                    };
                }
                else
                {
                    await _batcher.Add(new NfcPaymentEventDocument
                    {
                        customerTransactionId = customerTransactionId,
                        eventType = NfcPaymentEventType.DECLINED,
                        message = "declined-charge",
                        paymentId = paymentId,
                        data = processResponseRawJson,
                        createdByGamerTag = _userContext.UserId
                    });
                    return new PaymentResult
                    {
                        success = false,
                        magTekTransactionId = processResponse.MagTranID,
                        message = "payment declined",
                        paymentToken = processResponse.TransactionOutput.Token
                    };
                }

            }
            catch (Exception ex)
            {
                await _batcher.Add(new NfcPaymentEventDocument
                {
                    customerTransactionId = customerTransactionId,
                    eventType = NfcPaymentEventType.FAILED_CHARGE,
                    message = "failed-charge",
                    data = JsonHack.ToJson(ex),
                    paymentId = paymentId,
                    createdByGamerTag = _userContext.UserId
                });
                throw;
            }
        }



        private bool IsValidListing(ListingContent listing, out string reason)
        {
            reason = "";
            if (listing.offer.obtainItems?.Count > 0)
            {
                reason = "Listing does not support offer with items";
                return false;
            }
            var isSkuListing = listing.price.type == "skus";
            if (!isSkuListing)
            {
                reason = "Listing must be using a sku";
                return false;
            }

            var unSupportedOptions = new List<(Optional, string)>
            {
                (listing.schedule, "Listing cannot support schedule"),
                (listing.activePeriod, "Listing cannot support active period"),
                (listing.cohortRequirements, "Listing cannot support cohortRequirements"),
                (listing.offerRequirements, "Listing cannot support offerRequirements"),
                (listing.purchaseLimit, "Listing cannot support purchaseLimit"),
                (listing.activeDurationSeconds, "Listing cannot support activeDurationSeconds"),
                (listing.playerStatRequirements, "Listing cannot support playerStatRequirements"),
                (listing.activeDurationPurchaseLimit, "Listing cannot support activeDurationPurchaseLimit"),
                (listing.activeDurationCoolDownSeconds, "Listing cannot support activeDurationCoolDownSeconds"),
            };

            foreach (var option in unSupportedOptions)
            {
                if (option.Item1.HasValue)
                {
                    reason = option.Item2;
                    return false;
                }
            }
            
            return true;
        }

        public async Promise<List<NfcPaymentDocument>> GetPayment(string paymentId)
        {
            var collection = await GetCollection();
            var cursor = await collection.FindAsync(Builders<NfcPaymentDocument>.Filter.Eq(x => x.Id, paymentId));
            var set = await cursor.ToListAsync();
            return set;
        }
        
        public async Promise<List<NfcPaymentDocument>> GetPlayerPayments(long gamerTag, int offset, int limit)
        {
            var collection = await GetCollection();
            var cursor = await collection.FindAsync(Builders<NfcPaymentDocument>.Filter.Eq(x => x.gamerTag, gamerTag), new FindOptions<NfcPaymentDocument>
            {
                AllowPartialResults = true,
                Limit = limit,
                Skip = offset
            });
           
            var set = await cursor.ToListAsync();
            return set;
        }
    }
}

