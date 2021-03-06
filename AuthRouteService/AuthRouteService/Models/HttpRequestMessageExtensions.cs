﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NLog;

namespace AuthRouteService
{
	public static class HttpRequestMessageExtensions
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage req, Uri uri)
		{
			var clone = new HttpRequestMessage(req.Method, uri);

			var ms = new MemoryStream();
			if (req.Content != null)
			{
				await req.Content.CopyToAsync(ms).ConfigureAwait(false);
				ms.Position = 0;

				if ((ms.Length > 0 || req.Content.Headers.Any()) && clone.Method != HttpMethod.Get)
				{
					clone.Content = new StreamContent(ms);

					if (req.Content.Headers != null)
						foreach (var h in req.Content.Headers)
							clone.Content.Headers.Add(h.Key, h.Value);
				}
			}

			clone.Version = req.Version;

			foreach (var prop in req.Properties)
				clone.Properties.Add(prop);

			foreach (var header in req.Headers)
				clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

			clone.Headers.Host = uri.Authority;
			clone.RequestUri = uri;
		

			return clone;
		}

		public static T GetFirstHeaderValueOrDefault<T>(this HttpRequestMessage req, string headerKey)
		{
			var toReturn = default(T);

			IEnumerable<string> headerValues;

			if (req.Headers.TryGetValues(headerKey, out headerValues))
			{
				var valueString = headerValues.FirstOrDefault();
				if (valueString != null)
				{
					return (T)Convert.ChangeType(valueString, typeof(T));
				}
			}

			return toReturn;
		}

	
	}
}