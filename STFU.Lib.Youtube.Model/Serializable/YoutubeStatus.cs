﻿using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model.Helpers;

namespace STFU.Lib.Youtube.Model.Serializable
{
	public class YoutubeStatus
	{
		[JsonProperty(PropertyName = "publicStatsViewable")]
		public bool PublicStatsViewable { get; set; }

		[JsonProperty(PropertyName = "publishAt")]
		public string PublishAt { get; set; }

		[JsonProperty(PropertyName = "privacyStatus")]
		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy { get; set; }

		[JsonProperty(PropertyName = "embeddable")]
		public bool IsEmbeddable { get; set; }

		[JsonProperty(PropertyName = "license")]
		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; }

		public bool ShouldPublishAt { get; set; }
		
		public bool ShouldSerializeShouldPublishAt()
		{ return false; }

		public bool ShouldSerializePublishAt()
		{ return ShouldPublishAt; }
	}
}
