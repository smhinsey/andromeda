using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class ApproveComment : DefaultCommand
	{
		public Guid CommentIdentifier { get; set; }
		public Guid ApprovedBy { get; set; }
	}
}