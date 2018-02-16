using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

	internal static class LicenseParser
	{
		public static License Parse(JToken token)
		{
			License retval = License.Youtube;

			switch (token.ToString().ToLower())
			{
				case "creativecommon":
					retval = License.CreativeCommons;
					break;
				case "youtube":
					break;
			}

			return retval;
		}
	}
}
