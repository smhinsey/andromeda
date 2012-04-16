﻿using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class DeleteForumUser : DefaultCommand
	{
		public Guid UserIdentifier { get; set; }
	}
}