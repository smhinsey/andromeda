using System;
using System.Web.Mvc;

namespace Andromeda.Composites.Mvc.Binders
{
	public interface IAndromedaModelBinder : IModelBinder
	{
		bool IsMatch(Type modelType);
	}
}