using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Services
{
	public class YoutubePlaylistCommunicator
	{
		public YoutubePlaylistCommunicator() { }

		public IList<IYoutubePlaylist> LoadPlaylists(IYoutubeAccount account)
		{
			var list = new List<IYoutubePlaylist>();

			string nextPageToken = null;

			do
			{
				string pagetoken = !string.IsNullOrWhiteSpace(nextPageToken) ? $"&pageToken={nextPageToken}" : string.Empty;
				string url = $"https://youtube.googleapis.com/youtube/v3/playlists?part=snippet&maxResults=50&mine=true{pagetoken}&key={YoutubeClientData.YoutubeApiKey}";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "GET";
				request.Credentials = CredentialCache.DefaultCredentials;
				request.ProtocolVersion = HttpVersion.Version11;
				request.Accept = "application/json";

				// Header schreiben
				request.Headers.Add($"Authorization: Bearer {account.Access.GetActiveToken()}");

				var result = WebService.Communicate(request);
				QuotaProblemHandler.ThrowOnQuotaLimitReached(result);

				Response response = JsonConvert.DeserializeObject<Response>(result);

				nextPageToken = response.nextPageToken;
				foreach (var serializedPlaylist in response.items)
				{
					list.Add(new YoutubePlaylist()
					{
						Title = serializedPlaylist.snippet.title,
						Id = serializedPlaylist.id,
						PublishedAt = serializedPlaylist.snippet.publishedAt
					});
				}
			} while (!string.IsNullOrWhiteSpace(nextPageToken));

			return list;
		}
	}
}
