using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class ActivateStopWord : DefaultCommand
	{
		public Guid StopWordIdentifier { get; set; }
		public bool Active { get; set; }
	}
}