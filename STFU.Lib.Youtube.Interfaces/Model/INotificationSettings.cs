namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface INotificationSettings
	{
		bool NotifyOnVideoFoundDesktop { get; set; }
		bool NotifyOnVideoFoundMail { get; set; }
		bool NotifyOnVideoUploadStartedDesktop { get; set; }
		bool NotifyOnVideoUploadStartedMail { get; set; }
		bool NotifyOnVideoUploadFinishedDesktop { get; set; }
		bool NotifyOnVideoUploadFinishedMail { get; set; }
		bool NotifyOnVideoUploadFailedDesktop { get; set; }
		bool NotifyOnVideoUploadFailedMail { get; set; }

		string MailReceiver { get; set; }

		INotificationSettings CreateCopy();
	}
}
