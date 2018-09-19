using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Enums
{
	public enum YoutubeScope
	{
		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtube")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtube")]
		Manage = 1,

		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtube.force-ssl")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtube.force-ssl")]
		ManageSSL = 2,

		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtube.readonly")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtube.readonly")]
		View = 4,

		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtube.upload")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtube.upload")]
		Upload = 8,

		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtubepartner")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtubepartner")]
		Partner = 16,

		[JsonProperty(PropertyName = "https://www.googleapis.com/auth/youtubepartner-channel-audit")]
		[EnumMember(Value = "https://www.googleapis.com/auth/youtubepartner-channel-audit")]
		Audit = 32
	}
}
