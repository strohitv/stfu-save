using System;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeJob : INotifyPropertyChanged
	{
		/// <summary>
		/// the video that is being uploaded
		/// </summary>
		IYoutubeVideo Video { get; }

		/// <summary>
		/// the channel the video is being uploaded to
		/// </summary>
		IYoutubeAccount Account { get; }

		/// <summary>
		/// id of the video after it was successfully uploaded
		/// </summary>
		string VideoId { get; }

		/// <summary>
		/// the url the video has to be uploaded
		/// </summary>
		Uri Uri { get; }

		/// <summary>
		/// current state of the job
		/// </summary>
		UploadState State { get; }

		/// <summary>
		/// current progress of the job
		/// </summary>
		double Progress { get; }

		/// <summary>
		/// Contains information about the error if something fails
		/// </summary>
		IYoutubeError Error { get; }
	}
}
