using System;

namespace Andromeda.Composites.Mvc.ActionFilters
{
	public class CannotRetrieveInputModelException : Exception
	{
		public CannotRetrieveInputModelException(string inputModelName) : base(inputModelName)
		{
		}
	}
}