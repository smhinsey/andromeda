using System;

namespace Andromeda.Composites.Conversion
{
	public class InputModelAlreadyRegisteredException : Exception
	{
		public InputModelAlreadyRegisteredException(string message)
			: base(message)
		{
		}
	}
}