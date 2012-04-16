using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class RejectPost : DefaultCommand
	{
		public Guid PostIdentifier { get; set; }
	}
}