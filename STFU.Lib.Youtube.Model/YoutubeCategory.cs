using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeCategory : ICategory
	{
		public int Id { get; private set; }
		public string Title { get; private set; }

		private YoutubeCategory() { }

		public YoutubeCategory(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public override string ToString()
		{
			return $"{Id} - {Title}";
		}

		public static YoutubeCategory Default => new YoutubeCategory(20, "Gaming");

		public static YoutubeCategory Parse(JToken property)
		{
			YoutubeCategory cat = new YoutubeCategory();

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
