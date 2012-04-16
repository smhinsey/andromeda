using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class AvailableCategories : SyntheticReadModel
	{
		public IList<Category> Categories { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int TotalCategories { get; set; }
	}
}
