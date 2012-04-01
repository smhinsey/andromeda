﻿using System;
using System.Web.Mvc;
using Andromeda.Common.Logging;

namespace Andromeda.Sdk.TestComposite.Controllers
{
	public class HomeController : Controller, ILoggingSource
	{
		public ActionResult Index()
		{
			try
			{
				var zero = 0;
				var dumb = 9 / zero;
			}
			catch (Exception e)
			{
				this.WriteErrorMessage("An error occurred", e);
			}

			this.WriteDebugMessage("Test debug message");

			return View();
		}
	}
}