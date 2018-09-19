using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Enums
{
	public enum YoutubeRedirectUri
	{
		[JsonProperty(PropertyName = "http://localhost")]
		[EnumMember(Value = "http://localhost")]
		Localhost,

		[JsonProperty(PropertyName = "urn:ietf:wg:oauth:2.0:oob")]
		[EnumMember(Value = "urn:ietf:wg:oauth:2.0:oob")]
		Code
	}
}
