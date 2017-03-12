namespace STFU.AutoUploader
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tlpSettings = new System.Windows.Forms.TableLayoutPanel();
			this.btnConnectYoutubeAccount = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.lvSelectedPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblCurrentLoggedIn = new System.Windows.Forms.Label();
			this.lnklblCurrentLoggedIn = new System.Windows.Forms.LinkLabel();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.youtubeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verbindenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verbindungTrennenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templatesVerwaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alleTemplatesLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pfadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pfadeVerwaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allePfadeLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abgebrochenerUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abgebrochenenUploadAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abgebrochenenUploadLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bgwCreateUploader = new System.ComponentModel.BackgroundWorker();
			this.tlpSettings.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpSettings
			// 
			this.tlpSettings.AutoSize = true;
			this.tlpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpSettings.ColumnCount = 9;
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.Controls.Add(this.btnConnectYoutubeAccount, 5, 4);
			this.tlpSettings.Controls.Add(this.btnStart, 7, 4);
			this.tlpSettings.Controls.Add(this.lvSelectedPaths, 1, 2);
			this.tlpSettings.Controls.Add(this.lblCurrentLoggedIn, 1, 4);
			this.tlpSettings.Controls.Add(this.lnklblCurrentLoggedIn, 3, 4);
			this.tlpSettings.Controls.Add(this.mainMenu, 0, 0);
			this.tlpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpSettings.Enabled = false;
			this.tlpSettings.Location = new System.Drawing.Point(0, 0);
			this.tlpSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tlpSettings.Name = "tlpSettings";
			this.tlpSettings.RowCount = 6;
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.Size = new System.Drawing.Size(897, 397);
			this.tlpSettings.TabIndex = 0;
			// 
			// btnConnectYoutubeAccount
			// 
			this.btnConnectYoutubeAccount.AutoSize = true;
			this.btnConnectYoutubeAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnConnectYoutubeAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConnectYoutubeAccount.Location = new System.Drawing.Point(606, 354);
			this.btnConnectYoutubeAccount.Margin = new System.Windows.Forms.Padding(0);
			this.btnConnectYoutubeAccount.Name = "btnConnectYoutubeAccount";
			this.btnConnectYoutubeAccount.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.btnConnectYoutubeAccount.Size = new System.Drawing.Size(190, 33);
			this.btnConnectYoutubeAccount.TabIndex = 8;
			this.btnConnectYoutubeAccount.Text = "Mit Youtube verbinden";
			this.btnConnectYoutubeAccount.UseVisualStyleBackColor = true;
			this.btnConnectYoutubeAccount.Click += new System.EventHandler(this.btnConnectYoutubeAccountClick);
			// 
			// btnStart
			// 
			this.btnStart.AutoSize = true;
			this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnStart.Enabled = false;
			this.btnStart.Location = new System.Drawing.Point(806, 354);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Name = "btnStart";
			this.btnStart.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.btnStart.Size = new System.Drawing.Size(81, 33);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Start!";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStartClick);
			// 
			// lvSelectedPaths
			// 
			this.lvSelectedPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath,
            this.chFilter,
            this.chRecursive});
			this.tlpSettings.SetColumnSpan(this.lvSelectedPaths, 7);
			this.lvSelectedPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSelectedPaths.FullRowSelect = true;
			this.lvSelectedPaths.GridLines = true;
			this.lvSelectedPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSelectedPaths.Location = new System.Drawing.Point(10, 38);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.ShowGroups = false;
			this.lvSelectedPaths.Size = new System.Drawing.Size(877, 306);
			this.lvSelectedPaths.TabIndex = 9;
			this.lvSelectedPaths.UseCompatibleStateImageBehavior = false;
			this.lvSelectedPaths.View = System.Windows.Forms.View.Details;
			// 
			// chPath
			// 
			this.chPath.Text = "Pfad";
			this.chPath.Width = 500;
			// 
			// chFilter
			// 
			this.chFilter.Text = "Filter";
			this.chFilter.Width = 150;
			// 
			// chRecursive
			// 
			this.chRecursive.Text = "Unterverzeichnisse";
			this.chRecursive.Width = 150;
			// 
			// lblCurrentLoggedIn
			// 
			this.lblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLoggedIn.AutoSize = true;
			this.lblCurrentLoggedIn.Location = new System.Drawing.Point(10, 362);
			this.lblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lblCurrentLoggedIn.Name = "lblCurrentLoggedIn";
			this.lblCurrentLoggedIn.Size = new System.Drawing.Size(87, 17);
			this.lblCurrentLoggedIn.TabIndex = 10;
			this.lblCurrentLoggedIn.Text = "Angemeldet:";
			this.lblCurrentLoggedIn.Visible = false;
			this.lblCurrentLoggedIn.Click += new System.EventHandler(this.lblCurrentLoggedIn_Click);
			// 
			// lnklblCurrentLoggedIn
			// 
			this.lnklblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lnklblCurrentLoggedIn.Location = new System.Drawing.Point(107, 360);
			this.lnklblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lnklblCurrentLoggedIn.Name = "lnklblCurrentLoggedIn";
			this.lnklblCurrentLoggedIn.Size = new System.Drawing.Size(489, 21);
			this.lnklblCurrentLoggedIn.TabIndex = 11;
			this.lnklblCurrentLoggedIn.TabStop = true;
			this.lnklblCurrentLoggedIn.Text = "link";
			this.lnklblCurrentLoggedIn.Visible = false;
			this.lnklblCurrentLoggedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCurrentLoggedInLinkClicked);
			// 
			// mainMenu
			// 
			this.mainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.mainMenu, 9);
			this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.youtubeAccountToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.pfadeToolStripMenuItem,
            this.abgebrochenerUploadToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(897, 28);
			this.mainMenu.TabIndex = 13;
			this.mainMenu.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.dateiToolStripMenuItem.Text = "Datei";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
			this.beendenToolStripMenuItem.Text = "Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItemClick);
			// 
			// youtubeAccountToolStripMenuItem
			// 
			this.youtubeAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verbindenToolStripMenuItem,
            this.verbindungTrennenToolStripMenuItem});
			this.youtubeAccountToolStripMenuItem.Name = "youtubeAccountToolStripMenuItem";
			this.youtubeAccountToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
			this.youtubeAccountToolStripMenuItem.Text = "Youtube-Account";
			// 
			// verbindenToolStripMenuItem
			// 
			this.verbindenToolStripMenuItem.Name = "verbindenToolStripMenuItem";
			this.verbindenToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
			this.verbindenToolStripMenuItem.Text = "Verbinden";
			// 
			// verbindungTrennenToolStripMenuItem
			// 
			this.verbindungTrennenToolStripMenuItem.Name = "verbindungTrennenToolStripMenuItem";
			this.verbindungTrennenToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
			this.verbindungTrennenToolStripMenuItem.Text = "Verbindung trennen";
			// 
			// templatesToolStripMenuItem
			// 
			this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templatesVerwaltenToolStripMenuItem,
            this.alleTemplatesLöschenToolStripMenuItem});
			this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
			this.templatesToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
			this.templatesToolStripMenuItem.Text = "Templates";
			// 
			// templatesVerwaltenToolStripMenuItem
			// 
			this.templatesVerwaltenToolStripMenuItem.Name = "templatesVerwaltenToolStripMenuItem";
			this.templatesVerwaltenToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
			this.templatesVerwaltenToolStripMenuItem.Text = "Templates verwalten";
			// 
			// alleTemplatesLöschenToolStripMenuItem
			// 
			this.alleTemplatesLöschenToolStripMenuItem.Name = "alleTemplatesLöschenToolStripMenuItem";
			this.alleTemplatesLöschenToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
			this.alleTemplatesLöschenToolStripMenuItem.Text = "Alle Templates löschen";
			// 
			// pfadeToolStripMenuItem
			// 
			this.pfadeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pfadeVerwaltenToolStripMenuItem,
            this.allePfadeLöschenToolStripMenuItem});
			this.pfadeToolStripMenuItem.Name = "pfadeToolStripMenuItem";
			this.pfadeToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.pfadeToolStripMenuItem.Text = "Pfade";
			// 
			// pfadeVerwaltenToolStripMenuItem
			// 
			this.pfadeVerwaltenToolStripMenuItem.Name = "pfadeVerwaltenToolStripMenuItem";
			this.pfadeVerwaltenToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
			this.pfadeVerwaltenToolStripMenuItem.Text = "Pfade verwalten";
			this.pfadeVerwaltenToolStripMenuItem.Click += new System.EventHandler(this.pfadeVerwaltenToolStripMenuItemClick);
			// 
			// allePfadeLöschenToolStripMenuItem
			// 
			this.allePfadeLöschenToolStripMenuItem.Name = "allePfadeLöschenToolStripMenuItem";
			this.allePfadeLöschenToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
			this.allePfadeLöschenToolStripMenuItem.Text = "Alle Pfade löschen";
			this.allePfadeLöschenToolStripMenuItem.Click += new System.EventHandler(this.allePfadeLöschenToolStripMenuItemClick);
			// 
			// abgebrochenerUploadToolStripMenuItem
			// 
			this.abgebrochenerUploadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abgebrochenenUploadAnzeigenToolStripMenuItem,
            this.abgebrochenenUploadLöschenToolStripMenuItem});
			this.abgebrochenerUploadToolStripMenuItem.Name = "abgebrochenerUploadToolStripMenuItem";
			this.abgebrochenerUploadToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
			this.abgebrochenerUploadToolStripMenuItem.Text = "Unvollendeter Upload";
			// 
			// abgebrochenenUploadAnzeigenToolStripMenuItem
			// 
			this.abgebrochenenUploadAnzeigenToolStripMenuItem.Name = "abgebrochenenUploadAnzeigenToolStripMenuItem";
			this.abgebrochenenUploadAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
			this.abgebrochenenUploadAnzeigenToolStripMenuItem.Text = "Unvollendeten Upload anzeigen";
			this.abgebrochenenUploadAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.abgebrochenenUploadAnzeigenToolStripMenuItemClick);
			// 
			// abgebrochenenUploadLöschenToolStripMenuItem
			// 
			this.abgebrochenenUploadLöschenToolStripMenuItem.Name = "abgebrochenenUploadLöschenToolStripMenuItem";
			this.abgebrochenenUploadLöschenToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
			this.abgebrochenenUploadLöschenToolStripMenuItem.Text = "Unvollendeten Upload löschen";
			this.abgebrochenenUploadLöschenToolStripMenuItem.Click += new System.EventHandler(this.abgebrochenenUploadLöschenToolStripMenuItemClick);
			// 
			// bgwCreateUploader
			// 
			this.bgwCreateUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCreateUploaderDoWork);
			this.bgwCreateUploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCreateUploaderRunWorkerCompleted);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(897, 397);
			this.Controls.Add(this.tlpSettings);
			this.MainMenuStrip = this.mainMenu;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Strohis Toolset Für Uploads - AutoUploader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tlpSettings.ResumeLayout(false);
			this.tlpSettings.PerformLayout();
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpSettings;
		private System.Windows.Forms.Button btnConnectYoutubeAccount;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ListView lvSelectedPaths;
		private System.Windows.Forms.ColumnHeader chPath;
		private System.Windows.Forms.ColumnHeader chFilter;
		private System.ComponentModel.BackgroundWorker bgwCreateUploader;
		private System.Windows.Forms.Label lblCurrentLoggedIn;
		private System.Windows.Forms.LinkLabel lnklblCurrentLoggedIn;
		private System.Windows.Forms.ColumnHeader chRecursive;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem templatesVerwaltenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem alleTemplatesLöschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abgebrochenerUploadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abgebrochenenUploadAnzeigenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abgebrochenenUploadLöschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem youtubeAccountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verbindenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verbindungTrennenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pfadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pfadeVerwaltenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allePfadeLöschenToolStripMenuItem;
	}
}

