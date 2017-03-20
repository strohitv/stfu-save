using System.Collections.Generic;
using System.IO;

namespace STFU.UploadLib.Videos
{
	public class Video
	{
		public FileInfo File { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
		public List<string> Tags { get; private set; }
		public PrivacyValues Privacy { get; set; }
		public Licences License { get; set; }


		public VideoSnippet snippet { get; set; }
		public VideoStatus status { get; set; }
		public string Path { get { return File.FullName; } }
		public string Name { get { return File.Name; } }
		public string Extension { get { return File.Extension.Substring(1); } }
		public long Size { get { return File.Length; } }

		public Video()
		{
		}

		public Video(string path)
		{
			File = new FileInfo(path);
		}

		public void ChangeVideoPath(string path)
		{
			File = new FileInfo(path);
		}

		public bool ShouldSerializestatus()
		{
			if (status == null || (!status.embeddable && status.licence == null && status.privacyStatus == PrivacyValues.Public && !status.publicStatsViewable))
			{
				return false;
			}
			return true;
		}

		public bool ShouldSerializesnippet()
		{
			if (snippet == null || (snippet.categoryId == 0 && snippet.description == "" && snippet.title == "" && (snippet.tags == null || snippet.tags.Length == 0)))
			{
				return false;
			}
			return true;
		}

		public bool ShouldSerializePath()
		{
			return false;
		}
		public bool ShouldSerializeName()
		{
			return false;
		}
		public bool ShouldSerializeExtension()
		{
			return false;
		}
		public bool ShouldSerializeSize()
		{
			return false;
		}
	}
}
