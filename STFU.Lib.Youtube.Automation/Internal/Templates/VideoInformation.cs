using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Templates
{
	public class VideoInformation
	{
		public IYoutubeVideo Video { get; set; }
		public ExpressionEvaluator Evaluator { get; set; }
		public INotificationSettings NotificationSettings { get; set; }

		public VideoInformation(IYoutubeVideo video, ExpressionEvaluator evaluator, INotificationSettings notificationSettings)
		{
			Video = video;
			Evaluator = evaluator;
			NotificationSettings = notificationSettings;
		}
	}
}
