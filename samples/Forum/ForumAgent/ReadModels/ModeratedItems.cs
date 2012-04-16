using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ModeratedItems : SyntheticReadModel
	{
		public Guid CurrentUserId { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int Offset { get; set; }

		public int PageSize { get; set; }

		public IList<dynamic> Posts { get; set; }

		public int TotalPosts { get; set; }
	}
}
