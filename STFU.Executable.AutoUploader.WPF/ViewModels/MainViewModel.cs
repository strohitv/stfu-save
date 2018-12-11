using STFU.Executable.AutoUploader.WPF.Helpers;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public enum ProcessDependentActivity
        {
            Nothing,
            BackToMain,
            Close,
            Shutdown
        }

        private const string DOWNLOAD_PAGE = "https://drive.google.com/drive/folders/1kCRPLg-95PjbQKjEpj-HW7tjvzmZ87RI";
        private const string STROHI_TWITTER = "https://twitter.com/strohkoenig";
        private const string DISCORD_SERVER = "https://discord.gg/pDcw6rQ";
        private const string TUTORIAL_VIDEO = "https://www.youtube.com/watch?v=XjYvy36BrNo";
        private const string YTF_THREAD = "https://ytforum.de/index.php/Thread/19543-BETA-Strohis-Toolset-Für-Uploads-v0-1-1-Videos-automatisch-hochladen/";
        private const string LPF_THREAD = "https://letsplayforum.de/thread/175111-beta-strohis-toolset-f%C3%BCr-uploads-automatisch-videos-hochladen";

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
        TemplatePersistor templatePersistor = null;
        AccountPersistor accountPersistor = null;
        CategoryPersistor categoryPersistor = null;
        LanguagePersistor languagePersistor = null;
        AutoUploaderSettingsPersistor settingsPersistor = null;
        private bool waitForProcess;

        public bool LoggedIn
        {
            get => accountContainer.RegisteredAccounts.Count > 0;
        }

        private ProcessDependentActivity dependentActivity;

        public ProcessDependentActivity DependentActivity
        {
            get => dependentActivity;
            set
            {
                dependentActivity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ActivitySelected));
            }
        }

        public bool ActivitySelected { get { return dependentActivity != ProcessDependentActivity.Nothing; } }

        public bool WaitForProcess { get => waitForProcess; set { waitForProcess = value; OnPropertyChanged(); } }

        public YouTubeAccountViewModel YouTubeAccountVM { get; } = new YouTubeAccountViewModel();

        public void Start()
        {

        }

        public void Load()
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

        public void ChoseProcessToWaitFor()
        {
            ProcessWindow processChoser = new ProcessWindow(processContainer);
            if (processChoser.ShowDialog() == true && processChoser.ViewModel.Selected.Count > 0)
                processChoser.ViewModel.ApplyProcessSelection();
            else
                WaitForProcess = false;
        }

        public void ShowReleaseNotes()
        {
            new ReleaseNotesWindow().ShowDialog();
            settingsPersistor.Save();
        }

        public void OpenStrohiTwitter() => BrowserHelper.Open(STROHI_TWITTER);

        public void OpenTutorialVideo() => BrowserHelper.Open(TUTORIAL_VIDEO);

        public void OpenDiscordServer() => BrowserHelper.Open(DISCORD_SERVER);

        public void OpenLPFThread() => BrowserHelper.Open(LPF_THREAD);

        public void OpenYTFThread() => BrowserHelper.Open(YTF_THREAD);

        public void OpenDownloadPage() => BrowserHelper.Open(DOWNLOAD_PAGE);

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

        public void RevokeAccess()
        {
            YouTubeAccountVM.UnregisterAccount();
            accountCommunicator.RevokeAccount(accountContainer, accountContainer.RegisteredAccounts.Single());
            accountPersistor.Save();

            OnPropertyChanged(nameof(LoggedIn));
            MessageBox.Show("Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
