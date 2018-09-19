using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class CategoryPersistor
	{
		private string path = null;
		public string Path { get => path; private set => path = value; }

		IYoutubeCategoryContainer container = null;
		public IYoutubeCategoryContainer Container { get => container; private set => container = value; }

		IYoutubeCategoryContainer saved = null;
		public IYoutubeCategoryContainer Saved { get => saved; private set => saved = value; }

		public CategoryPersistor(IYoutubeCategoryContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			container.UnregisterAllCategories();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var categories = JsonConvert.DeserializeObject<YoutubeCategory[]>(json);

						foreach (var loaded in categories)
						{
							container.RegisterCategory(loaded);
						}
					}
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			ICategory[] categories = container.RegisteredCategories.ToArray();

			var json = JsonConvert.SerializeObject(categories);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			Saved = new YoutubeCategoryContainer();
			foreach (var category in Container.RegisteredCategories)
			{
				var newCategory = new YoutubeCategory(category.Id, category.Title);

				Saved.RegisterCategory(newCategory);
			}
		}
	}
}
