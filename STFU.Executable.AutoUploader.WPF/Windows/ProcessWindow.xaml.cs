using STFU.Executable.AutoUploader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        public ProcessViewModel ViewModel { get; set; }

        public ProcessWindow(Lib.Youtube.Automation.Interfaces.IProcessContainer processContainer)
        {
            InitializeComponent();
            ViewModel = DataContext as ProcessViewModel;
            ViewModel.ProcessContainer = processContainer;
            ViewModel.RefreshAllProcessesAsync();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e) => ViewModel.RefreshAllProcessesAsync();

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ProcessCheck_Click(object sender, RoutedEventArgs e) => ViewModel.RefreshSelectedProcesses();
    }
}
