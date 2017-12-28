using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.UploadLib.Videos
{
	public enum PrivacyStatus
	{
		[JsonProperty(PropertyName = "public")]
		[EnumMember(Value = "public")]
		Public = 0,
		[JsonProperty(PropertyName = "public")]
		[EnumMember(Value = "public")]
		Unlisted = 1,
		[JsonProperty(PropertyName = "private")]
		[EnumMember(Value = "private")]
		Private = 2
	}
}
