using System;

namespace Andromeda.Composites.Mvc.Extensions
{
	public class RequiredInputModelFieldIsEmptyException : Exception
	{
		public RequiredInputModelFieldIsEmptyException(string fieldName)
			: base(fieldName)
		{
		}
	}
}