using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using NLog;
using System.Net;

namespace AuthRouteService
{
	public class ProxyHandler : DelegatingHandler
	{
		public static  String FORWARDED_URL = "X-CF-Forwarded-Url";

	    private static  String PROXY_METADATA = "X-CF-Proxy-Metadata";

		private static  String PROXY_SIGNATURE = "X-CF-Proxy-Signature";

		private static Logger logger = LogManager.GetCurrentClassLogger();

		protected  override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return RedirectRequest(request, cancellationToken);
		}

		private async Task<HttpResponseMessage> RedirectRequest(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			logger.Debug("Incoming Request {0} ", request);

			String remoteserver = request.GetFirstHeaderValueOrDefault<String>(FORWARDED_URL);

			if (remoteserver == null)
				return await ErrorPage(request);

		
			ServicePointManager.ServerCertificateValidationCallback += (mender, certificate, chain, sslPolicyErrors) => true;

			var client = new HttpClient(new HttpClientHandler {
								AllowAutoRedirect = false,
								UseCookies = false
				
			});


			var remoteUri = new Uri(remoteserver);

			var clonedRequest = await HttpRequestMessageExtensions.CloneHttpRequestMessageAsync(request, remoteUri);
			logger.Debug("Forwarding to  {0} ", clonedRequest);

			var httpResponseMessage = await client.SendAsync(clonedRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken);


			logger.Debug("Outgoing Response {0} ", httpResponseMessage);

			return httpResponseMessage;
		}

		private  Task<HttpResponseMessage> ErrorPage(HttpRequestMessage request)
		{
			// Create the response.
			var response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
			{
				Content = new StringContent("Route service does not get required constraints")
			};

			// Note: TaskCompletionSource creates a task that does not contain a delegate.
			var tsc = new TaskCompletionSource<HttpResponseMessage>();
			tsc.SetResult(response);   // Also sets the task state to "RanToCompletion"
			return tsc.Task;
		}
	}
}