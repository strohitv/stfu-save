using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace STFU.UploadLib.Programming
{
	public class Variable
	{
		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "Content")]
		public string Content { get; set; }

		private Variable() { }

		public Variable(string name, string content)
		{
			Name = name;
			Content = content;
		}

		public override string ToString()
		{
			return $"{Name}: {Content}";
		}

		internal static Variable Parse(JToken value)
		{
			var variable = new Variable();

			foreach (var child in value.Children<JProperty>())
			{
				switch (child.Name.ToLower())
				{
					case "name":
						variable.Name = (string)child.Value;
						break;
					case "content":
						variable.Content = (string)child.Value;
						break;
				}
			}

			return variable;
		}

		public static IReadOnlyList<string> ReservedNames => new List<string>() {
			"file",
			"filename",
			"fileext",
			"filenameext",
			"folder",
			"foldername",
			"template"
		}.AsReadOnly();
	}
}
