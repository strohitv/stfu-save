namespace STFU.UploadLib.Videos
{
	public class Language
	{
		public string Id { get; set; }
		public string Hl { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}