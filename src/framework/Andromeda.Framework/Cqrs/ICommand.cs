using Andromeda.Common.Messaging;
using Andromeda.Framework.AgentMetadata;

namespace Andromeda.Framework.Cqrs
{
	/// <summary>
	/// 	A command encapsulates an action undertaken by the user of a system, human or computer, with the intent
	/// 	of modifying the state of the system.
	/// </summary>
	public interface ICommand : IMessage, IAgentPart
	{
	}
}