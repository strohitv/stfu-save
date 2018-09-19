using System.Collections.Generic;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface ITemplateContainer
	{
		IReadOnlyCollection<ITemplate> RegisteredTemplates { get; }

		void RegisterTemplate(ITemplate template);
		void ShiftTemplatePositions(ITemplate first, ITemplate second);
		void ShiftTemplatePositionsAt(int firstIndex, int secondIndex);
		void UnregisterAllTemplates();
		void UnregisterTemplate(ITemplate template);
		void UnregisterTemplateAt(int index);
		void UpdateTemplate(ITemplate template);
	}
}