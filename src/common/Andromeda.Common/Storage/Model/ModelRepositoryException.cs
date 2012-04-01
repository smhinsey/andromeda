using System;

namespace Andromeda.Common.Storage.Model
{
	public class ModelRepositoryException : Exception
	{
		public ModelRepositoryException(string message)
			: base(message)
		{
		}
	}
}