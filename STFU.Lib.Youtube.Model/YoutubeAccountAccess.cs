using STFU.Lib.Youtube.Interfaces.Model;
using System;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeAccountAccess : IYoutubeAccountAccess
	{
		public string AccessToken { get; set; }

		public DateTime ExpirationDate { get; set; }

		public bool IsExpired => ExpirationDate.AddMinutes(1) < DateTime.Now;

		public DateTime NextRefreshAllowed { get; set; }

		public bool RefreshAllowed => NextRefreshAllowed < DateTime.Now;

		public string RefreshToken { get; set; }

		public string TokenType { get; set; }

		public bool HasSendMailPrivilegue { get; set; } = false;

		public string ClientId { get; set; }

		public IYoutubeClient Client { get; set; } = new YoutubeClient("812042275170-db6cf7ujravcq2l7vhu7gb7oodgii3e4.apps.googleusercontent.com",
				"cKUCRQz0sE4UUmvUHW6qckbP",
				"Strohis Toolset Für Uploads", false);
	}
}