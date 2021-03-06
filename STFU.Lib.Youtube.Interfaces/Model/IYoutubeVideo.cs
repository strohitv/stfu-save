﻿using System;
using System.Collections.Generic;
using System.IO;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeVideo : System.ComponentModel.INotifyPropertyChanged
	{
		/// <summary>
		/// The file that is being uploaded
		/// </summary>
		FileInfo File { get; }

		/// <summary>
		/// Title of the video
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Full path of the video
		/// </summary>
		string Path { get; set; }

		/// <summary>
		/// Description of the video
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Determines if the video will be Embeddable
		/// </summary>
		bool IsEmbeddable { get; set; }

		/// <summary>
		/// Determines if the stats of the video will be public
		/// </summary>
		bool PublicStatsViewable { get; set; }

		/// <summary>
		/// Determines if subscribers will be notified when the video is set public
		/// </summary>
		bool NotifySubscribers { get; set; }

		/// <summary>
		/// Determines if the levels of the video will be automatically corrected by youtube
		/// </summary>
		bool AutoLevels { get; set; }

		/// <summary>
		/// Determines if the video will be automatically stabilized by youtube
		/// </summary>
		bool Stabilize { get; set; }

		/// <summary>
		/// The videos Category
		/// </summary>
		ICategory Category { get; set; }

		/// <summary>
		/// The Videos default language
		/// </summary>
		ILanguage DefaultLanguage { get; set; }

		/// <summary>
		/// Determines the privacy of the video: Public, Unlisted or Private. To publish the video at a specific time, set this value to private and use <see cref="PublishAt"/>
		/// </summary>
		PrivacyStatus Privacy { get; set; }

		/// <summary>
		/// Determines the videos license
		/// </summary>
		License License { get; set; }

		/// <summary>
		/// Determines the time this video should be published. This value is not used if <see cref="Privacy"/> is not set to private.
		/// </summary>
		DateTime? PublishAt { get; set; }

		/// <summary>
		/// Tags associated with the video.
		/// </summary>
		ICollection<string> Tags { get; }

		/// <summary>
		/// Path of the video thumbnail
		/// </summary>
		string ThumbnailPath { get; set; }

		/// <summary>
		/// Determines if the video size is accepted by youtube
		/// </summary>
		bool SizeOk { get; }

		/// <summary>
		/// Gets the media type of the video
		/// </summary>
		string MediaType { get; }

		/// <summary>
		/// Determines if the video media type will be accepted by youtube
		/// </summary>
		bool MediaTypeOk { get; }

		/// <summary>
		/// Can be used to determine if the video properties were changed
		/// </summary>
		bool IsDirty { get; set; }

		/// <summary>
		/// Can be used to determine if the videos thumbnail was changed
		/// </summary>
		bool IsThumbnailDirty { get; set; }

		/// <summary>
		/// Gets or sets the URL the video has to be uploaded to
		/// </summary>
		Uri UploadUri { get; set; }

		/// <summary>
		/// Gets or sets the video id
		/// </summary>
		string Id { get; set; }

		/// <summary>
		/// Gets or sets if the video should be added to a playlist after upload
		/// </summary>
		bool AddToPlaylist { get; set; }

		/// <summary>
		/// Gets or sets the playlist the video should be added to after upload
		/// </summary>
		string PlaylistId { get; set; }

		/// <summary>
		/// Gets or sets the settings for sending the video to Strohis Playlistservice
		/// </summary>
		PlaylistServiceSettings PlaylistServiceSettings { get; set; }

		/// <summary>
		/// Creates a copy of itself
		/// </summary>
		/// <returns>a copy of itself</returns>
		IYoutubeVideo CreateCopy();

		/// <summary>
		/// Fills its fields and properties with values from the given IYoutubeVideo
		/// </summary>
		/// <param name="video"></param>
		void FillFields(IYoutubeVideo video);
	}
}
