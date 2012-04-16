using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class AwardBadge : DefaultCommand
	{
		public Guid ForumIdentifier { get; set; }
		public Guid UserIdentifier { get; set; }
		public Guid BadgeIdentifier { get; set; }
	}
}