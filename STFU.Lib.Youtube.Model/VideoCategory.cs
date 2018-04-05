using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class VideoCategory : ICategory
	{
		public int Id { get; private set; }
		public string Title { get; private set; }

		private VideoCategory() { }

		public VideoCategory(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public override string ToString()
		{
			return $"{Id} - {Title}";
		}

		public static VideoCategory Default => new VideoCategory(20, "Gaming");

		public static VideoCategory Parse(JToken property)
		{
			VideoCategory cat = new VideoCategory();

			foreach (var child in property.Children<JProperty>())
			{
				switch (child.Name.ToLower())
				{
					case "id":
						cat.Id = (int)child.Value;
						break;
					case "title":
						cat.Title = (string)child.Value;
						break;
				}
			}

			return cat;
		}
	}
}
