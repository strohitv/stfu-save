using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Executable.AutoUploader.WPF.ViewModels;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for AddPlannedVideoWindow.xaml
    /// </summary>
    public partial class AddPlannedVideoWindow : Window
    {
        private const string DESCRIPTION_FILE = "/Resources/AddPlannedVideoDescription.txt";

        public AddPlannedVideoViewModel ViewModel { get; set; }

        #region Public Constructors

        public AddPlannedVideoWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as AddPlannedVideoViewModel;
            ViewModel.Close += ViewModel_Close;
            double initialHeight = DescriptionBox.ActualHeight;
            DescriptionBox.Inlines.AddRange(TextToInline.LoadFile(DESCRIPTION_FILE));
            // Height += DescriptionBox.ActualHeight - initialHeight;
        }

        private void ViewModel_Close(object sender, System.EventArgs e)
        {
            DialogResult = ViewModel.Result;
            Close();
        }

        public string Filename { get { return ViewModel.Filename; } }

        #endregion Public Constructors
    }
}