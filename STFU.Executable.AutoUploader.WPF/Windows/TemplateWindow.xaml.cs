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
        public TemplateViewModel ViewModel { get; set; }

        #region Public Constructors

        public TemplateWindow(TemplatePersistor templatePersistor, IYoutubeCategoryContainer categoryContainer, IYoutubeLanguageContainer languageContainer)
        {
            InitializeComponent();
            ViewModel = DataContext as TemplateViewModel;
            ViewModel.TemplatePersistor = templatePersistor;
            ViewModel.CategoryContainer = categoryContainer;
            ViewModel.LanguageContainer = languageContainer;
        }

        #endregion Public Constructors
    }
}