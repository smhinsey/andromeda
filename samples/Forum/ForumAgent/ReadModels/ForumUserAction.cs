﻿using System;
using Andromeda.Framework.Models;

namespace ForumAgent.ReadModels
{
	public class ForumUserAction : DefaultReadModel
	{
		public virtual DateTime ActivityOccurredOn { get; set; }

		public virtual Guid AssociatedCommentIdentifier { get; set; }

		public virtual Guid AssociatedPostIdentifier { get; set; }

		public virtual string AssociatedPostTitle { get; set; }

		public virtual string Body { get; set; }

		public virtual Guid ForumIdentifier { get; set; }

		public virtual bool IsComment { get; set; }

		public virtual bool IsPost { get; set; }

		public virtual Guid UserIdentifier { get; set; }
	}
}
