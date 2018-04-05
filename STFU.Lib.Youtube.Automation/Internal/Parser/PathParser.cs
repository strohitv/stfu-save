using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Automation.Templates;

namespace STFU.Lib.Youtube.Automation.Internal.Parser
{
	internal class PathParser
	{
		public static IList<Path> Parse(string json, IReadOnlyList<Template> templates)
		{
			var jArray = JArray.Parse(json);

			IList<Path> result = new List<Path>();

			var node = jArray.First;

			if (node != null)
			{
				do
				{
					Path info = new Path();
					foreach (var item in node.Children<JProperty>())
					{
						switch (item.Name.ToLower())
						{
							case "path":
								info.Fullname = item.Value.Value<string>();
								break;
							case "filter":
								info.Filter = (string)item.Value;
								break;
							case "searchrecursively":
								info.SearchRecursively = (bool)item.Value;
								break;
							case "searchhidden":
								info.SearchHidden = (bool)item.Value;
								break;
							case "selectedtemplateid":
								info.SelectedTemplateId = (int)item.Value;
								break;
							case "inactive":
								info.Inactive = (bool)item.Value;
								break;
							default:
								break;
						}
					}
					result.Add(info);
				} while ((node = node.Next) != null);
			}

			return result;
		}
	}
}
