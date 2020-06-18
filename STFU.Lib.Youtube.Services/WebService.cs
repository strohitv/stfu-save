using System.IO;
using System.Net;

namespace STFU.Lib.Youtube.Services
{
	public static class WebService
	{
		public static string Communicate(WebRequest request, out WebException exception, byte[] bytes = null, string headerName = null)
		{
			exception = null;

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
				exception = ex;

				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					var response = ex.Response as HttpWebResponse;
					if ((int)response.StatusCode == 308)
					{
						var range = response.Headers.Get("range");
						return range;
					}
				}

//				string error = @"{
//  "error": {

//	"code": 403,
//    "message": "The request cannot be completed because you have exceeded your \u003ca href=\"/youtube/v3/getting-started#quota\"\u003equota\u003c/a\u003e.",
//    "errors": [
//      {
//        "message": "The request cannot be completed because you have exceeded your \u003ca href=\"/youtube/v3/getting-started#quota\"\u003equota\u003c/a\u003e.",
//        "domain": "youtube.quota",
//        "reason": "quotaExceeded",
//        "debugInfo": "Code: 8; Description: ?metric=youtube.googleapis.com/default&limit=defaultPerDayPerProject&qs_error_code=INSUFFICIENT_TOKENS"

//	  }
//    ]
//  }
//}
//"

				return null;
			}
		}

		public static string Communicate(WebRequest request, byte[] bytes = null, string headerName = null)
		{
			WebException ex = null;

			string result = Communicate(request, out ex, bytes, headerName);

			if (ex != null)
			{
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

			return result;
		}
	}
}
