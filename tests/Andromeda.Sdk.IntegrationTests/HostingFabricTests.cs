﻿using System;
using System.Collections.Generic;
using Andromeda.Common.Messaging;
using Andromeda.Sdk.TestAgent.Commands;
using Andromeda.Sdk.TestAgent.Queries;
using Andromeda.TestingSupport;
using NConfig;
using NUnit.Framework;

namespace Andromeda.Sdk.IntegrationTests
{
	[Category(TestCategories.Integration)]
	public class HostingFabricTests : HostingFabricFixture
	{
		public HostingFabricTests()
			: base(typeof(TestCommand).Assembly)
		{
		}

		[Test]
		public void PublishProcessAndCompleteManyCommands()
		{
			var publicationIds = new List<Guid>();
			const int NumberOfCommands = 100;

			var publisher = Container.Resolve<IPublisher>();

			for (var i = 0; i < NumberOfCommands; i++)
			{
				var publicationId = publisher.PublishMessage(new TestCommand { Number = i });

				publicationIds.Add(publicationId);
			}

			foreach (var publicationId in publicationIds)
			{
				WaitUntilComplete(publicationId);
			}
		}

		[Test]
		public void PublishProcessAndVerifyCommandByQuery()
		{
			const int MessageNumber = 134;

			var publisher = Container.Resolve<IPublisher>();

			WaitUntilComplete(publisher.PublishMessage(new TestCommand { Number = MessageNumber }));

			var query = Container.Resolve<TestQuery>();

			var models = query.FindByNumber(MessageNumber);

			Assert.AreEqual(1, models.Count);
			Assert.AreEqual(MessageNumber, models[0].Number);
		}
	}
}