using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class YouTubeAccountViewModel : ViewModelBase
    {
        #region Private Fields

        private IYoutubeAccount account;

        #endregion Private Fields

        #region Public Properties

        public string Id { get { return account?.Id ?? string.Empty; } }

        public string Region { get { return account?.Region ?? string.Empty; } }

        public string Title { get { return account?.Title ?? string.Empty; } }

        public string Uri { get { return account?.Uri?.ToString() ?? string.Empty; } }

        #endregion Public Properties

        #region Public Methods

        public void OpenChannelInBrowser() => BrowserHelper.Open(Uri);

        public void RegisterAccount(IYoutubeAccount youtubeAccount)
        {
            account = youtubeAccount;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Uri));
        }

        public void UnregisterAccount()
        {
            account = null;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Uri));
        }

        #endregion Public Methods
    }
}