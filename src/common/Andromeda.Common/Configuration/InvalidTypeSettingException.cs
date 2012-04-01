using System;

namespace Andromeda.Common.Configuration
{
	public class InvalidTypeSettingException : Exception
	{
		public InvalidTypeSettingException(string name, Type expected, Type received)
			: base(
				string.Format(
					"The setting {0} was configured with type {1} which does not implement {2}", name, received.Name, expected.Name))
		{
		}
	}
}