using System;
using System.Collections.Generic;

namespace Andromeda.Framework.AgentMetadata
{
	public interface ITypeMetadata
	{
		IEnumerable<IMethodMetadata> Methods { get; }

		string Name { get; set; }

		string Namespace { get; }

		IEnumerable<IPropertyMetadata> Properties { get; }

		Type Type { get; set; }

		IMetadataFormatter GetFormatter();
	}

	public interface IPartMetadata : ITypeMetadata
	{
		Type PartInterface { get; }

		IPartCollection GetContainingPartCollection();
	}
}