using System;

namespace Andromeda.Framework.HostingFabric
{
	public class HostedServiceNotResolvableException : Exception
	{
		public HostedServiceNotResolvableException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}