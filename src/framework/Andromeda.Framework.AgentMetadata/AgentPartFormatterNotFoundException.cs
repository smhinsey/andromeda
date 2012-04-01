using System;

namespace Andromeda.Framework.AgentMetadata
{
	public class AgentPartFormatterNotFoundException : Exception
	{
		public AgentPartFormatterNotFoundException(string agentPartTypeName)
			: base(agentPartTypeName)
		{
		}
	}
}