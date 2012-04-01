﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.Common.Messaging;
using Andromeda.Common.TestingFakes.Registry;
using NUnit.Framework;

namespace Andromeda.Common.UnitTests.Registry
{
	public class RegistryTester<TRegistry>
		where TRegistry : IPublicationRegistry<FakePublicationRecord, FakePublicationRecord>
	{
		private readonly TRegistry _registry;

		public RegistryTester(TRegistry registry)
		{
			_registry = registry;
		}

		public FakePublicationRecord CreateRecord(IMessage message)
		{
			var record = _registry.PublishMessage(message);

			Assert.NotNull(record);

			Assert.AreEqual(message.GetType(), record.MessageType);

			return record;
		}

		public IMessage GetMessage(FakePublicationRecord publicationRecord)
		{
			var message = _registry.GetMessage(publicationRecord.MessageLocation, publicationRecord.MessageType);

			Assert.NotNull(message);

			Assert.AreEqual(publicationRecord.MessageType, message.GetType());

			return message;
		}

		public FakePublicationRecord GetRecord()
		{
			var record = CreateRecord(new FakeMessage());

			Assert.NotNull(record);

			var retrieved = _registry.GetPublicationRecord(record.Identifier);

			Assert.AreEqual(record.Identifier, retrieved.Identifier);

			return retrieved;
		}

		public FakePublicationRecord MarkAsCompleted()
		{
			var record = CreateRecord(new FakeMessage());

			Assert.NotNull(record);

			record = _registry.GetPublicationRecord(record.Identifier);

			Assert.NotNull(record);

			Assert.IsFalse(record.Completed);

			record = _registry.MarkAsComplete(record.Identifier);

			Assert.NotNull(record);

			Assert.IsTrue(record.Completed);

			Assert.IsTrue(record.Dispatched);

			return record;
		}

		public IPublicationRecord MarkAsFailed()
		{
			const string errorMessage = "test error message";

			const string callStack = "call stack 1";

			var record = CreateRecord(new FakeMessage());

			Assert.NotNull(record);

			record = _registry.GetPublicationRecord(record.Identifier);

			Assert.NotNull(record);

			Assert.IsFalse(record.Error);

			record = _registry.MarkAsFailed(record.Identifier, errorMessage, callStack);

			Assert.NotNull(record);

			Assert.IsTrue(record.Error);

			Assert.IsTrue(record.Dispatched);

			Assert.AreEqual(errorMessage, record.ErrorMessage);

			Assert.AreEqual(callStack, record.CallStack);

			return record;
		}

		public IPublicationRecord MarkAsUnableToDispatch()
		{
			var record = CreateRecord(new FakeMessage());

			Assert.NotNull(record);

			record = _registry.GetPublicationRecord(record.Identifier);

			Assert.NotNull(record);

			Assert.IsFalse(record.Error);

			record = _registry.MarkAsUnableToDispatch(record.Identifier, true, "Unable to dispatch");

			Assert.NotNull(record);

			Assert.IsTrue(record.Error);

			Assert.IsFalse(record.Dispatched);

			Assert.IsTrue(record.Completed);

			Assert.AreEqual(record.ErrorMessage, "Unable to dispatch");

			return record;
		}

		public void TestThroughputAsynchronously(int howManyMessages, int numberOfThreads)
		{
			var start = DateTime.Now;

			Console.WriteLine("Creating {0} records in the {1} registry", howManyMessages, typeof(FakeMessage).FullName);

			var numberOfLoops = howManyMessages / numberOfThreads + 1;

			for (var i = 0; i < numberOfLoops; i++)
			{
				var results = Parallel.For(
					0,
					numberOfLoops,
					x =>
						{
							var record = CreateRecord(new FakeMessage());

							Assert.NotNull(record);
						});
			}

			Console.WriteLine("Created {0} messages in {1} seconds", howManyMessages, DateTime.Now.Subtract(start).TotalSeconds);
		}

		public void TestThroughputSynchronously(int howManyMessages)
		{
			var recordIds = new List<Guid>();

			var start = DateTime.Now;

			Console.WriteLine("Creating {0} records in the {1} registry", howManyMessages, typeof(FakeMessage).FullName);

			for (var i = 0; i < howManyMessages; i++)
			{
				var record = CreateRecord(new FakeMessage());

				Assert.NotNull(record);

				recordIds.Add(record.Identifier);
			}

			Console.WriteLine("Created {0} messages in {1} seconds", howManyMessages, DateTime.Now.Subtract(start).TotalSeconds);

			start = DateTime.Now;

			foreach (var id in recordIds)
			{
				var retrieved = _registry.GetPublicationRecord(id);

				Assert.AreEqual(id, retrieved.Identifier);

				Assert.AreEqual(retrieved.MessageType, typeof(FakeMessage));
			}

			Console.WriteLine(
				"Retrieved {0} messages in {1} seconds", howManyMessages, DateTime.Now.Subtract(start).TotalSeconds);
		}
	}
}