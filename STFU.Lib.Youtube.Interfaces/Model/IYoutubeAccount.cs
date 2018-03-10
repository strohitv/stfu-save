using System;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeAccount
	{
		/// <summary>
		/// Unique ChannelId of the youtube channel
		/// </summary>
		string Id { get; }

		/// <summary>
		/// Url of the youtube channel
		/// </summary>
		Uri Uri { get; }

		/// <summary>
		/// Title of the youtube channel
		/// </summary>
		string Title { get; }

		/// <summary>
		/// the channels region
		/// </summary>
		string Region { get; }
	}
}
