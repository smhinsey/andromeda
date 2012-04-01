using System;
using Andromeda.Common.ServiceHost;

namespace Andromeda.Framework.EventSourcing
{
	public class EventHost : DefaultHostedService
	{
		protected override void OnStart()
		{
			// set up EventStore and wire it into the container
			throw new NotImplementedException();
		}

		protected override void OnStop()
		{
			// take a snapshot and shut down
			throw new NotImplementedException();
		}
	}
}