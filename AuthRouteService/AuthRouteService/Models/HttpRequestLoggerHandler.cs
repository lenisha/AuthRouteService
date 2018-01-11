using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace AuthRouteService
{
	internal class HttpRequestLoggerHandler : DelegatingHandler
	{
		public HttpRequestLoggerHandler()
		{
		}
		private static Logger logger = LogManager.GetCurrentClassLogger();

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			logger.Debug("Incoming Request {0} ", request);

		
			var httpResponseMessage = base.SendAsync(request, cancellationToken);


			logger.Debug("Outgoing Response {0} ", httpResponseMessage);

			return httpResponseMessage;
		}

	}
}