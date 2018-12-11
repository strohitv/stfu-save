using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as MainViewModel;
            ViewModel.Close += ViewModel_Close;
            ViewModel.Load();
        }

        #endregion Public Constructors

        #region Public Properties

        public MainViewModel ViewModel { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void ChannelLink_Click(object sender, RoutedEventArgs e) => ViewModel?.YouTubeAccountVM.OpenChannelInBrowser();

        private void ChooseProcess_Click(object sender, RoutedEventArgs e) => ViewModel?.ChoseProcessToWaitFor();

        private void CloseItem_Click(object sender, RoutedEventArgs e) => Close();

        private void ConnectYouTubeItem_Click(object sender, RoutedEventArgs e) => ViewModel?.ConnectToYouTube();

        private void DisonnectYouTubeItem_Click(object sender, RoutedEventArgs e) => ViewModel?.RevokeAccess();

        private void FinishActivity_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => ViewModel?.ChangedDependentActivity();

        private void HelpItem_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is MenuItem item))
                return;

            ViewModel.HelpItemClicked((HelpLinkAction)item.Tag);
        }

        private void PathsItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Start_Click(object sender, RoutedEventArgs e) => ViewModel?.Start();

        private void TemplatesItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UncompletedUploadItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ViewModel_Close(object sender, System.EventArgs e) => Close();

        private void WaitForProcess_Checked(object sender, RoutedEventArgs e) => ViewModel?.ChoseProcessToWaitFor();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => ViewModel?.Shutdown();

        private void Window_Loaded(object sender, RoutedEventArgs e) => ViewModel?.Startup();

        #endregion Private Methods
    }
}