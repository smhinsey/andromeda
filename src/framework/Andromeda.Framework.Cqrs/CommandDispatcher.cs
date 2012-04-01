using Andromeda.Common.Messaging;
using Microsoft.Practices.ServiceLocation;

namespace Andromeda.Framework.Cqrs
{
	public class CommandDispatcher : MultitaskingMessageDispatcher<ICommandRegistry>, ICommandDispatcher
	{
		public CommandDispatcher(IServiceLocator container, ICommandRegistry publicationRegistry)
			: base(container, publicationRegistry)
		{
		}
	}
}