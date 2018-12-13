using STFU.Lib.Youtube.Automation.Interfaces.Model;
using System;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PathVM : ViewModelBase, IPath, IDataViewModel<IPath>
    {
        #region Private Fields

        private IPath source;

        #endregion Private Fields

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public string Filter { get => source.Filter; set { source.Filter = value; OnPropertyChanged(); } }

        public string Fullname { get => source.Fullname; set { source.Fullname = value; OnPropertyChanged(); } }

        public bool Inactive { get => source.Inactive; set { source.Inactive = value; OnPropertyChanged(); } }

        public bool SearchHidden { get => source.SearchHidden; set { source.SearchHidden = value; OnPropertyChanged(); } }

        public bool SearchRecursively
        {
            get => source.SearchRecursively; set
            {
                source.SearchRecursively = value;
                if (value == false)
                    SearchHidden = false;
                OnPropertyChanged();
            }
        }

        public int SelectedTemplateId { get => source.SelectedTemplateId; set { source.SelectedTemplateId = value; OnPropertyChanged(); } }

        public IPath Source { get => source; set { source = value; OnPropertyChanged(); Refresh(); OnSourceUpdated(); } }

        #endregion Public Properties

        #region Public Methods

        public int? GetDifference(string pathToCheck) => source.GetDifference(pathToCheck);

        public void Refresh()
        {
            OnPropertyChanged(nameof(Filter));
            OnPropertyChanged(nameof(Fullname));
            OnPropertyChanged(nameof(Inactive));
            OnPropertyChanged(nameof(SearchHidden));
            OnPropertyChanged(nameof(SearchRecursively));
            OnPropertyChanged(nameof(SelectedTemplateId));
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnSourceUpdated() => SourceUpdated?.Invoke(this, new EventArgs());

        #endregion Protected Methods
    }
}