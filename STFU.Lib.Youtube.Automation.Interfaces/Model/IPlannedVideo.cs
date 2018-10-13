using System.Collections.Generic;

namespace STFU.Lib.Youtube.Automation.Interfaces.Model
{
	public interface IPlannedVideo
	{
		string Name { get; set; }
		
		IDictionary<string, string> Fields { get; set; }
	}
}
