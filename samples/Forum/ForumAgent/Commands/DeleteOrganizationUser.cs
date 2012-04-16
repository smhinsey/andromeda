using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class DeleteOrganizationUser : DefaultCommand
	{
		public Guid UserIdentifier { get; set; }
	}
}