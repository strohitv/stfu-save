using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Programming;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Model.Helpers;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class Template : ITemplate
	{
		private IList<IPublishTime> publishTimes;

		public int Id { get; internal set; }

		public string Name { get; set; }

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

		public string CSharpPreparationScript { get; set; } = "// Dieses Skript wird vor allen Skripten in Beschreibung, Titel usw. ausgeführt und kann daher zur Vorbereitung genutzt werden (z. B. zum Erstellen von Variablen)." + Environment.NewLine
			+ "// Dieses Feld soll ausschließlich C#-Code enthalten. Bitte keine <<<, <<<C und >>> schreiben." + Environment.NewLine + Environment.NewLine
			+ "using System;";

		public string CSharpCleanUpScript { get; set; } = "// Dieses Skript wird nach allen Skripten in Beschreibung, Titel usw. ausgeführt und kann daher zum Aufräumen verwendet werden (z. B. um Disposes durchzuführen)." + Environment.NewLine
			+ "// Dieses Feld soll ausschließlich C#-Code enthalten. Bitte keine <<<, <<<C und >>> schreiben.";

		internal Dictionary<string, IVariable> LocalVars { get; set; } = new Dictionary<string, IVariable>();

		public IReadOnlyDictionary<string, IVariable> LocalVariables => new ReadOnlyDictionary<string, IVariable>(LocalVars);

		public static IReadOnlyDictionary<string, Func<string, string, string>> GlobalVariables => Variable.GlobalVariables;

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

		[JsonConstructor]
		public Template(int id, string name, YoutubeLanguage defaultlanguage, YoutubeCategory category, IList<PublishTime> publishTimes, Dictionary<string, Variable> localVariables)
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
			LocalVars = localVariables.ToDictionary(x => x.Key, x => (IVariable)x.Value);
		}

		public Template(int id, string name, ILanguage defaultlanguage, ICategory category, IList<IPublishTime> publishTimes, Dictionary<string, IVariable> localVars)
			: this(id, name, (YoutubeLanguage)defaultlanguage, (YoutubeCategory)category, publishTimes.Select(pt => (PublishTime)pt).ToList(), localVars.Select(kvp => new KeyValuePair<string, Variable>(kvp.Key, (Variable)kvp.Value)).ToDictionary(k => k.Key, v => v.Value))
		{ }

		public Template()
		{ }

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

		public static ITemplate Duplicate(ITemplate template)
		{
			return new Template(template.Id, template.Name, template.DefaultLanguage, template.Category, template.PublishTimes, template.LocalVariables.ToDictionary(x => x.Key, x => x.Value))
			{
				AutoLevels = template.AutoLevels,
				Description = template.Description,
				IsEmbeddable = template.IsEmbeddable,
				LocalVars = ((Template)template).LocalVars.ToDictionary(t => $"{new Variable(t.Value.Name, t.Value.Content).Name.ToLower()}",
										p => (IVariable)new Variable($"{p.Value.Name}", $"{p.Value.Content}")),
				License = template.License,
				NotifySubscribers = template.NotifySubscribers,
				Privacy = template.Privacy,
				PublicStatsViewable = template.PublicStatsViewable,
				PublishTimes = new List<IPublishTime>(template.PublishTimes),
				ShouldPublishAt = template.ShouldPublishAt,
				Stabilize = template.Stabilize,
				Tags = template.Tags,
				ThumbnailPath = template.ThumbnailPath,
				Title = template.Title,

				CSharpPreparationScript = template.CSharpPreparationScript,
				CSharpCleanUpScript = template.CSharpCleanUpScript
			};
		}
	}
}
