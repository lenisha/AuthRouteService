using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace AuthRouteService
{

	public class SMMiddleware
	{
		// use an alias for the OWIN AppFunc:
		AppFunc _next;
 
		
		public SMMiddleware(AppFunc next)
		{
			_next = next;
		}
		public async Task Invoke(IDictionary<string, object> env)
		{
			IOwinContext context = new OwinContext(env);
		
			var uri = new Uri("https://localhost:444");


			Console.WriteLine("Hello from My First Middleware!!!");
			env["owin.RequestPath"] = uri.AbsolutePath;
			env["owin.RequestPathBase"] = string.Empty;
			env["owin.RequestScheme"] = uri.Scheme;
			context.Request.Headers["Host"] = uri.Authority;
			context.Request.Headers["X-Forwarded-Proto"] = "https";//originalUri.Scheme;

		}
	}

	public static class AppBuilderExtensions
	{
	    public static IAppBuilder UseSMMiddleware(this IAppBuilder app)
	    {
	        return app.Use<SMMiddleware>();
	    }
	}
}