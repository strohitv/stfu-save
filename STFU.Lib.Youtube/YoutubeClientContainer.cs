using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeClientContainer : IYoutubeClientContainer
	{
		private IList<IYoutubeClient> Clients { get; } = new List<IYoutubeClient>();

		public IReadOnlyCollection<IYoutubeClient> RegisteredClients => new ReadOnlyCollection<IYoutubeClient>(Clients);

		public void RegisterClient(IYoutubeClient client)
		{
			if (!RegisteredClients.Any(c => c.Id == client.Id))
			{
				Clients.Add(client);
			}
		}

		public void UnregisterAllClients()
		{
			Clients.Clear();
		}

		public void UnregisterClient(IYoutubeClient client)
		{
			if (Clients.Contains(client))
			{
				Clients.Remove(client);
			}
		}

		public void UnregisterClientAt(int index)
		{
			if (Clients.Count > index)
			{
				Clients.RemoveAt(index);
			}
		}
	}
}
