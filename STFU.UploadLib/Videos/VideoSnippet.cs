using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.UploadLib.Videos
{
	public class VideoSnippet
	{
		public string title { get; set; }
		public string description { get; set; }
		public string[] tags { get; set; }
		public int categoryId { get; set; }
		public string defaultLanguage { get; set; }

		public bool shouldSerializedefaultLanguage { get { return defaultLanguage != null; } }
	}
}
