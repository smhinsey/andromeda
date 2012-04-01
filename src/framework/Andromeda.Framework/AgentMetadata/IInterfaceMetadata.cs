using System;

namespace Andromeda.Framework.AgentMetadata
{
	public interface IInterfaceMetadata
	{
		Type ImplementationType { get; }

		string InterfaceName { get; }

		Type InterfaceType { get; }
	}
}