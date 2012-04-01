﻿using Andromeda.Framework.EventSourcing;

namespace Andromeda.Framework.TestingFakes.EventSourcing
{
	public class PostCreatedEvent : DefaultEvent
	{
		public string AuthorUsername { get; set; }

		public string Body { get; set; }

		public string Title { get; set; }
	}
}