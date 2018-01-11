using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace AuthRouteService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			// Global Handlers
			config.MessageHandlers.Add(new HttpRequestLoggerHandler());

			// Web Api routes
			config.MapHttpAttributeRoutes();

			// Route Service healthcheck controllers
			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "me/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }

            );

			// Intercepting backend calls
			config.Routes.MapHttpRoute(
				name: "allpath",
				routeTemplate: "{*allpath}",
				defaults: null,
				constraints: null,
				handler: new ProxyHandler()
			);

			// Route Static files (js,css) requests too
			RouteTable.Routes.RouteExistingFiles = true;
			
		}
    }
}
