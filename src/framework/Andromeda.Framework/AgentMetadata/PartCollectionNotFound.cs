using System;

namespace Andromeda.Framework.AgentMetadata
{
	public class PartCollectionNotFound : Exception
	{
		public PartCollectionNotFound(string partType)
			: base(partType)
		{
		}
	}
}