using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.UploadLib.Videos
{
	public enum License
	{
		[JsonProperty(PropertyName = "youtube")]
		[EnumMember(Value = "youtube")]
		Youtube = 0,
		[JsonProperty(PropertyName = "creativeCommon")]
		[EnumMember(Value = "creativeCommon")]
		CreativeCommons = 1
	}
}
