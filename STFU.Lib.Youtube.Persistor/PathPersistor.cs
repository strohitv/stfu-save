using System;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class PathPersistor
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(PathPersistor));

		public string Path { get; private set; } = null;
		public IPathContainer Container { get; private set; } = null;
		public IPathContainer Saved { get; private set; } = null;

		public PathPersistor(IPathContainer container, string path)
		{
			LOGGER.Debug($"Creating path persistor for path '{path}'");

			Path = path;
			Container = container;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading paths from path '{Path}'");
			Container.UnregisterAllPaths();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						var paths = JsonConvert.DeserializeObject<Automation.Paths.Path[]>(json);
						LOGGER.Info($"Loaded {paths.Length} paths");

						foreach (var loaded in paths)
						{
							LOGGER.Info($"Adding path '{loaded.Fullname}'");
							if (!Directory.Exists(loaded.Fullname))
							{
								LOGGER.Warn($"Loaded path '{loaded.Fullname}' does not exist - it will be marked as inactive");
								loaded.Inactive = true;
							}

							Container.RegisterPath(loaded);
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
				LOGGER.Error($"Could not load paths, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			IPath[] paths = Container.RegisteredPaths.ToArray();
			LOGGER.Info($"Saving {paths.Length} paths to file '{Path}'");

			var json = JsonConvert.SerializeObject(paths);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}
				LOGGER.Info($"Paths saved");

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
				LOGGER.Error($"Could not save paths, exception occured!", e);
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved paths");
			Saved = new PathContainer();
			foreach (var path in Container.RegisteredPaths)
			{
				LOGGER.Debug($"Recreating cache for path '{path.Fullname}'");
				var newPath = new Automation.Paths.Path()
				{
					Filter = path.Filter,
					Fullname = path.Fullname,
					Inactive = path.Inactive,
					SearchHidden = path.SearchHidden,
					SearchRecursively = path.SearchRecursively,
					SelectedTemplateId = path.SelectedTemplateId,
					MoveAfterUpload = path.MoveAfterUpload,
					MoveDirectoryPath = path.MoveDirectoryPath,
					SearchOrder = path.SearchOrder
				};

				Saved.RegisterPath(newPath);
			}
		}
	}
}
