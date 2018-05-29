using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Templates;

namespace STFU.Lib.Youtube.Automation
{
	public class TemplateContainer : ITemplateContainer
	{
		private IList<ITemplate> templates = new List<ITemplate>();

		private IList<ITemplate> Templates => templates;

		public IReadOnlyCollection<ITemplate> RegisteredTemplates => new ReadOnlyCollection<ITemplate>(templates);

		private bool IdIsNotRegistered(int id)
		{
			return RegisteredTemplates.Any(t => t.Id == id);
		}

		private int GetNextUnusedId()
		{
			int maxId = RegisteredTemplates.Max(t => t.Id);
			return maxId + 1;
		}

		public void RegisterTemplate(ITemplate template)
		{
			if (!IdIsNotRegistered(template.Id))
			{
				((Template)template).Id = GetNextUnusedId();
			}

			Templates.Add(template);
		}

		public void UpdateTemplate(ITemplate template)
		{
			if (RegisteredTemplates.Any(t => t.Id == template.Id))
			{
				var temp = RegisteredTemplates.Single(t => t.Id == template.Id);
				var index = Templates.IndexOf(temp);

				Templates[index] = template;
			}
		}

		public void UnregisterTemplate(ITemplate template)
		{
			if (RegisteredTemplates.Any(t => t.Id == template.Id))
			{
				var temp = RegisteredTemplates.Single(t => t.Id == template.Id);
				Templates.Remove(temp);
			}
		}

		public void UnregisterTemplateAt(int index)
		{
			if (RegisteredTemplates.Count > index && Templates[index].Id != 0)
			{
				Templates.RemoveAt(index);
			}
		}

		public void UnregisterAllTemplates()
		{
			templates = templates.Where(t => t.Id == 0).ToList();
		}

		public void ShiftTemplatePositions(ITemplate first, ITemplate second)
		{
			ITemplate firstToChange = null;
			ITemplate secondToChange = null;
			if (first != null
				&& second != null
				&& (firstToChange = Templates.FirstOrDefault(t => t.Id == first.Id)) != null
				&& (secondToChange = Templates.FirstOrDefault(t => t.Id == second.Id)) != null)
			{
				ShiftTemplatePositionsAt(templates.IndexOf(firstToChange), templates.IndexOf(secondToChange));
			}
		}

		public void ShiftTemplatePositionsAt(int firstIndex, int secondIndex)
		{
			if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < Templates.Count && secondIndex < Templates.Count)
			{
				var save = templates[firstIndex];
				templates[firstIndex] = templates[secondIndex];
				templates[secondIndex] = save;
			}
		}
	}
}
