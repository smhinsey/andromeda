using System;

namespace Andromeda.Framework.HostingFabric
{
	public class NoHostedServicesConfiguredException : Exception
	{
		public NoHostedServicesConfiguredException(string message)
			: base(message)
		{
		}
	}
}