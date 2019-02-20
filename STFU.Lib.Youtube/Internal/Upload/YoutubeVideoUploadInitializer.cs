using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploadInitializer
	{
		private IYoutubeVideo Video { get; set; }
		private IYoutubeAccount Account { get; set; }

		internal bool Successful { get; private set; }
		internal Uri VideoUploadUri { get; private set; }

		internal YoutubeVideoUploadInitializer(IYoutubeVideo video, IYoutubeAccount account)
		{
			Video = video;
			Account = account;
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
			var ytVideo = SerializableYoutubeVideo.Create(Video);
			string content = JsonConvert.SerializeObject(ytVideo);
			var bytes = Encoding.UTF8.GetBytes(content);

			var request = HttpWebRequestCreator.CreateWithAuthHeader(
				$"https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable"
				+ $"&autoLevels={Video.AutoLevels}&notifySubscribers={Video.NotifySubscribers}"
				+ $"&stabilize={Video.Stabilize}&part=snippet,status,contentDetails",
				"POST",
				YoutubeAccountService.GetAccessToken(Account));

			request.Headers.Add($"x-upload-content-length: {Video.File.Length}");
			//request.Headers.Add($"x-upload-content-type: video/*");
			request.Headers.Add($"x-upload-content-type: {MimeMapping.GetMimeMapping(Video.File.Name)}");

			request.ContentLength = bytes.Length;
			request.ContentType = "application/json; charset=utf-8";

			return WebService.Communicate(request, bytes, "Location");
		}
	}
}
