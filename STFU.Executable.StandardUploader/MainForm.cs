using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.GUI.Forms;
using STFU.Lib.Youtube;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Enums;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model;
using STFU.Lib.Youtube.Persistor;

namespace STFU.Executable.StandardUploader.Forms
{
	public partial class MainForm : Form
	{
		IYoutubeClientContainer clientContainer = new YoutubeClientContainer();
		IYoutubeAccountCommunicator accountCommunicator = new YoutubeAccountCommunicator();
		IYoutubeAccountContainer accountContainer = new YoutubeAccountContainer();
		IYoutubeCategoryContainer categoryContainer = new YoutubeCategoryContainer();
		IYoutubeLanguageContainer languageContainer = new YoutubeLanguageContainer();

		IYoutubeUploader uploader = new YoutubeUploader();

		AccountPersistor accountPersistor = null;
		CategoryPersistor categoryPersistor = null;
		LanguagePersistor languagePersistor = null;

		public IYoutubeUploader Uploader { get => uploader; set => uploader = value; }

		public MainForm()
		{
			InitializeComponent();

			jobQueue.Uploader = Uploader;

			Text = $"Strohis Toolset Für Uploads - StandardUploader v{ProductVersion} [BETA]";

			IYoutubeClient client = new YoutubeClient("812042275170-db6cf7ujravcq2l7vhu7gb7oodgii3e4.apps.googleusercontent.com",
				"cKUCRQz0sE4UUmvUHW6qckbP",
				"Strohis Toolset Für Uploads", false);
			clientContainer.RegisterClient(client);

			if (!Directory.Exists("./settings"))
			{
				Directory.CreateDirectory("./settings");
			}

			accountPersistor = new AccountPersistor(accountContainer, "./settings/standard-accounts.json", clientContainer);
			accountPersistor.Load();

			categoryPersistor = new CategoryPersistor(categoryContainer, "./settings/standard-categories.json");
			categoryPersistor.Load();

			languagePersistor = new LanguagePersistor(languageContainer, "./settings/standard-languages.json");
			languagePersistor.Load();

			Uploader.PropertyChanged += Uploader_PropertyChanged;
		}

		private void Uploader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			throw new System.NotImplementedException();
		}

		private void ConnectToYoutube()
		{
			mainTableLayoutPanel.Enabled = false;

			var client = clientContainer.RegisteredClients.FirstOrDefault();

			var addForm = new AddAccountForm();
			addForm.ExternalCodeUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Code, YoutubeScope.Manage).AbsoluteUri;
			addForm.LocalHostUrl = accountCommunicator.CreateAuthUri(client, YoutubeRedirectUri.Localhost, YoutubeScope.Manage).AbsoluteUri;

			var result = addForm.ShowDialog(this);
			IYoutubeAccount account = null;
			if (result == DialogResult.OK
				&& (account = accountCommunicator.ConnectToAccount(addForm.AuthToken, client, YoutubeRedirectUri.Code)) != null)
			{
				accountContainer.RegisterAccount(account);

				var loader = new LanguageCategoryLoader(accountContainer);
				var categories = loader.Categories;

				categoryContainer.UnregisterAllCategories();
				foreach (var category in categories)
				{
					categoryContainer.RegisterCategory(category);
				}

				var languages = loader.Languages;

				languageContainer.UnregisterAllLanguages();
				foreach (var language in languages)
				{
					languageContainer.RegisterLanguage(language);
				}

				// Account speichern! Und so!
				accountPersistor.Save();
				categoryPersistor.Save();
				languagePersistor.Save();

				MessageBox.Show(this, "Der Uploader wurde erfolgreich mit dem Account verbunden!", "Account verbunden!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			mainTableLayoutPanel.Enabled = true;
		}
	}
}
