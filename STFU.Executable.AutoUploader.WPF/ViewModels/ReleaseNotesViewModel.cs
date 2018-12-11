using STFU.Executable.AutoUploader.WPF.Helpers;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class ReleaseNotesViewModel : ViewModelBase
    {
        #region Private Fields

        private const string FILENAME = "ReleaseNotes.rtf";
        private FlowDocument releaseNotesDocument;

        #endregion Private Fields

        #region Public Properties

        public FlowDocument ReleaseNotesDocument
        {
            get => releaseNotesDocument;

            set
            {
                releaseNotesDocument = value;
                OnPropertyChanged();
            }
        }

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

        #endregion Public Properties

        #region Public Methods

        public void Load()
        {
            LoadDocument();
        }

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}