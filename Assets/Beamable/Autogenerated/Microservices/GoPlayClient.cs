//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beamable.Server.Clients
{
    using System;
    using Beamable.Platform.SDK;
    using Beamable.Server;
    
    
    /// <summary> A generated client for <see cref="Beamable.Microservices.GoPlay"/> </summary
    public sealed class GoPlayClient : MicroserviceClient, Beamable.Common.IHaveServiceName
    {
        
        public GoPlayClient(BeamContext context = null) : 
                base(context)
        {
        }
        
        public string ServiceName
        {
            get
            {
                return "GoPlay";
            }
        }
        
        /// <summary>
        /// Call the BeginNfcPayment method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.BeginNfcPayment"/>
        /// </summary>
        public Beamable.Common.Promise<Beamable.Go4.Nfc.Common.MagtekBeginPaymentResponse> BeginNfcPayment(Beamable.Go4.Nfc.Common.MagtekBeginPaymentRequest request)
        {
            string serialized_request = this.SerializeArgument<Beamable.Go4.Nfc.Common.MagtekBeginPaymentRequest>(request);
            string[] serializedFields = new string[] {
                    serialized_request};
            return this.Request<Beamable.Go4.Nfc.Common.MagtekBeginPaymentResponse>("GoPlay", "BeginNfcPayment", serializedFields);
        }
        
        /// <summary>
        /// Call the FinishNfcPayment method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.FinishNfcPayment"/>
        /// </summary>
        public Beamable.Common.Promise<Beamable.Go4.Nfc.Common.MagtekFinishPaymentResponse> FinishNfcPayment(Beamable.Go4.Nfc.Common.MagtekFinishPaymentRequest request)
        {
            string serialized_request = this.SerializeArgument<Beamable.Go4.Nfc.Common.MagtekFinishPaymentRequest>(request);
            string[] serializedFields = new string[] {
                    serialized_request};
            return this.Request<Beamable.Go4.Nfc.Common.MagtekFinishPaymentResponse>("GoPlay", "FinishNfcPayment", serializedFields);
        }
        
        /// <summary>
        /// Call the Admin_ForceFulfillNfcPayment method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.Admin_ForceFulfillNfcPayment"/>
        /// </summary>
        public Beamable.Common.Promise<Beamable.Go4.Nfc.Common.MagtekFinishPaymentResponse> Admin_ForceFulfillNfcPayment(string paymentId)
        {
            string serialized_paymentId = this.SerializeArgument<string>(paymentId);
            string[] serializedFields = new string[] {
                    serialized_paymentId};
            return this.Request<Beamable.Go4.Nfc.Common.MagtekFinishPaymentResponse>("GoPlay", "Admin_ForceFulfillNfcPayment", serializedFields);
        }
        
        /// <summary>
        /// Call the Admin_RefundNfcPayment method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.Admin_RefundNfcPayment"/>
        /// </summary>
        public Beamable.Common.Promise<Beamable.Go4.Nfc.Common.MagtekRefundResponse> Admin_RefundNfcPayment(string paymentId)
        {
            string serialized_paymentId = this.SerializeArgument<string>(paymentId);
            string[] serializedFields = new string[] {
                    serialized_paymentId};
            return this.Request<Beamable.Go4.Nfc.Common.MagtekRefundResponse>("GoPlay", "Admin_RefundNfcPayment", serializedFields);
        }
        
        /// <summary>
        /// Call the Admin_GetPlayerPayments method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.Admin_GetPlayerPayments"/>
        /// </summary>
        public Beamable.Common.Promise<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentDocument>> Admin_GetPlayerPayments(long gamerTag, int offset, int limit)
        {
            string serialized_gamerTag = this.SerializeArgument<long>(gamerTag);
            string serialized_offset = this.SerializeArgument<int>(offset);
            string serialized_limit = this.SerializeArgument<int>(limit);
            string[] serializedFields = new string[] {
                    serialized_gamerTag,
                    serialized_offset,
                    serialized_limit};
            return this.Request<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentDocument>>("GoPlay", "Admin_GetPlayerPayments", serializedFields);
        }
        
        /// <summary>
        /// Call the Admin_GetPayment method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.Admin_GetPayment"/>
        /// </summary>
        public Beamable.Common.Promise<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentDocument>> Admin_GetPayment(string paymentId)
        {
            string serialized_paymentId = this.SerializeArgument<string>(paymentId);
            string[] serializedFields = new string[] {
                    serialized_paymentId};
            return this.Request<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentDocument>>("GoPlay", "Admin_GetPayment", serializedFields);
        }
        
        /// <summary>
        /// Call the Admin_GetPaymentAuditTrail method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.Admin_GetPaymentAuditTrail"/>
        /// </summary>
        public Beamable.Common.Promise<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentEventDocument>> Admin_GetPaymentAuditTrail(string paymentId)
        {
            string serialized_paymentId = this.SerializeArgument<string>(paymentId);
            string[] serializedFields = new string[] {
                    serialized_paymentId};
            return this.Request<System.Collections.Generic.List<Beamable.Go4.Nfc.Common.NfcPaymentEventDocument>>("GoPlay", "Admin_GetPaymentAuditTrail", serializedFields);
        }
        
        /// <summary>
        /// Call the TestConcurrency method on the GoPlay microservice
        /// <see cref="Beamable.Microservices.GoPlay.TestConcurrency"/>
        /// </summary>
        public Beamable.Common.Promise<string> TestConcurrency()
        {
            string[] serializedFields = new string[0];
            return this.Request<string>("GoPlay", "TestConcurrency", serializedFields);
        }
    }
    
    internal sealed class MicroserviceParametersGoPlayClient
    {
        
        [System.SerializableAttribute()]
        internal sealed class ParameterBeamable_Go4_Nfc_Common_MagtekBeginPaymentRequest : MicroserviceClientDataWrapper<Beamable.Go4.Nfc.Common.MagtekBeginPaymentRequest>
        {
        }
        
        [System.SerializableAttribute()]
        internal sealed class ParameterBeamable_Go4_Nfc_Common_MagtekFinishPaymentRequest : MicroserviceClientDataWrapper<Beamable.Go4.Nfc.Common.MagtekFinishPaymentRequest>
        {
        }
        
        [System.SerializableAttribute()]
        internal sealed class ParameterSystem_String : MicroserviceClientDataWrapper<string>
        {
        }
        
        [System.SerializableAttribute()]
        internal sealed class ParameterSystem_Int64 : MicroserviceClientDataWrapper<long>
        {
        }
        
        [System.SerializableAttribute()]
        internal sealed class ParameterSystem_Int32 : MicroserviceClientDataWrapper<int>
        {
        }
    }
    
    [BeamContextSystemAttribute()]
    public static class ExtensionsForGoPlayClient
    {
        
        [Beamable.Common.Dependencies.RegisterBeamableDependenciesAttribute()]
        public static void RegisterService(Beamable.Common.Dependencies.IDependencyBuilder builder)
        {
            builder.AddScoped<GoPlayClient>();
        }
        
        public static GoPlayClient GoPlay(this Beamable.Server.MicroserviceClients clients)
        {
            return clients.GetClient<GoPlayClient>();
        }
    }
}
