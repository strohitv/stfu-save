using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		public IList<PublishTimeCalculator> PublishInfos { get; set; }

		public TemplateVideoCreator(IList<PublishTimeCalculator> publishInfo)
		{
			PublishInfos = publishInfo;
		}

		public VideoInformation CreateVideo(string path, bool saveNextUploadSuggestion = true)
		{

			// Template suchen anhand des Pfades
			var publishCalculator = PublishInfos.Where(pi => Directory.Exists(pi.PathInfo.Fullname)).OrderBy(x => x.GetDifference(path)).FirstOrDefault(x => x.GetDifference(path) != null);

			if (publishCalculator == null)
			{
				publishCalculator = new PublishTimeCalculator(new Paths.Path(), new Template());
			}

			return CreateVideo(path, publishCalculator, saveNextUploadSuggestion);
		}

		public VideoInformation CreateVideo(string path, PublishTimeCalculator publishCalculator, bool saveNextUploadSuggestion = true)
		{
			IYoutubeVideo video = new YoutubeVideo(path);
			var template = publishCalculator.Template;

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
				}
			}

			foreach (var tag in CutOff(evaluator.Evaluate(template.Tags).Replace("<", string.Empty).Replace(">", string.Empty), YoutubeVideo.MaxTagsLength).Split(','))
			{
				video.Tags.Add(tag);
			}

			video.AddToPlaylist = template.AddToPlaylist;
			video.PlaylistId = template.PlaylistId;

			return new VideoInformation(video, evaluator, notificationSettings);
		}

		public IPath FindNearestPath(string path)
		{
			var publishCalculator = PublishInfos.Where(pi => Directory.Exists(pi.PathInfo.Fullname)).OrderBy(x => x.GetDifference(path)).FirstOrDefault(x => x.GetDifference(path) != null);
			return publishCalculator?.PathInfo;
		}

		public void SaveNextUploadSuggestions()
		{
			foreach (var publishCalculator in PublishInfos)
			{
				var template = publishCalculator.Template;
				if (!publishCalculator.UploadPrivate
					&& template.Privacy == PrivacyStatus.Private
					&& template.ShouldPublishAt
					&& template.PublishTimes.Count > 0)
				{
					template.NextUploadSuggestion = publishCalculator.GetNextPublishTime(true);
				}
			}
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
