using System;

namespace Andromeda.Composites
{
	public class QueryNotFoundInCompositeException : Exception
	{
		public QueryNotFoundInCompositeException(string queryName) : base(queryName)
		{
		}
	}
}