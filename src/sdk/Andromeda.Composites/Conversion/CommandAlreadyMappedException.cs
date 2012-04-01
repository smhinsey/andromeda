using System;

namespace Andromeda.Composites.Conversion
{
	public class CommandAlreadyMappedException : Exception
	{
		public CommandAlreadyMappedException(string commandType)
			: base(commandType)
		{
		}
	}
}