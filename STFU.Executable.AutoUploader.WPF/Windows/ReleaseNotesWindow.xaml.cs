using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ReleaseNotesWindow.xaml
    /// </summary>
    public partial class ReleaseNotesWindow : Window
    {
        #region Public Constructors

        public ReleaseNotesWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as ReleaseNotesViewModel;
            ViewModel.Load();
            ReleaseNotesBox.Document = ViewModel.ReleaseNotesDocument;
        }

        #endregion Public Constructors

        #region Public Properties

        public ReleaseNotesViewModel ViewModel { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void Close_Click(object sender, RoutedEventArgs e) => Close();

        #endregion Private Methods
    }
}