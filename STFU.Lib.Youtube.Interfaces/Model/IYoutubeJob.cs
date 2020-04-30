using System.ComponentModel;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeJob : ITriggerDeletion, IUploadCompleted, INotifyPropertyChanged
	{
		IYoutubeVideo Video { get; set; }

		IYoutubeAccount Account { get; set; }

		JobState State { get; set; }

		IYoutubeError Error { get; set; }

		// TODO: Step-Gedöns muss vermutlich vom UploadStatus weg, da der JobUploader eig. die Stepverwaltung ist (?)
		// Frage: Wie benachrichtige ich die GUI dann über den aktuellen Schritt? Enum?
		UploadStatus UploadStatus { get; }

		INotificationSettings NotificationSettings { get; set; }

		bool ShouldBeSkipped { get; set; }

		void Run();

		void Pause();

		void Resume();

		void Cancel();

		void Delete();

		void Reset(bool resetStatus = false);

		void RefreshDurationAndSpeed();
	}
}
