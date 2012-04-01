using System;

namespace Andromeda.Framework.AgentMetadata
{
	public class ExpectedConstructorMissingException : Exception
	{
		public ExpectedConstructorMissingException(string typeMissingConstructor)
			: base(typeMissingConstructor)
		{
		}
	}
}