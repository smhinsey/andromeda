using System;
using System.Collections.Generic;

namespace Andromeda.Framework.AgentMetadata
{
	public interface IPartCollection : IEnumerable<IPartMetadata>
	{
		string AgentSystemName { get; }

		Type CollectionType { get; }

		string DescriptiveName { get; }

		string Namespace { get; }

		IMetadataFormatter GetFormatter();
	}
}