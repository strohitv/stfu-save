﻿using System;
using STFU.Lib.Youtube.Communication.InternalInterfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Communication.Internal
{
	internal class YoutubeAccountAccess : IYoutubeAccountAccess
	{
		public string AccessToken { get; set; }

		public DateTime ExpirationDate { get; set; }

		public bool IsExpired => ExpirationDate < DateTime.Now;

		public string RefreshToken { get; set; }

		public string TokenType { get; set; }

		public IYoutubeClient Client { get; set; }
	}
}
