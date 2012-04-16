using System;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ForumBadge : DefaultReadModel
	{
		public virtual bool Active { get; set; }

		public virtual string Description { get; set; }

		public virtual string Field { get; set; }

		public virtual Guid ForumIdentifier { get; set; }

		public virtual string ImageUrl { get; set; }

		public virtual string Name { get; set; }

		public virtual string Operator { get; set; }

		public virtual string Value { get; set; }
	}
}
