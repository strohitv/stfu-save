using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using STFU.UploadLib.Communication.Youtube.Serializable;

namespace STFU.UploadLib.Videos
{
	public class Video : IVideo
	{
		private PrivacyStatus privacy;
		private DateTime? publishAt;
		private Collection<string> tags = new Collection<string>(new List<string>());

		public string Path { get; set; }

		public FileInfo File { get { return (!string.IsNullOrWhiteSpace(Path)) ? new FileInfo(Path) : null; } }

		public string Title { get; set; }

		public string Description { get; set; }

		public Category Category { get; set; }

		public Language DefaultLanguage { get; set; }

		public Collection<string> Tags { get { return tags; } }

		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy
		{
			get
			{
				return privacy;
			}
			set
			{
				if (value != PrivacyStatus.Private && PublishAt != null)
				{
					PublishAt = null;
				}
				privacy = value;
			}
		}

		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; }

		public bool IsEmbeddable { get; set; }

		public bool PublicStatsViewable { get; set; }

		public bool NotifySubscribers { get; set; }

		public bool AutoLevels { get; set; }

		public bool Stabilize { get; set; }

		public DateTime? PublishAt
		{
			get
			{
				return publishAt;
			}
			set
			{
				if (value != null && Privacy != PrivacyStatus.Private)
				{
					Privacy = PrivacyStatus.Private;
				}
				publishAt = value;
			}
		}

		public string ThumbnailPath { get; set; }

		public static int MaxTitleLength => 100;

		public static int MaxDescriptionLength => 5000;

		public static int MaxTagsLength => 500;

		public Video(string path)
		{
			Path = path;
		}
	}
}
