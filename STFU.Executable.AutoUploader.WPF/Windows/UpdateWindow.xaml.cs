using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateViewModel ViewModel { get; set; }
        public bool RequiresRestart { get { return ViewModel?.RequiresRestart ?? false; } }

        #region Public Constructors

        public UpdateWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as UpdateViewModel;
            ViewModel.Close += (s,e) => Close();
        }

        #endregion Public Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e) => ViewModel.Start();
    }
}