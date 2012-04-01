using System;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Framework.TestingFakes.Cqrs
{
	public class FakeCommand3 : ICommand
	{
		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public Guid Identifier { get; set; }
	}
}