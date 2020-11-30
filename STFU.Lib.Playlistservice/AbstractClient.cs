using System;

namespace STFU.Lib.Playlistservice
{
	public abstract class AbstractClient
	{
		protected Uri Host { get; set; }
		protected string Username { get; set; }
		protected string Password { get; set; }

		public AbstractClient(Uri host)
		{
			Host = host;
		}

		public AbstractClient(Uri host, string user, string pass)
			: this(host)
		{
			Username = user;
			Password = pass;
		}
	}
}
