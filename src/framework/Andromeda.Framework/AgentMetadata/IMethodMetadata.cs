using System;
using System.Collections.Generic;

namespace Andromeda.Framework.AgentMetadata
{
	public interface IMethodMetadata
	{
		IEnumerable<IArgumentMetadata> Arguments { get; set; }

		Type ContainingType { get; set; }

		string Name { get; set; }

		Type ReturnType { get; set; }
	}
}