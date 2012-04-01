using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Transport
{
	public class FakeMessageProcessor2 : DefaultMessageProcessor<FakeMessage>
	{
		public static bool ProcessedAnyMessages;

		public override void Process(FakeMessage message)
		{
			ProcessedAnyMessages = true;
		}
	}
}