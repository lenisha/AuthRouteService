using System;
using System.Text;
using System.Web;

namespace AuthRouteService
{
	public class ProxyModule : IHttpModule
	{
		/// <summary>
		/// You will need to configure this module in the Web.config file of your
		/// web and register it with IIS before being able to use it. For more information
		/// see the following link: https://go.microsoft.com/?linkid=8101007
		/// </summary>
		#region IHttpModule Members

		public void Dispose()
		{
			//clean-up code here.
		}

		public void Init(HttpApplication context)
		{
			// Below is an example of how you can handle LogRequest event and provide 
			// custom logging implementation for it
			context.LogRequest += new EventHandler(OnLogRequest);

			context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
			context.EndRequest += (new EventHandler(this.Application_EndRequest));
			context.AuthenticateRequest += (new EventHandler(this.Application_AuthenticateRequest));
		}

		#endregion

		public void OnLogRequest(Object source, EventArgs e)
		{
			//custom logging logic can go here
		}

		public void Application_BeginRequest(Object sender, EventArgs e)
		{
			HttpApplication httpApp = (HttpApplication)sender;
			httpApp.Context.Items["beginRequestTime"] = DateTime.Now;
			
		}

		public void Application_EndRequest(Object sender, EventArgs e)
		{
			HttpApplication httpApp = (HttpApplication)sender;

			// Get the time of the begin request event.
			DateTime beginRequestTime =
				(DateTime)httpApp.Context.Items["beginRequestTime"];

			// Evaluate the time between the begin and the end request events.
			TimeSpan ts = DateTime.Now - beginRequestTime;

			// Write the time span out as a request header.
			httpApp.Context.Response.AppendHeader("TimeSpan", ts.ToString());

		
			// Display the information in the page.
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("<H2>RequestTimeInterval HTTP Module Output {0}</H2>", ts.ToString());
		
			httpApp.Context.Response.ClearContent();
			httpApp.Context.Response.BinaryWrite(Encoding.ASCII.GetBytes(sb.ToString()));
			httpApp.Context.Response.StatusCode = 200;

		}
		private void Application_AuthenticateRequest(Object source, EventArgs e)
		{
			HttpContext context = ((HttpApplication)source).Context;

			// Do something with context near the end of request processing.
		}

	}
}
