using STFU.Lib.Youtube.Interfaces.Model;
using System;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class CategoryVM : ViewModelBase, ICategory, IDataViewModel<ICategory>
    {
        #region Private Fields

        private ICategory source;

        #endregion Private Fields

        #region Public Events

        public event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        public int Id => source.Id;

        public ICategory Source
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

        public string Title => source.Title;

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Title));
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnSourceUpdated() => SourceUpdated?.Invoke(this, new EventArgs());

        #endregion Protected Methods
    }
}