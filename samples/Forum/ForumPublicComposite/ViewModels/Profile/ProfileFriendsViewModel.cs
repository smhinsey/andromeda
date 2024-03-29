﻿using System.Collections.Generic;

namespace ForumComposite.ViewModels.Profile
{
	public class ProfileFriendsViewModel
	{
		public ForumAgent.ReadModels.ForumUser User { get; set; }

		public bool IsCurrentUser { get; set; }

		public IList<ForumAgent.ReadModels.ForumUserFriend> Friends { get; set; }
	}
}