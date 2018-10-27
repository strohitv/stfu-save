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

		IList<IPlannedVideo> PlannedVideos { get; set; }

		string CSharpPreparationScript { get; set; }
		string CSharpCleanUpScript { get; set; }
		
		string ToString();
	}
}