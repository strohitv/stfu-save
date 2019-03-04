using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Internal.Services;

namespace STFU.Lib.Youtube
{
	public static class YoutubeAccountAccessExtension
	{
		public static string GetActiveToken(this IList<IYoutubeAccountAccess> access)
		{
			return YoutubeAccountService.GetAccessToken(access);
		}

		public static string GetActiveToken(this IYoutubeAccount account)
		{
			return YoutubeAccountService.GetAccessToken(account);
		}
	}
}
