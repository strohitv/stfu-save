using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Executable.AutoUploader.WPF.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ReleaseNotesViewModel : ViewModelBase
    {
        private const string FILENAME = "ReleaseNotes.rtf";
        private FlowDocument releaseNotesDocument;

        public bool ShowReleaseNotes
        {
            get => MainViewModel.AutoUploaderSettings.ShowReleaseNotes;
            set
            {
                if (MainViewModel.AutoUploaderSettings.ShowReleaseNotes == value)
                    return;

                MainViewModel.AutoUploaderSettings.ShowReleaseNotes = value;
                OnPropertyChanged();
            }
        }

        public FlowDocument ReleaseNotesDocument
        {
            get => releaseNotesDocument;

            set
            {
                releaseNotesDocument = value;
                OnPropertyChanged();
            }
        }

        public void Load()
        {
            LoadDocument();
        }

        private void LoadDocument()
        {
            releaseNotesDocument = new FlowDocument();
            TextRange textRange = new TextRange(ReleaseNotesDocument.ContentStart, ReleaseNotesDocument.ContentEnd);
            if (File.Exists(FILENAME))
            {
                using (FileStream stream = File.Open(FILENAME, FileMode.Open, FileAccess.Read))
                    textRange.Load(stream, DataFormats.Rtf);
            }
            releaseNotesDocument.ParseHyperlinks();
            OnPropertyChanged(nameof(ReleaseNotesDocument));
        }
    }
}
