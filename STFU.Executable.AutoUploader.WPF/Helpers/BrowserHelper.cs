using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class BrowserHelper
    {
        public static void Open(string address)
        {
            Process.Start(address);
        }

        public static void Open(Uri address)
        {
            Process.Start(address.AbsoluteUri);
        }
    }
}
