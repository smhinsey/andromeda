using System;
using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Storage
{
	public class FakeMessage : IMessage
	{
		public virtual DateTime Created { get; set; }

		public virtual Guid CreatedBy { get; set; }

		public virtual Guid Identifier { get; set; }
	}
}