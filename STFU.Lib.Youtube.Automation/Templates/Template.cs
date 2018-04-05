using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model.Helpers;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class Template
	{
		private IList<PublishTime> publishTimes;

		public int Id { get; internal set; }

		public string Name { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public ICategory Category { get; set; }

		public ILanguage DefaultLanguage { get; set; }

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

		internal Dictionary<string, Variable> LocalVars { get; set; } = new Dictionary<string, Variable>();

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
		public Template(int id, string name, ILanguage defaultlanguage, ICategory category)
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

		public Template()
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
	}
}
