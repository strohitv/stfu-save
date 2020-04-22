using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ThumbnailUploadStep : AbstractUploadStep
	{
		public ThumbnailUploadStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

		protected override void Run()
		{
			throw new NotImplementedException();
		}
	}
}
