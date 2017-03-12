using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace STFU.UploadLib.Automation
{
	public class PathSettings : IEnumerable<PathInformation>
	{
		private List<PathInformation> paths = new List<PathInformation>();

		public int Count { get { return paths.Count; } }

		public bool ContainsPath(string path)
		{
			return paths.SingleOrDefault(p => p.Path.ToLower() == path.ToLower()) != null;
		}

		internal PathSettings()
		{ }

		internal PathSettings(params PathInformation[] information)
		{
			foreach (var item in information)
			{
				Add(item);
			}
		}

		public void Add(PathInformation item)
		{
			var settings = paths.SingleOrDefault(p => p.Path.ToLower() == item.Path.ToLower());
			if (settings != null)
			{
				throw new ArgumentException("Der angegebene Pfad ist bereits vorhanden");
			}
			else
			{
				paths.Add(item);
			}
		}

		public void Add(string path, string filter, bool searchRecursively)
		{
			var newSettings = new PathInformation()
			{
				Path = path,
				Filter = filter,
				SearchRecursively = searchRecursively
			};

			var settings = paths.SingleOrDefault(p => p.Path.ToLower() == path.ToLower());
			if (settings != null)
			{
				throw new ArgumentException("Der angegebene Pfad ist bereits vorhanden");
			}
			else
			{
				paths.Add(newSettings);
			}
		}

		public void Remove(string path)
		{
			if (ContainsPath(path))
			{
				var settings = this[path];
				paths.Remove(settings);
			}
			else
			{
				throw new ArgumentException("Der angegebene Pfad ist nicht vorhanden");
			}
		}

		public void RemoveAt(int index)
		{
			if (Count > index && index >= 0)
			{
				paths.RemoveAt(index);
			}
			else
			{
				throw new ArgumentException("Der Index war außerhalb des gültigen Bereichs");
			}
		}

		public void Clear()
		{
			paths.Clear();
		}

		public IEnumerator<PathInformation> GetEnumerator()
		{
			return ((IEnumerable<PathInformation>)paths).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<PathInformation>)paths).GetEnumerator();
		}

		public PathInformation this[string path]
		{
			get { return paths.SingleOrDefault(p => p.Path.ToLower() == path.ToLower()); }
			set
			{
				var settings = paths.SingleOrDefault(p => p.Path.ToLower() == path.ToLower());
				if (settings == null)
				{
					throw new ArgumentException("Der angegebene Pfad ist nicht vorhanden");
				}
				else
				{
					settings.Path = value.Path;
					settings.Filter = value.Filter;
					settings.SearchRecursively = value.SearchRecursively;
				}
			}
		}

		public PathInformation this[int index]
		{
			get
			{
				if (paths.Count > index && index >= 0)
				{
					return paths[index];
				}
				else
				{
					throw new ArgumentException("Der Index war außerhalb des gültigen Bereichs");
				}
			}
			set
			{
				var settings = this[index];

				settings.Path = value.Path;
				settings.Filter = value.Filter;
				settings.SearchRecursively = value.SearchRecursively;
			}
		}

		public static PathSettings Parse(string json)
		{
			var jArray = JArray.Parse(json);

			var result = new PathSettings();

			var node = jArray.First;

			if (node != null)
			{
				do
				{
					PathInformation info = new PathInformation();
					foreach (var item in node.Children<JProperty>())
					{
						switch (item.Name.ToLower())
						{
							case "path":
								info.Path = item.Value.Value<string>();
								break;
							case "filter":
								info.Filter = (string)item.Value;
								break;
							case "searchrecursively":
								info.SearchRecursively = (bool)item.Value;
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

		public void InsertAt(int index, PathInformation currentItem)
		{
			paths.Insert(index, currentItem);
		}
	}
}
