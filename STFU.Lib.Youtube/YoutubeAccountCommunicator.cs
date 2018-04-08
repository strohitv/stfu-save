using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using STFU.Lib.Youtube.Internal.Services;
using STFU.Lib.Youtube.Model.Helpers;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeAccountCommunicator : IYoutubeAccountCommunicator
	{
		public ReadOnlyCollection<IYoutubeAccount> ConnectedAccounts => new ReadOnlyCollection<IYoutubeAccount>(YoutubeAccountService.ConnectedAccounts.Keys.ToList());

		public bool HasAtLeastOneAccount => ConnectedAccounts.Count > 0;

		public YoutubeAccountCommunicator() { }

		public Uri CreateAuthUri(IYoutubeClient client, YoutubeRedirectUri redirectUri, YoutubeScope scope)
		{
			string scopeString = JoinScopes(scope);
			string redirectUriString = redirectUri.GetAttribute<EnumMemberAttribute>().Value;
			string authRequestString = $"https://accounts.google.com/o/oauth2/auth?client_id={client.Id}&redirect_uri={redirectUriString}&scope={scopeString}&response_type=code&approval_prompt=force&access_type=offline";

			return new Uri(authRequestString);
		}

		public IYoutubeAccount ConnectToAccount(string code, IYoutubeClient client, YoutubeRedirectUri redirectUri)
		{
			return YoutubeAccountService.ConnectAccount(code, client, redirectUri);
		}

		public void RevokeAccount(IYoutubeAccount account)
		{
			YoutubeAccountService.RevokeAccessOfAccount(account);
		}

		private string JoinScopes(YoutubeScope scope)
		{
			string result = string.Empty;
			bool needsPlus = false;
			foreach (YoutubeScope value in typeof(YoutubeScope).GetEnumValues())
			{
				if (scope.HasFlag(value))
				{
					if (needsPlus)
					{
						result += "+";
					}
					else
					{
						needsPlus = true;
					}

					result += value.GetAttribute<EnumMemberAttribute>().Value;
				}
			}

			return result;
		}
	}
}
