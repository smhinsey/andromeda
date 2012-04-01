﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Andromeda.Common.Messaging;
using Andromeda.Common.Messaging.Azure;
using Andromeda.Common.ServiceHost;
using Andromeda.Common.Storage.Azure;
using Andromeda.Common.Storage.NHibernate;
using Andromeda.Composites;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.HostingFabric;
using FluentNHibernate.Cfg.Db;
using Microsoft.WindowsAzure;
using NConfig;
using NUnit.Framework;
using log4net.Config;

namespace Andromeda.TestingSupport
{
	public class HostingFabricFixture
	{
		protected WindsorContainer Container;

		protected ConsoleFabric Fabric;

		private readonly Assembly[] _agentAssemblies;

		public HostingFabricFixture(params Assembly[] agentAssemblies)
		{
			_agentAssemblies = agentAssemblies;

			NConfigurator.UsingFile(@"Config\custom.config").SetAsSystemDefault();

			XmlConfigurator.Configure(new FileInfo(Path.Combine(Environment.CurrentDirectory, NConfigurator.Default.FileNames[0])));
		}

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
		}

		[SetUp]
		public void SetUp()
		{
			var compositeDatabaseConnection =
				MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("test-db"));

			Container = new WindsorContainer();

			setAzureCredentials(Container);

			Fabric = new ConsoleFabric(Container);

			var composite = new BasicCompositeApp(Container)
				{
					Name = "Andromeda.TestingSupport.HostingFabricFixture.Composite",
					Description = "A composite used in specification tests"
				};

			composite.RegisterNh(compositeDatabaseConnection, false);

			foreach (var agentAssembly in _agentAssemblies)
			{
				composite.AddAgent(agentAssembly);
			}

			composite.Configure(getCompositeSettings());

			Fabric.Initialize(getFabricSettings());

			Fabric.InstallComposite(composite);

			composite.CreateSchema(compositeDatabaseConnection, true);

			Fabric.Start();
		}

		protected void WaitUntilComplete(Guid publicationId)
		{
			while (true)
			{
				var registry = Container.Resolve<ICommandRegistry>();

				var record = registry.GetPublicationRecord(publicationId);

				if (record.Completed || record.Error)
				{
					break;
				}

				Thread.Sleep(250);
			}
		}

		private CompositeAppSettings getCompositeSettings()
		{
			var compositeAppSettings = new CompositeAppSettings();

			compositeAppSettings.OutputChannel.WithDefault(typeof(AzureMessageChannel));
			compositeAppSettings.BlobStorage.WithDefault(typeof(AzureBlobStorage));
			compositeAppSettings.CommandPublicationRecordMapper.WithDefault(typeof(NhRecordMapper<CommandPublicationRecord>));

			return compositeAppSettings;
		}

		private FabricRuntimeSettings getFabricSettings()
		{
			var fabricSettings = new FabricRuntimeSettings();

			fabricSettings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			fabricSettings.HostedServices.WithDefault(new List<Type> { typeof(CommandHost) });

			var messageChannel = new AzureMessageChannel(new JsonMessageSerializer());

			fabricSettings.InputChannel.WithDefault(messageChannel);
			fabricSettings.ErrorChannel.WithDefault(messageChannel);

			return fabricSettings;
		}

		private void setAzureCredentials(IWindsorContainer container)
		{
			// as soon as we can stop using the azure storage emulator we should
			var storageAccount = new CloudStorageAccount(
				CloudStorageAccount.DevelopmentStorageAccount.Credentials,
				CloudStorageAccount.DevelopmentStorageAccount.BlobEndpoint,
				CloudStorageAccount.DevelopmentStorageAccount.QueueEndpoint,
				CloudStorageAccount.DevelopmentStorageAccount.TableEndpoint);

			container.Register(Component.For<CloudStorageAccount>().Instance(storageAccount));
		}
	}
}