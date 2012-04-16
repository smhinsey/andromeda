﻿using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class UpdateOrganizationUserLastLogin : DefaultCommand
	{
		public DateTime LoginTime { get; set; }

		public Guid UserIdentifier { get; set; }
	}
}