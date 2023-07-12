using System;
using System.Collections.Generic;
using Beamable.Common;
using Beamable.Server;
using DynaProx.MPPGv4Service;
using MongoDB.Driver;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Beamable.Microservices
{
	[Microservice("GoPlay")]
	public class GoPlay : Microservice
	{

		[ConfigureServices]
		public static void Configure(IServiceBuilder builder)
		{
			builder.Builder.AddSingleton<IMPPGv4Service>(_ =>
				new MPPGv4ServiceClient(MPPGv4ServiceClient.EndpointConfiguration.BasicHttpBinding_IMPPGv4Service));
			builder.Builder.AddSingleton<PaymentServiceSettings>();
			builder.Builder.AddSingleton<MagTekService>();
			builder.Builder.AddScoped<NfcPaymentService>();
			builder.Builder.AddSingleton<NfcPaymentEventBatcher>();

			JsonHack.Load();
			
		}

		[InitializeServices]
		public static void Init(IServiceInitializer initializer)
		{
			Debug.Log("Running init");
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
		}
		
		
		[ClientCallable]
		[SwaggerCategory("Payment")]
		public async Promise<MagtekBeginPaymentResponse> BeginNfcPayment(MagtekBeginPaymentRequest request)
		{
			var api = Provider.GetService<NfcPaymentService>();
			var res = await api.BeginNfcPayment(Context.UserId, request);
			
			return res;
		}

		[ClientCallable]
		[SwaggerCategory("Payment")]
		public async Promise<MagtekFinishPaymentResponse> FinishNfcPayment(MagtekFinishPaymentRequest request)
		{
			var api = Provider.GetService<NfcPaymentService>();
			var res = await api.FinishNfcPayment(Services.Inventory, request);
			return res;
		}
		
		

		[AdminOnlyCallable]
		[SwaggerCategory("Payment/Admin")]
		public async Promise<MagtekFinishPaymentResponse> Admin_ForceFulfillNfcPayment(string paymentId)
		{
			var api = Provider.GetService<NfcPaymentService>();
			return await api.ForceFulfillNfcPayment(gamerTag => AssumeUser(gamerTag).Services.Inventory, paymentId);
		}
		
		[AdminOnlyCallable]
		[SwaggerCategory("Payment/Admin")]
		public async Promise<MagtekRefundResponse> Admin_RefundNfcPayment(string paymentId)
		{
			var api = Provider.GetService<NfcPaymentService>();
			return await api.RefundNfcPayment(paymentId);
		}
		
		[AdminOnlyCallable]
		[SwaggerCategory("Payment/Admin")]
		public async Promise<List<NfcPaymentDocument>> Admin_GetPlayerPayments(long gamerTag, int offset, int limit)
		{
			var api = Provider.GetService<NfcPaymentService>();
			return await api.GetPlayerPayments(gamerTag, offset, limit);
		}
		
		[AdminOnlyCallable]
		[SwaggerCategory("Payment/Admin")]
		public async Promise<List<NfcPaymentDocument>> Admin_GetPayment(string paymentId)
		{
			var api = Provider.GetService<NfcPaymentService>();
			return await api.GetPayment(paymentId);
		}
		
		[AdminOnlyCallable]
		[SwaggerCategory("Payment/Admin")]
		public async Promise<List<NfcPaymentEventDocument>> Admin_GetPaymentAuditTrail(string paymentId)
		{
			var api = Provider.GetService<NfcPaymentEventBatcher>();
			return await api.GetAudits(paymentId);
		}
		

		[ClientCallable]
		public async Promise<string> TestConcurrency()
		{
			var storage = await Storage.PaymentStorageCollection<TestDocument>();

			var doc = new TestDocument();
			await storage.InsertOneAsync(doc);

			var tasks = new List<Task>();
			int failedCount = 0;
			int successCount = 0;
			int runCount = 0;
			for (var i = 0; i < 1000; i++)
			{
				var index = i;
				var t= Task.Run(async () =>
				{
					System.Threading.Interlocked.Increment(ref runCount);

					await Task.Delay(1000 - index);
					
						var res = await storage.FindOneAndUpdateAsync(
							filter: Builders<TestDocument>.Filter.And(
								Builders<TestDocument>.Filter.Eq(x => x.Id, doc.Id),
								Builders<TestDocument>.Filter.Eq(x => x.count, 0)),
							update: Builders<TestDocument>.Update.Inc(x => x.count, 1));


						if (res == null)
						{
							System.Threading.Interlocked.Increment(ref failedCount);

						}
						else
						{
							System.Threading.Interlocked.Increment(ref successCount);

						}
						
						
				});
				tasks.Add(t);
			}

			await Task.WhenAll(tasks);

			return $"{runCount}/{tasks.Count} || {successCount}/{failedCount} = {successCount+failedCount}";
		}
		
	}
}
