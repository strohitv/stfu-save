using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	public class Template
	{
		private PrivacyStatus privacy;
		private DateTime? publishAt;

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
	}
}
