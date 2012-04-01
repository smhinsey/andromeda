﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using Andromeda.Framework.AgentMetadata;
using Nancy;

namespace CompositeInspector.Extensions
{
	public static class FormatExtensions
	{
		public static ResponseFormat GetResponseFormat(this NancyModule module)
		{
			return module.Context.GetResponseFormat();
		}

		public static ResponseFormat GetResponseFormat(this NancyContext ctx)
		{
			// NOTE: the headers are stored as a weighted Tuple (Item1 is the value, Item2 is the weight), this could be redone to respect the weight
			var format = ResponseFormat.Html;
			if (
				ctx.Request.Headers.Accept.Any(a => a.Item1.IndexOf("application/json", StringComparison.CurrentCultureIgnoreCase) >= 0)
				||
				ctx.Request.Path.EndsWith(".json", StringComparison.CurrentCultureIgnoreCase)
				)
			{
				format = ResponseFormat.Json;
			}
			else if (
				ctx.Request.Headers.Accept.Any(a => a.Item1.IndexOf("text/xml", StringComparison.CurrentCultureIgnoreCase) >= 0)
				||
				ctx.Request.Headers.Accept.Any(a => a.Item1.IndexOf("application/xml", StringComparison.CurrentCultureIgnoreCase) >= 0)
				||
				ctx.Request.Path.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)
				)
			{
				format = ResponseFormat.Xml;
			}

			return format;
		}

		public static Response WriteTo(this IMetadataFormatter formatter, IResponseFormatter response)
		{
			var format = response.Context.GetResponseFormat();

			if (format == ResponseFormat.Html)
			{
				return HttpStatusCode.NoContent;
			}

			var representation = format == ResponseFormat.Json ? "json" : "xml";
			var encodedString = formatter.GetRepresentation(representation);
			var stream = new MemoryStream(Encoding.UTF8.GetBytes(encodedString));
			return response.FromStream(stream, Andromeda.Common.Extensions.MimeTypes.GetByExtension(representation));
		}
	}
}