using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Interfaces
{
	public interface IYoutubeVideoCommunicator
	{
		void UploadVideo(IYoutubeVideo video, IYoutubeAccount account);

		void UploadThumbnail(IYoutubeThumbnail thumbnail, IYoutubeAccount account);
	}
}
