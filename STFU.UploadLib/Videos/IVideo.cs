using System;
using System.Collections.ObjectModel;
using System.IO;

namespace STFU.UploadLib.Videos
{
	public interface IVideo
	{
		bool AutoLevels { get; set; }
		Category Category { get; set; }
		Language DefaultLanguage { get; set; }
		string Description { get; set; }
		FileInfo File { get; }
		bool IsEmbeddable { get; set; }
		License License { get; set; }
		bool NotifySubscribers { get; set; }
		string Path { get; set; }
		PrivacyStatus Privacy { get; set; }
		bool PublicStatsViewable { get; set; }
		DateTime? PublishAt { get; set; }
		bool Stabilize { get; set; }
		Collection<string> Tags { get; }
		string ThumbnailPath { get; set; }
		string Title { get; set; }
	}
}