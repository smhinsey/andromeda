using Andromeda.Common.Logging;
using Andromeda.Common.Messaging;

namespace Andromeda.Framework.Cqrs
{
	public abstract class DefaultCommandProcessor<TCommand> : ILoggingSource, ICommandProcessor<TCommand>
		where TCommand : ICommand
	{
		public bool CanProcessMessage(IMessage message)
		{
			return message.GetType() == typeof(TCommand);
		}

		public abstract void Process(TCommand message);
	}
}