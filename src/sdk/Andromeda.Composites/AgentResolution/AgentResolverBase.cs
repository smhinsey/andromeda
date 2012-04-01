using System.Reflection;
using Andromeda.Common.Logging;
using Andromeda.Framework.AgentMetadata.Extensions;

namespace Andromeda.Composites.AgentResolution
{
	public abstract class AgentResolverBase : ILoggingSource, IAgentResolver
	{
		public abstract Assembly GetAgent(string systemName);

		protected bool IsAgent(Assembly assembly, string systemName)
		{
			var metadata = assembly.GetAgentMetadata();

			if (metadata == null)
			{
				return false;
			}

			return systemName == metadata.SystemName;
		}
	}
}