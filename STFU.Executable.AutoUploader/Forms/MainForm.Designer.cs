namespace STFU.Executable.AutoUploader.Forms
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
			this.btnStart = new System.Windows.Forms.Button();
			this.lvSelectedPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTemplate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbInactive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblCurrentLoggedIn = new System.Windows.Forms.Label();
			this.lnklblCurrentLoggedIn = new System.Windows.Forms.LinkLabel();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verwaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.youtubeAccountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.verbindenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.verbindungLösenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pfadeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.unvollständigerUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tutorialVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.discordServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.threadImLPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.threadImYTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.strohiAufTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.downloadSeiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblFinishAction = new System.Windows.Forms.Label();
			this.cmbbxFinishAction = new System.Windows.Forms.ComboBox();
			this.chbChoseProcesses = new System.Windows.Forms.CheckBox();
			this.btnChoseProcs = new System.Windows.Forms.Button();
			this.bgwCreateUploader = new System.ComponentModel.BackgroundWorker();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.neueFunktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tlpSettings.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpSettings
			// 
			this.tlpSettings.AutoSize = true;
			this.tlpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpSettings.ColumnCount = 15;
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
			this.tlpSettings.Controls.Add(this.btnStart, 13, 4);
			this.tlpSettings.Controls.Add(this.lvSelectedPaths, 1, 2);
			this.tlpSettings.Controls.Add(this.lblCurrentLoggedIn, 1, 4);
			this.tlpSettings.Controls.Add(this.lnklblCurrentLoggedIn, 3, 4);
			this.tlpSettings.Controls.Add(this.mainMenu, 0, 0);
			this.tlpSettings.Controls.Add(this.lblFinishAction, 5, 4);
			this.tlpSettings.Controls.Add(this.cmbbxFinishAction, 7, 4);
			this.tlpSettings.Controls.Add(this.chbChoseProcesses, 9, 4);
			this.tlpSettings.Controls.Add(this.btnChoseProcs, 11, 4);
			this.tlpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpSettings.Enabled = false;
			this.tlpSettings.Location = new System.Drawing.Point(0, 0);
			this.tlpSettings.Margin = new System.Windows.Forms.Padding(2);
			this.tlpSettings.Name = "tlpSettings";
			this.tlpSettings.RowCount = 6;
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.Size = new System.Drawing.Size(979, 323);
			this.tlpSettings.TabIndex = 0;
			// 
			// btnStart
			// 
			this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnStart.Enabled = false;
			this.btnStart.Location = new System.Drawing.Point(902, 286);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Name = "btnStart";
			this.btnStart.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.btnStart.Size = new System.Drawing.Size(64, 27);
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
            this.chTemplate,
            this.chRecursive,
            this.chHidden,
            this.cbInactive});
			this.tlpSettings.SetColumnSpan(this.lvSelectedPaths, 13);
			this.lvSelectedPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSelectedPaths.FullRowSelect = true;
			this.lvSelectedPaths.GridLines = true;
			this.lvSelectedPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSelectedPaths.Location = new System.Drawing.Point(10, 34);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.ShowGroups = false;
			this.lvSelectedPaths.Size = new System.Drawing.Size(956, 242);
			this.lvSelectedPaths.TabIndex = 9;
			this.lvSelectedPaths.UseCompatibleStateImageBehavior = false;
			this.lvSelectedPaths.View = System.Windows.Forms.View.Details;
			// 
			// chPath
			// 
			this.chPath.Text = "Pfad";
			this.chPath.Width = 350;
			// 
			// chFilter
			// 
			this.chFilter.Text = "Filter";
			this.chFilter.Width = 150;
			// 
			// chTemplate
			// 
			this.chTemplate.Text = "Template";
			this.chTemplate.Width = 150;
			// 
			// chRecursive
			// 
			this.chRecursive.Text = "Unterverzeichnisse";
			this.chRecursive.Width = 150;
			// 
			// chHidden
			// 
			this.chHidden.Text = "Versteckte";
			this.chHidden.Width = 80;
			// 
			// cbInactive
			// 
			this.cbInactive.Text = "Inaktiv";
			// 
			// lblCurrentLoggedIn
			// 
			this.lblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLoggedIn.AutoSize = true;
			this.lblCurrentLoggedIn.Location = new System.Drawing.Point(10, 293);
			this.lblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lblCurrentLoggedIn.Name = "lblCurrentLoggedIn";
			this.lblCurrentLoggedIn.Size = new System.Drawing.Size(66, 13);
			this.lblCurrentLoggedIn.TabIndex = 10;
			this.lblCurrentLoggedIn.Text = "Angemeldet:";
			this.lblCurrentLoggedIn.Visible = false;
			// 
			// lnklblCurrentLoggedIn
			// 
			this.lnklblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lnklblCurrentLoggedIn.Location = new System.Drawing.Point(86, 293);
			this.lnklblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lnklblCurrentLoggedIn.Name = "lnklblCurrentLoggedIn";
			this.lnklblCurrentLoggedIn.Size = new System.Drawing.Size(271, 13);
			this.lnklblCurrentLoggedIn.TabIndex = 11;
			this.lnklblCurrentLoggedIn.TabStop = true;
			this.lnklblCurrentLoggedIn.Text = "link";
			this.lnklblCurrentLoggedIn.Visible = false;
			this.lnklblCurrentLoggedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCurrentLoggedInLinkClicked);
			// 
			// mainMenu
			// 
			this.mainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.mainMenu, 15);
			this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.verwaltenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.mainMenu.Size = new System.Drawing.Size(979, 24);
			this.mainMenu.TabIndex = 13;
			this.mainMenu.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.dateiToolStripMenuItem.Text = "Datei";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			this.beendenToolStripMenuItem.Text = "Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItemClick);
			// 
			// verwaltenToolStripMenuItem
			// 
			this.verwaltenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youtubeAccountToolStripMenuItem1,
            this.templatesToolStripMenuItem1,
            this.pfadeToolStripMenuItem1,
            this.unvollständigerUploadToolStripMenuItem});
			this.verwaltenToolStripMenuItem.Name = "verwaltenToolStripMenuItem";
			this.verwaltenToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.verwaltenToolStripMenuItem.Text = "Verwalten";
			// 
			// youtubeAccountToolStripMenuItem1
			// 
			this.youtubeAccountToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verbindenToolStripMenuItem1,
            this.verbindungLösenToolStripMenuItem});
			this.youtubeAccountToolStripMenuItem1.Name = "youtubeAccountToolStripMenuItem1";
			this.youtubeAccountToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
			this.youtubeAccountToolStripMenuItem1.Text = "Youtube-Account";
			// 
			// verbindenToolStripMenuItem1
			// 
			this.verbindenToolStripMenuItem1.Name = "verbindenToolStripMenuItem1";
			this.verbindenToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
			this.verbindenToolStripMenuItem1.Text = "Verbinden";
			this.verbindenToolStripMenuItem1.Click += new System.EventHandler(this.verbindenToolStripMenuItem1_Click);
			// 
			// verbindungLösenToolStripMenuItem
			// 
			this.verbindungLösenToolStripMenuItem.Name = "verbindungLösenToolStripMenuItem";
			this.verbindungLösenToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.verbindungLösenToolStripMenuItem.Text = "Verbindung lösen";
			this.verbindungLösenToolStripMenuItem.Click += new System.EventHandler(this.verbindungLösenToolStripMenuItem_Click);
			// 
			// templatesToolStripMenuItem1
			// 
			this.templatesToolStripMenuItem1.Name = "templatesToolStripMenuItem1";
			this.templatesToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
			this.templatesToolStripMenuItem1.Text = "Templates";
			this.templatesToolStripMenuItem1.Click += new System.EventHandler(this.templatesToolStripMenuItem1Click);
			// 
			// pfadeToolStripMenuItem1
			// 
			this.pfadeToolStripMenuItem1.Name = "pfadeToolStripMenuItem1";
			this.pfadeToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
			this.pfadeToolStripMenuItem1.Text = "Pfade";
			this.pfadeToolStripMenuItem1.Click += new System.EventHandler(this.pfadeToolStripMenuItem1_Click);
			// 
			// unvollständigerUploadToolStripMenuItem
			// 
			this.unvollständigerUploadToolStripMenuItem.Name = "unvollständigerUploadToolStripMenuItem";
			this.unvollständigerUploadToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			this.unvollständigerUploadToolStripMenuItem.Text = "Unvollständiger Upload";
			this.unvollständigerUploadToolStripMenuItem.Visible = false;
			this.unvollständigerUploadToolStripMenuItem.Click += new System.EventHandler(this.unvollständigerUploadToolStripMenuItem_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueFunktionenToolStripMenuItem,
            this.toolStripSeparator2,
            this.tutorialVideoToolStripMenuItem,
            this.discordServerToolStripMenuItem,
            this.threadImLPFToolStripMenuItem,
            this.threadImYTFToolStripMenuItem,
            this.strohiAufTwitterToolStripMenuItem,
            this.toolStripSeparator1,
            this.downloadSeiteToolStripMenuItem});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe / Support";
			// 
			// tutorialVideoToolStripMenuItem
			// 
			this.tutorialVideoToolStripMenuItem.Name = "tutorialVideoToolStripMenuItem";
			this.tutorialVideoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.tutorialVideoToolStripMenuItem.Text = "Tutorial-Video";
			this.tutorialVideoToolStripMenuItem.Click += new System.EventHandler(this.tutorialVideoToolStripMenuItem_Click);
			// 
			// discordServerToolStripMenuItem
			// 
			this.discordServerToolStripMenuItem.Name = "discordServerToolStripMenuItem";
			this.discordServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.discordServerToolStripMenuItem.Text = "Discord-Server";
			this.discordServerToolStripMenuItem.Click += new System.EventHandler(this.discordServerToolStripMenuItem_Click);
			// 
			// threadImLPFToolStripMenuItem
			// 
			this.threadImLPFToolStripMenuItem.Name = "threadImLPFToolStripMenuItem";
			this.threadImLPFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.threadImLPFToolStripMenuItem.Text = "Thread im LPF";
			this.threadImLPFToolStripMenuItem.Click += new System.EventHandler(this.threadImLPFToolStripMenuItem_Click);
			// 
			// threadImYTFToolStripMenuItem
			// 
			this.threadImYTFToolStripMenuItem.Name = "threadImYTFToolStripMenuItem";
			this.threadImYTFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.threadImYTFToolStripMenuItem.Text = "Thread im YTF";
			this.threadImYTFToolStripMenuItem.Click += new System.EventHandler(this.threadImYTFToolStripMenuItem_Click);
			// 
			// strohiAufTwitterToolStripMenuItem
			// 
			this.strohiAufTwitterToolStripMenuItem.Name = "strohiAufTwitterToolStripMenuItem";
			this.strohiAufTwitterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.strohiAufTwitterToolStripMenuItem.Text = "strohi auf Twitter";
			this.strohiAufTwitterToolStripMenuItem.Click += new System.EventHandler(this.strohiAufTwitterToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// downloadSeiteToolStripMenuItem
			// 
			this.downloadSeiteToolStripMenuItem.Name = "downloadSeiteToolStripMenuItem";
			this.downloadSeiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.downloadSeiteToolStripMenuItem.Text = "Download-Seite";
			this.downloadSeiteToolStripMenuItem.Click += new System.EventHandler(this.downloadSeiteToolStripMenuItem_Click);
			// 
			// lblFinishAction
			// 
			this.lblFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFinishAction.Location = new System.Drawing.Point(367, 293);
			this.lblFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.lblFinishAction.Name = "lblFinishAction";
			this.lblFinishAction.Size = new System.Drawing.Size(53, 13);
			this.lblFinishAction.TabIndex = 14;
			this.lblFinishAction.Text = "Am Ende:";
			// 
			// cmbbxFinishAction
			// 
			this.cmbbxFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbbxFinishAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbxFinishAction.FormattingEnabled = true;
			this.cmbbxFinishAction.Items.AddRange(new object[] {
            "Nichts tun",
            "Zurück zum Hauptmenü",
            "Programm schließen",
            "Herunterfahren"});
			this.cmbbxFinishAction.Location = new System.Drawing.Point(425, 289);
			this.cmbbxFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.cmbbxFinishAction.Name = "cmbbxFinishAction";
			this.cmbbxFinishAction.Size = new System.Drawing.Size(271, 21);
			this.cmbbxFinishAction.TabIndex = 15;
			this.cmbbxFinishAction.SelectedIndexChanged += new System.EventHandler(this.cmbbxFinishActionSelectedIndexChanged);
			// 
			// chbChoseProcesses
			// 
			this.chbChoseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbChoseProcesses.Enabled = false;
			this.chbChoseProcesses.Location = new System.Drawing.Point(701, 291);
			this.chbChoseProcesses.Margin = new System.Windows.Forms.Padding(0);
			this.chbChoseProcesses.Name = "chbChoseProcesses";
			this.chbChoseProcesses.Size = new System.Drawing.Size(150, 17);
			this.chbChoseProcesses.TabIndex = 16;
			this.chbChoseProcesses.Text = "Programmenden abwarten";
			this.chbChoseProcesses.UseVisualStyleBackColor = true;
			this.chbChoseProcesses.CheckedChanged += new System.EventHandler(this.chbChoseProcessesCheckedChanged);
			// 
			// btnChoseProcs
			// 
			this.btnChoseProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChoseProcs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnChoseProcs.Enabled = false;
			this.btnChoseProcs.Location = new System.Drawing.Point(856, 286);
			this.btnChoseProcs.Margin = new System.Windows.Forms.Padding(0);
			this.btnChoseProcs.Name = "btnChoseProcs";
			this.btnChoseProcs.Padding = new System.Windows.Forms.Padding(2);
			this.btnChoseProcs.Size = new System.Drawing.Size(36, 27);
			this.btnChoseProcs.TabIndex = 17;
			this.btnChoseProcs.Text = "[...]";
			this.btnChoseProcs.UseVisualStyleBackColor = true;
			this.btnChoseProcs.Click += new System.EventHandler(this.btnChoseProcsClick);
			// 
			// bgwCreateUploader
			// 
			this.bgwCreateUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCreateUploaderDoWork);
			this.bgwCreateUploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCreateUploaderRunWorkerCompleted);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// neueFunktionenToolStripMenuItem
			// 
			this.neueFunktionenToolStripMenuItem.Name = "neueFunktionenToolStripMenuItem";
			this.neueFunktionenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.neueFunktionenToolStripMenuItem.Text = "Neue Funktionen";
			this.neueFunktionenToolStripMenuItem.Click += new System.EventHandler(this.neueFunktionenToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(979, 323);
			this.Controls.Add(this.tlpSettings);
			this.MainMenuStrip = this.mainMenu;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[BETA] Strohis Toolset Für Uploads - AutoUploader";
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
		private System.Windows.Forms.Label lblFinishAction;
		private System.Windows.Forms.ComboBox cmbbxFinishAction;
		private System.Windows.Forms.CheckBox chbChoseProcesses;
		private System.Windows.Forms.Button btnChoseProcs;
		private System.Windows.Forms.ColumnHeader chTemplate;
		private System.Windows.Forms.ToolStripMenuItem verwaltenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem pfadeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem youtubeAccountToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem verbindenToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem verbindungLösenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unvollständigerUploadToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chHidden;
		private System.Windows.Forms.ColumnHeader cbInactive;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem threadImLPFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem strohiAufTwitterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tutorialVideoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem threadImYTFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem discordServerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem downloadSeiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem neueFunktionenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}

