using Andromeda.Framework.Agent;
using Andromeda.Framework.TestingFakes.Cqrs;

[assembly: AgentSystemName(Value = "Andromeda.Framework.TestingFakeAgent")]
[assembly: AgentName(Value = "Testing Fake Agent")]

// hardcode agent namepsace

[assembly: LocationOfCommands(NamespaceOfType = typeof(FakeCommand))]

// specify namespace by type

[assembly: LocationOfQueries(Namespace = "FakeAgent.Queries")]

// explicitly set namespace

[assembly: LocationOfProcessors(Namespace = "FakeAgent.Processors")]
[assembly: AgentDescription(Value = "A fake agent used for testing in the Andromeda.Framework namespace")]