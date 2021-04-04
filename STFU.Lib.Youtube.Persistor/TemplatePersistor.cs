using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
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
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(TemplatePersistor));
		private object lockobject = new object();

		public string Path { get; private set; } = null;
		public ITemplateContainer Container { get; private set; } = null;
		public ITemplateContainer Saved { get; private set; } = null;

		public TemplatePersistor(ITemplateContainer container, string path)
		{
			LOGGER.Debug($"Creating template persistor for path '{path}'");

			Path = path;
			Container = container;
		}

		public bool Load()
		{
			LOGGER.Info($"Loading templates from path '{Path}'");
			Container.UnregisterAllTemplates();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();
						LOGGER.Debug($"Json from loaded path: '{json}'");

						var templates = JsonConvert.DeserializeObject<Template[]>(json);
						LOGGER.Info($"Loaded {templates.Length} templates");

						foreach (var loaded in templates)
						{
							LOGGER.Info($"Adding template '{loaded.Name}'");
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
				LOGGER.Error($"Could not load templates, exception occured!", e);
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
				LOGGER.Warn($"There is no standard template, creating one");

				var language = new YoutubeLanguage() {
					Hl = "de",
					Id = "de",
					Name = "Deutsch"
				};

				var category = new YoutubeCategory(20, "Gaming");

				var standardTemplate = new Template(0, "Standard", language, category, new List<IPublishTime>(), new List<IPlannedVideo>());
				Container.RegisterTemplate(standardTemplate);

				LOGGER.Info($"Standard template was created successfully");
			}
		}

		public bool Save()
		{
			lock (lockobject)
			{
				ITemplate[] templates = Container.RegisteredTemplates.ToArray();
				LOGGER.Info($"Saving {templates.Length} templates to file '{Path}'");

				var json = JsonConvert.SerializeObject(templates);

				var worked = true;
				try
				{
					using (StreamWriter writer = new StreamWriter(Path, false))
					{
						writer.Write(json);
					}
					LOGGER.Info($"Templates saved");

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
					LOGGER.Error($"Could not save templates, exception occured!", e);
					worked = false;
				}

				return worked;
			}
		}

		private void RecreateSaved()
		{
			LOGGER.Debug($"Recreating cache of saved tempaltes");
			Saved = new TemplateContainer();
			foreach (var template in Container.RegisteredTemplates)
			{
				LOGGER.Debug($"Recreating cache for template '{template.Name}'");
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
					Title = template.Title,
					CSharpCleanUpScript = template.CSharpCleanUpScript,
					CSharpPreparationScript = template.CSharpPreparationScript,
					EnableExpertMode = template.EnableExpertMode,
					MailTo = template.MailTo,
					NewVideoDesktopNotification = template.NewVideoDesktopNotification,
					NewVideoMailNotification = template.NewVideoMailNotification,
					NextUploadSuggestion = template.NextUploadSuggestion,
					ReferencedAssembliesText = template.ReferencedAssembliesText,
					UploadFailedDesktopNotification = template.UploadFailedDesktopNotification,
					UploadFailedMailNotification = template.UploadFailedMailNotification,
					UploadFinishedDesktopNotification = template.UploadFinishedDesktopNotification,
					UploadFinishedMailNotification = template.UploadFinishedMailNotification,
					UploadStartedDesktopNotification = template.UploadStartedDesktopNotification,
					UploadStartedMailNotification = template.UploadStartedMailNotification
				};

				Saved.RegisterTemplate(newTemplate);
			}
		}
	}
}
