using Andromeda.Common.Messaging;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;

namespace Andromeda.Framework.Cqrs
{
	public class CommandRegistry : PublicationRegistry<CommandPublicationRecord, ICommandPublicationRecord>,
	                               ICommandRegistry
	{
		public CommandRegistry(
			IRecordMapper<CommandPublicationRecord> mapper, IBlobStorage blobStorage, IMessageSerializer serializer)
			: base(mapper, blobStorage, serializer)
		{
		}
	}
}