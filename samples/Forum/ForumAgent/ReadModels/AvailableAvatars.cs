using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class AvailableAvatars : SyntheticReadModel
	{
		public IList<ForumAvatar> Avatars { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }

		public int TotalAvatars { get; set; }
	}
}
