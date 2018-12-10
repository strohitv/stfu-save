using STFU.Executable.AutoUploader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public AddAccountViewModel ViewModel { get; set; }

        public AddAccountWindow(string externalCodeUri, string localHostUri)
        {
            InitializeComponent();
            ViewModel = DataContext as AddAccountViewModel;
            ViewModel.ExternalCodeUri = externalCodeUri;
            ViewModel.LocalHostUri = localHostUri;
        }

        private void ExternalLink_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OpenExternalUrl();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = ViewModel.SignIn();
            Close();
        }
    }
}
