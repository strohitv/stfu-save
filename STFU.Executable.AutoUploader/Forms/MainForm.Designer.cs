using STFU.Lib.GUI.Controls;

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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tlpSettings = new System.Windows.Forms.TableLayoutPanel();
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
			this.neueFunktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.videotutorialPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.threadImLPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.threadImYTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.discordServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.strohiAufTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.downloadSeiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fehlerverzeichnisÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.uploaderTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.queueStatusLabel = new System.Windows.Forms.Label();
			this.queueStatusButton = new System.Windows.Forms.Button();
			this.lblFinishAction = new System.Windows.Forms.Label();
			this.cmbbxFinishAction = new System.Windows.Forms.ComboBox();
			this.chbChoseProcesses = new System.Windows.Forms.CheckBox();
			this.btnChoseProcs = new System.Windows.Forms.Button();
			this.jobQueue = new STFU.Lib.GUI.Controls.Queue.JobQueue();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.autoUploaderStateLabel = new System.Windows.Forms.Label();
			this.btnStart = new STFU.Lib.GUI.Controls.MenuButton();
			this.startExtendedOptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pathsTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lvSelectedPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTemplate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbInactive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.archiveTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.archiveLabel = new System.Windows.Forms.Label();
			this.archiveListView = new System.Windows.Forms.ListView();
			this.archiveVideoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.archiveRemoveJobButton = new System.Windows.Forms.Button();
			this.bgwCreateUploader = new System.ComponentModel.BackgroundWorker();
			this.watchingTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.archiveAddButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.archiveVideoPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.moveBackToQueueButton = new System.Windows.Forms.Button();
			this.tlpSettings.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.uploaderTabPage.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.startExtendedOptionsContextMenu.SuspendLayout();
			this.pathsTabPage.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.archiveTabPage.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpSettings
			// 
			this.tlpSettings.AutoSize = true;
			this.tlpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpSettings.ColumnCount = 5;
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.Controls.Add(this.lblCurrentLoggedIn, 1, 4);
			this.tlpSettings.Controls.Add(this.lnklblCurrentLoggedIn, 3, 4);
			this.tlpSettings.Controls.Add(this.mainMenu, 0, 0);
			this.tlpSettings.Controls.Add(this.tabControl1, 1, 2);
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
			this.tlpSettings.Size = new System.Drawing.Size(1158, 675);
			this.tlpSettings.TabIndex = 0;
			// 
			// lblCurrentLoggedIn
			// 
			this.lblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLoggedIn.AutoSize = true;
			this.lblCurrentLoggedIn.Location = new System.Drawing.Point(10, 652);
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
			this.lnklblCurrentLoggedIn.Location = new System.Drawing.Point(86, 652);
			this.lnklblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lnklblCurrentLoggedIn.Name = "lnklblCurrentLoggedIn";
			this.lnklblCurrentLoggedIn.Size = new System.Drawing.Size(1062, 13);
			this.lnklblCurrentLoggedIn.TabIndex = 11;
			this.lnklblCurrentLoggedIn.TabStop = true;
			this.lnklblCurrentLoggedIn.Text = "link";
			this.lnklblCurrentLoggedIn.Visible = false;
			this.lnklblCurrentLoggedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCurrentLoggedInLinkClicked);
			// 
			// mainMenu
			// 
			this.mainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.mainMenu, 5);
			this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.verwaltenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.mainMenu.Size = new System.Drawing.Size(1158, 24);
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
            this.videotutorialPlaylistToolStripMenuItem,
            this.threadImLPFToolStripMenuItem,
            this.threadImYTFToolStripMenuItem,
            this.discordServerToolStripMenuItem,
            this.strohiAufTwitterToolStripMenuItem,
            this.toolStripSeparator1,
            this.downloadSeiteToolStripMenuItem,
            this.toolStripSeparator3,
            this.fehlerverzeichnisÖffnenToolStripMenuItem});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe / Support";
			// 
			// neueFunktionenToolStripMenuItem
			// 
			this.neueFunktionenToolStripMenuItem.Name = "neueFunktionenToolStripMenuItem";
			this.neueFunktionenToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.neueFunktionenToolStripMenuItem.Text = "Neue Funktionen";
			this.neueFunktionenToolStripMenuItem.Click += new System.EventHandler(this.neueFunktionenToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
			// 
			// videotutorialPlaylistToolStripMenuItem
			// 
			this.videotutorialPlaylistToolStripMenuItem.Name = "videotutorialPlaylistToolStripMenuItem";
			this.videotutorialPlaylistToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.videotutorialPlaylistToolStripMenuItem.Text = "Videotutorial-Playlist";
			this.videotutorialPlaylistToolStripMenuItem.Click += new System.EventHandler(this.videotutorialPlaylistToolStripMenuItem_Click);
			// 
			// threadImLPFToolStripMenuItem
			// 
			this.threadImLPFToolStripMenuItem.Name = "threadImLPFToolStripMenuItem";
			this.threadImLPFToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.threadImLPFToolStripMenuItem.Text = "Thread im LPF";
			this.threadImLPFToolStripMenuItem.Click += new System.EventHandler(this.threadImLPFToolStripMenuItem_Click);
			// 
			// threadImYTFToolStripMenuItem
			// 
			this.threadImYTFToolStripMenuItem.Name = "threadImYTFToolStripMenuItem";
			this.threadImYTFToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.threadImYTFToolStripMenuItem.Text = "Thread im YTF";
			this.threadImYTFToolStripMenuItem.Click += new System.EventHandler(this.threadImYTFToolStripMenuItem_Click);
			// 
			// discordServerToolStripMenuItem
			// 
			this.discordServerToolStripMenuItem.Name = "discordServerToolStripMenuItem";
			this.discordServerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.discordServerToolStripMenuItem.Text = "Discord-Server";
			this.discordServerToolStripMenuItem.Click += new System.EventHandler(this.discordServerToolStripMenuItem_Click);
			// 
			// strohiAufTwitterToolStripMenuItem
			// 
			this.strohiAufTwitterToolStripMenuItem.Name = "strohiAufTwitterToolStripMenuItem";
			this.strohiAufTwitterToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.strohiAufTwitterToolStripMenuItem.Text = "strohi auf Twitter";
			this.strohiAufTwitterToolStripMenuItem.Click += new System.EventHandler(this.strohiAufTwitterToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
			// 
			// downloadSeiteToolStripMenuItem
			// 
			this.downloadSeiteToolStripMenuItem.Name = "downloadSeiteToolStripMenuItem";
			this.downloadSeiteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.downloadSeiteToolStripMenuItem.Text = "Download-Seite";
			this.downloadSeiteToolStripMenuItem.Click += new System.EventHandler(this.downloadSeiteToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
			// 
			// fehlerverzeichnisÖffnenToolStripMenuItem
			// 
			this.fehlerverzeichnisÖffnenToolStripMenuItem.Name = "fehlerverzeichnisÖffnenToolStripMenuItem";
			this.fehlerverzeichnisÖffnenToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.fehlerverzeichnisÖffnenToolStripMenuItem.Text = "Fehlerverzeichnis öffnen";
			this.fehlerverzeichnisÖffnenToolStripMenuItem.Click += new System.EventHandler(this.fehlerverzeichnisÖffnenToolStripMenuItem_Click);
			// 
			// tabControl1
			// 
			this.tlpSettings.SetColumnSpan(this.tabControl1, 3);
			this.tabControl1.Controls.Add(this.uploaderTabPage);
			this.tabControl1.Controls.Add(this.pathsTabPage);
			this.tabControl1.Controls.Add(this.archiveTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(10, 34);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1138, 608);
			this.tabControl1.TabIndex = 18;
			// 
			// uploaderTabPage
			// 
			this.uploaderTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.uploaderTabPage.Controls.Add(this.tableLayoutPanel3);
			this.uploaderTabPage.Location = new System.Drawing.Point(4, 22);
			this.uploaderTabPage.Name = "uploaderTabPage";
			this.uploaderTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.uploaderTabPage.Size = new System.Drawing.Size(1130, 582);
			this.uploaderTabPage.TabIndex = 1;
			this.uploaderTabPage.Text = "Warteschlange";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel3.Controls.Add(this.groupBox1, 1, 3);
			this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 5;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(1124, 576);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(13, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1098, 472);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Warteschlange";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 13;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel2.Controls.Add(this.queueStatusLabel, 9, 3);
			this.tableLayoutPanel2.Controls.Add(this.queueStatusButton, 11, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblFinishAction, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.cmbbxFinishAction, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.chbChoseProcesses, 5, 3);
			this.tableLayoutPanel2.Controls.Add(this.btnChoseProcs, 7, 3);
			this.tableLayoutPanel2.Controls.Add(this.jobQueue, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 5;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(1092, 453);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// queueStatusLabel
			// 
			this.queueStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.queueStatusLabel.AutoSize = true;
			this.queueStatusLabel.Location = new System.Drawing.Point(858, 426);
			this.queueStatusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.queueStatusLabel.Name = "queueStatusLabel";
			this.queueStatusLabel.Size = new System.Drawing.Size(155, 13);
			this.queueStatusLabel.TabIndex = 19;
			this.queueStatusLabel.Text = "Die Warteschlange ist gestoppt";
			// 
			// queueStatusButton
			// 
			this.queueStatusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.queueStatusButton.AutoSize = true;
			this.queueStatusButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.queueStatusButton.Enabled = false;
			this.queueStatusButton.Location = new System.Drawing.Point(1023, 419);
			this.queueStatusButton.Margin = new System.Windows.Forms.Padding(0);
			this.queueStatusButton.Name = "queueStatusButton";
			this.queueStatusButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.queueStatusButton.Size = new System.Drawing.Size(64, 27);
			this.queueStatusButton.TabIndex = 7;
			this.queueStatusButton.Text = "Start!";
			this.queueStatusButton.UseVisualStyleBackColor = true;
			this.queueStatusButton.Click += new System.EventHandler(this.queueStatusButton_Click);
			// 
			// lblFinishAction
			// 
			this.lblFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFinishAction.Location = new System.Drawing.Point(5, 426);
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
            "Programm schließen",
            "Herunterfahren"});
			this.cmbbxFinishAction.Location = new System.Drawing.Point(68, 422);
			this.cmbbxFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.cmbbxFinishAction.Name = "cmbbxFinishAction";
			this.cmbbxFinishAction.Size = new System.Drawing.Size(574, 21);
			this.cmbbxFinishAction.TabIndex = 15;
			this.cmbbxFinishAction.SelectedIndexChanged += new System.EventHandler(this.cmbbxFinishActionSelectedIndexChanged);
			// 
			// chbChoseProcesses
			// 
			this.chbChoseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbChoseProcesses.Enabled = false;
			this.chbChoseProcesses.Location = new System.Drawing.Point(652, 424);
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
			this.btnChoseProcs.Location = new System.Drawing.Point(812, 419);
			this.btnChoseProcs.Margin = new System.Windows.Forms.Padding(0);
			this.btnChoseProcs.Name = "btnChoseProcs";
			this.btnChoseProcs.Padding = new System.Windows.Forms.Padding(2);
			this.btnChoseProcs.Size = new System.Drawing.Size(36, 27);
			this.btnChoseProcs.TabIndex = 17;
			this.btnChoseProcs.Text = "[...]";
			this.btnChoseProcs.UseVisualStyleBackColor = true;
			this.btnChoseProcs.Click += new System.EventHandler(this.btnChoseProcsClick);
			// 
			// jobQueue
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.jobQueue, 11);
			this.jobQueue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jobQueue.Location = new System.Drawing.Point(5, 7);
			this.jobQueue.Margin = new System.Windows.Forms.Padding(0);
			this.jobQueue.Name = "jobQueue";
			this.jobQueue.ShowActionsButtons = true;
			this.jobQueue.Size = new System.Drawing.Size(1082, 402);
			this.jobQueue.TabIndex = 18;
			this.jobQueue.Uploader = null;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.AutoSize = true;
			this.groupBox2.Controls.Add(this.tableLayoutPanel4);
			this.groupBox2.Location = new System.Drawing.Point(13, 13);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1098, 62);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Automatischer Videoupload";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.ColumnCount = 5;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel4.Controls.Add(this.autoUploaderStateLabel, 1, 1);
			this.tableLayoutPanel4.Controls.Add(this.btnStart, 3, 1);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(1092, 43);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// autoUploaderStateLabel
			// 
			this.autoUploaderStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.autoUploaderStateLabel.AutoSize = true;
			this.autoUploaderStateLabel.Location = new System.Drawing.Point(5, 15);
			this.autoUploaderStateLabel.Margin = new System.Windows.Forms.Padding(0);
			this.autoUploaderStateLabel.Name = "autoUploaderStateLabel";
			this.autoUploaderStateLabel.Size = new System.Drawing.Size(949, 13);
			this.autoUploaderStateLabel.TabIndex = 19;
			this.autoUploaderStateLabel.Text = "Der AutoUploader ist gestoppt";
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.AutoSize = true;
			this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStart.Enabled = false;
			this.btnStart.Location = new System.Drawing.Point(964, 7);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Menu = this.startExtendedOptionsContextMenu;
			this.btnStart.Name = "btnStart";
			this.btnStart.Padding = new System.Windows.Forms.Padding(15, 3, 25, 3);
			this.btnStart.Size = new System.Drawing.Size(123, 29);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Sofort starten!";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStartClick);
			// 
			// startExtendedOptionsContextMenu
			// 
			this.startExtendedOptionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem});
			this.startExtendedOptionsContextMenu.Name = "startExtendedOptionsContextMenu";
			this.startExtendedOptionsContextMenu.Size = new System.Drawing.Size(298, 26);
			// 
			// zeitenFestlegenUndAutouploaderStartenToolStripMenuItem
			// 
			this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Name = "zeitenFestlegenUndAutouploaderStartenToolStripMenuItem";
			this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
			this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Text = "Zeiten festlegen und Autouploader starten";
			this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem.Click += new System.EventHandler(this.zeitenFestlegenUndAutouploaderStartenToolStripMenuItem_Click);
			// 
			// pathsTabPage
			// 
			this.pathsTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.pathsTabPage.Controls.Add(this.tableLayoutPanel1);
			this.pathsTabPage.Location = new System.Drawing.Point(4, 22);
			this.pathsTabPage.Name = "pathsTabPage";
			this.pathsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.pathsTabPage.Size = new System.Drawing.Size(1130, 582);
			this.pathsTabPage.TabIndex = 0;
			this.pathsTabPage.Text = "Zu überwachende Pfade";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Controls.Add(this.lvSelectedPaths, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 576);
			this.tableLayoutPanel1.TabIndex = 0;
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
			this.lvSelectedPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSelectedPaths.FullRowSelect = true;
			this.lvSelectedPaths.GridLines = true;
			this.lvSelectedPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSelectedPaths.Location = new System.Drawing.Point(10, 10);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.ShowGroups = false;
			this.lvSelectedPaths.Size = new System.Drawing.Size(1104, 556);
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
			// archiveTabPage
			// 
			this.archiveTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.archiveTabPage.Controls.Add(this.tableLayoutPanel5);
			this.archiveTabPage.Location = new System.Drawing.Point(4, 22);
			this.archiveTabPage.Margin = new System.Windows.Forms.Padding(0);
			this.archiveTabPage.Name = "archiveTabPage";
			this.archiveTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.archiveTabPage.Size = new System.Drawing.Size(1130, 582);
			this.archiveTabPage.TabIndex = 2;
			this.archiveTabPage.Text = "Videos, die nicht hochgeladen werden sollen";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 9;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.Controls.Add(this.archiveLabel, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.archiveListView, 1, 3);
			this.tableLayoutPanel5.Controls.Add(this.archiveRemoveJobButton, 7, 5);
			this.tableLayoutPanel5.Controls.Add(this.archiveAddButton, 3, 5);
			this.tableLayoutPanel5.Controls.Add(this.moveBackToQueueButton, 5, 5);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 7;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(1124, 576);
			this.tableLayoutPanel5.TabIndex = 0;
			// 
			// archiveLabel
			// 
			this.archiveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.archiveLabel.AutoSize = true;
			this.tableLayoutPanel5.SetColumnSpan(this.archiveLabel, 7);
			this.archiveLabel.Location = new System.Drawing.Point(10, 10);
			this.archiveLabel.Margin = new System.Windows.Forms.Padding(0);
			this.archiveLabel.Name = "archiveLabel";
			this.archiveLabel.Size = new System.Drawing.Size(1104, 65);
			this.archiveLabel.TabIndex = 0;
			this.archiveLabel.Text = resources.GetString("archiveLabel.Text");
			// 
			// archiveListView
			// 
			this.archiveListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.archiveVideoName,
            this.archiveVideoPath});
			this.tableLayoutPanel5.SetColumnSpan(this.archiveListView, 7);
			this.archiveListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.archiveListView.FullRowSelect = true;
			this.archiveListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.archiveListView.LabelWrap = false;
			this.archiveListView.Location = new System.Drawing.Point(10, 85);
			this.archiveListView.Margin = new System.Windows.Forms.Padding(0);
			this.archiveListView.Name = "archiveListView";
			this.archiveListView.Size = new System.Drawing.Size(1104, 442);
			this.archiveListView.TabIndex = 1;
			this.archiveListView.UseCompatibleStateImageBehavior = false;
			this.archiveListView.View = System.Windows.Forms.View.Details;
			this.archiveListView.SelectedIndexChanged += new System.EventHandler(this.archiveListView_SelectedIndexChanged);
			// 
			// archiveVideoName
			// 
			this.archiveVideoName.Text = "Video";
			this.archiveVideoName.Width = 1000;
			// 
			// archiveRemoveJobButton
			// 
			this.archiveRemoveJobButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.archiveRemoveJobButton.AutoSize = true;
			this.archiveRemoveJobButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.archiveRemoveJobButton.Enabled = false;
			this.archiveRemoveJobButton.Location = new System.Drawing.Point(976, 537);
			this.archiveRemoveJobButton.Margin = new System.Windows.Forms.Padding(0);
			this.archiveRemoveJobButton.Name = "archiveRemoveJobButton";
			this.archiveRemoveJobButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.archiveRemoveJobButton.Size = new System.Drawing.Size(138, 29);
			this.archiveRemoveJobButton.TabIndex = 2;
			this.archiveRemoveJobButton.Text = "Aus Archiv löschen";
			this.archiveRemoveJobButton.UseVisualStyleBackColor = true;
			this.archiveRemoveJobButton.Click += new System.EventHandler(this.archiveRemoveJobButton_Click);
			// 
			// bgwCreateUploader
			// 
			this.bgwCreateUploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCreateUploaderDoWork);
			this.bgwCreateUploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCreateUploaderRunWorkerCompleted);
			// 
			// watchingTimer
			// 
			this.watchingTimer.Enabled = true;
			this.watchingTimer.Interval = 3000;
			this.watchingTimer.Tick += new System.EventHandler(this.watchingTimer_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Strohis Toolset Für Uploads";
			this.notifyIcon.Visible = true;
			// 
			// archiveAddButton
			// 
			this.archiveAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.archiveAddButton.AutoSize = true;
			this.archiveAddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.archiveAddButton.Location = new System.Drawing.Point(635, 537);
			this.archiveAddButton.Margin = new System.Windows.Forms.Padding(0);
			this.archiveAddButton.Name = "archiveAddButton";
			this.archiveAddButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.archiveAddButton.Size = new System.Drawing.Size(129, 29);
			this.archiveAddButton.TabIndex = 2;
			this.archiveAddButton.Text = "Video hinzufügen";
			this.archiveAddButton.UseVisualStyleBackColor = true;
			this.archiveAddButton.Click += new System.EventHandler(this.archiveAddButton_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Alle Dateien|*.*";
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.Title = "Videos zum ignorieren hinzufügen";
			// 
			// archiveVideoPath
			// 
			this.archiveVideoPath.Text = "Pfad";
			this.archiveVideoPath.Width = 500;
			// 
			// moveBackToQueueButton
			// 
			this.moveBackToQueueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.moveBackToQueueButton.AutoSize = true;
			this.moveBackToQueueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveBackToQueueButton.Enabled = false;
			this.moveBackToQueueButton.Location = new System.Drawing.Point(774, 537);
			this.moveBackToQueueButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveBackToQueueButton.Name = "moveBackToQueueButton";
			this.moveBackToQueueButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.moveBackToQueueButton.Size = new System.Drawing.Size(192, 29);
			this.moveBackToQueueButton.TabIndex = 2;
			this.moveBackToQueueButton.Text = "In Warteschlange verschieben";
			this.moveBackToQueueButton.UseVisualStyleBackColor = true;
			this.moveBackToQueueButton.Click += new System.EventHandler(this.moveBackToQueueButton_Click);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnStart;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1158, 675);
			this.Controls.Add(this.tlpSettings);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenu;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[BETA] Strohis Toolset Für Uploads - AutoUploader";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tlpSettings.ResumeLayout(false);
			this.tlpSettings.PerformLayout();
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.uploaderTabPage.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.startExtendedOptionsContextMenu.ResumeLayout(false);
			this.pathsTabPage.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.archiveTabPage.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpSettings;
		private MenuButton btnStart;
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
		private System.Windows.Forms.ToolStripMenuItem threadImYTFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem discordServerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem downloadSeiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem neueFunktionenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem fehlerverzeichnisÖffnenToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage pathsTabPage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabPage uploaderTabPage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private Lib.GUI.Controls.Queue.JobQueue jobQueue;
		private System.Windows.Forms.Timer watchingTimer;
		private System.Windows.Forms.Label autoUploaderStateLabel;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Button queueStatusButton;
		private System.Windows.Forms.Label queueStatusLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ContextMenuStrip startExtendedOptionsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem zeitenFestlegenUndAutouploaderStartenToolStripMenuItem;
		private System.Windows.Forms.TabPage archiveTabPage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label archiveLabel;
		private System.Windows.Forms.ListView archiveListView;
		private System.Windows.Forms.ColumnHeader archiveVideoName;
		private System.Windows.Forms.Button archiveRemoveJobButton;
		private System.Windows.Forms.ToolStripMenuItem videotutorialPlaylistToolStripMenuItem;
		private System.Windows.Forms.Button archiveAddButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ColumnHeader archiveVideoPath;
		private System.Windows.Forms.Button moveBackToQueueButton;
	}
}

