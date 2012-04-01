using System;
using System.Threading;
using Andromeda.Common.ServiceHost;
using Andromeda.Common.TestingFakes.ServiceHost;
using Andromeda.TestingSupport;
using NUnit.Framework;
using log4net.Config;

namespace Andromeda.Common.UnitTests.ServiceHost
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class MultitaskingServiceHostTests
	{
		[Test]
		[ExpectedException(typeof(HostedServiceNotFoundException))]
		public void CancelFailsForMissingService()
		{
			var host = new MultitaskingServiceHost();

			host.Cancel(Guid.NewGuid());
		}

		[Test]
		[ExpectedException(typeof(HostedServiceNotFoundException))]
		public void GetStateFailsForMissingService()
		{
			var host = new MultitaskingServiceHost();

			host.GetState(Guid.NewGuid());
		}

		[Test]
		public void InstallsStartsAndCancels()
		{
			var host = new MultitaskingServiceHost();

			host.Install(new FakeHostedService());
			host.Install(new FakeHostedService());

			host.StartAll();

			Thread.Sleep(100);

			Assert.AreEqual(ServiceHostState.Started, host.State);

			host.CancelAll();

			Assert.AreEqual(ServiceHostState.Stopped, host.State);
		}

		[Test]
		public void ModifyIndividualServiceState()
		{
			var host = new MultitaskingServiceHost();

			var serviceId = host.Install(new FakeHostedService());

			host.Start(serviceId);

			Assert.AreEqual(ServiceHostState.Started, host.State);

			Thread.Sleep(100);

			Assert.AreEqual(HostedServiceState.Started, host.GetState(serviceId));

			host.Cancel(serviceId);

			Assert.AreEqual(ServiceHostState.Stopped, host.State);
			Assert.AreEqual(HostedServiceState.Stopped, host.GetState(serviceId));
		}

		[SetUp]
		public void SetUp()
		{
			BasicConfigurator.Configure();
		}

		[Test]
		public void StartAndCancelIndividualService()
		{
			var host = new MultitaskingServiceHost();

			var serviceId = host.Install(new FakeHostedService());

			host.Start(serviceId);

			Assert.AreEqual(ServiceHostState.Started, host.State);

			Thread.Sleep(100);

			Assert.AreEqual(HostedServiceState.Started, host.GetState(serviceId));

			host.Cancel(serviceId);

			Assert.AreEqual(ServiceHostState.Stopped, host.State);
			Assert.AreEqual(HostedServiceState.Stopped, host.GetState(serviceId));
		}

		[Test]
		[ExpectedException(typeof(HostedServiceNotFoundException))]
		public void StartFailsForMissingService()
		{
			var host = new MultitaskingServiceHost();

			host.Start(Guid.NewGuid());
		}

		[Test]
		public void StartsAndCancels()
		{
			var host = new MultitaskingServiceHost();

			host.StartAll();

			Assert.AreEqual(ServiceHostState.Started, host.State);

			host.CancelAll();

			Assert.AreEqual(ServiceHostState.Stopped, host.State);
		}

		[Test]
		public void StartsWithoutError()
		{
			var host = new MultitaskingServiceHost();

			host.StartAll();

			Assert.AreEqual(ServiceHostState.Started, host.State);
		}
	}
}