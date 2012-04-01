using Andromeda.Common.Messaging;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Framework.Cqrs
{
	/// <summary>
	/// 	A command processor interprets an ICommand into a series of actions in the system.
	/// </summary>
	public interface ICommandProcessor<in TCommand> : IMessageProcessor<TCommand>, IAgentPart, ICommandProcessor
		where TCommand : ICommand
	{
	}

	public interface ICommandProcessor
	{
	}
}