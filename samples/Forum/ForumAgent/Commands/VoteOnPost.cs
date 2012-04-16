using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class VoteOnPost : DefaultCommand
	{
		public Guid AuthorIdentifier { get; set; }

		public Guid PostIdentifier { get; set; }

		public bool VoteUp { get; set; }
	}
}