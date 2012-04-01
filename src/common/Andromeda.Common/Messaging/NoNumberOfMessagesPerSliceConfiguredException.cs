using System;

namespace Andromeda.Common.Messaging
{
	public class NoNumberOfMessagesPerSliceConfiguredException : Exception
	{
		public NoNumberOfMessagesPerSliceConfiguredException(string message)
			: base(message)
		{
		}
	}
}