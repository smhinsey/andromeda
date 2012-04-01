using System;

namespace Andromeda.Common.Messaging
{
	public class NoInputChannelConfiguredException : Exception
	{
		public NoInputChannelConfiguredException(string message)
			: base(message)
		{
		}
	}
}