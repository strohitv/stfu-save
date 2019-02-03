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

        public int Id
        {
            get
            {
                return source?.Id ?? 0;
            }
            set
            {
                OnCategoryRequested(value);
            }
        }

        public event EventHandler<CategoryRequestEventArgs> CategoryRequested;

        private void OnCategoryRequested(int id)
        {
            CategoryRequested?.Invoke(this, new CategoryRequestEventArgs(id));
        }

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

        public string Title
        {
            get
            {
                return source?.Title;
            }
            set
            {

            }
        }

        public bool IsSourceSet => source != null;

        #endregion Public Properties

        #region Public Methods

        public void Refresh()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Title));
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnSourceUpdated()
        {
            OnPropertyChanged(nameof(IsSourceSet));
            SourceUpdated?.Invoke(this, new EventArgs());
        }

        public class CategoryRequestEventArgs
        {
            public CategoryRequestEventArgs(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }

        #endregion Protected Methods
    }
}