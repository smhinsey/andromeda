using Andromeda.Framework.Agent;
using Andromeda.Sdk.TestAgent.Commands;
using Andromeda.Sdk.TestAgent.Processors;
using Andromeda.Sdk.TestAgent.Queries;
using Andromeda.Sdk.TestAgent.ReadModels;

[assembly: AgentSystemName(Value = "SDKTests.TestAgent")]
[assembly: AgentName(Value = "Test Agent")]
[assembly: AgentDescription(Value = "An agent used for testing")]
[assembly: LocationOfCommands(NamespaceOfType = typeof(TestCommand))]
[assembly: LocationOfQueries(NamespaceOfType = typeof(TestQuery))]
[assembly: LocationOfProcessors(NamespaceOfType = typeof(TestCommandProcessor))]
[assembly: LocationOfReadModels(NamespaceOfType = typeof(TestReadModel))]