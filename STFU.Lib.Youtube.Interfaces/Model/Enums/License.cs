using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Model.Enums
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
