using System.IO;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeVideo
	{
		/// <summary>
		/// The file that is being uploaded
		/// </summary>
		FileInfo File { get; set; }

		/// <summary>
		/// Title of the video
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Description of the video
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Determines if the video will be Embeddable
		/// </summary>
		bool IsEmbeddable { get; set; }

		/// <summary>
		/// Determines if the stats of the video will be public
		/// </summary>
		bool PublicStatsViewable { get; set; }

		/// <summary>
		/// Determines if subscribers will be notified when the video is set public
		/// </summary>
		bool NotifySubscribers { get; set; }

		/// <summary>
		/// Determines if the levels of the video will be automatically corrected by youtube
		/// </summary>
		bool AutoLevels { get; set; }

		/// <summary>
		/// Determines if the video will be automatically stabilized by youtube
		/// </summary>
		bool Stabilize { get; set; }

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
