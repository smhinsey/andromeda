using Andromeda.Common.Messaging;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Framework.TestingFakes.Cqrs
{
	public class FakeCommandProcessor : ICommandProcessor<FakeCommand>, ICommandProcessor<FakeCommand2>
	{
		public static int FakeCommandCount;

		public static int FakeCommandTwoCount;

		public bool CanProcessMessage(IMessage message)
		{
			return message.GetType() == typeof(FakeCommand) || message.GetType() == typeof(FakeCommand2);
		}

		public void Process(FakeCommand command)
		{
			FakeCommandCount++;
		}

		public void Process(FakeCommand2 message)
		{
			FakeCommandTwoCount++;
		}
	}
}