using System.IO;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeThumbnail
	{
		/// <summary>
		/// Fileinfo of the image that should be uploaded as a thumbnail
		/// </summary>
		FileInfo File { get; }

		/// <summary>
		/// Determines if the video size is accepted by youtube
		/// </summary>
		bool SizeOk { get; }

		/// <summary>
		/// Gets the media type of the video
		/// </summary>
		string MediaType { get; }

		/// <summary>
		/// Determines if the video media type will be accepted by youtube
		/// </summary>
		bool MediaTypeOk { get; }
	}
}
