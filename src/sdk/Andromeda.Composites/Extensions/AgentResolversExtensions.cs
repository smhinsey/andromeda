using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Andromeda.Composites.AgentResolution;
using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.AgentMetadata.Extensions;

namespace Andromeda.Composites.Extensions
{
	public static class AgentResolversExtensions
	{
		public static Assembly GetAgent(this IEnumerable<IAgentResolver> resolvers, string systemName)
		{
			var agent = resolvers.Select(rslvr => rslvr.GetAgent(systemName)).FirstOrDefault(assembly => assembly != null);

			if (agent == null)
			{
				throw new AgentNotFoundException(systemName);
			}

			return agent;
		}

		public static IAgentMetadata GetAgentMetadata(this IEnumerable<IAgentResolver> resolvers, string systemName)
		{
			var agent = resolvers.Select(rslvr => rslvr.GetAgent(systemName)).FirstOrDefault(assembly => assembly != null);

			if (agent == null)
			{
				throw new AgentNotFoundException(systemName);
			}

			return agent.GetAgentMetadata();
		}
	}
}