using System.Collections.Generic;

using STFU.Lib.Youtube.Communication.Interfaces;
using STFU.Lib.Youtube.Communication.Internal;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication
{
	public class YoutubeClientCommunicator : IYoutubeClientCommunicator
	{
		public IReadOnlyCollection<IYoutubeClient> Clients => YoutubeClientService.Clients;

		public void AddClient(string clientId, string clientSecret, string name)
		{
			YoutubeClientService.AddClient(clientId, clientSecret, name);
		}

		public void RemoveClient(IYoutubeClient client)
		{
			YoutubeClientService.RemoveClient(client);
		}
	}
}
