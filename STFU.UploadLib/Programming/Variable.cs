using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
			: this(name, content, false)
		{
		}

		internal Variable(string name, string content, bool skipNameCheck)
		{
			if (!skipNameCheck)
			{
				name = createAllowedName(name);
			}

			Name = name;
			Content = content;
		}

		private string createAllowedName(string name)
		{
			return string.Join(string.Empty, name.Where(n => char.IsLetterOrDigit(n)));
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

		public static IReadOnlyDictionary<string, Func<string, string, string>> GlobalVariables =>
			new ReadOnlyDictionary<string, Func<string, string, string>>(new Dictionary<string, Func<string, string, string>>
		{
			{ "file", (path, template) => path },
			{ "filename", (path, template) => Path.GetFileNameWithoutExtension(path) },
			{ "fileext", (path, template) => new FileInfo(path).Extension },
			{ "filenameext", (path, template) => new FileInfo(path).Name },
			{ "folder", (path, template) => new FileInfo(path).DirectoryName },
			{ "foldername", (path, template) => new FileInfo(path).Directory.Name },
			{ "template", (path, template) => template }
		});
	}
}
