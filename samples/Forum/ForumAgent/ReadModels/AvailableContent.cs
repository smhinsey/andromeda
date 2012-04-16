using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class AvailableContent : SyntheticReadModel
	{
		public IList<ForumContent> ContentItems { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int TotalContentItems { get; set; }
	}
}
