using Andromeda.Common.Logging;
using Andromeda.Common.Messaging;

namespace Andromeda.Framework.Cqrs
{
	public class CommandPublisher : DefaultPublisher, ILoggingSource
	{
		public CommandPublisher(ICommandRegistry registry, IMessageChannel channel)
			: base(registry, channel)
		{
		}
	}
}