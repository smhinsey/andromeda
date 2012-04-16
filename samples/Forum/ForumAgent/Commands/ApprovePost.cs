using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class ApprovePost : DefaultCommand
	{
		public Guid PostIdentifier { get; set; }
		public Guid ApprovedBy { get; set; }
	}
}