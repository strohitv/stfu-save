using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Internal.Parser
{
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
