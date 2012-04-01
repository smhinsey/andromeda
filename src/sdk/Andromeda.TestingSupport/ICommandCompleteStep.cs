using Andromeda.Common.Messaging;
using Andromeda.Framework.Cqrs;

namespace Andromeda.TestingSupport
{
	public interface ICommandCompleteStep<in T>
		where T : ICommand
	{
		void CommandCompleted(IPublicationRecord record, T command);
	}
}