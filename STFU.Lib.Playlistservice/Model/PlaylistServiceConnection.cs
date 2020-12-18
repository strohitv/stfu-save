﻿namespace STFU.Lib.Playlistservice.Model
{
	public class PlaylistServiceConnection
	{
		public string Host { get; set; }
		public string Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public Account[] Accounts { get; set; }
	}
}
