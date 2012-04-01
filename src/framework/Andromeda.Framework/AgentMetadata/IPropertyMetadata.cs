using System;

namespace Andromeda.Framework.AgentMetadata
{
	public interface IPropertyMetadata
	{
		string Name { get; set; }

		Type PropertyType { get; set; }
	}
}