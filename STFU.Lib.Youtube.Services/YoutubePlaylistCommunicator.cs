using System.Collections.Generic;
using System.Net;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Services
{
	public class YoutubePlaylistCommunicator
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(YoutubePlaylistCommunicator));

		public YoutubePlaylistCommunicator() { }

		public IList<IYoutubePlaylist> LoadPlaylists(IYoutubeAccount account)
		{
			LOGGER.Info($"Loading playlists of account with id: '{account.Id}' and title: '{account.Title}' from youtube");

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

			foreach (var playlist in list)
			{
				LOGGER.Info($"Loaded playlist with id: {playlist.Id} and title: '{playlist.Title}'. Playlist has been published at: '{playlist.PublishedAt}'");
			}

			return list;
		}
	}
}
