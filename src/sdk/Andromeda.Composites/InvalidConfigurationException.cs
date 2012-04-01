using System;

namespace Andromeda.Composites
{
	public class InvalidConfigurationException : Exception
	{
		public InvalidConfigurationException(string message)
			: base(message)
		{
		}
	}
}