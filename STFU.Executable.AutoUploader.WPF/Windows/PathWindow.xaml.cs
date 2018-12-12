using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for PathWindow.xaml
    /// </summary>
    public partial class PathWindow : Window
    {
        #region Public Constructors

        public PathWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as PathViewModel;
        }

        public PathViewModel ViewModel { get; private set; }

        #endregion Public Constructors

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ViewModel.DoAction((PathWindowAction)button.Tag);
        }

        private void ChosePath_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MarkAllVideos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}