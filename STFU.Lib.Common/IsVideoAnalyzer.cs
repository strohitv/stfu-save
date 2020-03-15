using System.Linq;

namespace STFU.Lib.Common
{
	public static class IsVideoAnalyzer
	{
		static string[] allowedVideoTypes = new[]
		{
			".mkv",
			".mov",
			".mp4",
			".avi",
			".wmv",
			".mpegps",
			".flv",
			".3gp",
			".webm",
			".ogv",
			".mpg",
			".mpeg",
			".m2v",
			".3g2",
			".webm",
			".ogg"
		};

		public static bool IsVideo(string filename)
		{
			return allowedVideoTypes.Any(extension => filename.ToLower().EndsWith(extension));
		}
	}
}
