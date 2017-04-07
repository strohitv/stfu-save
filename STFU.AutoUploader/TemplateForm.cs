using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STFU.UploadLib.Automation;
using STFU.UploadLib.Templates;

namespace STFU.AutoUploader
{
	public partial class TemplateForm : Form
	{
		private AutomationUploader uploader;
		private Template current;

		public TemplateForm(AutomationUploader upl)
		{
			InitializeComponent();

			uploader = upl;
		}

		private void addPathButtonClick(object sender, EventArgs e)
		{
			Template templ = new Template();
			uploader.Templates.Add(templ);

			RefillListView();
		}

		private void RefillListView()
		{
			templateListView.Items.Clear();

			foreach (var template in uploader.Templates)
			{
				templateListView.Items.Add(template.Name);
			}
		}
	}
}
