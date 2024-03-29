﻿using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class ActivateAvatar : DefaultCommand
	{
		public Guid AvatarIdentifier { get; set; }
		public bool Active { get; set; }
	}
}