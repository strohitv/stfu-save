﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STFU.UploadLib.Communication.Youtube.Serializable;
using STFU.UploadLib.Programming;
using STFU.UploadLib.Videos;

namespace STFU.UploadLib.Templates
{
	public class Template
	{
		private IList<PublishTime> publishTimes;

		public int Id { get; internal set; }

		public string Name { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public Category Category { get; set; }

		public Language DefaultLanguage { get; set; }

		public string Tags { get; set; }

		[JsonConverter(typeof(EnumConverter))]
		public PrivacyStatus Privacy { get; set; }

		[JsonConverter(typeof(EnumConverter))]
		public License License { get; set; }

		public bool IsEmbeddable { get; set; }

		public bool PublicStatsViewable { get; set; }

		public bool NotifySubscribers { get; set; }

		public bool AutoLevels { get; set; }

		public bool Stabilize { get; set; }

		public bool ShouldPublishAt { get; set; }

		public string ThumbnailPath { get; set; }

		private Dictionary<string, Variable> LocalVars { get; set; } = new Dictionary<string, Variable>();

		public IReadOnlyDictionary<string, Variable> LocalVariables => new ReadOnlyDictionary<string, Variable>(LocalVars);

		public static IReadOnlyDictionary<string, Func<string, string, string>> GlobalVariables => Variable.GlobalVariables;

		public IList<PublishTime> PublishTimes
		{
			get
			{
				if (publishTimes == null)
				{
					publishTimes = new List<PublishTime>();
				}

				return publishTimes;
			}
			set
			{
				publishTimes = value;
			}
		}

		[JsonConstructor]
		public Template(int id, string name, Language defaultlanguage, Category category)
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
		}

		private Template()
		{

		}

		public void AddVariable()
		{
			int number = 1;
			string name = $"var{number}";

			while (LocalVariables.ContainsKey(name))
			{
				number++;
				name = $"var{number}";
			}

			AddVariable(name, string.Empty);
		}

		public string RenameVariable(string oldName, string newName)
		{
			string currentVarName = oldName;

			if (!GlobalVariables.ContainsKey(newName.ToLower()) && !LocalVariables.ContainsKey(newName.ToLower()))
			{
				LocalVars.Add(newName.ToLower(), LocalVariables[oldName.ToLower()]);
				LocalVars[newName.ToLower()].Name = newName;
				RemoveVariable(oldName.ToLower());
				currentVarName = newName;
			}

			return currentVarName;
		}

		public void AddVariable(string name, string content)
		{
			if (!GlobalVariables.ContainsKey(name.ToLower()) && !LocalVariables.ContainsKey(name.ToLower()))
			{
				var newVar = new Variable(name, content);
				LocalVars.Add(newVar.Name.ToLower(), newVar);
			}
		}

		public void EditVariable(string name, string newValue)
		{
			if (LocalVariables.ContainsKey(name.ToLower()))
			{
				LocalVars[name.ToLower()].Content = newValue;
			}
		}

		public void RemoveVariable(string name)
		{
			if (LocalVariables.ContainsKey(name.ToLower()))
			{
				LocalVars.Remove(name.ToLower());
			}
		}

		public void ClearVariables()
		{
			LocalVars.Clear();
		}

		public static explicit operator Template(JToken v)
		{
			return JsonConvert.DeserializeObject<Template>(v.ToString());
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}";
		}

		public static Template Duplicate(Template template)
		{
			return new Template(template.Id, template.Name, template.DefaultLanguage, template.Category)
			{
				AutoLevels = template.AutoLevels,
				Description = template.Description,
				IsEmbeddable = template.IsEmbeddable,
				LocalVars = template.LocalVars.ToDictionary(t =>
					$"{new Variable(t.Value.Name, t.Value.Content).Name.ToLower()}", p =>
						new Variable($"{p.Value.Name}", $"{p.Value.Content}")),
				License = template.License,
				NotifySubscribers = template.NotifySubscribers,
				Privacy = template.Privacy,
				PublicStatsViewable = template.PublicStatsViewable,
				PublishTimes = new List<PublishTime>(template.PublishTimes),
				ShouldPublishAt = template.ShouldPublishAt,
				Stabilize = template.Stabilize,
				Tags = template.Tags,
				ThumbnailPath = template.ThumbnailPath,
				Title = template.Title
			};
		}

		public static Template Parse(string json)
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
						result.Category = Category.Parse(item.Value);
						break;
					case "defaultlanguage":
						result.DefaultLanguage = Language.Parse(item.Value);
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

		public static IList<Template> ParseList(string json)
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
