using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthRouteService.Controllers
{
	// GET /me/health
	public class HealthController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "UP" };
		}

		
	}
}