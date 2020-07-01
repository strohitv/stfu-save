namespace STFU.Lib.Youtube.Services
{
	public class QuotaErrorResponse
	{
		public QuotaError error { get; set; }
	}

	public class QuotaError
	{
		public int code { get; set; }
		public string message { get; set; }

		public QuotaErrorDetails[] errors { get; set; }
	}

	public class QuotaErrorDetails
	{
		public string message { get; set; }
		public string domain { get; set; }
		public string reason { get; set; }
		public string debugInfo { get; set; }
	}

	//	string error = @"{
	//  "error": {

	//    "code": 403,
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
}
