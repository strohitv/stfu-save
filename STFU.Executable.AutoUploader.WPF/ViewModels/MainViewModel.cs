using STFU.Executable.AutoUploader.WPF.Windows;
using STFU.Lib.Youtube;
using STFU.Lib.Youtube.Automation;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Persistor;
using STFU.Lib.Youtube.Persistor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        IPathContainer pathContainer = new PathContainer();
        ITemplateContainer templateContainer = new TemplateContainer();
        IYoutubeClientContainer clientContainer = new YoutubeClientContainer();
        IYoutubeAccountContainer accountContainer = new YoutubeAccountContainer();
        IYoutubeCategoryContainer categoryContainer = new YoutubeCategoryContainer();
        IYoutubeLanguageContainer languageContainer = new YoutubeLanguageContainer();
        IYoutubeAccountCommunicator accountCommunicator = new YoutubeAccountCommunicator();
        IAutomationUploader autoUploader = new AutomationUploader();
        IProcessContainer processContainer = new ProcessContainer();

        public static AutoUploaderSettings AutoUploaderSettings { get; } = new AutoUploaderSettings();

        PathPersistor pathPersistor = null;

        public void RevokeAccess()
        {
            YouTubeAccountVM.UnregisterAccount();
            accountCommunicator.RevokeAccount(accountContainer, accountContainer.RegisteredAccounts.Single());
            accountPersistor.Save();

            OnPropertyChanged(nameof(LoggedIn));
            MessageBox.Show("Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        TemplatePersistor templatePersistor = null;
        AccountPersistor accountPersistor = null;
        CategoryPersistor categoryPersistor = null;
        LanguagePersistor languagePersistor = null;
        AutoUploaderSettingsPersistor settingsPersistor = null;

        public bool LoggedIn
        {
            get => accountContainer.RegisteredAccounts.Count > 0;
        }

        public YouTubeAccountViewModel YouTubeAccountVM { get; } = new YouTubeAccountViewModel();

        public override void Load()
        {
            IYoutubeClient client = new YoutubeClient("812042275170-db6cf7ujravcq2l7vhu7gb7oodgii3e4.apps.googleusercontent.com",
                "cKUCRQz0sE4UUmvUHW6qckbP",
                "Strohis Toolset Für Uploads", false);
            clientContainer.RegisterClient(client);

            if (!Directory.Exists("./settings"))
            {
                Directory.CreateDirectory("./settings");
            }

            pathPersistor = new PathPersistor(pathContainer, "./settings/paths.json");
            pathPersistor.Load();

            templatePersistor = new TemplatePersistor(templateContainer, "./settings/templates.json");
            templatePersistor.Load();

            accountPersistor = new AccountPersistor(accountContainer, "./settings/accounts.json", clientContainer);
            accountPersistor.Load();

            categoryPersistor = new CategoryPersistor(categoryContainer, "./settings/categories.json");
            categoryPersistor.Load();

            languagePersistor = new LanguagePersistor(languageContainer, "./settings/languages.json");
            languagePersistor.Load();

            settingsPersistor = new AutoUploaderSettingsPersistor(AutoUploaderSettings, "./settings/autouploader.json");
            settingsPersistor.Load();
        }

        public void ConnectToYouTube()
        {
            var client = clientContainer.RegisteredClients.FirstOrDefault();

            var addWindow = new AddAccountWindow(
                accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, YoutubeScope.Manage).AbsoluteUri,
                accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Localhost, YoutubeScope.Manage).AbsoluteUri);

            if (addWindow.ShowDialog() == true)
            {
                IYoutubeAccount account = accountCommunicator.ConnectToAccount(addWindow.ViewModel.AuthToken, client, YoutubeRedirectUri.Code);
                if (account == null)
                    return;

                YouTubeAccountVM.RegisterAccount(account);
                accountContainer.RegisterAccount(account);
                var loader = new LanguageCategoryLoader(accountContainer);
                var categories = loader.Categories;

                categoryContainer.UnregisterAllCategories();
                foreach (var category in categories)
                    categoryContainer.RegisterCategory(category);

                var languages = loader.Languages;
                languageContainer.UnregisterAllLanguages();
                foreach (var language in languages)
                    languageContainer.RegisterLanguage(language);

                // Account speichern! und so! - strohi 2018
                accountPersistor.Save();
                categoryPersistor.Save();
                languagePersistor.Save();

                MessageBox.Show("Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButton.OK, MessageBoxImage.Information);
                ActivateAccountLink();
            }
        }

        private void ActivateAccountLink() => OnPropertyChanged(nameof(LoggedIn));

    }
}
