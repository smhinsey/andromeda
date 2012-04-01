using Andromeda.Framework.Cqrs;

namespace Andromeda.Sdk.TestAgent.Commands
{
	public class TestCommand : DefaultCommand
	{
		public int Number { get; set; }
	}
}