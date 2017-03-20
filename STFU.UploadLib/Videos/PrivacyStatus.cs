using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.UploadLib.Videos
{
	public enum PrivacyStatus
	{
		[JsonProperty(PropertyName = "public")]
		[EnumMember(Value = "public")]
		Public,
		[JsonProperty(PropertyName = "public")]
		[EnumMember(Value = "public")]
		Unlisted,
		[JsonProperty(PropertyName = "private")]
		[EnumMember(Value = "private")]
		Private
	}
}
