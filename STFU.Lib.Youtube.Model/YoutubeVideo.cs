﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeVideo : IYoutubeVideo
	{
		public YoutubeVideo()
		{ }

		public YoutubeVideo(string path)
		{
			Path = path;
		}

		public bool AutoLevels { get; set; }

		public ICategory Category { get; set; }

		public ILanguage DefaultLanguage { get; set; }

		public string Description { get; set; }

		public FileInfo File => new FileInfo(Path);

		public bool IsEmbeddable { get; set; }

		public License License { get; set; }

		public string MediaType => MimeMapping.GetMimeMapping(Path);

		public bool MediaTypeOk
			=> MediaType.ToLower().StartsWith("video/") || MediaType.ToLower().StartsWith("application/");

		public bool NotifySubscribers { get; set; }

		public string Path { get; set; }

		public PrivacyStatus Privacy { get; set; }

		public bool PublicStatsViewable { get; set; }

		public DateTime? PublishAt { get; set; }

		public bool SizeOk => File.Length < (long)128 * 1000 * 1000 * 1000;

		public bool Stabilize { get; set; }

		public ICollection<string> Tags { get; } = new List<string>();

		public string ThumbnailPath { get; set; }

		public string Title { get; set; }

		public static int MaxTitleLength => 100;

		public static int MaxDescriptionLength => 5000;

		public static int MaxTagsLength => 500;

		public bool IsDirty { get; set; }

		public bool IsThumbnailDirty { get; set; }

		public Uri UploadUri { get; set; }

		public string Id { get; set; }

		public override string ToString()
		{
			return Title;
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
