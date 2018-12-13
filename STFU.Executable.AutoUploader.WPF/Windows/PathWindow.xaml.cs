using STFU.Executable.AutoUploader.WPF.ViewModels;
using STFU.Lib.Youtube.Automation.Interfaces;
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

        public PathWindow(IPathContainer pathContainer, ITemplateContainer templateContainer)
        {
            InitializeComponent();
            ViewModel = DataContext as PathViewModel;
            ViewModel.PathContainer = pathContainer;
            ViewModel.TemplateContainer = templateContainer;
            ViewModel.RefreshPathVMs();
            ViewModel.RefreshTemplateVMs();
        }

        public PathViewModel ViewModel { get; private set; }

        #endregion Public Constructors

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ViewModel.DoAction((PathWindowAction)button.Tag);
        }
    }
}