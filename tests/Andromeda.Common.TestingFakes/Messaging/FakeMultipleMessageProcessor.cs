using Andromeda.Common.Messaging;
using Andromeda.Common.TestingFakes.Transport;

namespace Andromeda.Common.TestingFakes.Messaging
{
	public class FakeMultipleMessageProcessor : MultipleMessageProcessor
	{
		public static int ProcessedMessages;

		public void Process(FakeMessage message)
		{
			ProcessedMessages++;
		}

		public void Process(DifferentFakeMessage message)
		{
			ProcessedMessages++;
		}
	}
}