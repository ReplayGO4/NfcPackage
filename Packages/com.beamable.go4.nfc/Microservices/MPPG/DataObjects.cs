namespace DynaProx.MPPGv4Service
{

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessCardSwipeRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessCardSwipeRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private DynaProx.MPPGv4Service.CardSwipeInput CardSwipeInputField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.CardSwipeInput CardSwipeInput
        {
            get
            {
                return this.CardSwipeInputField;
            }
            set
            {
                this.CardSwipeInputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Authentication", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class Authentication : object
    {
        
        private string CustomerCodeField;
        
        private string PasswordField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string CustomerCode
        {
            get
            {
                return this.CustomerCodeField;
            }
            set
            {
                this.CustomerCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardSwipeInput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class CardSwipeInput : object
    {
        
        private string CVVField;
        
        private DynaProx.MPPGv4Service.EncryptedCardSwipe EncryptedCardSwipeField;
        
        private string ZIPField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CVV
        {
            get
            {
                return this.CVVField;
            }
            set
            {
                this.CVVField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.EncryptedCardSwipe EncryptedCardSwipe
        {
            get
            {
                return this.EncryptedCardSwipeField;
            }
            set
            {
                this.EncryptedCardSwipeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ZIP
        {
            get
            {
                return this.ZIPField;
            }
            set
            {
                this.ZIPField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionInput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DynaProx.MPPGv4Service.ReferenceIDTransactionInput))]
    public partial class TransactionInput : object
    {
        
        private System.Nullable<decimal> AmountField;
        
        private string ClientCertAsBase64StringField;
        
        private string ClientCertPasswordField;
        
        private string ProcessorNameField;
        
        private System.Collections.Generic.KeyValuePair<string, string>[] TransactionInputDetailsField;
        
        private DynaProx.MPPGv4Service.TransactionType TransactionTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Amount
        {
            get
            {
                return this.AmountField;
            }
            set
            {
                this.AmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientCertAsBase64String
        {
            get
            {
                return this.ClientCertAsBase64StringField;
            }
            set
            {
                this.ClientCertAsBase64StringField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientCertPassword
        {
            get
            {
                return this.ClientCertPasswordField;
            }
            set
            {
                this.ClientCertPasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcessorName
        {
            get
            {
                return this.ProcessorNameField;
            }
            set
            {
                this.ProcessorNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] TransactionInputDetails
        {
            get
            {
                return this.TransactionInputDetailsField;
            }
            set
            {
                this.TransactionInputDetailsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionType TransactionType
        {
            get
            {
                return this.TransactionTypeField;
            }
            set
            {
                this.TransactionTypeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EncryptedCardSwipe", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class EncryptedCardSwipe : object
    {
        
        private string DeviceSNField;
        
        private string KSNField;
        
        private string MagnePrintField;
        
        private string MagnePrintStatusField;
        
        private string Track1Field;
        
        private string Track2Field;
        
        private string Track3Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviceSN
        {
            get
            {
                return this.DeviceSNField;
            }
            set
            {
                this.DeviceSNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string KSN
        {
            get
            {
                return this.KSNField;
            }
            set
            {
                this.KSNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string MagnePrint
        {
            get
            {
                return this.MagnePrintField;
            }
            set
            {
                this.MagnePrintField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string MagnePrintStatus
        {
            get
            {
                return this.MagnePrintStatusField;
            }
            set
            {
                this.MagnePrintStatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Track1
        {
            get
            {
                return this.Track1Field;
            }
            set
            {
                this.Track1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Track2
        {
            get
            {
                return this.Track2Field;
            }
            set
            {
                this.Track2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Track3
        {
            get
            {
                return this.Track3Field;
            }
            set
            {
                this.Track3Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReferenceIDTransactionInput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ReferenceIDTransactionInput : DynaProx.MPPGv4Service.TransactionInput
    {
        
        private string ReferenceAuthCodeField;
        
        private string ReferenceTransactionIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReferenceAuthCode
        {
            get
            {
                return this.ReferenceAuthCodeField;
            }
            set
            {
                this.ReferenceAuthCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ReferenceTransactionID
        {
            get
            {
                return this.ReferenceTransactionIDField;
            }
            set
            {
                this.ReferenceTransactionIDField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionType", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public enum TransactionType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SALE = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AUTHORIZE = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CAPTURE = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        VOID = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REFUND = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FORCE = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REJECT = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TOKEN = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REPORT = 9,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessCardSwipeResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessCardSwipeResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private DynaProx.MPPGv4Service.CardSwipeOutput CardSwipeOutputField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.CardSwipeOutput CardSwipeOutput
        {
            get
            {
                return this.CardSwipeOutputField;
            }
            set
            {
                this.CardSwipeOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardSwipeOutput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class CardSwipeOutput : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputDataField;
        
        private string CardIDField;
        
        private System.Nullable<bool> IsReplayField;
        
        private System.Nullable<decimal> MagnePrintScoreField;
        
        private string PANLast4Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData
        {
            get
            {
                return this.AdditionalOutputDataField;
            }
            set
            {
                this.AdditionalOutputDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardID
        {
            get
            {
                return this.CardIDField;
            }
            set
            {
                this.CardIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsReplay
        {
            get
            {
                return this.IsReplayField;
            }
            set
            {
                this.IsReplayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> MagnePrintScore
        {
            get
            {
                return this.MagnePrintScoreField;
            }
            set
            {
                this.MagnePrintScoreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PANLast4
        {
            get
            {
                return this.PANLast4Field;
            }
            set
            {
                this.PANLast4Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MPPGv4WSFault", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class MPPGv4WSFault : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalFaultDataField;
        
        private string CustomerTransactionIDField;
        
        private string FaultCodeField;
        
        private string FaultReasonField;
        
        private string MagTranIDField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalFaultData
        {
            get
            {
                return this.AdditionalFaultDataField;
            }
            set
            {
                this.AdditionalFaultDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultCode
        {
            get
            {
                return this.FaultCodeField;
            }
            set
            {
                this.FaultCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultReason
        {
            get
            {
                return this.FaultReasonField;
            }
            set
            {
                this.FaultReasonField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionOutput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class TransactionOutput : object
    {
        
        private string AVSResultField;
        
        private string AuthCodeField;
        
        private System.Nullable<decimal> AuthorizedAmountField;
        
        private string CVVResultField;
        
        private bool IsTransactionApprovedField;
        
        private string IssuerAuthenticationDataField;
        
        private string IssuerScriptTemplate1Field;
        
        private string IssuerScriptTemplate2Field;
        
        private string TokenField;
        
        private string TransactionIDField;
        
        private string TransactionMessageField;
        
        private System.Collections.Generic.KeyValuePair<string, string>[] TransactionOutputDetailsField;
        
        private string TransactionStatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AVSResult
        {
            get
            {
                return this.AVSResultField;
            }
            set
            {
                this.AVSResultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthCode
        {
            get
            {
                return this.AuthCodeField;
            }
            set
            {
                this.AuthCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> AuthorizedAmount
        {
            get
            {
                return this.AuthorizedAmountField;
            }
            set
            {
                this.AuthorizedAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CVVResult
        {
            get
            {
                return this.CVVResultField;
            }
            set
            {
                this.CVVResultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsTransactionApproved
        {
            get
            {
                return this.IsTransactionApprovedField;
            }
            set
            {
                this.IsTransactionApprovedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssuerAuthenticationData
        {
            get
            {
                return this.IssuerAuthenticationDataField;
            }
            set
            {
                this.IssuerAuthenticationDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssuerScriptTemplate1
        {
            get
            {
                return this.IssuerScriptTemplate1Field;
            }
            set
            {
                this.IssuerScriptTemplate1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssuerScriptTemplate2
        {
            get
            {
                return this.IssuerScriptTemplate2Field;
            }
            set
            {
                this.IssuerScriptTemplate2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Token
        {
            get
            {
                return this.TokenField;
            }
            set
            {
                this.TokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionID
        {
            get
            {
                return this.TransactionIDField;
            }
            set
            {
                this.TransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionMessage
        {
            get
            {
                return this.TransactionMessageField;
            }
            set
            {
                this.TransactionMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] TransactionOutputDetails
        {
            get
            {
                return this.TransactionOutputDetailsField;
            }
            set
            {
                this.TransactionOutputDetailsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionStatus
        {
            get
            {
                return this.TransactionStatusField;
            }
            set
            {
                this.TransactionStatusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessReferenceIDRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessReferenceIDRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.ReferenceIDTransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.ReferenceIDTransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessReferenceIDResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessReferenceIDResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessManualEntryRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessManualEntryRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.ManualEntryInput ManualEntryInputField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.ManualEntryInput ManualEntryInput
        {
            get
            {
                return this.ManualEntryInputField;
            }
            set
            {
                this.ManualEntryInputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ManualEntryInput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ManualEntryInput : object
    {
        
        private string AddressLine1Field;
        
        private string AddressLine2Field;
        
        private string CVVField;
        
        private string CityField;
        
        private string CountryField;
        
        private string ExpirationDateField;
        
        private string NameOnCardField;
        
        private string PANField;
        
        private string StateField;
        
        private string ZIPField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AddressLine1
        {
            get
            {
                return this.AddressLine1Field;
            }
            set
            {
                this.AddressLine1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AddressLine2
        {
            get
            {
                return this.AddressLine2Field;
            }
            set
            {
                this.AddressLine2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CVV
        {
            get
            {
                return this.CVVField;
            }
            set
            {
                this.CVVField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                this.CityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country
        {
            get
            {
                return this.CountryField;
            }
            set
            {
                this.CountryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ExpirationDate
        {
            get
            {
                return this.ExpirationDateField;
            }
            set
            {
                this.ExpirationDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NameOnCard
        {
            get
            {
                return this.NameOnCardField;
            }
            set
            {
                this.NameOnCardField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string PAN
        {
            get
            {
                return this.PANField;
            }
            set
            {
                this.PANField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ZIP
        {
            get
            {
                return this.ZIPField;
            }
            set
            {
                this.ZIPField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessManualEntryResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessManualEntryResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessTokenRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessTokenRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private string TokenField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Token
        {
            get
            {
                return this.TokenField;
            }
            set
            {
                this.TokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessTokenResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessTokenResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private string PANLast4Field;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PANLast4
        {
            get
            {
                return this.PANLast4Field;
            }
            set
            {
                this.PANLast4Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessDataRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessDataRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.DataInput DataInputField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.DataInput DataInput
        {
            get
            {
                return this.DataInputField;
            }
            set
            {
                this.DataInputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataInput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class DataInput : object
    {
        
        private string DataField;
        
        private DynaProx.MPPGv4Service.FormatType DataFormatTypeField;
        
        private DynaProx.MPPGv4Service.EncryptionInfo EncryptionInfoField;
        
        private bool IsEncryptedField;
        
        private DynaProx.MPPGv4Service.PaymentMode PaymentModeField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Data
        {
            get
            {
                return this.DataField;
            }
            set
            {
                this.DataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.FormatType DataFormatType
        {
            get
            {
                return this.DataFormatTypeField;
            }
            set
            {
                this.DataFormatTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.EncryptionInfo EncryptionInfo
        {
            get
            {
                return this.EncryptionInfoField;
            }
            set
            {
                this.EncryptionInfoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsEncrypted
        {
            get
            {
                return this.IsEncryptedField;
            }
            set
            {
                this.IsEncryptedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.PaymentMode PaymentMode
        {
            get
            {
                return this.PaymentModeField;
            }
            set
            {
                this.PaymentModeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EncryptionInfo", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class EncryptionInfo : object
    {
        
        private string EncryptionTypeField;
        
        private string KSNField;
        
        private int NumberOfPaddedBytesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EncryptionType
        {
            get
            {
                return this.EncryptionTypeField;
            }
            set
            {
                this.EncryptionTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string KSN
        {
            get
            {
                return this.KSNField;
            }
            set
            {
                this.KSNField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberOfPaddedBytes
        {
            get
            {
                return this.NumberOfPaddedBytesField;
            }
            set
            {
                this.NumberOfPaddedBytesField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FormatType", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public enum FormatType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TLV = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NONE = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentMode", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public enum PaymentMode : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = -1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MagStripe = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EMV = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ManualEntry = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessDataResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessDataResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.DataOutput DataOutputField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.DataOutput DataOutput
        {
            get
            {
                return this.DataOutputField;
            }
            set
            {
                this.DataOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataOutput", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class DataOutput : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputDataField;
        
        private string CardIDField;
        
        private System.Nullable<bool> IsReplayField;
        
        private string PANLast4Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData
        {
            get
            {
                return this.AdditionalOutputDataField;
            }
            set
            {
                this.AdditionalOutputDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardID
        {
            get
            {
                return this.CardIDField;
            }
            set
            {
                this.CardIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsReplay
        {
            get
            {
                return this.IsReplayField;
            }
            set
            {
                this.IsReplayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PANLast4
        {
            get
            {
                return this.PANLast4Field;
            }
            set
            {
                this.PANLast4Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessKeyPadEntryRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessKeyPadEntryRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private DynaProx.MPPGv4Service.CardSwipeInput CardSwipeInputField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.CardSwipeInput CardSwipeInput
        {
            get
            {
                return this.CardSwipeInputField;
            }
            set
            {
                this.CardSwipeInputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessKeyPadEntryResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessKeyPadEntryResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private DynaProx.MPPGv4Service.CardSwipeOutput CardSwipeOutputField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.CardSwipeOutput CardSwipeOutput
        {
            get
            {
                return this.CardSwipeOutputField;
            }
            set
            {
                this.CardSwipeOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetProcessorReportRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class GetProcessorReportRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetProcessorReportResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class GetProcessorReportResponse : object
    {
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessInAppApplePayRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessInAppApplePayRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private string ApplePayTokenField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ApplePayToken
        {
            get
            {
                return this.ApplePayTokenField;
            }
            set
            {
                this.ApplePayTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessInAppApplePayResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessInAppApplePayResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputDataField;
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData
        {
            get
            {
                return this.AdditionalOutputDataField;
            }
            set
            {
                this.AdditionalOutputDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessTECApplePayRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessTECApplePayRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private string ApplePayTokenField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ApplePayToken
        {
            get
            {
                return this.ApplePayTokenField;
            }
            set
            {
                this.ApplePayTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessTECApplePayResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessTECApplePayResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputDataField;
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData
        {
            get
            {
                return this.AdditionalOutputDataField;
            }
            set
            {
                this.AdditionalOutputDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessGooglePayRequest", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessGooglePayRequest : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestDataField;
        
        private DynaProx.MPPGv4Service.Authentication AuthenticationField;
        
        private string CustomerTransactionIDField;
        
        private string GooglePayTokenField;
        
        private DynaProx.MPPGv4Service.TransactionInput TransactionInputField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalRequestData
        {
            get
            {
                return this.AdditionalRequestDataField;
            }
            set
            {
                this.AdditionalRequestDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.Authentication Authentication
        {
            get
            {
                return this.AuthenticationField;
            }
            set
            {
                this.AuthenticationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string GooglePayToken
        {
            get
            {
                return this.GooglePayTokenField;
            }
            set
            {
                this.GooglePayTokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public DynaProx.MPPGv4Service.TransactionInput TransactionInput
        {
            get
            {
                return this.TransactionInputField;
            }
            set
            {
                this.TransactionInputField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "1.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessGooglePayResponse", Namespace="http://schemas.datacontract.org/2004/07/MPPGv4WS.Core")]
    public partial class ProcessGooglePayResponse : object
    {
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputDataField;
        
        private System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseDataField;
        
        private string CustomerTransactionIDField;
        
        private DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFaultField;
        
        private string MagTranIDField;
        
        private DynaProx.MPPGv4Service.TransactionOutput TransactionOutputField;
        
        private string TransactionUTCTimestampField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalOutputData
        {
            get
            {
                return this.AdditionalOutputDataField;
            }
            set
            {
                this.AdditionalOutputDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] AdditionalResponseData
        {
            get
            {
                return this.AdditionalResponseDataField;
            }
            set
            {
                this.AdditionalResponseDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerTransactionID
        {
            get
            {
                return this.CustomerTransactionIDField;
            }
            set
            {
                this.CustomerTransactionIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.MPPGv4WSFault MPPGv4WSFault
        {
            get
            {
                return this.MPPGv4WSFaultField;
            }
            set
            {
                this.MPPGv4WSFaultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MagTranID
        {
            get
            {
                return this.MagTranIDField;
            }
            set
            {
                this.MagTranIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DynaProx.MPPGv4Service.TransactionOutput TransactionOutput
        {
            get
            {
                return this.TransactionOutputField;
            }
            set
            {
                this.TransactionOutputField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionUTCTimestamp
        {
            get
            {
                return this.TransactionUTCTimestampField;
            }
            set
            {
                this.TransactionUTCTimestampField = value;
            }
        }
    }
    
}