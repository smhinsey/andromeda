using System.Data;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Sdk.TestAgent.Commands
{
	public class FailingCommand : DefaultCommand
	{
		public int Number { get; set; }
	}
}