﻿using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class AddForumUserAsFriend : DefaultCommand
	{
		public Guid ForumIdentifier { get; set; }
		public Guid UserIdentifier { get; set; }
		public Guid FriendIdentifier { get; set; }
	}
}