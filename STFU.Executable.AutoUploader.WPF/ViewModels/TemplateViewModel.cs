using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Persistor;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class TemplateViewModel : ViewModelBase
    {
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
            set { templateContainer = value; OnPropertyChanged(); }
        }


        private IYoutubeCategoryContainer categoryContainer;

        public IYoutubeCategoryContainer CategoryContainer
        {
            get => categoryContainer;
            set { categoryContainer = value; OnPropertyChanged(); }
        }

        private IYoutubeLanguageContainer languageContainer;

        public IYoutubeLanguageContainer LanguageContainer
        {
            get => languageContainer;
            set { languageContainer = value; OnPropertyChanged(); }
        }
    }
}
