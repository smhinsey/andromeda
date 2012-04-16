using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class TagDetail : DefaultReadModel
	{
		public virtual IList<Post> Posts { get; set; }

		public virtual Tag Tag { get; set; }
	}
}
