using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        #region Public Constructors

        public AddAccountWindow(string externalCodeUri, string localHostUri)
        {
            InitializeComponent();
            ViewModel = DataContext as AddAccountViewModel;
            ViewModel.ExternalCodeUri = externalCodeUri;
            ViewModel.LocalHostUri = localHostUri;
        }

        #endregion Public Constructors

        #region Public Properties

        public AddAccountViewModel ViewModel { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = ViewModel.SignIn();
            Close();
        }

        #endregion Private Methods
    }
}