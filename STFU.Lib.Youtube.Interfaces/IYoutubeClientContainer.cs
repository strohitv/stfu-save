using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeClientContainer
	{
		IReadOnlyCollection<IYoutubeClient> RegisteredClients { get; }

		void RegisterClient(IYoutubeClient client);
		void UnregisterAllClients();
		void UnregisterClient(IYoutubeClient client);
		void UnregisterClientAt(int index);
	}
}
