using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploadInitializer : UploadStep
	{
		public YoutubeVideoUploadInitializer(IYoutubeVideo video, IYoutubeAccount account)
			: base(video, account)
		{ }

		public override async Task RunAsync()
		{
			await Task.Run(() => Run());
		}

		public void Run()
		{
			State = UploadStepState.Initializing;

			if (Video.UploadUri == null)
			{
				string result = InitializeUploadOnYoutube();

				Uri uri = null;
				if (Uri.TryCreate(result, UriKind.Absolute, out uri))
				{
					Video.UploadUri = uri;

					if (State == UploadStepState.PausePending)
					{
						State = UploadStepState.Paused;
					}
					else if (State == UploadStepState.CancelPending)
					{
						State = UploadStepState.Canceled;
					}
					else
					{
						State = UploadStepState.Successful;
					}
				}
				else
				{
					SetError(result);
				}
			}
			else
			{
				State = UploadStepState.Successful;
			}
		}

		private string InitializeUploadOnYoutube()
		{
			var ytVideo = SerializableYoutubeVideo.Create(Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable"
				+ $"&autoLevels={Video.AutoLevels}&notifySubscribers={Video.NotifySubscribers}"
				+ $"&stabilize={Video.Stabilize}&part=snippet,status,contentDetails",
				"POST",
				Account.GetActiveToken());

			request.Headers.Add($"x-upload-content-length: {Video.File.Length}");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			State = UploadStepState.Running;

			return WebService.Communicate(request, bytes, "Location");
		}

		private void SetError(string result)
		{
			YoutubeErrorResponse error = null;
			try
			{
				error = JsonConvert.DeserializeObject<YoutubeErrorResponse>(result);
			}
			catch (Exception)
			{ }

			if (error != null && error.error != null && error.error.errors != null && error.error.errors.Any(e => e.reason == "uploadLimitExceeded"))
			{
				Error = FailReasonConverter.GetError(FailureReason.UserUploadLimitExceeded);
			}
			else
			{
				Error = FailReasonConverter.GetError(FailureReason.Unknown);
			}

			State = UploadStepState.Error;
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
