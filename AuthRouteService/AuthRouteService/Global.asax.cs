﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AuthRouteService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

		void Application_Error(object sender, EventArgs e)
		{
			Exception lastError = Server.GetLastError();
			Console.WriteLine("Unhandled exception: " + lastError.Message + lastError.StackTrace);
			Response.ClearContent();
			Response.Output.WriteLine("Unhandled exception: " + lastError.Message + lastError.StackTrace);
			Response.StatusCode = 403;
			Response.End();
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}
		protected void Application_MapRequestHandler(object sender, EventArgs e)
		{
		}
	}
}
