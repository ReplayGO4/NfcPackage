using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamable.Common;
using Beamable.Server;
using MongoDB.Driver;
using UnityEngine;

namespace Beamable.Microservices
{
    
    public class NfcPaymentEventBatcher
    {
        private readonly PaymentServiceSettings _settings;
        private readonly IStorageObjectConnectionProvider _storageProvider;

        private ConcurrentQueue<NfcPaymentEventDocument> _queue = new ConcurrentQueue<NfcPaymentEventDocument>();



        private readonly Promise<PaymentSettings> _settingsPromise;
        
        public NfcPaymentEventBatcher(PaymentServiceSettings settings, IStorageObjectConnectionProvider storageProvider)
        {
            _settings = settings;
            _storageProvider = storageProvider;
            _settingsPromise = settings.LoadSettings();
        }

        private Promise<IMongoCollection<NfcPaymentEventDocument>> GetEventCollection() =>
            _storageProvider.PaymentStorageCollection<NfcPaymentEventDocument>();


        public async Task<List<NfcPaymentEventDocument>> GetAudits(string paymentId)
        {
            var collection = await GetEventCollection();
            var cursor = await collection.FindAsync(Builders<NfcPaymentEventDocument>.Filter.Eq(x => x.paymentId, paymentId));
            var set = await cursor.ToListAsync();

            // TODO: the audit trail won't get audit events that haven't been sent yet.
            return set;
        }
        
        public async Task Add(NfcPaymentEventDocument evt)
        {
            var settings = await _settingsPromise;
            
            if (evt.createdAt == 0)
            {
                evt.createdAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
            _queue.Enqueue(evt);

            if (_queue.Count > settings.paymentEventDocumentBatchSizeLimit)
            {
                await SendAll();
            }
        }

        public async Task SendAll()
        {
            try
            {
                var set = _queue.ToList();
                _queue.Clear();

                if (set.Count == 0) return;
                var collection = await GetEventCollection();
                
                await collection.InsertManyAsync(set);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
        
        
    }
}