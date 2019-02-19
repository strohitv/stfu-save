using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Internal
{
	internal class YoutubeError : IYoutubeError
	{
		public int ErrorCode { get; set; }

		public string Json { get; set; }

		public string Message { get; set; }

		internal YoutubeError(string message) : this(-1, message, string.Empty) { }

		internal YoutubeError(int code, string message, string json)
		{
			ErrorCode = code;
			Message = message;
			Json = json;
		}
	}
}
