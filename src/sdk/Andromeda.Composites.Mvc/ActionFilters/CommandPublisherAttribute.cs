﻿using System;
using System.Globalization;
using System.Web.Mvc;
using AutoMapper;
using Andromeda.Common.Messaging;
using Andromeda.Composites.Mvc.Extensions;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Composites.Mvc.ActionFilters
{
	public class CommandPublisherAttribute : ActionFilterAttribute
	{
		public ICompositeApp CompositeApp { get; set; }

		public IPublisher Publisher { get; set; }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var commandName = filterContext.HttpContext.Request.Form["partName"];

			if (filterContext.HttpContext.Request.Params == null)
			{
				throw new NullReferenceException("filterContext.HttpContext.Request.Params");
			}

			var valueProvider = new NameValueCollectionValueProvider(
				filterContext.HttpContext.Request.Params, CultureInfo.CurrentCulture);

			var inputModel = CompositeApp.GetInputModelFromCommandName(commandName, valueProvider, filterContext.HttpContext.Request.Files);

			var command = CompositeApp.GetCommandForInputModel(inputModel);

			var publicationId = Publisher.PublishMessage(command);

			filterContext.ActionParameters["publicationId"] = publicationId;
		}
	}
}