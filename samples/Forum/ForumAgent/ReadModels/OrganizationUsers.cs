using System;
using System.Collections.Generic;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class OrganizationUsers : SyntheticReadModel
	{
		public Guid OrganizationIdentifier { get; set; }

		public string OrganizationName { get; set; }

		public string OrganizationSlug { get; set; }

		public int TotalNumberOfUsers { get; set; }

		public IList<OrganizationUser> Users { get; set; }
	}
}
