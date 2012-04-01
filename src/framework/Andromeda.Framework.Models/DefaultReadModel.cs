using System;

namespace Andromeda.Framework.Models
{
	public class DefaultReadModel : IReadModel
	{
		public virtual DateTime Created { get; set; }

		public virtual Guid Identifier { get; set; }

		public virtual DateTime Modified { get; set; }
	}
}