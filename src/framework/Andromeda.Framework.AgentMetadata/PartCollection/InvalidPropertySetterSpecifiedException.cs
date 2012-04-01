using System;

namespace Andromeda.Framework.AgentMetadata.PartCollection
{
	public class InvalidPropertySetterSpecifiedException : Exception
	{
		public InvalidPropertySetterSpecifiedException(Type propertyValueSetterType)
		{
		}
	}
}