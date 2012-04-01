using System;

namespace Andromeda.Common.Messaging
{
	public class NoMessageProcessorsConfiguredException : Exception
	{
		public NoMessageProcessorsConfiguredException(string message)
			: base(message)
		{
		}
	}
}