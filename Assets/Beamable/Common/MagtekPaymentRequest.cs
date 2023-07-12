using System;
using Beamable.Common.Shop;

namespace Beamable.Common
{
    [Serializable]
    public class MagtekPaymentRequest
    {
        public string amount;
        public string transactionToken;
        /// <inheritdoc cref="MagtekBeginPaymentResponse.customerTransactionId"/>
        public string customerTransactionId;
    }

    [Serializable]
    public class MagtekPaymentResponse
    {
        public bool isSuccess;
        public string message;
        public string magTekTransactionId;
        /// <inheritdoc cref="MagtekBeginPaymentResponse.customerTransactionId"/>
        public string customerTransactionId;

    }

    [Serializable]
    public class MagtekFinishPaymentRequest
    {
        /// <inheritdoc cref="MagtekBeginPaymentResponse.customerTransactionId"/>
        public string customerTransactionId;

        public string transactionAmount;
        
        public string transactionCryptogram;

        public string nfcPaymentId;
    }

    [Serializable]
    public class MagtekFinishPaymentResponse
    {
        public bool success;
        public MagtekFinishPaymentStatus status;
    }

    public enum MagtekFinishPaymentStatus
    {
        SUCCESS,
        PAYMENT_FAILED,
        FULFILLMENT_FAILED
    }

    [Serializable]
    public class MagtekRefundResponse
    {
        public bool success;
        public string message;
    }
    
    
    [Serializable]
    public class MagtekBeginPaymentRequest
    {
        public ListingRef listingRef;
    }

    [Serializable]
    public class MagtekBeginPaymentResponse
    {
        public string amount;

        public SKURef skuRef;
        public ListingRef listingRef;

        public string nfcPaymentId;
        
        /// <summary>
        /// an id for the transaction. The "customer" nature means this id is created by the Payment C#MS.
        /// </summary>
        public string customerTransactionId;
    }
    
}