using System.Text;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ChangeVideoDetailsStep : AbstractUploadStep
	{
		public ChangeVideoDetailsStep(IYoutubeVideo video, IYoutubeAccount account, UploadStatus status)
			: base(video, account, status) { }

		internal override void Run()
		{
			// TODO: try-catch außenrum bauen für den Fall, dass da was schiefgeht..

			var request = HttpWebRequestCreator.CreateWithAuthHeader("https://www.googleapis.com/youtube/v3/videos?part=snippet,status", "PUT", Account.GetActiveToken());
			request.ContentType = "application/json";

			SerializableYoutubeVideo resource = SerializableYoutubeVideo.Create(Video);
			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resource));

			var response = WebService.Communicate(request, bytes);

			FinishedSuccessful = true;

			OnStepFinished();
		}
	}
}
