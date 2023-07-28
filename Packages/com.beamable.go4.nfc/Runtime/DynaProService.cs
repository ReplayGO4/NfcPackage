using System;
using System.Collections.Generic;
using Beamable.Common;
using Beamable.Coroutines;

namespace Beamable.Go4.Nfc
{
    public class DynaProService
    {
        private readonly CoroutineService _coroutineService;
        private readonly DynaProSettings _settings;

        public DynaProService(CoroutineService coroutineService, DynaProSettings settings)
        {
            _coroutineService = coroutineService;
            _settings = settings;
        }

        public DynaProCharge RequestCharge(decimal amount, byte timeoutSeconds=20)
        {
            var command = new DynaProCommand($"{_settings.CommandPath} charge {amount} -t {timeoutSeconds}", _settings, _coroutineService);
            var p = new Promise<DynaProChargeResult>();
            var charge = new DynaProCharge
            {
                ResultPromise = p,
                Result = null,
                ProgressEvents = new List<DynaProChargeProgress>()
            };
            p.Then(res => charge.Result = res);

            command.On<DynaProChargeResult>("charge-result", result =>
            {
                p.CompleteSuccess(result.data);
            });
            command.On<DynaProChargeProgress>("charge-status", progress =>
            {
                IDynaProChargeBuilder builder = charge;
                builder.AddProgressEvent(progress.data);
                
                if (progress.data.status == ChargeStatus.TIMEOUT)
                {
                    p.CompleteError(new DynaProChargeTimeoutException());
                }

                if (progress.data.status == ChargeStatus.PAYMENT_FAILED)
                {
                    p.CompleteError(new DynaProChargeFailedException());
                }
            });
            var _ = command.Run();
            return charge;
        }

        public class DynaProChargeTimeoutException : Exception
        {
            public DynaProChargeTimeoutException(){}
        }
        public class DynaProChargeFailedException : Exception
        {
            public DynaProChargeFailedException(){}
        }

        [Serializable]
        public class DynaProChargeResult
        {
            public string transactionResult;
        }

        [Serializable]
        public class DynaProChargeProgress
        {
            public ChargeStatus status;
        }
        public enum ChargeStatus
        {
        
            INIT = 1,
            TAP_CARD = 2,
            TRY_AGAIN = 3,
            REMOVE_CARD = 4,
            TIMEOUT = 5,
            PAYMENT_FAILED = 6
        }


        public interface IDynaProChargeBuilder
        {
            void AddProgressEvent(DynaProChargeProgress progress);
        }

        [Serializable]
        public class DynaProCharge : IDynaProChargeBuilder
        {
            public Promise<DynaProChargeResult> ResultPromise;
            public DynaProChargeResult Result;
            public List<DynaProChargeProgress> ProgressEvents;
            public Action<DynaProChargeProgress> OnProgress;
            
            void IDynaProChargeBuilder.AddProgressEvent(DynaProChargeProgress progress)
            {
                ProgressEvents.Add(progress);
                OnProgress?.Invoke(progress);
            }
        }
        
    }
}