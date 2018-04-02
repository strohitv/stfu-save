using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Internal.Services
{
	internal static class YoutubeClientService
	{
		private static IList<IYoutubeClient> YoutubeClients { get; set; }

		internal static IReadOnlyCollection<IYoutubeClient> Clients => new ReadOnlyCollection<IYoutubeClient>(YoutubeClients);

		internal static void AddClient(IYoutubeClient client)
		{
			if (!Clients.Any(c => c.Id == client.Id))
			{
				YoutubeClients.Add(client);
			}
		}

		internal static void AddClient(string id, string secret, string name)
		{
			AddClient(new YoutubeClient(id, secret, name, false));
		}

		internal static void RemoveClient(IYoutubeClient client)
		{
			var clientToRemove = Clients.FirstOrDefault(c => c.Id == client.Id);
			if (clientToRemove != null)
			{
				YoutubeAccountService.RemoveAllAccessesWithClient(client);
				YoutubeClients.Remove(clientToRemove);
			}
		}
	}
}
