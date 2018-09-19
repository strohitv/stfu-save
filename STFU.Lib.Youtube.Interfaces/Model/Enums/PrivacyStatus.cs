using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Model.Enums
{
	public enum PrivacyStatus
	{
		[JsonProperty(PropertyName = "public")]
		[EnumMember(Value = "public")]
		Public = 0,
		[JsonProperty(PropertyName = "unlisted")]
		[EnumMember(Value = "unlisted")]
		Unlisted = 1,
		[JsonProperty(PropertyName = "private")]
		[EnumMember(Value = "private")]
		Private = 2
	}
}
