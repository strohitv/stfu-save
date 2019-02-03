using STFU.Executable.AutoUploader.WPF.ViewModels.Internal;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Persistor;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class TemplateViewModel : ViewModelBase
    {
        #region Private Fields

        private IYoutubeCategoryContainer categoryContainer;
        private IYoutubeLanguageContainer languageContainer;
        private ITemplateContainer templateContainer;
        private TemplatePersistor templatePersistor;

        #endregion Private Fields

        #region Public Constructors

        public TemplateViewModel()
        {
            Template = new TemplateVM();
            Template.Category.CategoryRequested += Category_CategoryRequested;
            ToolCommand = new ButtonCommand<ToolAction>(UseTool);
            ThumbnailPathCommand = new ButtonCommand(OpenThumbnailPathDialog);
            PlannedVideosCommand = new ButtonCommand<ToolAction>(Template.UsePlannedVideoTool);
        }

        private void OpenThumbnailPathDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                Template.ThumbnailPath = openFileDialog.FileName;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool CanSelectedMovedDown
        {
            get => SelectedTemplate != null && Templates.IndexOf(SelectedTemplate) < Templates.Count - 1;
        }

        public bool CanSelectedMovedUp
        {
            get => SelectedTemplate != null && Templates.IndexOf(SelectedTemplate) > 0;
        }

        public IYoutubeCategoryContainer CategoryContainer
        {
            get => categoryContainer;
            set { categoryContainer = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Inline> CSharpDocumentation { get; }

        public bool HasSelection
        {
            get
            {
                return SelectedTemplate != null;
            }
        }

        public IYoutubeLanguageContainer LanguageContainer
        {
            get => languageContainer;
            set { languageContainer = value; OnPropertyChanged(); }
        }

        public ITemplate SelectedTemplate
        {
            get { return Template.Source; }
        }

        public TemplateVM Template { get; private set; }

        public ITemplateContainer TemplateContainer
        {
            get => templateContainer;
            set
            {
                templateContainer = value;
                OnPropertyChanged();
                ApplyTemplateContainer();
            }
        }

        public TemplatePersistor TemplatePersistor
        {
            get => templatePersistor;
            set { templatePersistor = value; TemplateContainer = templatePersistor.Container; OnPropertyChanged(); }
        }

        public ObservableCollection<ITemplate> Templates { get; } = new ObservableCollection<ITemplate>();
        public TimePickerVM TimePicker { get; } = new TimePickerVM();
        public ButtonCommand<ToolAction> ToolCommand { get; set; }
        public ButtonCommand ThumbnailPathCommand { get; set; }
        public ButtonCommand<ToolAction> PlannedVideosCommand { get; set; }

        public string[] WeekDayItems { get { return Enum.GetNames(typeof(DayOfWeek)); } }

        #endregion Public Properties

        #region Private Methods

        private void ApplyTemplateContainer()
        {
            Templates.Clear();
            foreach (var template in templateContainer.RegisteredTemplates)
                Templates.Add(template);
        }

        private void Category_CategoryRequested(object sender, CategoryVM.CategoryRequestEventArgs e)
        {
            if (!(sender is CategoryVM category))
                return;
            category.Source = categoryContainer.RegisteredCategories.FirstOrDefault(c => c.Id == e.Id);
        }

        private void UseTool(ToolAction tool)
        {
            SelectedTemplate.CSharpPreparationScript = "Test";
        }

        #endregion Private Methods
    }
}