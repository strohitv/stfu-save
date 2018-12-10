using STFU.Executable.AutoUploader.WPF.ViewModels;
using STFU.Lib.Youtube.Persistor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for ReleaseNotesWindow.xaml
    /// </summary>
    public partial class ReleaseNotesWindow : Window
    {
        public ReleaseNotesViewModel ViewModel { get; set; }

        public ReleaseNotesWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as ReleaseNotesViewModel;
            ViewModel.Load();
            ReleaseNotesBox.Document = ViewModel.ReleaseNotesDocument;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
