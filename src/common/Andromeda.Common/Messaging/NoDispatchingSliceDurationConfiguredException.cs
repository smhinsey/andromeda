using System;

namespace Andromeda.Common.Messaging
{
	public class NoDispatchingSliceDurationConfiguredException : Exception
	{
		public NoDispatchingSliceDurationConfiguredException(string message)
			: base(message)
		{
		}
	}
}