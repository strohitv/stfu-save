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
            WPF.Windows.MainWindow.Settings = new AutoUploaderSettings
            {
                ShowReleaseNotes = true || e.Args.Any(arg => arg.ToLower() == "showreleasenotes")
            };
        }
    }
}
