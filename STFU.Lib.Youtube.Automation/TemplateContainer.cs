using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Automation.Templates;

namespace STFU.Lib.Youtube.Automation
{
	public class TemplateContainer
	{
		private IList<Template> templates = new List<Template>();

		private IList<Template> Templates => templates;

		public IReadOnlyCollection<Template> RegisteredTemplates => new ReadOnlyCollection<Template>(templates);

		private bool IdIsNotRegistered(int id)
		{
			return RegisteredTemplates.Any(t => t.Id == id);
		}

		private int GetNextUnusedId()
		{
			int maxId = RegisteredTemplates.Max(t => t.Id);
			return maxId + 1;
		}

		public void RegisterTemplate(Template template)
		{
			if (!IdIsNotRegistered(template.Id))
			{
				template.Id = GetNextUnusedId();
			}

			Templates.Add(template);
		}

		public void UnregisterTemplate(Template template)
		{
			if (RegisteredTemplates.Any(t => t.Id == template.Id))
			{
				var temp = RegisteredTemplates.Single(t => t.Id == template.Id);
				Templates.Remove(temp);
			}
		}
	}
}
