using System;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeAccountAccess
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
		/// Determines if access is expired
		/// </summary>
		DateTime NextRefreshAllowed { get; set; }

		/// <summary>
		/// Determines if access is expired
		/// </summary>
		bool RefreshAllowed { get; }

		/// <summary>
		/// The id of the youtube client the account is connected to
		/// </summary>
		string ClientId { get; set; }

		/// <summary>
		/// Determines if the uploader may send mails for this account
		/// </summary>
		bool HasSendMailPrivilegue { get; set; }

		/// <summary>
		/// The youtube client the account is connected to
		/// </summary>
		[JsonIgnore]
		IYoutubeClient Client { get; set; }
	}
}
