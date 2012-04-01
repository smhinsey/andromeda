﻿using System;
using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Registry
{
	public class FakeMessage : IMessage
	{
		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public Guid Identifier { get; set; }
	}
}