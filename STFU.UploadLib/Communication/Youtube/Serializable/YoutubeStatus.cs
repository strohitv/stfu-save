using System;
using Newtonsoft.Json;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public class YoutubeStatus
	{
		public bool publicStatsViewable { get; set; }
		public DateTime publishAt { get; set; }

		[JsonProperty(PropertyName = "nope")]
		public PrivacyValues privacyStatus { get; set; }

		[JsonProperty(PropertyName = "privacyStatus")]
		public string privacyValue { get { return privacyStatus; } }
		public bool embeddable { get; set; }

		[JsonProperty(PropertyName = "license")]
		public string licenceString { get { return licence; } }

		[JsonProperty(PropertyName = "dont")]
		public Licences licence { get; set; }

		//public PrivacyValues PrivacyValues = { "public", "unlisted", "private" };
		public bool ShouldPublishAt { get; set; }

		//public Licences Licences = { "youtube", "creativeCommon" };

		public bool ShouldSerializelicence()
		{ return false; }
		public bool ShouldSerializeShouldPublishAt()
		{ return false; }
		public bool ShouldSerializeprivacyStatus()
		{ return false; }
		public bool ShouldSerializepublishAt()
		{ return ShouldPublishAt; }
	}
}
