using Andromeda.Framework.AgentMetadata.Extensions;
using Andromeda.Sdk.TestAgent.Commands;
using Andromeda.Sdk.TestAgent.Queries;
using Andromeda.Sdk.TestAgent.ReadModels;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.Metadata.Agent
{
	[Binding]
	public class AgentPartProvidesMetadata : PropertiesUsedInTests
	{
		[Given("the part (.*)")]
		public void ValidAgentMetadata(string partName)
		{
			Agent = typeof(TestCommand).Assembly.GetAgentMetadata();

			switch (partName.ToLower())
			{
				case "command":
					Formatter = typeof(TestCommand).GetMetadata().GetFormatter();
					break;
				case "query":
					Formatter = typeof(TestQuery).GetMetadata().GetFormatter();
					break;
				case "readmodel":
					Formatter = typeof(TestReadModel).GetMetadata().GetFormatter();
					break;
			}
		}
	}
}