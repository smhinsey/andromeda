using System;
using System.Linq;
using System.Reflection;
using Andromeda.Framework.AgentMetadata.Extensions;

namespace Andromeda.Composites.AgentResolution
{
	public class AppDomainAgentResolver : AgentResolverBase
	{
		public override Assembly GetAgent(string systemName)
		{
			return
				AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.ContainsAgent() && IsAgent(assembly, systemName))
					.FirstOrDefault();
		}
	}
}