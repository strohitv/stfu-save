using System.IO;
using System.Net;

namespace STFU.Lib.Youtube.Internal
{
	public static class WebService
	{
		public static string Communicate(WebRequest request, byte[] bytes = null, string headerName = null)
		{
			if (bytes != null && bytes.Length != 0)
			{
				// Senden
				var requestStream = request.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
			}

			try
			{
				// Verbinden
				var response = request.GetResponse();
				var responseStream = response.GetResponseStream();

				if (string.IsNullOrWhiteSpace(headerName))
				{
					// Lesen
					StreamReader responseReader = new StreamReader(responseStream);
					return responseReader.ReadToEnd();
				}
				else
				{
					// Url erhalten
					return response.Headers.Get(headerName);
				}
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					var response = ex.Response as HttpWebResponse;
					if ((int)response.StatusCode == 308)
					{
						var range = response.Headers.Get("range");
						return range;
					}
				}

				if (ex.Response != null)
				{
					using (var stream = ex.Response.GetResponseStream())
					{
						using (var reader = new StreamReader(stream))
						{
							return reader.ReadToEnd();
						}
					}
				}
				return null;
			}
		}
	}
}
