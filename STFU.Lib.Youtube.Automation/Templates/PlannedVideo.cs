using System.Collections.Generic;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Templates
{
	public class PlannedVideo : IPlannedVideo
	{
		public string Name { get; set; } = string.Empty;
		public IDictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();
	}
}
