using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AuthRouteService.Startup))]

namespace AuthRouteService
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseSMMiddleware();
		
			//WebApiConfig.Register(GlobalConfiguration.Configuration);
			//app.UseWebApi(GlobalConfiguration.Configuration);
		}
	}
}
