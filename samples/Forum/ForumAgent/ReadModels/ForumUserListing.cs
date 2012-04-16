using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ForumUserListing : DefaultReadModel
	{
		public virtual int TotalUsers { get; set; }

		public virtual IList<ForumUser> Users { get; set; }
	}
}
