using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploadInitializer
	{
		internal InternalYoutubeJob Job { get; private set; }
		internal bool Successful { get; private set; }
		internal Uri VideoUploadUri { get; private set; }

		internal YoutubeVideoUploadInitializer(InternalYoutubeJob job)
		{
			Job = job;
		}

		internal void InitializeUpload()
		{
			string url = InitializeUploadOnYoutube();

			Uri uri = null;
			if (Successful = Uri.TryCreate(url, UriKind.Absolute, out uri))
			{
				VideoUploadUri = uri;
			}
		}

		private string InitializeUploadOnYoutube()
		{
			var ytVideo = SerializableYoutubeVideo.Create(Job.Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable"
				+ $"&autoLevels={Job.Video.AutoLevels}&notifySubscribers={Job.Video.NotifySubscribers}"
				+ $"&stabilize={Job.Video.Stabilize}&part=snippet,status,contentDetails",
				"POST",
				YoutubeAccountService.GetAccessToken(Job.Account));

			request.Headers.Add($"x-upload-content-length: {Job.Video.File.Length}");
			//request.Headers.Add($"x-upload-content-type: video/*");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Job.Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			return WebService.Communicate(request, bytes, "Location");
		}
	}
}
