namespace STFU.UploadLib.Videos
{
	public class Category
	{
		public int Id { get; private set; }
		public string Title { get; private set; }

		public Category(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public override string ToString()
		{
			return Title;
		}
	}
}
