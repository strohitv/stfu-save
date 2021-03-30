using System;
using log4net;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Services
{
	public class QuotaProblemHandler
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(QuotaProblemHandler));

		public static bool IsQuotaLimitReached(string response)
		{
			try
			{
				var castedError = JsonConvert.DeserializeObject<QuotaErrorResponse>(response);

				var isQuotaReached = castedError?.error?.code == 403
					&& castedError?.error?.errors?[0] != null
					&& castedError?.error?.errors?[0].domain == "youtube.quota"
					&& castedError?.error?.errors?[0].reason == "quotaExceeded";

				if (isQuotaReached)
				{
					LOGGER.Error($"YOUTUBE QUOTA FOR THIS APPLICATION WAS REACHED! RESPONSE: '{response}'");
				}

				return isQuotaReached;
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
				LOGGER.Error($"THROWING AN EXCEPTION!");
				throw new QuotaErrorException();
			}
		}
	}
}
