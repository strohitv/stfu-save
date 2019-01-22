using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Helpers;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class Template : ITemplate
	{
		private IList<IPublishTime> publishTimes;

		public int Id { get; internal set; } = 0;

		private string name = string.Empty;
		public string Name
		{
			get
			{
				if (name == null)
				{
					name = string.Empty;
				}

				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public ICategory Category { get; set; } = new YoutubeCategory(20, "Gaming");

		public ILanguage DefaultLanguage { get; set; } = new YoutubeLanguage()
		{
			Hl = "de",
			Id = "de",
			Name = "Deutsch"
		};

		public string Tags { get; set; } = string.Empty;

		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy { get; set; } = PrivacyStatus.Private;

		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; } = License.Youtube;

		public bool IsEmbeddable { get; set; } = true;

		public bool PublicStatsViewable { get; set; } = false;

		public bool NotifySubscribers { get; set; } = true;

		public bool AutoLevels { get; set; } = false;

		public bool Stabilize { get; set; } = false;

		public bool ShouldPublishAt { get; set; } = false;

		public string ThumbnailPath { get; set; } = string.Empty;

		public string CSharpPreparationScript { get; set; } = "// Dieses Skript wird vor allen Skripten in Beschreibung, Titel usw. ausgeführt und kann daher zur Vorbereitung genutzt werden (z. B. zum Erstellen von Variablen)." + Environment.NewLine
			+ "// Dieses Feld soll ausschließlich C#-Code enthalten. Bitte keine <<<, <<<C und >>> schreiben." + Environment.NewLine + Environment.NewLine
			+ "using System;";

		public string CSharpCleanUpScript { get; set; } = "// Dieses Skript wird nach allen Skripten in Beschreibung, Titel usw. ausgeführt und kann daher zum Aufräumen verwendet werden (z. B. um Disposes durchzuführen)." + Environment.NewLine
			+ "// Dieses Feld soll ausschließlich C#-Code enthalten. Bitte keine <<<, <<<C und >>> schreiben.";

		public IList<IPublishTime> PublishTimes
		{
			get
			{
				if (publishTimes == null)
				{
					publishTimes = new List<IPublishTime>();
				}

				return publishTimes;
			}
			set
			{
				publishTimes = value;
			}
		}

		public IList<IPlannedVideo> PlannedVideos { get; set; } = new List<IPlannedVideo>();

		private DateTime? nextUploadSuggestion = null;

		public DateTime NextUploadSuggestion
		{
			get
			{
				if (nextUploadSuggestion == null || nextUploadSuggestion.Value < DateTime.Now)
				{
					nextUploadSuggestion = DateTime.Now.Date.AddHours(DateTime.Now.TimeOfDay.Hours + 1);
				}

				return nextUploadSuggestion.Value;
			}
			set
			{
				if (value != null)
				{
					nextUploadSuggestion = value;
				}
			}
		}

		public Template(int id, string name, ILanguage defaultlanguage, ICategory category, IList<IPublishTime> publishTimes, IList<IPlannedVideo> plannedVideos)
			: this(id, name, (YoutubeLanguage)defaultlanguage, (YoutubeCategory)category, publishTimes.Select(pt => (PublishTime)pt).ToList(), plannedVideos.Select(pv => (PlannedVideo)pv).ToList())
		{ }

		[JsonConstructor]
		public Template(int id, string name, YoutubeLanguage defaultlanguage, YoutubeCategory category, IList<PublishTime> publishTimes, IList<PlannedVideo> plannedVideos)
		{
			Id = id;
			Name = name;
			Privacy = PrivacyStatus.Private;
			Title = string.Empty;
			Description = string.Empty;
			Tags = string.Empty;
			NotifySubscribers = true;
			License = License.Youtube;
			DefaultLanguage = defaultlanguage;
			Category = category;
			PublishTimes = publishTimes.Select(pt => (IPublishTime)pt).ToList();
			PlannedVideos = plannedVideos.Select(pv => (IPlannedVideo)pv).ToList();
		}

		public Template(int id, string name, YoutubeLanguage defaultlanguage, YoutubeCategory category, IList<PublishTime> publishTimes)
		{
			Id = id;
			Name = name;
			Privacy = PrivacyStatus.Private;
			Title = string.Empty;
			Description = string.Empty;
			Tags = string.Empty;
			NotifySubscribers = true;
			License = License.Youtube;
			DefaultLanguage = defaultlanguage;
			Category = category;
			PublishTimes = publishTimes.Select(pt => (IPublishTime)pt).ToList();
			PlannedVideos = new List<IPlannedVideo>();
		}

		public Template()
		{ }

		public static explicit operator Template(JToken v)
		{
			return JsonConvert.DeserializeObject<Template>(v.ToString());
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}";
		}

		public static ITemplate Duplicate(ITemplate template)
		{
			return new Template(template.Id, template.Name, template.DefaultLanguage, template.Category, template.PublishTimes, template.PlannedVideos)
			{
				AutoLevels = template.AutoLevels,
				Description = template.Description,
				IsEmbeddable = template.IsEmbeddable,
				License = template.License,
				NotifySubscribers = template.NotifySubscribers,
				Privacy = template.Privacy,
				PublicStatsViewable = template.PublicStatsViewable,
				PlannedVideos = new List<IPlannedVideo>(template.PlannedVideos),
				PublishTimes = new List<IPublishTime>(template.PublishTimes),
				ShouldPublishAt = template.ShouldPublishAt,
				Stabilize = template.Stabilize,
				Tags = template.Tags,
				ThumbnailPath = template.ThumbnailPath,
				Title = template.Title,

				CSharpPreparationScript = template.CSharpPreparationScript,
				CSharpCleanUpScript = template.CSharpCleanUpScript
			};
		}
	}
}
