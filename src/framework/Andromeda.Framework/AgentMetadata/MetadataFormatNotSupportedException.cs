using System;

namespace Andromeda.Framework.AgentMetadata
{
	public class MetadataFormatNotSupportedException : Exception
	{
		public MetadataFormatNotSupportedException(string format)
			: base(format)
		{
		}
	}
}