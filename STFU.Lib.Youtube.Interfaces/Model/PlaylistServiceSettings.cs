using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public class PlaylistServiceSettings : INotifyPropertyChanged
	{
		private bool shouldSend;

		private string host;
		private string port;
		private string username;
		private string password;

		private long accountId;

		private string playlistId;
		private string playlistTitle;

		public bool ShouldSend
		{
			get
			{
				return shouldSend;
			}
			set
			{
				if (value != shouldSend)
				{
					shouldSend = value;
					OnPropertyChanged();
				}
			}
		}

		public long? TaskId { get; set; }

		public string Host
		{
			get
			{
				return host;
			}
			set
			{
				if (value != host)
				{
					host = value;
					OnPropertyChanged();
				}
			}
		}

		public string Port
		{
			get
			{
				return port;
			}
			set
			{
				if (value != port)
				{
					port = value;
					OnPropertyChanged();
				}
			}
		}

		public string Username
		{
			get
			{
				return username;
			}
			set
			{
				if (value != username)
				{
					username = value;
					OnPropertyChanged();
				}
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				if (value != password)
				{
					password = value;
					OnPropertyChanged();
				}
			}
		}

		public long AccountId
		{
			get
			{
				return accountId;
			}
			set
			{
				if (value != accountId)
				{
					accountId = value;
					OnPropertyChanged();
				}
			}
		}

		public string PlaylistId
		{
			get
			{
				return playlistId;
			}
			set
			{
				if (value != playlistId)
				{
					playlistId = value;
					OnPropertyChanged();
				}
			}
		}

		public string PlaylistTitle
		{
			get
			{
				return playlistTitle;
			}
			set
			{
				if (value != playlistTitle)
				{
					playlistTitle = value;
					OnPropertyChanged();
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string caller = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
		}
	}
}
