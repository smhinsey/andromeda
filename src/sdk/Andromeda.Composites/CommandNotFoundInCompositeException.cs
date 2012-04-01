using System;

namespace Andromeda.Composites
{
	public class CommandNotFoundInCompositeException : Exception
	{
		public CommandNotFoundInCompositeException(string commandName) : base(commandName)
		{
		}
	}
}