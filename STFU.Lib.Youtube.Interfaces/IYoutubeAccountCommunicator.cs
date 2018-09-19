using System;
using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeAccountCommunicator
	{
		Uri CreateAuthUri(IYoutubeClient client, YoutubeRedirectUri redirectUri, YoutubeScope scope);

		IYoutubeAccount ConnectToAccount(string code, IYoutubeClient client, YoutubeRedirectUri redirectUri);

		void RevokeAccount(IYoutubeAccountContainer container, IYoutubeAccount account);

		void RevokeAccounts(IYoutubeAccountContainer container, IEnumerable<IYoutubeAccount> accounts);
	}
}
