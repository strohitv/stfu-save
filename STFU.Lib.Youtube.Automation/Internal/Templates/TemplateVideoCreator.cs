using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Templates
{
	public class TemplateVideoCreator
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(TemplateVideoCreator));

		public IList<PublishTimeCalculator> PublishInfos { get; set; }

		public IPlaylistServiceConnectionContainer PlaylistServiceConnectionContainer { get; set; }

		public TemplateVideoCreator(IList<PublishTimeCalculator> publishInfo, IPlaylistServiceConnectionContainer container)
		{
			PublishInfos = publishInfo;
			PlaylistServiceConnectionContainer = container;
		}

		public VideoInformation CreateVideo(string path, bool saveNextUploadSuggestion = true)
		{
			LOGGER.Info($"Creating video for path: '{path}' and save next upload suggestion: {saveNextUploadSuggestion}");

			// Template suchen anhand des Pfades
			var publishCalculator = PublishInfos.Where(pi => Directory.Exists(pi.PathInfo.Fullname)).OrderBy(x => x.GetDifference(path)).FirstOrDefault(x => x.GetDifference(path) != null);

			if (publishCalculator == null)
			{
				LOGGER.Warn($"Could not find fitting publish calculator - using a new one with empty fields");

				publishCalculator = new PublishTimeCalculator(new Paths.Path(), new Template());
			}

			return CreateVideo(path, publishCalculator, saveNextUploadSuggestion);
		}

		public VideoInformation CreateVideo(string path, PublishTimeCalculator publishCalculator, bool saveNextUploadSuggestion = true)
		{
			IYoutubeVideo video = new YoutubeVideo(path);
			var template = publishCalculator.Template;

			LOGGER.Info($"Creating video for path: '{path}' and template with id: {template.Id} and name: '{template.Name}'");

			//TODO: Video muss die Mailversandsinformationen gespeicher bekommen, am besten via einer eigenen Klasse!
			var notificationSettings = new NotificationSettings()
			{
				MailReceiver = template.MailTo,
				NotifyOnVideoFoundDesktop = template.NewVideoDesktopNotification,
				NotifyOnVideoFoundMail = template.NewVideoMailNotification,
				NotifyOnVideoUploadStartedDesktop = template.UploadStartedDesktopNotification,
				NotifyOnVideoUploadStartedMail = template.UploadStartedMailNotification,
				NotifyOnVideoUploadFinishedDesktop = template.UploadFinishedDesktopNotification,
				NotifyOnVideoUploadFinishedMail = template.UploadFinishedMailNotification,
				NotifyOnVideoUploadFailedDesktop = template.UploadFailedDesktopNotification,
				NotifyOnVideoUploadFailedMail = template.UploadFailedMailNotification
			};

			ExpressionEvaluator evaluator = new ExpressionEvaluator(path, template.Name, template.PlannedVideos, template.CSharpPreparationScript, template.CSharpCleanUpScript, template.ReferencedAssembliesText);

			// Werte füllen
			video.Title = CutOff(evaluator.Evaluate(template.Title).Replace("<", string.Empty).Replace(">", string.Empty), YoutubeVideo.MaxTitleLength);
			video.Description = CutOff(evaluator.Evaluate(template.Description).Replace("<", string.Empty).Replace(">", string.Empty), YoutubeVideo.MaxDescriptionLength);
			video.Category = template.Category;
			video.DefaultLanguage = template.DefaultLanguage;

			video.Privacy = publishCalculator.UploadPrivate ? PrivacyStatus.Private : template.Privacy;
			video.License = template.License;
			video.IsEmbeddable = template.IsEmbeddable;
			video.PublicStatsViewable = template.PublicStatsViewable;

			video.NotifySubscribers = template.NotifySubscribers;
			video.AutoLevels = template.AutoLevels;
			video.Stabilize = template.Stabilize;

			video.ThumbnailPath = evaluator.Evaluate(template.ThumbnailPath);

			// Evtl. Nächsten Veröffentlichungszeitpunkt berechnen
			// Dafür benötigt: Datum letztes Video und Position in PublishTimes (!)
			if (!publishCalculator.UploadPrivate
				&& template.Privacy == PrivacyStatus.Private
				&& template.ShouldPublishAt
				&& template.PublishTimes.Count > 0)
			{
				video.PublishAt = publishCalculator.GetNextPublishTime();

				if (saveNextUploadSuggestion)
				{
					template.NextUploadSuggestion = publishCalculator.GetNextPublishTime(true);

					LOGGER.Info($"Changed next upload suggestion for template with id: {template.Id} and name: '{template.Name}' to: {template.NextUploadSuggestion}");
				}
			}

			foreach (var tag in CutOff(evaluator.Evaluate(template.Tags).Replace("<", string.Empty).Replace(">", string.Empty), YoutubeVideo.MaxTagsLength).Split(','))
			{
				video.Tags.Add(tag);
			}

			video.AddToPlaylist = template.AddToPlaylist;
			video.PlaylistId = template.PlaylistId;

			if (template.SendToPlaylistService)
			{
				video.PlaylistServiceSettings = new PlaylistServiceSettings()
				{
					ShouldSend = true,
					AccountId = template.AccountId,
					Host = PlaylistServiceConnectionContainer?.Connection?.Host ?? null,
					Port = PlaylistServiceConnectionContainer?.Connection?.Port ?? null,
					Username = PlaylistServiceConnectionContainer?.Connection?.Username ?? null,
					Password = PlaylistServiceConnectionContainer?.Connection?.Password ?? null,
					PlaylistId = template.PlaylistIdForService,
					PlaylistTitle = template.PlaylistTitleForService
				};
			}
			else
			{
				video.PlaylistServiceSettings = new PlaylistServiceSettings();
			}

			LOGGER.Info($"Created video with settings: '{JsonConvert.SerializeObject(video)}'");

			return new VideoInformation(video, evaluator, notificationSettings);
		}

		public IPath FindNearestPath(string path)
		{
			var publishCalculator = PublishInfos.Where(pi => Directory.Exists(pi.PathInfo.Fullname)).OrderBy(x => x.GetDifference(path)).FirstOrDefault(x => x.GetDifference(path) != null);

			LOGGER.Info($"Found nearest directory for path: '{path}': '{publishCalculator?.PathInfo.Fullname}'");

			return publishCalculator?.PathInfo;
		}

		public void SaveNextUploadSuggestions()
		{
			LOGGER.Info($"Saving all next upload suggestions");

			foreach (var publishCalculator in PublishInfos)
			{
				var template = publishCalculator.Template;
				if (!publishCalculator.UploadPrivate
					&& template.Privacy == PrivacyStatus.Private
					&& template.ShouldPublishAt
					&& template.PublishTimes.Count > 0)
				{
					template.NextUploadSuggestion = publishCalculator.GetNextPublishTime(true);

					LOGGER.Info($"Changed next upload suggestion for template with id: {template.Id} and name: '{template.Name}' to: {template.NextUploadSuggestion}");
				}
			}

			LOGGER.Info($"Saved all next upload suggestions");
		}

		private string CutOff(string value, int maxlength)
		{
			if (value.Length > maxlength)
			{
				value = value.Substring(0, maxlength);
			}

			return value;
		}
	}
}
