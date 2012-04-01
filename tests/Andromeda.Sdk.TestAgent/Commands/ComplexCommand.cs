using Andromeda.Framework.Cqrs;

namespace Andromeda.Sdk.TestAgent.Commands
{
	public class ComplexCommand : DefaultCommand
	{
		public int StringLength { get; set; }

		public string StringValue { get; set; }
	}

	public class UnsupportedCommand : DefaultCommand
	{
		public string SomeDate { get; set; }
	}
}