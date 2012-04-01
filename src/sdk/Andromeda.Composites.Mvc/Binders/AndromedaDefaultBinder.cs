using System.Web.Mvc;

namespace Andromeda.Composites.Mvc.Binders
{
	// lifted wholesale from http://lostechies.com/jimmybogard/2009/03/18/a-better-model-binder/
	public class AndromedaDefaultBinder : DefaultModelBinder
	{
		private readonly IAndromedaModelBinder[] _AndromedaModelBinders;

		public AndromedaDefaultBinder(IAndromedaModelBinder[] AndromedaModelBinders)
		{
			_AndromedaModelBinders = AndromedaModelBinders;
		}

		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			foreach (var binder in _AndromedaModelBinders)
			{
				if (binder.IsMatch(bindingContext.ModelType))
				{
					return binder.BindModel(controllerContext, bindingContext);
				}
			}

			return bindingContext.ModelType.IsInterface ? null : base.BindModel(controllerContext, bindingContext);
		}
	}
}