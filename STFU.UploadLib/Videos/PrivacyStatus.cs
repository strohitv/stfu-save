using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace STFU.UploadLib.Videos
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

	internal static class PrivacyStatusParser
	{
		public static PrivacyStatus Parse(JToken token)
		{
			var retval = PrivacyStatus.Private;

			switch (token.ToString().ToLower())
			{
				case "public":
					retval = PrivacyStatus.Public;
					break;
				case "unlisted":
					retval = PrivacyStatus.Unlisted;
					break;
				case "private":
					break;
			}

			return retval;
		}
	}
}
