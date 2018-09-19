using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Internal
{
	internal class InternalYoutubeJob : IYoutubeJob
	{
		private IYoutubeError error = null;
		private double progress = 0.0;
		private UploadState state = UploadState.NotStarted;

		public IYoutubeAccount Account { get; }

		public IYoutubeError Error
		{
			get
			{
				return error;
			}

			set
			{
				if (value != error)
				{
					error = value;
					OnPropertyChanged();
				}
			}
		}

		public double Progress
		{
			get
			{
				return progress;
			}

			set
			{
				if (value != progress)
				{
					progress = value;
					OnPropertyChanged();
				}
			}
		}

		public UploadState State
		{
			get
			{
				return state;
			}

			set
			{
				if (value != state)
				{
					state = value;
					OnPropertyChanged();
				}
			}
		}

		public IYoutubeVideo Video { get; }

		public Uri Uri { get; set; }

		public string VideoId { get; set; }

		internal InternalYoutubeJob(IYoutubeVideo video, IYoutubeAccount account)
		{
			Account = account;
			Video = video;
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INofityPropertyChanged
	}
}
