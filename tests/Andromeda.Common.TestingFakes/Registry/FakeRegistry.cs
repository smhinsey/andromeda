using Andromeda.Common.Messaging;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;

namespace Andromeda.Common.TestingFakes.Registry
{
	public class FakeRegistry : PublicationRegistry<FakePublicationRecord, FakePublicationRecord>
	{
		public FakeRegistry(IRecordMapper<FakePublicationRecord> mapper, IBlobStorage storage, IMessageSerializer serializer)
			: base(mapper, storage, serializer)
		{
		}
	}
}