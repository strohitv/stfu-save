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
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static AutoUploaderSettings Settings { get; internal set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.ShowReleaseNotes)
                new ReleaseNotesWindow().ShowDialog();
        }
    }
}
