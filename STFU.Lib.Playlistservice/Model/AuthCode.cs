namespace STFU.Lib.Playlistservice.Model
{
	public class AuthCode
	{
		public string code { get; set; }
		public string clientId { get; set; }
		public string clientSecret { get; set; }
		public string redirectUri { get; set; }
	}
}
