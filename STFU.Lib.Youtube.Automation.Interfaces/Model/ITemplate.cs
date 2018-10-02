using System.Collections.Generic;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Automation.Interfaces.Model
{
	public interface ITemplate
	{
		bool AutoLevels { get; set; }
		ICategory Category { get; set; }
		ILanguage DefaultLanguage { get; set; }
		string Description { get; set; }
		int Id { get; }
		bool IsEmbeddable { get; set; }
		License License { get; set; }
		IReadOnlyDictionary<string, IVariable> LocalVariables { get; }
		string Name { get; set; }
		bool NotifySubscribers { get; set; }
		PrivacyStatus Privacy { get; set; }
		bool PublicStatsViewable { get; set; }
		IList<IPublishTime> PublishTimes { get; set; }
		bool ShouldPublishAt { get; set; }
		bool Stabilize { get; set; }
		string Tags { get; set; }
		string ThumbnailPath { get; set; }
		string Title { get; set; }

		string CSharpPreparationScript { get; set; }
		string CSharpCleanUpScript { get; set; }

		void AddVariable();
		void AddVariable(string name, string content);
		void ClearVariables();
		void EditVariable(string name, string newValue);
		void RemoveVariable(string name);
		string RenameVariable(string oldName, string newName);
		string ToString();
	}
}