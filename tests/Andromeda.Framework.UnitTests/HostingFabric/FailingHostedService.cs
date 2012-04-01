using System;
using Andromeda.Common.ServiceHost;

namespace Andromeda.Framework.UnitTests.HostingFabric
{
	public class FailingHostedService : DefaultHostedService
	{
		protected override void OnStart()
		{
			throw new Exception("Ha!");
		}

		protected override void OnStop()
		{
		}
	}
}