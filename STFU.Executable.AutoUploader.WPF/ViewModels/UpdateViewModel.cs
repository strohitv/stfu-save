using STFU.Lib.Updater;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class UpdateViewModel : ViewModelBase
    {
        #region Private Fields

        private float progress;
        private bool progressUnknown;
        private string status;
        private Updater updater;
        private BackgroundWorker updateWorker;

        #endregion Private Fields

        #region Public Constructors

        public UpdateViewModel()
        {
            updater = new Updater(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            updateWorker = new BackgroundWorker();
            updateWorker.DoWork += UpdateWorker_DoWork;
            updateWorker.RunWorkerCompleted += UpdateWorker_RunWorkerCompleted;
            updateWorker.ProgressChanged += UpdateWorker_ProgressChanged;
            updateWorker.WorkerReportsProgress = true;
        }

        #endregion Public Constructors

        #region Public Properties

        public FileInfo Executable { get; private set; }
        public float Progress { get { return progress; } set { progress = value; OnPropertyChanged(); } }

        public bool ProgressUnknown { get { return progressUnknown; } set { progressUnknown = value; OnPropertyChanged(); } }

        public bool RequiresRestart { get; private set; }
        public string Status { get { return status; } set { status = value; OnPropertyChanged(); } }

        #endregion Public Properties

        #region Public Methods

        public void Start() => updateWorker.RunWorkerAsync();

        #endregion Public Methods

        #region Private Methods

        private void UpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Status = $"Es wird nach Updates gesucht.{Environment.NewLine}Bitte warten...";
            bool updateAvailable = updater.UpdateAvailable;
            if (!updateAvailable)
                return;
            if (MessageBox.Show($"Ein Update auf Version {updater.NewVersion} ist nun verfügbar.{Environment.NewLine}{Environment.NewLine}Soll es heruntergeladen und installiert werden?", "Update verfügbar!", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;
            ProgressUnknown = false;
            updateWorker.ReportProgress(0);
            Status = $"Update wird heruntergeladen.{Environment.NewLine}Bitte warten...";
            updater.DownloadUpdate();
            updateWorker.ReportProgress(50);
            Status = $"Updater wird extrahiert. Programm startet anschließend neu.{Environment.NewLine}Bitte warten...";
            Executable = updater.ExtractUpdateExe();
            updateWorker.ReportProgress(100);
        }

        private void UpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
        }

        private void UpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Executable != null)
            {
                if (Executable.Exists)
                {
                    var app = Path.GetFullPath(Assembly.GetEntryAssembly().Location);
                    RequiresRestart = true;
                    ProcessStartInfo info = new ProcessStartInfo(Executable.FullName, $"\"{updater.UpdateFile.FullName}\" \"{app}\"");
                    Process.Start(info);
                }
                else
                    MessageBox.Show($"Es gab leider einen Fehler beim Herunterladen des Updates, daher kann es nicht installiert werden.", "Fehler beim Download!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            OnClose();
        }

        #endregion Private Methods
    }
}