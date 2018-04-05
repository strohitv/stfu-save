using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation.Internal.Parser
{
	public static class LicenseParser
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
