using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class NotificationSettings : INotificationSettings
	{
		public bool NotifyOnVideoFoundDesktop { get; set; }
		public bool NotifyOnVideoFoundMail { get; set; }
		public bool NotifyOnVideoUploadStartedDesktop { get; set; }
		public bool NotifyOnVideoUploadStartedMail { get; set; }
		public bool NotifyOnVideoUploadFinishedDesktop { get; set; }
		public bool NotifyOnVideoUploadFinishedMail { get; set; }
		public bool NotifyOnVideoUploadFailedDesktop { get; set; }
		public bool NotifyOnVideoUploadFailedMail { get; set; }

		public string MailReceiver { get; set; }
	}
}
