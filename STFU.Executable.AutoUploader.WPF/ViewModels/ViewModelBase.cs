using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Events

        public event EventHandler Close;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Protected Methods

        protected void OnClose()
        {
            Close?.Invoke(this, new EventArgs());
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Protected Methods
    }
}