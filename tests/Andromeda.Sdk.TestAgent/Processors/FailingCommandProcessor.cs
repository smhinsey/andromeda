using System;
using Andromeda.Framework.Cqrs;
using Andromeda.Sdk.TestAgent.Commands;

namespace Andromeda.Sdk.TestAgent.Processors
{
	public class FailingCommandProcessor : DefaultCommandProcessor<FailingCommand>
	{
		public override void Process(FailingCommand message)
		{
			throw new NotImplementedException();
		}
	}
}