using System;
using System.Collections.Generic;
using System.Reflection;
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
using log4net.Config;

namespace Andromeda.TestingSupport
{
	public class AgentConfigurator
	{
		private readonly IWindsorContainer _container;

		private bool _configured;

		public AgentConfigurator(IWindsorContainer container)
		{
			_container = container;
		}

		public ConsoleFabric Fabric { get; set; }

		public void Configure(Assembly agentAssembly, bool recreateDb = true)
		{
			if (_configured)
			{
				return;
			}

			var compositeDatabaseConnection =
				MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("test-db"));

			XmlConfigurator.Configure();

			setAzureCredentials(_container);

			Fabric = new ConsoleFabric(_container);

			var composite = new BasicCompositeApp(_container)
				{ Name = "Andromeda.TestingSupport.ConfigureAgentSteps.Composite", Description = "A composite used for testing" };

			composite.AddAgent(agentAssembly);

			composite.Configure(getCompositeSettings());

			composite.RegisterNh(compositeDatabaseConnection, false);

			Fabric.Initialize(getFabricSettings());

			Fabric.InstallComposite(composite);

			Fabric.Start();

			_container.Register(Component.For<BasicFabric>().Instance(Fabric));

			composite.CreateSchema(compositeDatabaseConnection, recreateDb);

			_configured = true;
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