using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload
{
	public class YoutubeJob
	{
		public IYoutubeVideo Video { get; }

		public IYoutubeAccount Account { get; }

		public UploadStatus UploadStatus { get; } = new UploadStatus();

		private JobUploader JobUploader { get; }
	}
}
