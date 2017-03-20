using System;
using Newtonsoft.Json;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public class YoutubeStatus
	{
		[JsonProperty(PropertyName = "publicStatsViewable")]
		public bool PublicStatsViewable { get; set; }

		[JsonProperty(PropertyName = "publishAt")]
		public DateTime PublishAt { get; set; }

		[JsonProperty(PropertyName = "privacyStatus")]
		public PrivacyStatus Privacy { get; set; }

		[JsonProperty(PropertyName = "embeddable")]
		public bool IsEmbeddable { get; set; }

		[JsonProperty(PropertyName = "license")]
		public License License { get; set; }

		public bool ShouldPublishAt { get; set; }

		//public bool ShouldSerializelicence()
		//{ return false; }
		public bool ShouldSerializeShouldPublishAt()
		{ return false; }
		//public bool ShouldSerializeprivacyStatus()
		//{ return false; }
		public bool ShouldSerializepublishAt()
		{ return ShouldPublishAt; }
	}
}
