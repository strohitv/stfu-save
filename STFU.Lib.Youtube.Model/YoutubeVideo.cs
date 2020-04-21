using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeVideo : IYoutubeVideo
	{
		public YoutubeVideo(string path)
		{
			Path = path;
		}

		private bool autoLevels = false;
		public bool AutoLevels
		{
			get
			{
				return autoLevels;
			}
			set
			{
				if (autoLevels != value)
				{
					autoLevels = value;
					OnPropertyChanged();
				}
			}
		}

		private ICategory category;
		[JsonConverter(typeof(ConcreteTypeConverter<YoutubeCategory>))]
		public ICategory Category
		{
			get
			{
				return category;
			}
			set
			{
				if (category != value)
				{
					category = value;
					OnPropertyChanged();
				}
			}
		}

		private ILanguage defaultLanguage;
		[JsonConverter(typeof(ConcreteTypeConverter<YoutubeLanguage>))]
		public ILanguage DefaultLanguage
		{
			get
			{
				return defaultLanguage;
			}
			set
			{
				if (defaultLanguage != value)
				{
					defaultLanguage = value;
					OnPropertyChanged();
				}
			}
		}

		private string description = string.Empty;
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				if (value != null)
				{
					value = value.Replace("<", string.Empty).Replace(">", string.Empty);

					if (value.Length > MaxDescriptionLength)
					{
						value = value.Substring(0, MaxDescriptionLength);
					}
				}

				if (description != value)
				{
					description = value;
					OnPropertyChanged();
				}
			}
		}

		[JsonIgnore]
		public FileInfo File => !string.IsNullOrWhiteSpace(Path) ? new FileInfo(Path) : null;

		private bool isEmbeddable = false;
		public bool IsEmbeddable
		{
			get
			{
				return isEmbeddable;
			}
			set
			{
				if (isEmbeddable != value)
				{
					isEmbeddable = value;
					OnPropertyChanged();
				}
			}
		}

		private License license = License.Youtube;
		public License License
		{
			get
			{
				return license;
			}
			set
			{
				if (license != value)
				{
					license = value;
					OnPropertyChanged();
				}
			}
		}

		[JsonIgnore]
		public string MediaType => MimeMapping.GetMimeMapping(Path);

		[JsonIgnore]
		public bool MediaTypeOk
			=> MediaType.ToLower().StartsWith("video/") || MediaType.ToLower().StartsWith("application/");

		private bool notifySubscribers = true;
		public bool NotifySubscribers
		{
			get
			{
				return notifySubscribers;
			}
			set
			{
				if (notifySubscribers != value)
				{
					notifySubscribers = value;
					OnPropertyChanged();
				}
			}
		}

		private string path;
		public string Path
		{
			get
			{
				return path;
			}
			set
			{
				if (path != value)
				{
					path = value;
					OnPropertyChanged();
				}
			}
		}

		private PrivacyStatus privacy = PrivacyStatus.Private;
		public PrivacyStatus Privacy
		{
			get
			{
				return privacy;
			}
			set
			{
				if (privacy != value)
				{
					privacy = value;
					OnPropertyChanged();
				}
			}
		}

		private bool publicStatsViewable = false;
		public bool PublicStatsViewable
		{
			get
			{
				return publicStatsViewable;
			}
			set
			{
				if (publicStatsViewable != value)
				{
					publicStatsViewable = value;
					OnPropertyChanged();
				}
			}
		}

		private DateTime? publishAt;
		public DateTime? PublishAt
		{
			get
			{
				return publishAt;
			}
			set
			{
				if (publishAt != value)
				{
					publishAt = value;
					OnPropertyChanged();
				}
			}
		}

		[JsonIgnore]
		public bool SizeOk => File.Length < (long)128 * 1000 * 1000 * 1000;

		private bool stabilize = false;
		public bool Stabilize
		{
			get
			{
				return stabilize;
			}
			set
			{
				if (stabilize != value)
				{
					stabilize = value;
					OnPropertyChanged();
				}
			}
		}

		private List<string> tags = new List<string>();
		public ICollection<string> Tags
		{
			get
			{
				EnsureNoTagIsTooLong();
				EnsureTagStringIsNotTooLong();

				return tags;
			}
		}

		private void EnsureNoTagIsTooLong()
		{
			for (int i = 0; i < tags.Count; i++)
			{
				if (!string.IsNullOrWhiteSpace(tags[i]))
				{
					tags[i] = tags[i].Replace("<", string.Empty).Replace(">", string.Empty).Trim();

					if (tags[i].Length > MaxSingleTagLength)
					{
						tags[i] = tags[i].Substring(0, MaxSingleTagLength).Trim();
					}
				}
				else
				{
					tags.RemoveAt(i);
					i--;
				}
			}
		}

		private void EnsureTagStringIsNotTooLong()
		{
			var count = 0;

			while (tags.Count > 0 &&
				(count = tags
				.Select(t => t.Contains(" ") ? $"\"{t}\"" : t)
				.Aggregate((a, b) => $"{a},{b}")
				.Length) > MaxTagsLength)
			{
				tags.RemoveAt(tags.Count - 1);
			}
		}

		private string thumbnailPath;
		public string ThumbnailPath
		{
			get
			{
				return thumbnailPath;
			}
			set
			{
				if (thumbnailPath != value)
				{
					thumbnailPath = value;
					OnPropertyChanged();
				}
			}
		}

		private string title = string.Empty;
		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				if (value != null)
				{
					value = value.Replace("<", string.Empty).Replace(">", string.Empty);

					if (value.Length > MaxTitleLength)
					{
						value = value.Substring(0, MaxTitleLength);
					}
				}

				if (title != value)
				{
					title = value;
					OnPropertyChanged();
				}
			}
		}

		public static int MaxTitleLength => 100;

		public static int MaxDescriptionLength => 5000;

		public static int MaxTagsLength => 500;

		public static int MaxSingleTagLength => 100;

		// obsolete
		public bool IsDirty { get; set; }

		// obsolete
		public bool IsThumbnailDirty { get; set; }

		// gehört in den UploadStatus des Jobs => obsolete
		public Uri UploadUri { get; set; }

		private string id;
		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				if (id != value)
				{
					id = value;
					OnPropertyChanged();
				}
			}
		}

		// Das gehört eigentlich zum Job
		[JsonConverter(typeof(ConcreteTypeConverter<NotificationSettings>))]
		public INotificationSettings NotificationSettings { get; set; }

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string caller = null)
		{
			PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(caller));
		}

		public override string ToString()
		{
			return $"{Title} - {Path}";
		}

		public IYoutubeVideo CreateCopy()
		{
			YoutubeVideo video = new YoutubeVideo(Path)
			{
				AutoLevels = AutoLevels,
				Category = Category,
				DefaultLanguage = DefaultLanguage,
				Description = Description,
				IsDirty = false,
				IsEmbeddable = IsEmbeddable,
				IsThumbnailDirty = false,
				License = License,
				NotifySubscribers = NotifySubscribers,
				Privacy = Privacy,
				PublicStatsViewable = PublicStatsViewable,
				PublishAt = PublishAt,
				Stabilize = Stabilize,
				ThumbnailPath = ThumbnailPath,
				Title = Title
			};

			foreach (var tag in Tags)
			{
				video.Tags.Add(tag);
			}

			return video;
		}

		public void FillFields(IYoutubeVideo video)
		{
			if (AutoLevels != video.AutoLevels)
			{
				IsDirty = true;
				AutoLevels = video.AutoLevels;
			}

			if (Category != video.Category)
			{
				IsDirty = true;
				Category = video.Category;
			}

			if (DefaultLanguage != video.DefaultLanguage)
			{
				IsDirty = true;
				DefaultLanguage = video.DefaultLanguage;
			}

			if (Description != video.Description)
			{
				IsDirty = true;
				Description = video.Description;
			}

			if (IsEmbeddable != video.IsEmbeddable)
			{
				IsDirty = true;
				IsEmbeddable = video.IsEmbeddable;
			}

			if (License != video.License)
			{
				IsDirty = true;
				License = video.License;
			}

			if (NotifySubscribers != video.NotifySubscribers)
			{
				IsDirty = true;
				NotifySubscribers = video.NotifySubscribers;
			}

			if (Privacy != video.Privacy)
			{
				IsDirty = true;
				Privacy = video.Privacy;
			}

			if (PublicStatsViewable != video.PublicStatsViewable)
			{
				IsDirty = true;
				PublicStatsViewable = video.PublicStatsViewable;
			}

			if (PublishAt != video.PublishAt)
			{
				IsDirty = true;
				PublishAt = video.PublishAt;
			}

			if (Stabilize != video.Stabilize)
			{
				IsDirty = true;
				Stabilize = video.Stabilize;
			}

			if (!TagsEqual(video.Tags))
			{
				IsDirty = true;

				Tags.Clear();
				foreach (var tag in video.Tags)
				{
					Tags.Add(tag);
				}
			}

			if (Title != video.Title)
			{
				IsDirty = true;
				Title = video.Title;
			}

			if (ThumbnailPath != video.ThumbnailPath)
			{
				IsDirty = true;
				IsThumbnailDirty = true;
				ThumbnailPath = video.ThumbnailPath;
			}
		}

		private bool TagsEqual(ICollection<string> otherTags)
		{
			var tagsEqual = otherTags.Count == Tags.Count;

			if (tagsEqual)
			{
				for (int i = 0; i < Tags.Count; i++)
				{
					if (Tags.ElementAt(i) != otherTags.ElementAt(i))
					{
						tagsEqual = false;
						break;
					}
				}
			}

			return tagsEqual;
		}
	}
}
