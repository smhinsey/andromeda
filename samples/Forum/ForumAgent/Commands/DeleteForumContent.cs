using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class DeleteForumContent : DefaultCommand
	{
		public Guid ContentIdentifier { get; set; }
	}
}