﻿using System;
using Andromeda.Common.Messaging;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;
using Andromeda.Common.TestingFakes.Registry;
using Andromeda.TestingSupport;
using NUnit.Framework;

namespace Andromeda.Common.IntegrationTests
{
	[TestFixture]
	[Category(TestCategories.Integration)]
	public class PublicationTests
	{
		private readonly IBlobStorage _blobStorage;

		private readonly IMessageChannel _channel;

		private readonly IRecordMapper<FakePublicationRecord> _mapper;

		private readonly IPublicationRegistry<FakePublicationRecord, FakePublicationRecord> _publicationRegistry;

		private readonly IMessageSerializer _serializer;

		public PublicationTests()
		{
			_serializer = new JsonMessageSerializer();
			_blobStorage = new InMemoryBlobStorage();
			_mapper = new InMemoryRecordMapper<FakePublicationRecord>();
			_publicationRegistry = new FakeRegistry(_mapper, _blobStorage, _serializer);
			_channel = new InMemoryMessageChannel();
		}

		[Test]
		public void TestSendMessageOverTransport()
		{
			_channel.Open();

			var msgId = Guid.NewGuid();

			var createdById = Guid.NewGuid();

			var created = DateTime.Now;

			var msg = new FakeMessage { Created = created, CreatedBy = createdById, Identifier = msgId };

			var record = _publicationRegistry.PublishMessage(msg);

			_channel.Send(record);

			var receivedMsg = _channel.ReceiveSingle(TimeSpan.MaxValue);

			Assert.NotNull(receivedMsg);

			Assert.NotNull(receivedMsg as FakePublicationRecord);

			var receivedRecord = receivedMsg as FakePublicationRecord;

			Assert.AreEqual(typeof(FakeMessage), receivedRecord.MessageType);

			var blob = _blobStorage.Get(receivedRecord.MessageLocation);

			Assert.NotNull(blob);

			var storedMessage = Convert.ChangeType(_serializer.Deserialize(blob.Content), receivedRecord.MessageType);

			Assert.NotNull(storedMessage);

			Assert.AreEqual(typeof(FakeMessage), storedMessage.GetType());

			_channel.Close();
		}
	}
}