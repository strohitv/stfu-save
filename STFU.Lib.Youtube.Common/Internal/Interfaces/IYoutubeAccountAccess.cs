using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Common.Internal.Interfaces
{
	internal interface IYoutubeAccountAccess
	{
		/// <summary>
		/// An accounts access token which is used to allow access to a youtube account
		/// </summary>
		string AccessToken { get; set; }

		/// <summary>
		/// An accounts refresh token. This will be used to refresh access when the access token is too old.
		/// </summary>
		string RefreshToken { get; set; }

		/// <summary>
		/// Type of the token. Will be always bearer for youtube api.
		/// </summary>
		string TokenType { get; set; }

		/// <summary>
		/// Date the accesstoken will expire. After this time it has to be refreshed using the refresh token.
		/// </summary>
		DateTime ExpirationDate { get; set; }

		/// <summary>
		/// Determines if access is expired
		/// </summary>
		bool IsExpired { get; }

		/// <summary>
		/// The youtube client the account is connected to
		/// </summary>
		IYoutubeClient Client { get; set; }
	}
}
