using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube
{
	public class YoutubeAccountContainer : IYoutubeAccountContainer
	{
		IList<IYoutubeAccount> Accounts { get; } = new List<IYoutubeAccount>();

		public IReadOnlyCollection<IYoutubeAccount> RegisteredAccounts => new ReadOnlyCollection<IYoutubeAccount>(Accounts);

		public void RegisterAccount(IYoutubeAccount account)
		{
			if (!RegisteredAccounts.Any(r => r.Id == account.Id))
			{
				Accounts.Add(account);
			}
		}

		public void UnregisterAccount(IYoutubeAccount account)
		{
			if (Accounts.Contains(account))
			{
				Accounts.Remove(account);
			}
		}

		public void UnregisterAccountAt(int index)
		{
			if (Accounts.Count > index)
			{
				Accounts.RemoveAt(index);
			}
		}

		public void UnregisterAllAccounts()
		{
			Accounts.Clear();
		}
	}
}
