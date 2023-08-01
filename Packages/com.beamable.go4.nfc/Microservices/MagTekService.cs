using System;
using Beamable.Common;
using Beamable.Go4.Nfc.Common;
using DynaProx.MPPGv4Service;

namespace Beamable.Go4.Nfc.Microservices
{
    public class MagTekService
    {
        private readonly PaymentServiceSettings _config;
        private readonly IStandardMPPGv4Service _client;

        public MagTekService(PaymentServiceSettings config, IStandardMPPGv4Service client)
        {
            _config = config;
            _client = client;
        }

        public async Promise<ProcessTokenResponse> RefundPayment(string paymentToken, string amountStr)
        {
            var settings = await _config.LoadSettings();

            
            if (!decimal.TryParse(amountStr, out var amount))
            {
                throw new Exception($"unparsable amount str=[{amountStr}]");
            }
            var responses = await _client.ProcessTokenAsync(new ProcessTokenRequest[]
            {
                new ProcessTokenRequest
                {
                    Authentication = settings.ToAuth(),
                    CustomerTransactionID = Guid.NewGuid().ToString(),
                    Token = paymentToken,
                    TransactionInput = new TransactionInput
                    {
                        Amount = amount,
                        ProcessorName = settings.processor,
                        TransactionType = TransactionType.REFUND,
                    }
                }
            });

            var response = responses[0];


            return response;
        }

        public async Promise<ProcessDataResponse> DoPayment(MagtekPaymentRequest request)
        {
            var settings = await _config.LoadSettings();

            if (!decimal.TryParse(request.amount, out var amount))
            {
                throw new Exception($"unparsable amount str=[{request.amount}]");
            }
            
            var responses = await _client.ProcessDataAsync(new ProcessDataRequest[]
            {
                new ProcessDataRequest
                {
                    DataInput = new DataInput
                    {
                        Data = request.transactionToken,
                        DataFormatType = FormatType.TLV,
                        EncryptionInfo = new EncryptionInfo
                        {

                        },
                        IsEncrypted = true,
                        PaymentMode = PaymentMode.EMV
                    },
                    Authentication = settings.ToAuth(),
                    TransactionInput = new TransactionInput
                    {
                        Amount = amount,
                        ProcessorName = settings.processor,
                        TransactionType = TransactionType.SALE

                    },
                    CustomerTransactionID = request.customerTransactionId
                }
            });

            var response = responses[0];


            return response;
        }


    }
}