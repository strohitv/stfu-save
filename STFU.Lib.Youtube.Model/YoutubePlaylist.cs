using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubePlaylist : IYoutubePlaylist
	{
		private string title;
		private string id;
		private DateTime publishedAt;

		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged();
			}
		}

		public string Id
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged();
			}
		}

		public DateTime PublishedAt
		{
			get { return publishedAt; }
			set
			{
				publishedAt = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string caller = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}
	}
}
