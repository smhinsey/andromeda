﻿using System;
using System.Collections.Generic;
using System.Threading;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Andromeda.Common.Messaging;
using Andromeda.Common.ServiceHost;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.Cqrs.Settings;
using Andromeda.Framework.TestingFakes.Cqrs;
using Andromeda.TestingSupport;
using NUnit.Framework;
using log4net.Config;

namespace Andromeda.Framework.UnitTests.Cqrs
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class CommandHostTests
	{
		private IWindsorContainer _container;

		private IMessageDispatcherSettings _dispatcherSettings;

		private WindsorServiceLocator _locator;

		// private IList<ICommandDispatcher> _dispatchers = new List<ICommandDispatcher>();
		[Test]
		public void CommandHostCancel()
		{
			var host = GetCommandHost();
			host.Cancel();
			Thread.Sleep(250);
			Assert.AreEqual(HostedServiceState.Stopped, host.State);
		}

		[Test]
		public void CommandHostDispatches()
		{
			var host = GetCommandHost();

			host.Start();

			var channel = _container.Resolve<IMessageChannel>("input");

			var invalid = _container.Resolve<IMessageChannel>("invalid");

			var registry = GetRegistry();

			channel.Open();

			var recordOfCommandOne = registry.PublishMessage(new FakeCommand());

			channel.Send(recordOfCommandOne);

			Thread.Sleep(750);

			Assert.Null(invalid.ReceiveSingle(TimeSpan.MaxValue));

			Assert.Greater(FakeCommandProcessor.FakeCommandCount, 0);

			var recordOfCommandTwo = registry.PublishMessage(new FakeCommand2());

			channel.Send(recordOfCommandTwo);

			Thread.Sleep(750);

			Assert.Null(invalid.ReceiveSingle(TimeSpan.MaxValue));

			Assert.Greater(FakeCommandProcessor.FakeCommandTwoCount, 0);

			var recordOfCommandThree = registry.PublishMessage(new FakeCommand3());

			channel.Send(recordOfCommandThree);

			Thread.Sleep(750);

			recordOfCommandThree = registry.GetPublicationRecord(recordOfCommandThree.Identifier);

			Assert.True(recordOfCommandThree.Error);

			Assert.False(recordOfCommandThree.Dispatched);

			Assert.True(recordOfCommandThree.Completed);
		}

		[Test]
		public void CommandHostStarts()
		{
			var host = GetCommandHost();

			host.Start();

			Assert.AreEqual(HostedServiceState.Started, host.State);

			// container.Register<
		}

		[SetUp]
		public void Setup()
		{
			BasicConfigurator.Configure();

			ConfigureContainer();

			_dispatcherSettings = new MessageDispatcherSettings();

			_dispatcherSettings.InvalidChannel.WithDefault(_container.Resolve<IMessageChannel>("invalid"));
			_dispatcherSettings.InputChannel.WithDefault(_container.Resolve<IMessageChannel>("input"));
			_dispatcherSettings.NumberOfMessagesToDispatchPerSlice.WithDefault(20);
			_dispatcherSettings.DurationOfDispatchingSlice.WithDefault(new TimeSpan(0, 0, 0, 0, 500));
			_dispatcherSettings.MessageProcessorTypes.WithDefault(new List<Type> { typeof(FakeCommandProcessor) });

			_locator = new WindsorServiceLocator(_container);
		}

		[Test]
		public void TestFluentConfiguration()
		{
			var c =
				CommandHostService.Configure().AddDispatcher(
					Dispatcher.Configure().AddCommandProcessor<FakeCommandProcessor>().InputChannelAs<InMemoryMessageChannel>().
						InvalidChannelAs<InMemoryMessageChannel>().BlobStorageAs<InMemoryBlobStorage>().RecordRepositoryAs
						<InMemoryRecordMapper<CommandPublicationRecord>>().CommandSerializerAs<JsonMessageSerializer>().PollingInterval().
						Milliseconds(50).ProcessMessageInBatchesOf(25)).GetCommandHost();

			Assert.NotNull(c);

			Assert.AreEqual(typeof(CommandHost), c.GetType());

			c.Start();

			Assert.AreEqual(HostedServiceState.Started, c.State);

			c.Cancel();

			Assert.AreEqual(HostedServiceState.Stopped, c.State);
		}

		private void ConfigureContainer()
		{
			_container = new WindsorContainer();

			var recordMapper = new InMemoryRecordMapper<CommandPublicationRecord>();
			var blobStorage = new InMemoryBlobStorage();
			var messageSerializer = new JsonMessageSerializer();

			_container.Register(Component.For<IRecordMapper<CommandPublicationRecord>>().Instance(recordMapper));

			_container.Register(Component.For<IBlobStorage>().Instance(blobStorage));

			_container.Register(Component.For<IMessageSerializer>().Instance(messageSerializer));

			_container.Register(Component.For<IMessageChannel>().Instance(new InMemoryMessageChannel()).Named("input"));

			_container.Register(Component.For<IMessageChannel>().Instance(new InMemoryMessageChannel()).Named("invalid"));

			_container.Register(Component.For<FakeCommandProcessor>().ImplementedBy(typeof(FakeCommandProcessor)));

			_container.Register(Component.For<ICommandRegistry>().Instance(new CommandRegistry(recordMapper, blobStorage, messageSerializer)).Forward<IPublicationRegistry<IPublicationRecord, IPublicationRecord>>());
		}

		private CommandHost GetCommandHost()
		{
			var dispatchers = new List<ICommandDispatcher>();
			var dispatcher = new CommandDispatcher(_locator, GetRegistry());

			dispatcher.Configure(_dispatcherSettings);

			dispatchers.Add(dispatcher);

			return new CommandHost(dispatchers);
		}

		private ICommandRegistry GetRegistry()
		{
			var recordMapper = _locator.GetInstance<IRecordMapper<CommandPublicationRecord>>();
			var blobStorage = _locator.GetInstance<IBlobStorage>();
			var messageSerializer = _locator.GetInstance<IMessageSerializer>();

			return new CommandRegistry(recordMapper, blobStorage, messageSerializer);
		}
	}
}