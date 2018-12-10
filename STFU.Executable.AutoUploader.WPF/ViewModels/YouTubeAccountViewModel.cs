using STFU.Lib.Youtube.Interfaces.Model;
using System;
using System.Diagnostics;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class YouTubeAccountViewModel : ViewModelBase
    {
        private IYoutubeAccount account;

        public string Id { get { return account?.Id ?? string.Empty; } }

        public string Uri { get { return account?.Uri?.ToString() ?? string.Empty; } }

        public string Title { get { return account?.Title ?? string.Empty; } }

        public string Region { get { return account?.Region ?? string.Empty; } }

        public override void Load()
        {

        }

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

        public void OpenChannelInBrowser()
        {
            Process.Start(Uri);
        }
    }
}