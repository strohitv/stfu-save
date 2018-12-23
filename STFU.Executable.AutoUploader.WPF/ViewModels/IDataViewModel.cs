using System;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public interface IDataViewModel<T>
    {
        #region Public Events

        event EventHandler SourceUpdated;

        #endregion Public Events

        #region Public Properties

        T Source { get; set; }

        bool IsSourceSet { get; }

        #endregion Public Properties

        #region Public Methods

        void Refresh();

        #endregion Public Methods
    }
}