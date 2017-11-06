using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using NLog;

namespace AuthRouteService
{
	public class ProxyHandler : DelegatingHandler
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		protected  override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return RedirectRequest(request, cancellationToken);
		}

		private async Task<HttpResponseMessage> RedirectRequest(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var redirectLocation = "http://localhost:49599";
			var localPath = request.RequestUri.LocalPath;

			logger.Info("Incoming Request {0} ", request);
			var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false });

			var clonedRequest = await HttpRequestMessageExtensions.CloneHttpRequestMessageAsync(request);

			clonedRequest.RequestUri = new Uri(redirectLocation + localPath);

			return await client.SendAsync(clonedRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		}
	}
}