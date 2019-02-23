using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Internal
{
	internal class YoutubeError : IYoutubeError
	{
		public FailureReason FailReason { get; set; }

		public int ErrorCode { get; set; }

		public string Json { get; set; }

		public string Message { get; set; }

		public YoutubeError(FailureReason failreason, string message) : this(failreason, -1, message, string.Empty) { }

		public YoutubeError(FailureReason failreason, int code, string message, string json)
		{
			FailReason = failreason;
			ErrorCode = code;
			Message = message;
			Json = json;
		}
	}
}
