using System;
using System.ComponentModel;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubePlaylist : INotifyPropertyChanged
	{
		string Title { get; set; }
		string Id { get; set; }

		DateTime PublishedAt { get; set; }
	}
}
