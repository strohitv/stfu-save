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

		public bool EnableExpertMode { get; set; } = false;

		public string CSharpPreparationScript { get; set; } = @"/// <summary>
/// Der Code in diesem Textfeld kann geändert werden.
/// 
/// Der folgende Code wird jeweils vor der Erstellung eines Uploads vor der Auswertung des Codes 
/// in Titel, Beschreibung, Tags und Thumbnail-Pfad ausgeführt.
/// Beispielsweise könnten hier eigene Felder für die Benutzung in den Textfeldern initialisiert werden.
/// </summary>

";

		public string CSharpCleanUpScript { get; set; } = @"/// <summary>
/// Der Code in diesem Textfeld kann geändert werden.
/// 
/// Der folgende Code wird jeweils nach dem erfolgreichen Ende eines Uploads ausgeführt.
/// Beispielsweise könnte die Datei hier in ein anderes Verzeichnis verschoben werden,
/// oder eine Mail versandt werden, dass der Upload fertig ist.
/// (Den Code dafür müsst ihr selbst schreiben. ;)
/// </summary>

";

		public string ReferencedAssembliesText { get; set; } = @"/// <summary>
/// Der Text in diesem Textfeld kann geändert werden.
/// 
/// In diesem Textfeld kann pro Zeile eine Assembly angegeben werden, die vor dem Ausführen von C#-Code referenziert werden soll.
/// Das kann ein Pfad zur DLL sein (relativ oder absolut) oder ein Assemblyname (qualifiziert oder unqualifiziert).
/// Assemblynamen werden mit der Standard-Vorgehensweise bei .NET gesucht.
/// Ausgangsverzeichnis für relative Pfade ist das Verzeichnis, in dem die AutoUploader.exe liegt.
/// Ich empfehle, eigene DLLs in ein separates Verzeichnis (z. B. mylibs) zu legen.
/// 
/// Leerzeilen und Zeilen, die mit // beginnen, sind Kommentare und werden ignoriert. Mehrzeilige Kommentare werden nicht unterstützt.
/// 
/// Beispiele für mögliche Referenzen:
/// via Assemblyname:
/// System.Windows.Forms
/// System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
/// 
/// via Pfad:
/// C:\Pfad\...\MeineDll.dll
/// .\mylib\MeineDll.dll
/// lib\NewtonSoft.Json.dll
/// </summary>

";

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

		public bool AddToPlaylist { get; set; } = false;

		public string PlaylistId { get; set; } = null;

		public IList<IPlannedVideo> PlannedVideos { get; set; } = new List<IPlannedVideo>();

		private DateTime? nextUploadSuggestion = null;

		public DateTime NextUploadSuggestion
		{
			get
			{
				if (nextUploadSuggestion == null)
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

		public string MailTo { get; set; } = string.Empty;

		public bool NewVideoDesktopNotification { get; set; } = false;

		public bool NewVideoMailNotification { get; set; } = false;

		public bool UploadStartedDesktopNotification { get; set; } = false;

		public bool UploadStartedMailNotification { get; set; } = false;

		public bool UploadFinishedDesktopNotification { get; set; } = true;

		public bool UploadFinishedMailNotification { get; set; } = false;

		public bool UploadFailedDesktopNotification { get; set; } = true;

		public bool UploadFailedMailNotification { get; set; } = false;

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

			if (publishTimes != null)
			{
				PublishTimes = publishTimes.Select(pt => (IPublishTime)pt).ToList();
			}

			if (plannedVideos != null)
			{
				PlannedVideos = plannedVideos.Select(pv => (IPlannedVideo)pv).ToList();
			}
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

				EnableExpertMode = template.EnableExpertMode,
				CSharpPreparationScript = template.CSharpPreparationScript,
				CSharpCleanUpScript = template.CSharpCleanUpScript,
				ReferencedAssembliesText = template.ReferencedAssembliesText,

				NextUploadSuggestion = template.NextUploadSuggestion,

				MailTo = template.MailTo,

				NewVideoDesktopNotification = template.NewVideoDesktopNotification,
				NewVideoMailNotification = template.NewVideoMailNotification,
				UploadStartedDesktopNotification = template.UploadStartedDesktopNotification,
				UploadStartedMailNotification = template.UploadStartedMailNotification,
				UploadFinishedDesktopNotification = template.UploadFinishedDesktopNotification,
				UploadFinishedMailNotification = template.UploadFinishedMailNotification,
				UploadFailedDesktopNotification = template.UploadFailedDesktopNotification,
				UploadFailedMailNotification = template.UploadFailedMailNotification,

				AddToPlaylist = template.AddToPlaylist,
				PlaylistId = template.PlaylistId
			};
		}
	}
}
