using STFU.Lib.Youtube.Interfaces.Model;
using System;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeAccountAccess : IYoutubeAccountAccess
	{
		public string AccessToken { get; set; }

		public DateTime ExpirationDate { get; set; }

		public bool IsExpired => ExpirationDate < DateTime.Now;

		public string RefreshToken { get; set; }

		public string TokenType { get; set; }

		public string ClientId { get; set; }

		public IYoutubeClient Client { get; set; }
	}
}