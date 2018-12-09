using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Persistor
{
	public class TemplatePersistor
	{
		public string Path { get; private set; } = null;
		public ITemplateContainer Container { get; private set; } = null;
		public ITemplateContainer Saved { get; private set; } = null;

		public TemplatePersistor(ITemplateContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.UnregisterAllTemplates();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var templates = JsonConvert.DeserializeObject<Template[]>(json);

						foreach (var loaded in templates)
						{
							Container.RegisterTemplate(loaded);
						}
					}
				}
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

			EnsureStandardTemplateExists();
			RecreateSaved();

			return worked;
		}

		private void EnsureStandardTemplateExists()
		{
			if (!Container.RegisteredTemplates.Any(t => t.Id == 0))
			{
				var language = new YoutubeLanguage() {
					Hl = "de",
					Id = "de",
					Name = "Deutsch"
				};

				var category = new YoutubeCategory(20, "Gaming");

				var standardTemplate = new Template(0, "Standard", language, category, new List<IPublishTime>(), new List<IPlannedVideo>());
				Container.RegisterTemplate(standardTemplate);
			}
		}

		public bool Save()
		{
			ITemplate[] templates = Container.RegisteredTemplates.ToArray();

			var json = JsonConvert.SerializeObject(templates);

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
			Saved = new TemplateContainer();
			foreach (var template in Container.RegisteredTemplates)
			{
				var newTemplate = new Template (template.Id, template.Name, template.DefaultLanguage, template.Category, template.PublishTimes, template.PlannedVideos)
				{
					AutoLevels = template.AutoLevels,
					Description = template.Description,
					IsEmbeddable = template.IsEmbeddable,
					License = template.License,
					NotifySubscribers = template.NotifySubscribers,
					PlannedVideos = template.PlannedVideos,
					Privacy = template.Privacy,
					PublicStatsViewable = template.PublicStatsViewable,
					PublishTimes = template.PublishTimes,
					ShouldPublishAt = template.ShouldPublishAt,
					Stabilize = template.Stabilize,
					Tags = template.Tags,
					ThumbnailPath = template.ThumbnailPath,
					Title = template.Title
				};

				Saved.RegisterTemplate(newTemplate);
			}
		}
	}
}
