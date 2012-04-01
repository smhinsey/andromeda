using System;

namespace Andromeda.Framework.AgentMetadata.PartCollection
{
	public class InvalidAgentPartImplementationException : Exception
	{
		private Type _type;

		public InvalidAgentPartImplementationException(Type agentPartImplementationType)
		{
			_type = agentPartImplementationType;
		}
	}
}