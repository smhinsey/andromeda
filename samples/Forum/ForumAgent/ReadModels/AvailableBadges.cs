using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class AvailableBadges : SyntheticReadModel
	{
		public IList<ForumBadge> Badges { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int TotalBadges { get; set; }
	}
}
