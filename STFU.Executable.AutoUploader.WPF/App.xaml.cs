using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Linq;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private Methods

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainViewModel.ShowReleaseNotesOnStartup = e.Args.Any(arg => arg.ToLower() == "showreleasenotes");
        }

        #endregion Private Methods
    }
}