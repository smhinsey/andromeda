using System;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class StopWord : DefaultReadModel
	{
		public virtual bool Active { get; set; }

		public virtual Guid ForumIdentifier { get; set; }

		public virtual string ReplacementWord { get; set; }

		public virtual string WordToMatch { get; set; }
	}
}
