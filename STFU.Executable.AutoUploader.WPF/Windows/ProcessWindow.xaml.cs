using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        #region Public Constructors

        public ProcessWindow(Lib.Youtube.Automation.Interfaces.IProcessContainer processContainer)
        {
            InitializeComponent();
            ViewModel = DataContext as ProcessViewModel;
            ViewModel.ProcessContainer = processContainer;
            ViewModel.RefreshAllProcessesAsync();
        }

        #endregion Public Constructors

        #region Public Properties

        public ProcessViewModel ViewModel { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ProcessCheck_Click(object sender, RoutedEventArgs e) => ViewModel.RefreshSelectedProcesses();

        #endregion Private Methods
    }
}