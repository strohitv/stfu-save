using System;
using System.Diagnostics;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class BrowserHelper
    {
        #region Public Methods

        public static void Open(string address)
        {
            Process.Start(address);
        }

        public static void Open(Uri address)
        {
            Process.Start(address.AbsoluteUri);
        }

        #endregion Public Methods
    }
}