﻿using System;
using System.Collections.Generic;
using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Transport
{
	public class FakeMessage : IMessage
	{
		public FakeMessage()
		{
			Identifier = Guid.NewGuid();
		}

		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public int Field1 { get; set; }

		public IList<string> Field2 { get; set; }

		public Guid Identifier { get; set; }
	}
}