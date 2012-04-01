﻿using System;

namespace Andromeda.Framework.Cqrs
{
	public class InvalidMessageTypeException : Exception
	{
		public InvalidMessageTypeException(string message, Exception inner = null)
			: base(message, inner)
		{
		}
	}
}