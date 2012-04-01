﻿using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Andromeda.Framework.Models;

namespace Andromeda.Composites.Mvc
{
	public static class HtmlHelperExtensions
	{
		public const string PublishCommandRoute = "/composite/api/publish";

		public static MvcForm BeginFormForInputModel(
			this HtmlHelper helper,
			IInputModel inputModel,
			bool overrideRedirect = false,
			string alternateRedirectUrl = "",
			string formId = null)
		{
			if (inputModel == null)
			{
				throw new ArgumentNullException("inputModel");
			}

			if (string.IsNullOrEmpty(formId))
			{
				formId = Guid.NewGuid().ToString();
			}

			// jt: we can deduce the AgentSystemName & PartName w/out requiring them to be explicitly set on the inputmodel
			/*
			var compositeApp = DependencyResolver.Current.GetService<ICompositeApp>();
			var command = compositeApp.GetCommandMetadataForInputModel(inputModel.GetType());
			var agentSystemName = command.Type.Assembly.GetAgentMetadata().SystemName;
			var partName = command.Name;
			*/

			var tagBuilder = new TagBuilder("form");
			tagBuilder.Attributes.Add("method", "post");
			tagBuilder.Attributes.Add("action", PublishCommandRoute);
			tagBuilder.Attributes.Add("id", formId);
			tagBuilder.Attributes.Add("encType", "multipart/form-data");
			helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
			helper.ViewContext.Writer.Write(Environment.NewLine);

			tagBuilder = new TagBuilder("input");
			tagBuilder.Attributes.Add("type", "hidden");
			tagBuilder.Attributes.Add("name", "agentSystemName");
			tagBuilder.Attributes.Add("value", inputModel.AgentSystemName);
			tagBuilder.Attributes.Add("id", "inputmodel-agentsystemname");
			helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.SelfClosing));
			helper.ViewContext.Writer.Write(Environment.NewLine);

			tagBuilder = new TagBuilder("input");
			tagBuilder.Attributes.Add("type", "hidden");
			tagBuilder.Attributes.Add("name", "partName");
			tagBuilder.Attributes.Add("value", inputModel.PartName);
			tagBuilder.Attributes.Add("id", "inputmodel-partname");
			helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.SelfClosing));
			helper.ViewContext.Writer.Write(Environment.NewLine);

			if (string.IsNullOrEmpty(alternateRedirectUrl) || !overrideRedirect)
			{
				alternateRedirectUrl = helper.ViewContext.RequestContext.HttpContext.Request.RawUrl;
			}

			tagBuilder = new TagBuilder("input");
			tagBuilder.Attributes.Add("type", "hidden");
			tagBuilder.Attributes.Add("name", "redirectUrl");
			tagBuilder.Attributes.Add("value", alternateRedirectUrl);
			tagBuilder.Attributes.Add("id", "inputmodel-redirectUrl");
			helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.SelfClosing));
			helper.ViewContext.Writer.Write(Environment.NewLine);

			return new MvcForm(helper.ViewContext);
		}
	}
}