using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Protected Methods

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnClose()
        {
            Close?.Invoke(this, new EventArgs());
        }

        public event EventHandler Close;

        #endregion Protected Methods
    }
}