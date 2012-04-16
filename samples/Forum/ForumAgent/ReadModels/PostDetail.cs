using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class PostDetail : DefaultReadModel
	{
		public virtual Category Category { get; set; }

		public virtual IList<Comment> Comments { get; set; }

		public virtual Post InitialPost { get; set; }
	}
}
