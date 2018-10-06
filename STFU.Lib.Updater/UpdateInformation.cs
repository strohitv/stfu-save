namespace STFU.Lib.Updater
{
	public class UpdateInformation
	{
		public bool UpdateAvailable { get; }

		public string Version { get; }

		public string FileId { get; }

		public UpdateInformation(bool available, string version, string fileId)
		{
			UpdateAvailable = available;
			Version = version;
			FileId = fileId;
		}
	}
}
