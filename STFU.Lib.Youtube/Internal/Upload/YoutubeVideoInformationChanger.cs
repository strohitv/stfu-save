using System.Text;
using System.Threading.Tasks;
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
			State = UploadStepState.Initializing;
			var request = HttpWebRequestCreator.CreateWithAuthHeader("https://www.googleapis.com/youtube/v3/videos?part=snippet,status", "PUT", Account.GetActiveToken());
			request.ContentType = "application/json";

			SerializableYoutubeVideo resource = SerializableYoutubeVideo.Create(Video);
			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resource));

			State = UploadStepState.Running;
			var response = WebService.Communicate(request, bytes);

			State = UploadStepState.Successful;
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
