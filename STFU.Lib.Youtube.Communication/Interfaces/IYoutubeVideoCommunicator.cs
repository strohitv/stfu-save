using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Interfaces
{
	public interface IYoutubeVideoCommunicator : INotifyPropertyChanged
	{
		double Progress { get; }

		void UploadVideo(IYoutubeVideo video, IYoutubeAccount account);

		void UploadThumbnil(IYoutubeThumbnail thumbnail, IYoutubeAccount account);
	}
}
