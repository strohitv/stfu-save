using STFU.Lib.Youtube.Interfaces.Model;
using System;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class LanguageVM : ViewModelBase, ILanguage, IDataViewModel<ILanguage>
    {
        #region Private Fields

        private ILanguage source;

        #endregion Private Fields

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public string Hl { get => source?.Hl; set { source.Hl = value; OnPropertyChanged(); } }
        public string Id { get => source?.Id; set { source.Id = value; OnPropertyChanged(); } }
        public string Name { get => source?.Name; set { source.Name = value; OnPropertyChanged(); } }
        public ILanguage Source
        {
            get => source;
            set
            {
                source = value;
                Refresh();
                OnPropertyChanged();
                OnSourceUpdated();
            }
        }

        public bool IsSourceSet => source != null;

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            OnPropertyChanged(nameof(Hl));
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Name));
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        #endregion Protected Methods
    }
}