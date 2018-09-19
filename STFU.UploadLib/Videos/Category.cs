using Newtonsoft.Json.Linq;

namespace STFU.UploadLib.Videos
{
	public class Category
	{
		public int Id { get; private set; }
		public string Title { get; private set; }

		private Category() { }

		public Category(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public override string ToString()
		{
			return $"{Id} - {Title}";
		}

		public static Category Default => new Category(20, "Gaming");

		public static Category Parse(JToken property)
		{
			Category cat = new Category();

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
