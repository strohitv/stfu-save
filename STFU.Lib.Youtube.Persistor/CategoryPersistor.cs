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
		public string Path { get; private set; } = null;
		public IYoutubeCategoryContainer Container { get; private set; } = null;
		public IYoutubeCategoryContainer Saved { get; private set; } = null;

		public CategoryPersistor(IYoutubeCategoryContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.UnregisterAllCategories();

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
							Container.RegisterCategory(loaded);
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
			ICategory[] categories = Container.RegisteredCategories.ToArray();

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
