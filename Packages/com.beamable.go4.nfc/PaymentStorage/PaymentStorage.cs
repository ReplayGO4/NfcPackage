using Beamable.Common;
using Beamable.Server;
using MongoDB.Driver;

namespace Beamable.Go4.Nfc.Microservices
{
	[StorageObject("PaymentStorage")]
	public class PaymentStorage : MongoStorageObject
	{
	}

	public static class PaymentStorageExtension
	{
		/// <summary>
		/// Get an authenticated MongoDB instance for PaymentStorage
		/// </summary>
		/// <returns></returns>
		public static Promise<IMongoDatabase> PaymentStorageDatabase(this IStorageObjectConnectionProvider provider)
			=> provider.GetDatabase<PaymentStorage>();

		/// <summary>
		/// Gets a MongoDB collection from PaymentStorage by the requested name, and uses the given mapping class.
		/// If you don't want to pass in a name, consider using <see cref="PaymentStorageCollection{TCollection}()"/>
		/// </summary>
		/// <param name="name">The name of the collection</param>
		/// <typeparam name="TCollection">The type of the mapping class</typeparam>
		/// <returns>When the promise completes, you'll have an authorized collection</returns>
		public static Promise<IMongoCollection<TCollection>> PaymentStorageCollection<TCollection>(
			this IStorageObjectConnectionProvider provider, string name)
			where TCollection : StorageDocument
			=> provider.GetCollection<PaymentStorage, TCollection>(name);

		/// <summary>
		/// Gets a MongoDB collection from PaymentStorage by the requested name, and uses the given mapping class.
		/// If you want to control the collection name separate from the class name, consider using <see cref="PaymentStorageCollection{TCollection}(string)"/>
		/// </summary>
		/// <param name="name">The name of the collection</param>
		/// <typeparam name="TCollection">The type of the mapping class</typeparam>
		/// <returns>When the promise completes, you'll have an authorized collection</returns>
		public static Promise<IMongoCollection<TCollection>> PaymentStorageCollection<TCollection>(
			this IStorageObjectConnectionProvider provider)
			where TCollection : StorageDocument
			=> provider.GetCollection<PaymentStorage, TCollection>();
	}
}
