using Andromeda.Framework.AgentMetadata;
using Andromeda.Framework.AgentMetadata.Extensions;
using Andromeda.Sdk.TestAgent.Commands;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.Metadata.Agent
{
	[Binding]
	public class AgentProvidesMetadata : PropertiesUsedInTests
	{
		[Given("an agent")]
		public void AnAgent()
		{
			Agent = typeof(TestCommand).Assembly.GetAgentMetadata();
		}

		[When("the (.*) is requested")]
		public void FormattedMetadataIsRequested(string representationType)
		{
			switch (representationType.ToLower())
			{
				case "basic":
					Formatter = Agent.GetFormatter(FormatterType.Basic);
					break;
				case "full":
					Formatter = Agent.GetFormatter(FormatterType.Full);
					break;
			}
		}
	}
}