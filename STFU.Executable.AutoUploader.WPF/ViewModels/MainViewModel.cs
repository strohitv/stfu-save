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
using System.IO;
using System.Linq;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Private Fields

        private IYoutubeAccountCommunicator accountCommunicator = new YoutubeAccountCommunicator();
        private IYoutubeAccountContainer accountContainer = new YoutubeAccountContainer();
        private AccountPersistor accountPersistor = null;
        private IAutomationUploader autoUploader = new AutomationUploader();
        private IYoutubeCategoryContainer categoryContainer = new YoutubeCategoryContainer();
        private CategoryPersistor categoryPersistor = null;
        private IYoutubeClientContainer clientContainer = new YoutubeClientContainer();
        private FinishActivity dependentActivity;
        private HelpViewModel help = new HelpViewModel();
        private IYoutubeLanguageContainer languageContainer = new YoutubeLanguageContainer();

        private LanguagePersistor languagePersistor = null;

        private IPathContainer pathContainer = new PathContainer();

        private PathPersistor pathPersistor = null;

        private IProcessContainer processContainer = new ProcessContainer();

        private AutoUploaderSettingsPersistor settingsPersistor = null;

        private ITemplateContainer templateContainer = new TemplateContainer();

        private TemplatePersistor templatePersistor = null;

        private bool waitForProcess;

        #endregion Private Fields

        #region Public Constructors

        public MainViewModel()
        {
            help.ShowFeatures += (e, a) => ShowReleaseNotes();
            HelpActionCommand = new ButtonCommand<HelpLinkAction>(help.OpenHelpLink);
            StartCommand = new ButtonCommand(Start);
            ChooseProcessCommand = new ButtonCommand(ChooseProcessToWaitFor);
            ConnectAccountCommand = new ButtonCommand(ConnectToYouTube);
            DisconnectAccountCommand = new ButtonCommand(RevokeAccess);
            PathSettingsCommand = new ButtonCommand(PathSettings);
            ChannelLinkCommand = new ButtonCommand(YouTubeAccountVM.OpenChannelInBrowser);
            TemplateSettingsCommand = new ButtonCommand(TemplateSettings);
        }

        #endregion Public Constructors

        #region Public Enums

        public enum FinishActivity
        {
            DoNothing,
            BackToMain,
            Close,
            Shutdown
        }

        #endregion Public Enums

        #region Public Properties

        public static AutoUploaderSettings AutoUploaderSettings { get; } = new AutoUploaderSettings();

        public static bool ShowReleaseNotesOnStartup { get; set; }

        public bool ActivitySelected { get { return dependentActivity != FinishActivity.DoNothing; } }

        public ButtonCommand ChannelLinkCommand { get; set; }

        public ButtonCommand TemplateSettingsCommand { get; private set; }

        public ButtonCommand ChooseProcessCommand { get; set; }

        public ButtonCommand ConnectAccountCommand { get; set; }

        public FinishActivity DependentActivity
        {
            get => dependentActivity;
            set
            {
                dependentActivity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ActivitySelected));
            }
        }

        public ButtonCommand DisconnectAccountCommand { get; set; }

        public ButtonCommand<HelpLinkAction> HelpActionCommand { get; set; }

        public bool LoggedIn
        {
            get => accountContainer.RegisteredAccounts.Count > 0;
        }

        public ButtonCommand PathSettingsCommand { get; set; }

        public ButtonCommand StartCommand { get; set; }

        public bool WaitForProcess { get => waitForProcess; set { waitForProcess = value; OnPropertyChanged(); } }

        public YouTubeAccountViewModel YouTubeAccountVM { get; } = new YouTubeAccountViewModel();

        #endregion Public Properties

        #region Public Methods

        public void ChangedDependentActivity()
        {
            if (DependentActivity != FinishActivity.DoNothing)
                return;

            processContainer.RemoveAllProcesses();
            WaitForProcess = false;
        }

        public void ChooseProcessToWaitFor()
        {
            ProcessWindow processChooser = new ProcessWindow(processContainer);
            if (processChooser.ShowDialog() == true && processChooser.ViewModel.Selected.Count > 0)
                processChooser.ViewModel.ApplyProcessSelection();
            else
                WaitForProcess = false;
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

        public void HelpItemClicked(HelpLinkAction action) => help.OpenHelpLink(action);

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

        public void PathSettings()
        {
            PathWindow pathWindow = new PathWindow(pathContainer, templateContainer);
            pathWindow.ShowDialog();
            pathPersistor.Save();
        }

        public void TemplateSettings()
        {
            TemplateWindow templateWindow = new TemplateWindow(templatePersistor, categoryContainer, languageContainer);
            templateWindow.ShowDialog();
            templatePersistor.Save();
        }

        public void RevokeAccess()
        {
            YouTubeAccountVM.UnregisterAccount();
            accountCommunicator.RevokeAccount(accountContainer, accountContainer.RegisteredAccounts.Single());
            accountPersistor.Save();

            OnPropertyChanged(nameof(LoggedIn));
            MessageBox.Show("Die Verbindung zum Youtube-Account wurde erfolgreich getrennt.", "Verbindung getrennt!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowReleaseNotes()
        {
            new ReleaseNotesWindow().ShowDialog();
            settingsPersistor.Save();
        }

        public void Shutdown()
        {
            autoUploader?.Cancel();
            pathPersistor.Save();
            templatePersistor.Save();
        }

        public void Start()
        {
        }

        public void Startup()
        {
            if (File.Exists("stfu-updater.exe"))
            {
                try
                {
                    File.Delete("stfu-updater.exe");
                }
                catch (Exception) { }
            }

            if (AutoUploaderSettings.ShowReleaseNotes || ShowReleaseNotesOnStartup)
                ShowReleaseNotes();

            var updateWindow = new UpdateWindow();
            updateWindow.ShowDialog();
            if (updateWindow.RequiresRestart)
            {
                OnClose();
                return;
            }

            if (accountContainer.RegisteredAccounts.Count > 0)
                YouTubeAccountVM.RegisterAccount(accountContainer.RegisteredAccounts.FirstOrDefault());
            ActivateAccountLink();
        }

        #endregion Public Methods

        #region Private Methods

        private void ActivateAccountLink() => OnPropertyChanged(nameof(LoggedIn));

        #endregion Private Methods
    }
}