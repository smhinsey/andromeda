using System;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ForumVotingScheme : SyntheticReadModel
	{
		public VotingScheme CurrentScheme { get; set; }

		public Guid ForumIdentifier { get; set; }

		public string ForumName { get; set; }
	}
}
