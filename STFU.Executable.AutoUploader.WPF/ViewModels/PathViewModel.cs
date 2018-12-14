using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Lib.Youtube.Automation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{

    public class PathViewModel : ViewModelBase
    {
        public TemplateVM SelectedTemplate
        {
            get => selectedPath == null ? null : Templates.First(e => e.Id == selectedPath.SelectedTemplateId);
            set
            {
                if (selectedPath == null) return;
                selectedPath.SelectedTemplateId = value.Id;
                OnPropertyChanged();
            }
        }

        #region Public Fields

        public PathVM selectedPath;

        #endregion Public Fields

        #region Private Fields

        private bool hasSelection;
        private Dictionary<ToolAction, Action> toolActions;

        #endregion Private Fields

        #region Public Constructors

        public PathViewModel()
        {
            ChoosePathCommand = new ButtonCommand(ChoosePath);
            MarkAllVideosCommand = new ButtonCommand(MarkAllVideos);
            ToolCommand = new ButtonCommand<ToolAction>(DoAction);
            toolActions = new Dictionary<ToolAction, Action>
            {
                { ToolAction.Add, ToolAdd },
                { ToolAction.Clear, ToolClear },
                { ToolAction.Delete, ToolDelete },
                { ToolAction.MoveDown, ToolMoveDown },
                { ToolAction.MoveUp, ToolMoveUp }
            };
        }

        #endregion Public Constructors

        #region Public Properties

        public ButtonCommand CancelCommand { get; set; }
        public ButtonCommand ChoosePathCommand { get; set; }
        public bool HasSelection { get { return hasSelection; } set { hasSelection = value; OnPropertyChanged(); } }
        public ButtonCommand MarkAllVideosCommand { get; set; }
        public IPathContainer PathContainer { get; set; }
        public ObservableCollection<PathVM> Paths { get; } = new ObservableCollection<PathVM>();
        public ButtonCommand SaveCommand { get; set; }
        public PathVM SelectedPath
        {
            get { return selectedPath; }
            set
            {
                selectedPath = value;
                HasSelection = selectedPath != null;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedTemplate));
                OnPropertyChanged(nameof(CanSelectedMovedDown));
                OnPropertyChanged(nameof(CanSelectedMovedUp));
            }
        }
        public ITemplateContainer TemplateContainer { get; set; }
        public ObservableCollection<TemplateVM> Templates { get; } = new ObservableCollection<TemplateVM>();
        public ButtonCommand<ToolAction> ToolCommand { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void DoAction(ToolAction action) => toolActions[action]();

        public void RefreshPathVMs()
        {
            SelectedPath = null;
            Paths.Clear();
            foreach (var path in PathContainer.RegisteredPaths)
            {
                Paths.Add(new PathVM() { Source = path });
            }
        }

        public void RefreshTemplateVMs()
        {
            Templates.Clear();
            foreach (var template in TemplateContainer.RegisteredTemplates)
            {
                Templates.Add(new TemplateVM() { Source = template });
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ChoosePath()
        {
            if (SelectedPath == null)
                return;

            var dialog = new FolderBrowserDialog
            {
                SelectedPath = SelectedPath.Fullname
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SelectedPath.Fullname = dialog.SelectedPath;
        }

        private void MarkAllVideos()
        {
            PathContainer.MarkAllFilesAsRead(SelectedPath.Source);
            System.Windows.MessageBox.Show("Die Videos, die durch diesen Pfad gefunden werden können, wurden erfolgreich als bereits hochgeladen markiert. Der Uploader wird sie nun nicht mehr finden. Um das zu ändern, einfach die Videodatei wieder umbenennen, sodass sie nicht mehr mit einem Unterstrich _ startet.", "Videos erfolgreich als hochgeladen markiert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToolAdd()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (!Directory.Exists(dialog.SelectedPath) || PathContainer.RegisteredPaths.Any(path => path.Fullname == dialog.SelectedPath))
                return;

            var newPath = new Lib.Youtube.Automation.Paths.Path()
            {
                Fullname = dialog.SelectedPath,
                Filter = "*.mp4;*.mkv",
                SelectedTemplateId = 0,
                SearchRecursively = false,
                Inactive = false,
                SearchHidden = false
            };

            PathContainer.RegisterPath(newPath);
            var pathVM = new PathVM() { Source = newPath };
            Paths.Add(pathVM);
            SelectedPath = pathVM;
        }

        private void ToolClear()
        {
            SelectedPath = null;
            Paths.Clear();
            PathContainer.UnregisterAllPaths();
        }

        private void ToolDelete()
        {
            if (SelectedPath == null)
                return;

            PathContainer.UnregisterPath(SelectedPath.Source);
            Paths.Remove(SelectedPath);
            SelectedPath = null;
        }

        private void ToolMoveDown()
        {
            if (SelectedPath == null)
                return;

            int index = Paths.IndexOf(SelectedPath);
            PathContainer.ShiftPathPositionsAt(index, index + 1);
            Paths.Swap(index, index + 1);
        }

        private void ToolMoveUp()
        {
            if (SelectedPath == null)
                return;

            int index = Paths.IndexOf(SelectedPath);
            PathContainer.ShiftPathPositionsAt(index, index - 1);
            Paths.Swap(index, index - 1);
        }

        public bool CanSelectedMovedDown
        {
            get => SelectedPath != null && Paths.IndexOf(SelectedPath) < Paths.Count - 1;
        }

        public bool CanSelectedMovedUp
        {
            get => SelectedPath != null && Paths.IndexOf(SelectedPath) > 0;
        }

        #endregion Private Methods
    }
}