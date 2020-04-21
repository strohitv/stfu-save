using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ChangeVideoDetailsStep : AbstractUploadStep
	{
		public ChangeVideoDetailsStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status) : base(video, account, status)
		{
		}

		internal override void Run()
		{
			throw new NotImplementedException();
		}
	}
}
