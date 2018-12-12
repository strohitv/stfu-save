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

        private void CloseItem_Click(object sender, RoutedEventArgs e) => Close();

        private void FinishActivity_SelectionChanged(object sender, SelectionChangedEventArgs e) => ViewModel?.ChangedDependentActivity();

        private void ViewModel_Close(object sender, System.EventArgs e) => Close();

        private void WaitForProcess_Checked(object sender, RoutedEventArgs e) => ViewModel?.ChooseProcessToWaitFor();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => ViewModel?.Shutdown();

        private void Window_Loaded(object sender, RoutedEventArgs e) => ViewModel?.Startup();

        #endregion Private Methods
    }
}