using STFU.Executable.AutoUploader.WPF.ViewModels;
using STFU.Lib.Youtube.Persistor.Model;
using System.Linq;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainViewModel.AutoUploaderSettings.ShowReleaseNotes = e.Args.Any(arg => arg.ToLower() == "showreleasenotes");
        }
    }
}
