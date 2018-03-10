using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Interfaces
{
	public interface IYoutubeClientCommunicator
	{
		IReadOnlyCollection<IYoutubeClient> Clients { get; }

		void AddClient(string clientId, string clientSecret, string title);

		void RemoveClient(IYoutubeClient client);
	}
}
