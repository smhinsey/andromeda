using System;

namespace Andromeda.Framework.HostingFabric
{
	public class NoServiceHostConfiguredException : Exception
	{
		public NoServiceHostConfiguredException(string message)
			: base(message)
		{
		}
	}
}