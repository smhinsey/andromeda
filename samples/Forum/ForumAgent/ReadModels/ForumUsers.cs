using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ForumUsers : SyntheticReadModel
	{
		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int TotalUsers { get; set; }

		public IList<ForumUser> Users { get; set; }
	}
}
