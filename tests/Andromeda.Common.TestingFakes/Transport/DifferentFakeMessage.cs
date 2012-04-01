﻿using System;
using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Transport
{
	public class DifferentFakeMessage : IMessage
	{
		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public Guid Identifier { get; set; }

		public int Number { get; set; }

		public string Title { get; set; }
	}
}