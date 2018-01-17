using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	public class Template
	{
		private IList<PublishTime> publishTimes;

		private PrivacyStatus privacy;

		public string Name { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int CategoryId { get; set; }

		public string DefaultLanguage { get; set; }

		public string Tags { get; set; }

		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy
		{
			get { return privacy; }
			set { privacy = value; }
		}

		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; }

		public bool IsEmbeddable { get; set; }

		public bool PublicStatsViewable { get; set; }

		[JsonIgnore]
		public bool NeedsStart { get { return ShouldPublishAt && PublishTimes.Count > 0; } }

		public bool ShouldPublishAt { get; set; }

		public IList<PublishTime> PublishTimes
		{
			get
			{
				if (publishTimes == null)
				{
					publishTimes = new List<PublishTime>();
				}

				return publishTimes;
			}
			set
			{
				publishTimes = value;
			}
		}

		public Template()
			: this("neues Template")
		{
		}

		public Template(string name)
		{
			Name = name;
			Privacy = PrivacyStatus.Private;
		}

		public static explicit operator Template(JToken v)
		{
			return JsonConvert.DeserializeObject<Template>(v.ToString());
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
