using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Model;

namespace STFU.Lib.Youtube.Automation.Internal.Parser
{
	internal class TemplateParser
	{
		internal static Template Parse(string json)
		{
			var jObject = JObject.Parse(json);

			var result = new Template();

			foreach (var item in jObject.Children<JProperty>())
			{
				switch (item.Name.ToLower())
				{
					case "id":
						result.Id = (int)item.Value;
						break;
					case "autolevels":
						result.AutoLevels = (bool)item.Value;
						break;
					case "category":
						result.Category = VideoCategory.Parse(item.Value);
						break;
					case "defaultlanguage":
						result.DefaultLanguage = VideoLanguage.Parse(item.Value);
						break;
					case "description":
						result.Description = (string)item.Value;
						break;
					case "isembeddable":
						result.IsEmbeddable = (bool)item.Value;
						break;
					case "license":
						result.License = LicenseParser.Parse(item.Value);
						break;
					case "localvariables":
						result.LocalVars = ReadLocalVars(item.Value);
						break;
					case "name":
						result.Name = (string)item.Value;
						break;
					case "notifysubscribers":
						result.NotifySubscribers = (bool)item.Value;
						break;
					case "privacy":
						result.Privacy = PrivacyStatusParser.Parse(item.Value);
						break;
					case "publicstatsviewable":
						result.PublicStatsViewable = (bool)item.Value;
						break;
					case "publishtimes":
						result.PublishTimes = ReadPublishTimes(item.Value);
						break;
					case "shouldpublishat":
						result.ShouldPublishAt = (bool)item.Value;
						break;
					case "stabilize":
						result.Stabilize = (bool)item.Value;
						break;
					case "tags":
						result.Tags = (string)item.Value;
						break;
					case "thumbnailpath":
						result.ThumbnailPath = (string)item.Value;
						break;
					case "title":
						result.Title = (string)item.Value;
						break;
					default:
						break;
				}
			}

			return result;
		}

		internal static IList<Template> ParseList(string json)
		{
			var jArray = JArray.Parse(json);

			var result = new List<Template>();

			foreach (var item in jArray.Children<JObject>())
			{
				result.Add(Parse(item.ToString()));
			}

			return result;
		}

		private static IList<PublishTime> ReadPublishTimes(JToken item)
		{
			var times = new List<PublishTime>();

			foreach (var child in item.Children())
			{
				var time = new PublishTime();
				foreach (var property in child.Children<JProperty>())
				{
					switch (property.Name.ToLower())
					{
						case "dayofweek":
							time.DayOfWeek = (DayOfWeek)(int)property.Value;
							break;
						case "time":
							time.Time = (TimeSpan)property.Value;
							break;
						case "skipdays":
							time.SkipDays = (int)property.Value;
							break;
					}
				}
				times.Add(time);
			}

			return times;
		}

		private static Dictionary<string, Variable> ReadLocalVars(JToken item)
		{
			var localVarDict = new Dictionary<string, Variable>();

			foreach (var child in item.Children<JProperty>())
			{
				if (!localVarDict.ContainsKey(child.Name))
				{
					localVarDict.Add(child.Name, Variable.Parse(child.Value));
				}
			}

			return localVarDict;
		}
	}
}
