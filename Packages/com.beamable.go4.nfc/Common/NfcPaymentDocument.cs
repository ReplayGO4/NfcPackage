using System;
using System.Runtime.CompilerServices;
using Beamable.Server;

namespace Beamable.Go4.Nfc.Common
{

    public class TestDocument : StorageDocument
    {
        public int count;
    }
    
    [Serializable]
    public class NfcPaymentDocument : StorageDocument
    {
        public string magTekTransactionId;
        public string customerTransactionId;
        public string amount;
        public string beamableListingId;
        public string beamableSkuId;
        public long gamerTag;

        public bool startedProcessing;

        public NfcPaymentStatus paymentStatus;
  
        public NfcFulfillmentStatus fulfillmentStatus;
        
        public long createdAt;
        public long updatedAt;
        public string paymentToken;
    }

    public enum NfcPaymentStatus
    {
        AWAITING_PROCESSING,
        PENDING,
        SUCCESS,
        FAILED,
        REFUND_PENDING,
        REFUND_SUCCESS,
        REFUND_FAILED
    }

    public enum NfcFulfillmentStatus
    {
        AWAITING_PAYMENT,
        PENDING,
        SUCCESS,
        FAILED
    }
    
    

    [Serializable]
    public class NfcPaymentEventDocument : StorageDocument
    {
        public string paymentId;
        public string customerTransactionId;
        public long createdAt;
        public string message;
        public string data;
        public long createdByGamerTag;
        public NfcPaymentEventType eventType;
    }

    public enum NfcPaymentEventType
    {
        OPENED,
        STARTING_CHARGE,
        FINISHED_CHARGE,
        FAILED_CHARGE,
        STARTING_FULFILL,
        FINISHED_FULFILL,
        DECLINED,
        FAILED_FULFILLMENT,
        STARTED_FORCE_REFUND,
        FINISHED_FORCE_REFUND,
        FAILED_FORCE_REFUND
    }
    
}