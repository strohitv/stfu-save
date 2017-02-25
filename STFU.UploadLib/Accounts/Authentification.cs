using System;

namespace STFU.UploadLib.Accounts
{
	public class Authentification
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public string Type { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
