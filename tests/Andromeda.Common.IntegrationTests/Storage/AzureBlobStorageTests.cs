using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Azure;
using Andromeda.Common.UnitTests.Storage;
using Andromeda.TestingSupport;
using Microsoft.WindowsAzure;
using NUnit.Framework;

namespace Andromeda.Common.IntegrationTests.Storage
{
	[TestFixture]
	[Category(TestCategories.Integration)]
	public class AzureBlobStorageTests
	{
		private BlobTester _blobTester;

		[Test]
		public void Deletes()
		{
			var blob = _blobTester.GetNewBlob();

			var uri = _blobTester.Put(blob);

			_blobTester.Delete(uri);

			var retrieved = _blobTester.Get(uri);

			Assert.IsNull(retrieved);
		}

		[Test]
		public void Gets()
		{
			var blob = _blobTester.GetNewBlob();

			var uri = _blobTester.Put(blob);

			var retrieved = _blobTester.Get(uri);

			Assert.AreEqual(blob.Md5, retrieved.Md5);

			Assert.AreEqual(blob.ContentType, retrieved.ContentType);

			Assert.AreEqual(blob.Metdata, retrieved.Metdata);

			Assert.False(string.IsNullOrEmpty(retrieved.ETag));
		}

		[Test]
		public void Puts()
		{
			var blob = _blobTester.GetNewBlob();

			_blobTester.Put(blob);
		}

		[SetUp]
		public void Setup()
		{
			var settings = new BlobStorageSettings();

			var storageAccount = new CloudStorageAccount(
				CloudStorageAccount.DevelopmentStorageAccount.Credentials,
				CloudStorageAccount.DevelopmentStorageAccount.BlobEndpoint,
				CloudStorageAccount.DevelopmentStorageAccount.QueueEndpoint,
				CloudStorageAccount.DevelopmentStorageAccount.TableEndpoint);

			var blobStorage = new AzureBlobStorage(storageAccount);
			blobStorage.Configure(settings);

			_blobTester = new BlobTester(blobStorage);
		}
	}
}