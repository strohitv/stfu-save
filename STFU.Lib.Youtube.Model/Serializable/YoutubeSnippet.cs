﻿using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Model.Serializable
{
	public class YoutubeSnippet
	{
		[JsonProperty(PropertyName = "title")]
		public string title { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string description { get; set; }

		[JsonProperty(PropertyName = "tags")]
		public string[] tags { get; set; }

		[JsonProperty(PropertyName = "categoryId")]
		public int categoryId { get; set; }

		[JsonProperty(PropertyName = "defaultLanguage")]
		public string defaultLanguage { get; set; }

		[JsonProperty(PropertyName = "defaultAudioLanguage")]
		public string defaultAudioLanguage => defaultLanguage;

		public bool shouldSerializedefaultLanguage { get { return defaultLanguage != null; } }

		public bool shouldSerializedefaultAudioLanguage { get { return defaultLanguage != null; } }
	}
}
