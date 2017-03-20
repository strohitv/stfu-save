using System.IO;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public class YoutubeVideo
	{
		public FileInfo FileDetails { get; set; }
		public YoutubeSnippet snippet { get; set; }
		public YoutubeStatus status { get; set; }
		public string Path { get { return FileDetails.FullName; } }
		public string Name { get { return FileDetails.Name; } }
		public string Extension { get { return FileDetails.Extension.Substring(1); } }
		public long Size { get { return FileDetails.Length; } }

		public YoutubeVideo()
		{
		}

		internal YoutubeVideo(string path)
		{
			FileDetails = new FileInfo(path);
		}

		//public void ChangeVideoPath(string path)
		//{
		//	FileDetails = new FileInfo(path);
		//}

		public bool ShouldSerializestatus()
		{
			if (status == null || (!status.embeddable && status.licence == null && status.privacyStatus == PrivacyValues.Private && !status.publicStatsViewable))
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

		#region JSONSerialize methods
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
		#endregion JSONSerialize methods
	}
}

