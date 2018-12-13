﻿using STFU.Executable.AutoUploader.WPF.Helpers;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class AddAccountViewModel : ViewModelBase
    {
        #region Private Fields

        private string authToken;
        private string externalCodeUri;
        private string localHostUri;
        private bool usedLocalHostRedirect;

        #endregion Private Fields

        #region Public Constructors

        public AddAccountViewModel()
        {
            ExternalLinkCommand = new ButtonCommand(OpenExternalUrl);
        }

        #endregion Public Constructors

        #region Public Properties

        public string AuthToken
        {
            get { return authToken; }
            set { authToken = value; OnPropertyChanged(); }
        }

        public string ExternalCodeUri
        {
            get => externalCodeUri;
            set { externalCodeUri = value; OnPropertyChanged(); }
        }

        public ButtonCommand ExternalLinkCommand { get; set; }

        public string LocalHostUri
        {
            get => localHostUri;
            set { localHostUri = value; OnPropertyChanged(); }
        }

        public bool UsedLocalHostRedirect
        {
            get { return usedLocalHostRedirect; }
            private set { usedLocalHostRedirect = value; OnPropertyChanged(); }
        }

        #endregion Public Properties

        #region Public Methods

        public void OpenExternalUrl() => BrowserHelper.Open(externalCodeUri);

        public bool? SignIn()
        {
            usedLocalHostRedirect = false;
            return true;
        }

        #endregion Public Methods
    }
}