using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class DeleteAvatar : DefaultCommand
	{
		public Guid AvatarIdentifier { get; set; }
	}
}