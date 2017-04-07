using System;
using Newtonsoft.Json;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	public class Template
	{
		private PrivacyStatus privacy;
		private PublishRule publishRule;

		public string Name { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int CategoryId { get; set; }

		public string DefaultLanguage { get; set; }

		public string Tags { get; set; }

		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy
		{
			get
			{
				return privacy;
			}
			set
			{
				if (value != PrivacyStatus.Private && PublishRule != null)
				{
					PublishRule = null;
				}
				privacy = value;
			}
		}

		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; }

		public bool IsEmbeddable { get; set; }

		public bool PublicStatsViewable { get; set; }

		[JsonIgnore]
		public bool NeedsStart { get { return PublishRule != null; } }

		public PublishRule PublishRule
		{
			get
			{
				return publishRule;
			}
			set
			{
				if (value != null && Privacy != PrivacyStatus.Private)
				{
					Privacy = PrivacyStatus.Private;
				}
				publishRule = value;
			}
		}

		public Template()
			: this("neues Template")
		{
		}

		public Template(string name)
		{
			Name = name;
		}

		internal Video CreateVideo(Video video)
		{
			video.Title = Title;
			video.Description = Description;
			video.CategoryId = CategoryId;
			video.DefaultLanguage = DefaultLanguage;

			video.Privacy = Privacy;
			video.License = License;
			video.IsEmbeddable = IsEmbeddable;
			video.PublicStatsViewable = PublicStatsViewable;

			DateTime? pd = PublishRule.NextTime();
			video.PublishAt = pd.Value != default(DateTime) ? pd : null;

			video.Tags.Clear();
			foreach (var tag in Tags.Split(','))
			{
				video.Tags.Add(tag);
			}

			return video;
		}

		internal Video CreateVideo(string path)
		{
			Video video = new Video(path);

			return CreateVideo(video);
		}

		internal void StartPublishRule(DateTime start)
		{
			PublishRule.Start(start);
		}

		// TODO: Veröffentlichungen entsprechend einstellen, dass das funktioniert. Wie mach ich das? :o
	}
}
