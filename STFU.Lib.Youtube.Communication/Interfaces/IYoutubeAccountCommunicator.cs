using System;
using System.Collections.ObjectModel;
using STFU.Lib.Youtube.Communication.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Interfaces
{
	public interface IYoutubeAccountCommunicator
	{
		ReadOnlyCollection<IYoutubeAccount> ConnectedAccounts { get; }

		Uri CreateAuthUri(IYoutubeClient client, YoutubeRedirectUri redirectUri, YoutubeScope scope);

		IYoutubeAccount ConnectToAccount(string code, IYoutubeClient client, YoutubeRedirectUri redirectUri);

		void RemoveAccount(IYoutubeAccount account);
	}
}
