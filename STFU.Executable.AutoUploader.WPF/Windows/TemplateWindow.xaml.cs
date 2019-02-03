using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Executable.AutoUploader.WPF.ViewModels;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Persistor;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for TemplateWindow.xaml
    /// </summary>
    public partial class TemplateWindow : Window
    {
        public const string SCRIPT_DOCUMENTATION_FILE = "/Resources/ScriptingDocumentation.txt";

        public TemplateViewModel ViewModel { get; set; }

        #region Public Constructors

        public TemplateWindow(TemplatePersistor templatePersistor, IYoutubeCategoryContainer categoryContainer, IYoutubeLanguageContainer languageContainer)
        {
            InitializeComponent();
            ViewModel = DataContext as TemplateViewModel;
            ViewModel.TemplatePersistor = templatePersistor;
            ViewModel.CategoryContainer = categoryContainer;
            ViewModel.LanguageContainer = languageContainer;
            CodeDocumentationBox.Inlines.AddRange(TextToInline.LoadFile(SCRIPT_DOCUMENTATION_FILE));
        }

        #endregion Public Constructors

        private void TimePicker_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => ViewModel.TimePicker.ItemSelected(sender, e);
    }
}