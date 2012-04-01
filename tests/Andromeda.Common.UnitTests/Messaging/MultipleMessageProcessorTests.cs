using Andromeda.Common.TestingFakes.Messaging;
using Andromeda.Common.TestingFakes.Transport;
using Andromeda.TestingSupport;
using NUnit.Framework;

namespace Andromeda.Common.UnitTests.Messaging
{
	[TestFixture]
	[Category(TestCategories.Unit)]
	public class MultipleMessageProcessorTests
	{
		[Test]
		public void MultipleMessagesAreRecognizedByProcessor()
		{
			var processor = new FakeMultipleMessageProcessor();

			var fakeMessage = new FakeMessage();
			var differentMessage = new DifferentFakeMessage();

			Assert.IsTrue(processor.CanProcessMessage(fakeMessage));
			Assert.IsTrue(processor.CanProcessMessage(differentMessage));
		}
	}
}