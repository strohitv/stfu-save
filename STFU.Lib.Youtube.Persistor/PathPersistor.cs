using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PathPersistor
	{
		private string path = null;
		public string Path { get => path; private set => path = value; }

		IPathContainer container = null;
		public IPathContainer Container { get => container; private set => container = value; }

		IPathContainer saved = null;
		public IPathContainer Saved { get => saved; private set => saved = value; }

		public PathPersistor(IPathContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			container.UnregisterAllPaths();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var paths = JsonConvert.DeserializeObject<Automation.Paths.Path[]>(json);

						foreach (var loaded in paths)
						{
							container.RegisterPath(loaded);
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
			IPath[] paths = container.RegisteredPaths.ToArray();

			var json = JsonConvert.SerializeObject(paths);

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
			Saved = new PathContainer();
			foreach (var path in Container.RegisteredPaths)
			{
				var newPath = new Automation.Paths.Path()
				{
					Filter = path.Filter,
					Fullname = path.Fullname,
					Inactive = path.Inactive,
					SearchHidden = path.SearchHidden,
					SearchRecursively = path.SearchRecursively,
					SelectedTemplateId = path.SelectedTemplateId
				};

				Saved.RegisterPath(newPath);
			}
		}
	}
}
