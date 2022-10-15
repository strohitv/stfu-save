using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Interfaces.Enums
{
	public enum YoutubeRedirectUri
	{
		[JsonProperty(PropertyName = "http://localhost")]
		[EnumMember(Value = "http://localhost:10801")]
		Localhost,

		[JsonProperty(PropertyName = "urn:ietf:wg:oauth:2.0:oob")]
		[EnumMember(Value = "urn:ietf:wg:oauth:2.0:oob")]
		Code
	}
}
