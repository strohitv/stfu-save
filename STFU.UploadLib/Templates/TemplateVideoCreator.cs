using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	internal class TemplateVideoCreator
	{
		internal IList<PublishInformation> Paths { get; set; }

		internal TemplateVideoCreator(IList<PublishInformation> paths)
		{
			Paths = paths;
		}

		internal Video CreateVideo(string path)
		{
			Video video = new Video(path);

			// Template suchen anhand des Pfades
			var publishInfo = Paths.OrderBy(x => x.GetDifference(path)).First(x => x.GetDifference(path) != null);
			var template = publishInfo.Template;

			// Werte füllen
			video.Title = template.Title;
			video.Description = template.Description;
			video.CategoryId = template.CategoryId;
			video.DefaultLanguage = template.DefaultLanguage;

			video.Privacy = template.Privacy;
			video.License = template.License;
			video.IsEmbeddable = template.IsEmbeddable;
			video.PublicStatsViewable = template.PublicStatsViewable;

			// Evtl. Nächsten Veröffentlichungszeitpunkt berechnen
			// Dafür benötigt: Datum letztes Video und Position in PublishTimes (!)
			if (template.Privacy == PrivacyStatus.Private
				&& template.ShouldPublishAt
				&& template.PublishTimes.Count > 0)
			{
				video.PublishAt = publishInfo.GetNextPublishTime();
			}

			foreach (var tag in template.Tags.Split(','))
			{
				video.Tags.Add(tag);
			}

			return video;
		}
	}
}
