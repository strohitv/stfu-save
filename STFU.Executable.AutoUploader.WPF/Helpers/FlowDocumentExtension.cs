﻿using System;
using System.Windows.Documents;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class FlowDocumentExtension
    {
        #region Public Methods

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
                    hyperlink.RequestNavigate += (sender, e) => { BrowserHelper.Open(e.Uri); e.Handled = true; };
                    span.Inlines.Add(hyperlink);
                }
            }
        }

        #endregion Public Methods
    }
}