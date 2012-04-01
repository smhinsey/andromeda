using System.Collections.Generic;
using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.AgentMetadata.Extensions;
using Andromeda.Sdk.TestAgent.Commands;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.Metadata.Agent
{
	[Binding]
	public class CollectionOfAgentsProvideMetadata : PropertiesUsedInTests
	{
		private List<IAgentMetadata> _agents;

		[Given("an agent collection")]
		public void AnAgentCollection()
		{
			_agents = new List<IAgentMetadata> { typeof(TestCommand).Assembly.GetAgentMetadata() };
			_agents = new List<IAgentMetadata> { typeof(TestCommand).Assembly.GetAgentMetadata() };
		}

		[When("the (.*) is requested from the collection")]
		public void GetCollectionFormatter(string representationType)
		{
			switch (representationType.ToLower())
			{
				case "basic":
					Formatter = _agents.GetBasicMetadataFormatter();
					break;
				case "full":
					Formatter = _agents.GetFullMetadataFormatter();
					break;
			}
		}
	}
}