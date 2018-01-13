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
		internal Dictionary<PathInformation, DateTime> Paths { get; set; }

		internal TemplateVideoCreator(Dictionary<PathInformation, DateTime> paths)
		{
			Paths = paths;
		}

		internal Video CreateVideo(string path, Collection<Template> templates)
		{
			Video video = new Video(path);

			var pathInfoWithTime = FindPathInfo(path);
			var templateName = pathInfoWithTime.Key.SelectedTemplate.ToLower();

			Template template = templates.FirstOrDefault(t => t.Name.ToLower() == templateName);
			if (template == null)
			{
				template = templates.FirstOrDefault(t => t.Name.ToLower() == "standard");
			}

			video.Title = template.Title;
			video.Description = template.Description;
			video.CategoryId = template.CategoryId;
			video.DefaultLanguage = template.DefaultLanguage;

			video.Privacy = template.Privacy;
			video.License = template.License;
			video.IsEmbeddable = template.IsEmbeddable;
			video.PublicStatsViewable = template.PublicStatsViewable;

			if (template.Privacy == PrivacyStatus.Private
				&& template.ShouldPublishAt
				&& template.PublishTimes.Count > 0)
			{
				PathInformation pathInfo = pathInfoWithTime.Key;
				DateTime time = pathInfoWithTime.Value;
				video.PublishAt = FindPublishAt(template.PublishTimes, ref time);

				Paths[pathInfo] = time;
			}

			video.Tags.Clear();
			foreach (var tag in template.Tags.Split(','))
			{
				video.Tags.Add(tag);
			}

			return video;
		}

		private DateTime FindPublishAt(IList<PublishTime> templateTimes, ref DateTime dateTime)
		{
			var currentTime = dateTime;

			var dateTimes = new List<KeyValuePair<DateTime, PublishTime>>();

			foreach (var time in templateTimes)
			{
				var currentTimeSave = currentTime;

				if (currentTimeSave.DayOfWeek == time.DayOfWeek && currentTimeSave.TimeOfDay <= time.Time)
				{
					// Tag passt, Allerdings liegt die Zeit bereits in der Vergangenheit
					// => Termin ist in sieben Tagen zur eingestellten Uhrzeit
					currentTimeSave = currentTimeSave.AddDays(7.0);
				}
				else
				{
					// Richtigen Tag finden
					while (currentTimeSave.DayOfWeek != time.DayOfWeek)
					{
						currentTimeSave = currentTimeSave.AddDays(1.0);
					}
				}

				// Uhrzeit anpassen
				currentTimeSave = currentTimeSave.Date.Add(time.Time);

				dateTimes.Add(new KeyValuePair<DateTime, PublishTime>(currentTimeSave, time));
			}

			var publishTime = DateTime.MaxValue;
			var newCurrentTime = DateTime.MaxValue;

			foreach (var time in dateTimes)
			{
				if (time.Key - currentTime < publishTime - currentTime)
				{
					publishTime = time.Key;
					newCurrentTime = time.Key.AddDays(time.Value.SkipDays);
				}
			}

			dateTime = newCurrentTime;
			return publishTime;
		}

		private KeyValuePair<PathInformation, DateTime> FindPathInfo(string path)
		{
			string folder = Path.GetDirectoryName(path);

			var pathInfos = Paths.Where(y => (!y.Key.SearchRecursively && IsParent(folder, y.Key.Path)) 
											|| (y.Key.SearchRecursively && IsParentRecursively(folder, y.Key.Path))).ToArray();

			// Falls mehrere da sind: Nähsten Pfad rausfinden
			var pathInfo = pathInfos.First();
			var pathDirInfo = new DirectoryInfo(pathInfo.Key.Path);
			for (int i = 1; i < pathInfos.Length; i++)
			{
				var dirInfo = new DirectoryInfo(pathInfos[i].Key.Path);
				if (dirInfo.FullName.Length > pathDirInfo.FullName.Length)
				{
					// Neuer Pfad ist länger als alter
					// => Neuer Pfad ist näher an Videopfad dran als alter
					// => Neuer Pfad überschreibt Template von altem Pfad
					pathInfo = pathInfos[i];
					pathDirInfo = dirInfo;
				}
			}

			return pathInfo;
		}

		private static bool IsParent(string fullPath, string basePath)
		{
			DirectoryInfo di1 = new DirectoryInfo(fullPath);
			DirectoryInfo di2 = new DirectoryInfo(basePath);
			bool isParent = di2.Parent.FullName == di1.FullName;

			return isParent;
		}

		private static bool IsParentRecursively(string fullPath, string basePath)
		{
			var fullPathSegments = SegmentizePath(fullPath);
			var baseSegments = SegmentizePath(basePath);
			var index = 0;
			while (fullPathSegments.Count > index && baseSegments.Count > index &&
				fullPathSegments[index].Trim().ToLower() == baseSegments[index].Trim().ToLower())
				index++;
			return index == baseSegments.Count - 1;
		}

		private static IList<string> SegmentizePath(string path)
		{
			var segments = new List<string>();
			var remaining = new DirectoryInfo(path);
			while (null != remaining)
			{
				segments.Add(remaining.Name);
				remaining = remaining.Parent;
			}
			segments.Reverse();
			return segments;
		}
	}
}
