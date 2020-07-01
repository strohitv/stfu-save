using System;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Services
{
	public class QuotaProblemHandler
	{
		public static bool IsQuotaLimitReached(string response)
		{
			try
			{
				var castedError = JsonConvert.DeserializeObject<QuotaErrorResponse>(response);

				return castedError?.error?.code == 403
					&& castedError?.error?.errors?[0] != null
					&& castedError?.error?.errors?[0].domain == "youtube.quota"
					&& castedError?.error?.errors?[0].reason == "quotaExceeded";
			}
			catch (Exception)
			{
				// Lies sich nicht in einen Quota-Fehler parsen => Ist keiner
				return false;
			}

		}

		public static void ThrowOnQuotaLimitReached(string response)
		{
			if (IsQuotaLimitReached(response))
			{
				throw new QuotaErrorException();
			}
		}
	}
}
