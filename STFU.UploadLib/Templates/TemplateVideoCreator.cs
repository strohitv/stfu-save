using System.Collections.Generic;
using System.Linq;
using STFU.UploadLib.Programming;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	internal class TemplateVideoCreator
	{
		internal IList<PublishInformation> PublishInfos { get; set; }

		internal TemplateVideoCreator(IList<PublishInformation> publishInfo)
		{
			PublishInfos = publishInfo;
		}

		internal Video CreateVideo(string path)
		{
			Video video = new Video(path);

			// Template suchen anhand des Pfades
			var publishInfo = PublishInfos.OrderBy(x => x.GetDifference(path)).First(x => x.GetDifference(path) != null);
			var template = publishInfo.Template;

			ExpressionEvaluator evaluator = new ExpressionEvaluator(path, template.Name, template.LocalVariables);

			// Werte füllen
			video.Title = CutOff(evaluator.Evaluate(template.Title), Video.MaxTitleLength);
			video.Description = CutOff(evaluator.Evaluate(template.Description), Video.MaxDescriptionLength);
			video.Category = template.Category;
			video.DefaultLanguage = template.DefaultLanguage;

			video.Privacy = publishInfo.UploadPrivate ? PrivacyStatus.Private : template.Privacy;
			video.License = template.License;
			video.IsEmbeddable = template.IsEmbeddable;
			video.PublicStatsViewable = template.PublicStatsViewable;

			video.NotifySubscribers = template.NotifySubscribers;
			video.AutoLevels = template.AutoLevels;
			video.Stabilize = template.Stabilize;

			// Evtl. Nächsten Veröffentlichungszeitpunkt berechnen
			// Dafür benötigt: Datum letztes Video und Position in PublishTimes (!)
			if (!publishInfo.UploadPrivate
				&& template.Privacy == PrivacyStatus.Private
				&& template.ShouldPublishAt
				&& template.PublishTimes.Count > 0)
			{
				video.PublishAt = publishInfo.GetNextPublishTime();
			}

			foreach (var tag in CutOff(evaluator.Evaluate(template.Tags), Video.MaxTagsLength).Split(','))
			{
				video.Tags.Add(tag);
			}

			return video;
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
