namespace STFU.Lib.Youtube.Persistor.Model
{
	public class AutoUploaderSettings
	{
		public bool ShowReleaseNotes { get; set; } = true;

		public void Reset()
		{
			ShowReleaseNotes = true;
		}
	}
}
