using System;

namespace Andromeda.Composites.AgentResolution
{
	public class AgentNotFoundException : Exception
	{
		public AgentNotFoundException(string systemName)
			: base(string.Format("Could not find the agent {0}", systemName))
		{
		}
	}
}