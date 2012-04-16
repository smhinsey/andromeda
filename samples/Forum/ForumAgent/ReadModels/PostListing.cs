using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class PostListing : DefaultReadModel
	{
		public virtual string CategoryName { get; set; }

		public virtual IList<Post> Posts { get; set; }

		public virtual string TagName { get; set; }

		public virtual int TotalPosts { get; set; }
	}
}
