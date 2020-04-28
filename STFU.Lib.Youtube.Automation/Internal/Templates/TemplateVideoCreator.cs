using System.Collections.Generic;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Templates
{
	internal class TemplateVideoCreator
	{
		internal IList<PublishTimeCalculator> PublishInfos { get; set; }

		internal TemplateVideoCreator(IList<PublishTimeCalculator> publishInfo)
		{
			PublishInfos = publishInfo;
		}

		internal VideoInformation CreateVideo(string path)
		{
			IYoutubeVideo video = new YoutubeVideo(path);

			// Template suchen anhand des Pfades
			var publishCalculator = PublishInfos.OrderBy(x => x.GetDifference(path)).First(x => x.GetDifference(path) != null);
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
				template.NextUploadSuggestion = publishCalculator.GetNextPublishTime(true);
			}

			foreach (var tag in CutOff(evaluator.Evaluate(template.Tags).Replace("<", string.Empty).Replace(">", string.Empty), YoutubeVideo.MaxTagsLength).Split(','))
			{
				video.Tags.Add(tag);
			}

			return new VideoInformation(video, evaluator, notificationSettings);
		}

		public IPath FindNearestPath(string path)
		{
			var publishCalculator = PublishInfos.OrderBy(x => x.GetDifference(path)).First(x => x.GetDifference(path) != null);
			return publishCalculator?.PathInfo;
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
