using System;
using System.Threading.Tasks;
using Beamable.Common.Dependencies;
using Beamable.Go4.Nfc.Common;
using Beamable.Server;
using DynaProx.MPPGv4Service;
using UnityEngine;

namespace Beamable.Go4.Nfc.Microservices
{
    public static class Registrations
    {
        public static IServiceInitializer StartBatcher(this IServiceInitializer initializer)
        {
            try
            {
                var batcher = initializer.GetService<NfcPaymentEventBatcher>();
                Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(5000);
                        await batcher.SendAll();
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }

            return initializer;
        }
        
        
        public static IServiceBuilder AddNfcPaymentServices(this IServiceBuilder builder)
        {
            builder.Builder.AddNfcPaymentServices();
            return builder;
        }
        
        public static IDependencyBuilder AddNfcPaymentServices(this IDependencyBuilder builder)
        {
            builder.AddSingleton<IMPPGv4Service>(_ =>
                new MPPGv4ServiceClient(MPPGv4ServiceClient.EndpointConfiguration.BasicHttpBinding_IMPPGv4Service));
            builder.AddSingleton<PaymentServiceSettings>();
            builder.AddSingleton<MagTekService>();
            builder.AddSingleton<NfcPaymentEventBatcher>();

            // every request has its own NfcPaymentService, so that the service can use the IUserContext
            builder.AddScoped<NfcPaymentService>();

            JsonHack.Load();
            return builder;
        } 
    }
}