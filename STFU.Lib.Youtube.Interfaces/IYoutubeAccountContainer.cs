using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Interfaces
{
	public interface IYoutubeAccountContainer
	{
		IReadOnlyCollection<IYoutubeAccount> RegisteredAccounts { get; }

		void RegisterAccount(IYoutubeAccount account);
		void UnregisterAllAccounts();
		void UnregisterAccount(IYoutubeAccount account);
		void UnregisterAccountAt(int index);
	}
}
