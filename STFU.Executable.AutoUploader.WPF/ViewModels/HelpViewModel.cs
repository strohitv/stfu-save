using STFU.Executable.AutoUploader.WPF.Helpers;
using System;
using System.Collections.Generic;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public enum HelpLinkAction
    {
        NewFeatures,
        Discord,
        Download,
        LPFThread,
        YTFThread,
        Tutorial,
        TwitterStrohi
    }

    public class HelpViewModel : ViewModelBase
    {
        #region Private Fields

        private const string DISCORD_SERVER = "https://discord.gg/pDcw6rQ";
        private const string DOWNLOAD_PAGE = "https://drive.google.com/drive/folders/1kCRPLg-95PjbQKjEpj-HW7tjvzmZ87RI";
        private const string LPF_THREAD = "https://letsplayforum.de/thread/175111-beta-strohis-toolset-f%C3%BCr-uploads-automatisch-videos-hochladen";
        private const string STROHI_TWITTER = "https://twitter.com/strohkoenig";
        private const string TUTORIAL_VIDEO = "https://www.youtube.com/watch?v=XjYvy36BrNo";
        private const string YTF_THREAD = "https://ytforum.de/index.php/Thread/19543-BETA-Strohis-Toolset-Für-Uploads-v0-1-1-Videos-automatisch-hochladen/";
        private readonly Dictionary<HelpLinkAction, Action> actions;

        #endregion Private Fields

        #region Public Constructors

        public HelpViewModel()
        {
            actions = new Dictionary<HelpLinkAction, Action>
            {
                { HelpLinkAction.NewFeatures, () => { OnShowFeatures(); } },
                { HelpLinkAction.Discord, () => { BrowserHelper.Open(DISCORD_SERVER); } },
                { HelpLinkAction.Download, () => { BrowserHelper.Open(DOWNLOAD_PAGE); } },
                { HelpLinkAction.LPFThread, () => { BrowserHelper.Open(LPF_THREAD); } },
                { HelpLinkAction.YTFThread, () => { BrowserHelper.Open(YTF_THREAD); } },
                { HelpLinkAction.Tutorial, () => { BrowserHelper.Open(TUTORIAL_VIDEO); } },
                { HelpLinkAction.TwitterStrohi, () => { BrowserHelper.Open(STROHI_TWITTER); } }
            };
        }

        public event EventHandler ShowFeatures;

        protected void OnShowFeatures() => ShowFeatures?.Invoke(this, new EventArgs());

        #endregion Public Constructors

        #region Public Methods

        public void OpenHelpLink(HelpLinkAction link) => actions[link]();

        #endregion Public Methods
    }
}