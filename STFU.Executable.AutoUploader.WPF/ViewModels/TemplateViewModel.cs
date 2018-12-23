using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.Executable.AutoUploader.WPF.ViewModels.Internal;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Persistor;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class TemplateViewModel : ViewModelBase
    {
        public string[] WeekDayItems { get { return Enum.GetNames(typeof(SelectableDayOfWeek)); } }

        public TimePickerVM TimePicker { get; } = new TimePickerVM();

        public TemplateVM Template { get; } = new TemplateVM();

        public ObservableCollection<ITemplate> Templates { get; } = new ObservableCollection<ITemplate>();

        private TemplatePersistor templatePersistor;

        public TemplatePersistor TemplatePersistor
        {
            get => templatePersistor;
            set { templatePersistor = value; TemplateContainer = templatePersistor.Container; OnPropertyChanged(); }
        }

        private ITemplateContainer templateContainer;

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

        private IYoutubeCategoryContainer categoryContainer;

        public IYoutubeCategoryContainer CategoryContainer
        {
            get => categoryContainer;
            set { categoryContainer = value; OnPropertyChanged(); }
        }

        private IYoutubeLanguageContainer languageContainer;


        private void ApplyTemplateContainer()
        {
            Templates.Clear();
            foreach (var template in templateContainer.RegisteredTemplates)
                Templates.Add(template);
        }

        public IYoutubeLanguageContainer LanguageContainer
        {
            get => languageContainer;
            set { languageContainer = value; OnPropertyChanged(); }
        }
    }
}
