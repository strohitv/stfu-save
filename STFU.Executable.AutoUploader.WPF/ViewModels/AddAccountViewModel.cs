using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class AddAccountViewModel : ViewModelBase
    {
        private string externalCodeUri;
        private string localHostUri;
        private bool usedLocalHostRedirect;
        private string authToken;

        public string ExternalCodeUri
        {
            get => externalCodeUri;
            set { externalCodeUri = value; OnPropertyChanged(); }
        }

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

        public string AuthToken
        {
            get { return authToken; }
            set { authToken = value; OnPropertyChanged(); }
        }

        public override void Load()
        {

        }

        public void OpenExternalUrl()
        {
            Process.Start(externalCodeUri);
        }

        public bool? SignIn()
        {
            usedLocalHostRedirect = false;
            return true;
        }
    }
}
