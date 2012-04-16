using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class DeleteStopWord : DefaultCommand
	{
		public Guid StopWordIdentifier { get; set; }
	}
}