using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoInformationChanger : UploadStep
	{
		public YoutubeVideoInformationChanger(IYoutubeVideo video, IYoutubeAccount account)
			: base(video, account)
		{ }

		public override async Task RunAsync()
		{
			await Task.Run(() => Run());
		}

		public void Run()
		{
			// TODO!
		}

		public override void Cancel()
		{
			State = UploadStepState.CancelPending;
		}

		public override void Pause()
		{
			State = UploadStepState.PausePending;
		}

		public override void Resume()
		{
			if (State == UploadStepState.Paused)
			{
				State = UploadStepState.Successful;
			}
		}
	}
}
