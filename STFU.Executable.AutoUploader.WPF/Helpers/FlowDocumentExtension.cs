using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class FlowDocumentExtension
    {
        public static void ParseHyperlinks(this FlowDocument document)
        {
            var elements = LogicalTreeUtility.GetChildren<Run>(document, true);
            foreach (var run in elements)
            {
                if (run.Text.Contains("http"))
                {
                    Span span = run.Parent as Span;
                    Hyperlink hyperlink = new Hyperlink(run)
                    {
                        NavigateUri = new Uri(run.Text)
                    };
                    hyperlink.RequestNavigate += (sender, e) => { Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)); e.Handled = true; };
                    span.Inlines.Add(hyperlink);
                }
            }
        }
    }
}
