using Beamable.Common;
using Beamable.Common.Api.Realms;
using Beamable.Server.Api.RealmConfig;
using DynaProx.MPPGv4Service;

namespace Beamable.Microservices
{
    public class PaymentServiceSettings
    {
        private readonly IMicroserviceRealmConfigService _config;
        public Promise<PaymentSettings> _settings;
        
        public PaymentServiceSettings(IMicroserviceRealmConfigService config)
        {
            _config = config;
        }

        public async Promise<PaymentSettings> LoadSettings()
        {
            var data = await _config.GetRealmConfigSettings();

            var magTekNs = data.GetNamespace("magtek");
            var paymentNs = data.GetNamespace("payment");
            if (!int.TryParse(paymentNs.GetSetting("eventDocumentSizeLimit"), out var sizeLimit))
            {
                sizeLimit = 50;
            }
            if (!float.TryParse(paymentNs.GetSetting("eventDocumentTimeLimitSeconds"), out var timeLimit))
            {
                timeLimit = 60;
            }

            
            return new PaymentSettings
            {
                customer = magTekNs.GetSetting("customer"),
                username = magTekNs.GetSetting("username"),
                password = magTekNs.GetSetting("password"),
                processor = magTekNs.GetSetting("processor", "Rapid Connect v3 - Pilot"),
                paymentEventDocumentBatchSizeLimit = sizeLimit,
                paymentEventDocumentBatchTimeLimitSeconds = timeLimit
            };
        }


    }

    public class PaymentSettings
    {
        public string customer;
        public string username;
        public string password;
        public string processor;


        public int paymentEventDocumentBatchSizeLimit;
        public float paymentEventDocumentBatchTimeLimitSeconds;
        
        public Authentication ToAuth()
        {
            return new Authentication
            {
                CustomerCode = customer,
                Username = username,
                Password = password
            };
        }
    }
    
}