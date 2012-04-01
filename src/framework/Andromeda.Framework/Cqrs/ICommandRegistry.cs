using Andromeda.Common.Messaging;

namespace Andromeda.Framework.Cqrs
{
	public interface ICommandRegistry : IPublicationRegistry<ICommandPublicationRecord, ICommandPublicationRecord>
	{
	}
}