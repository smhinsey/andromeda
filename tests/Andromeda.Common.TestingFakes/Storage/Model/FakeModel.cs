using System;
using Andromeda.Common.Storage;

namespace Andromeda.Common.TestingFakes.Storage.Model
{
	public class FakeModel : IModel
	{
		public virtual DateTime Created { get; set; }

		public virtual Guid Identifier { get; set; }

		public virtual DateTime Modified { get; set; }

		public virtual string Name { get; set; }
	}
}