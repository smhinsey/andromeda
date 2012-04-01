using System.Reflection;

namespace Andromeda.Composites.AgentResolution
{
	public interface IAgentResolver
	{
		Assembly GetAgent(string systemName);
	}
}