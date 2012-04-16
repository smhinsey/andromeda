using System;
using Andromeda.Framework.Cqrs;

namespace ForumAgent.Commands
{
	public class ActivateOrganizationUser : DefaultCommand
	{
		public Guid UserIdentifier { get; set; }
		public bool Active { get; set; }
	}
}