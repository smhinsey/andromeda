using System;
using System.Web.Mvc;
using Andromeda.Composites.Mvc.Extensions;
using Andromeda.Framework.Models;

namespace Andromeda.Composites.Mvc.ActionFilters
{
	public class FormatInputModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var format = filterContext.ActionParameters["format"] as string ?? string.Empty;

			if (string.IsNullOrEmpty(format) || string.Equals(format, "html", StringComparison.CurrentCultureIgnoreCase))
			{
				return;
			}

			var inputModel = filterContext.ActionParameters["inputModel"] as IInputModel;

			if (inputModel == null)
			{
				return;
			}

			var formatter = inputModel.GetMetadataFormatter();

			filterContext.Result = new ContentResult
				{
					Content = formatter.GetRepresentation(format),
					ContentEncoding = formatter.GetEncoding(format),
					ContentType = formatter.GetContentType(format)
				};

			base.OnActionExecuting(filterContext);
		}
	}
}