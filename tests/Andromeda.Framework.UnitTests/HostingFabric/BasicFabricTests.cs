using System;
using System.Collections.Generic;
using System.Threading;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Andromeda.Common.ServiceHost;
using Andromeda.Framework.HostingFabric;
using Andromeda.Framework.TestingFakes.HostingFabric;
using Andromeda.TestingSupport;
using NUnit.Framework;

namespace Andromeda.Framework.UnitTests.HostingFabric
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class BasicFabricTests
	{
		[Test]
		public void ErrorFreeWithValidConfig()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(Component.For<IHostedService>().Forward<FakeHostedService>().Instance(new FakeHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FakeHostedService) });

			runtime.Initialize(settings);
		}

		[Test]
		public void ReportsBasicRuntimeStatistics()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(Component.For<IHostedService>().Forward<FakeHostedService>().Instance(new FakeHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FakeHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);
			Assert.AreEqual(FabricRuntimeState.Started, runtime.GetStatistics().RuntimeState);
			Assert.AreEqual(typeof(MultitaskingServiceHost), runtime.GetStatistics().ConfiguredServiceHost);
			Assert.AreEqual(typeof(FakeHostedService), runtime.GetStatistics().ConfiguredHostedServices[0]);
		}

		[Test]
		public void ReportsErrorsThrownByHostedServices()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(
				Component.For<IHostedService>().Forward<FailingHostedService>().Instance(new FailingHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FailingHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);

			Thread.Sleep(100); // let the exception have a chance to be thrown and caught

			var exceptions = runtime.GetExceptionsThrownByHostedServices();

			Assert.AreEqual(1, exceptions.Count);
		}

		[Test]
		public void ReportsRuntimeStatisticsWithExceptionInfo()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(
				Component.For<IHostedService>().Forward<FailingHostedService>().Instance(new FailingHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FailingHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);

			Thread.Sleep(100); // let the exception have a chance to be thrown and caught

			Assert.AreEqual(FabricRuntimeState.Started, runtime.GetStatistics().RuntimeState);
			Assert.AreEqual(typeof(MultitaskingServiceHost), runtime.GetStatistics().ConfiguredServiceHost);
			Assert.AreEqual(typeof(FailingHostedService), runtime.GetStatistics().ConfiguredHostedServices[0]);
			Assert.GreaterOrEqual(runtime.GetStatistics().HostedServiceExceptions.Count, 1);
		}

		[Test]
		public void Starts()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(Component.For<IHostedService>().Forward<FakeHostedService>().Instance(new FakeHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FakeHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);
		}

		[Test]
		public void StartsAndRestarts()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(Component.For<IHostedService>().Forward<FakeHostedService>().Instance(new FakeHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FakeHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);

			runtime.Shutdown();

			Assert.AreEqual(FabricRuntimeState.Stopped, runtime.State);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);
		}

		[Test]
		public void StartsAndStops()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			container.Register(Component.For<IHostedService>().Forward<FakeHostedService>().Instance(new FakeHostedService()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { typeof(FakeHostedService) });

			runtime.Initialize(settings);

			runtime.Start();

			Assert.AreEqual(FabricRuntimeState.Started, runtime.State);

			runtime.Shutdown();

			Assert.AreEqual(FabricRuntimeState.Stopped, runtime.State);
		}

		[Test]
		[ExpectedException(typeof(NoServiceHostConfiguredException))]
		public void ThrowsWhenConfigIsEmpty()
		{
			var container = new WindsorContainer();

			var runtime = new BasicFabric(container);

			runtime.Initialize(new FabricRuntimeSettings());
		}

		[Test]
		[ExpectedException(typeof(NoHostedServicesConfiguredException))]
		public void ThrowsWhenConfigIsMissingHostedServices()
		{
			var container = new WindsorContainer();

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(GetType());

			runtime.Initialize(settings);
		}

		[Test]
		[ExpectedException(typeof(NoServiceHostConfiguredException))]
		public void ThrowsWhenConfigIsMissingServiceHost()
		{
			var container = new WindsorContainer();

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.HostedServices.WithDefault(new List<Type>());

			runtime.Initialize(settings);
		}

		[Test]
		[ExpectedException(typeof(HostedServiceNotResolvableException))]
		public void ThrowsWhenHostedServiceNotResolvable()
		{
			var container = new WindsorContainer();

			container.Register(
				Component.For<IServiceHost>().Forward<MultitaskingServiceHost>().Instance(new MultitaskingServiceHost()));

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(typeof(MultitaskingServiceHost));
			settings.HostedServices.WithDefault(new List<Type> { GetType() });

			runtime.Initialize(settings);

			runtime.Start();
		}

		[Test]
		[ExpectedException(typeof(ServiceHostNotResolvableException))]
		public void ThrowsWhenServiceHostNotResolvable()
		{
			var container = new WindsorContainer();

			var runtime = new BasicFabric(container);

			var settings = new FabricRuntimeSettings();

			settings.ServiceHost.WithDefault(GetType());
			settings.HostedServices.WithDefault(new List<Type> { GetType() });

			runtime.Initialize(settings);
		}
	}
}