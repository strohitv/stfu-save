using Newtonsoft.Json.Linq;

namespace STFU.UploadLib.Videos
{
	public class Language
	{
		public string Id { get; set; }
		public string Hl { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Hl} - {Name}";
		}

		public static Language Default => new Language() { Hl = "de", Id = "de", Name = "Deutsch" };

		public static Language Parse(JToken property)
		{
			Language lang = new Language();

			foreach (var child in property.Children<JProperty>())
			{
				switch (child.Name.ToLower())
				{
					case "id":
						lang.Id = (string)child.Value;
						break;
					case "hl":
						lang.Hl = (string)child.Value;
						break;
					case "name":
						lang.Name = (string)child.Value;
						break;
				}
			}

			return lang;
		}
	}
}