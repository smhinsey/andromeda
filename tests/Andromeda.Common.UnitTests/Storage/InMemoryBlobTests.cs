﻿using Andromeda.Common.Storage;
using Andromeda.TestingSupport;
using NUnit.Framework;

namespace Andromeda.Common.UnitTests.Storage
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class InMemoryBlobTests
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
			var blobStorage = new InMemoryBlobStorage();

			blobStorage.Configure(new BlobStorageSettings());

			_blobTester = new BlobTester(blobStorage);
		}
	}
}