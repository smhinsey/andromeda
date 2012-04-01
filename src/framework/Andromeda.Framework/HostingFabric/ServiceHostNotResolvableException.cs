using System;

namespace Andromeda.Framework.HostingFabric
{
	public class ServiceHostNotResolvableException : Exception
	{
		public ServiceHostNotResolvableException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}