using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Upload
{
	public class YoutubeJob
	{
		public IYoutubeVideo Video { get; }

		public IYoutubeAccount Account { get; }

		// TODO: Step-Gedöns muss vermutlich vom UploadStatus weg, da der JobUploader eig. die Stepverwaltung ist (?)
		// Frage: Wie benachrichtige ich die GUI dann über den aktuellen Schritt? Enum?
		public UploadStatus UploadStatus { get; } = new UploadStatus();

		private JobUploader JobUploader { get; }

		public YoutubeJob(IYoutubeVideo video, IYoutubeAccount account)
		{
			Video = video;
			Account = account;

			JobUploader = new JobUploader(this);
		}

		public void Run()
		{
			JobUploader.Run();
		}

		public void Pause()
		{
			UploadStatus.CurrentStep.Cancel();
		}

		public void Resume()
		{
			UploadStatus.CurrentStep.RunAsync();
		}

		public void Cancel()
		{
			JobUploader.Reset();
		}
	}
}
