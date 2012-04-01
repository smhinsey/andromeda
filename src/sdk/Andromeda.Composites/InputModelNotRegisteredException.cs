using System;

namespace Andromeda.Composites
{
	public class InputModelNotRegisteredException : Exception
	{
		public InputModelNotRegisteredException(Type type)
			: base(type.FullName)
		{
		}
	}
}