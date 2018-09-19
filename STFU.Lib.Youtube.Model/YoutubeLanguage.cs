using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Model
{
	public class YoutubeLanguage : ILanguage
	{
		public string Id { get; set; }
		public string Hl { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Hl} - {Name}";
		}

		public static YoutubeLanguage Default => new YoutubeLanguage() { Hl = "de", Id = "de", Name = "Deutsch" };

		public static YoutubeLanguage Parse(JToken property)
		{
			YoutubeLanguage lang = new YoutubeLanguage();

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