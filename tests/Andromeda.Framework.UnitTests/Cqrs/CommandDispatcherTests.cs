﻿using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Andromeda.Common.Messaging;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;
using Andromeda.Composites;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.TestingFakes.Cqrs;
using Andromeda.TestingSupport;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;

namespace Andromeda.Framework.UnitTests.Cqrs
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class CommandDispatcherTests
	{
		[Test]
		public void CommandRegistryTests()
		{
			var command = new FakeCommand { Identifier = Guid.NewGuid() };
			var registry = new CommandRegistry(
				new InMemoryRecordMapper<CommandPublicationRecord>(), new InMemoryBlobStorage(), new JsonMessageSerializer());

			var record = registry.PublishMessage(command);
			Assert.NotNull(record);

			var retrieved = registry.GetMessage(record.MessageLocation, record.MessageType);
			Assert.NotNull(retrieved);
			Assert.AreEqual(command.Identifier, retrieved.Identifier);

			Assert.NotNull(retrieved as FakeCommand);
		}

		[Test]
		public void TestDispatcherResolution()
		{
			var c = new WindsorContainer();

			c.Register(Component.For<ICommandDispatcher>().ImplementedBy<CommandDispatcher>());

			c.Register(Component.For<ICommandRegistry>().ImplementedBy<CommandRegistry>());

			c.Register(Component.For<IServiceLocator>().ImplementedBy<WindsorServiceLocator>());

			c.Register(Component.For<IWindsorContainer>().Instance(c));

			c.Register(
				Component.For<IRecordMapper<CommandPublicationRecord>>().ImplementedBy<InMemoryCommandPublicationRecordMapper>());

			c.Register(Component.For<IBlobStorage>().ImplementedBy<InMemoryBlobStorage>());

			c.Register(Component.For<IMessageSerializer>().ImplementedBy<JsonMessageSerializer>());

			var d = c.Resolve<ICommandDispatcher>();
			Assert.NotNull(d);
		}
	}
}