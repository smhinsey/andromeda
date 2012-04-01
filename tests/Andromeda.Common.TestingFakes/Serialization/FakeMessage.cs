﻿using System;
using System.Collections.Generic;
using Andromeda.Common.Messaging;

namespace Andromeda.Common.TestingFakes.Serialization
{
	public class FakeMessage : IMessage
	{
		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public IList<string> Field1 { get; set; }

		public int Field2 { get; set; }

		public Guid Identifier { get; set; }
	}
}