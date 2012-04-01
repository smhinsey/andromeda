using System;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Framework.TestingFakes.Cqrs
{
	public class FakeCommand2 : ICommand
	{
		public string CommandName { get; set; }

		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public Guid Identifier { get; set; }
	}
}