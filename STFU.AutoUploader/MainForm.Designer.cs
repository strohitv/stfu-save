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
			this.components = new System.ComponentModel.Container();
			this.tlpSettings = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnConnectYoutubeAccount = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.lvSelectedPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtbxAddPath = new System.Windows.Forms.TextBox();
			this.txtbxAddFilter = new System.Windows.Forms.TextBox();
			this.lblCurrentLoggedIn = new System.Windows.Forms.Label();
			this.lnklblCurrentLoggedIn = new System.Windows.Forms.LinkLabel();
			this.chbRecursive = new System.Windows.Forms.CheckBox();
			this.btnSelectPath = new System.Windows.Forms.Button();
			this.btnAddPath = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tlpRunning = new System.Windows.Forms.TableLayoutPanel();
			this.statusLabel = new System.Windows.Forms.Label();
			this.prgbarProgress = new System.Windows.Forms.ProgressBar();
			this.btnStop = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.bgwCreateUploader = new System.ComponentModel.BackgroundWorker();
			this.tlpSettings.SuspendLayout();
			this.tlpRunning.SuspendLayout();
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
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSettings.Controls.Add(this.label1, 1, 1);
			this.tlpSettings.Controls.Add(this.label2, 1, 3);
			this.tlpSettings.Controls.Add(this.btnConnectYoutubeAccount, 5, 7);
			this.tlpSettings.Controls.Add(this.btnStart, 7, 7);
			this.tlpSettings.Controls.Add(this.lvSelectedPaths, 1, 5);
			this.tlpSettings.Controls.Add(this.txtbxAddPath, 3, 1);
			this.tlpSettings.Controls.Add(this.txtbxAddFilter, 3, 3);
			this.tlpSettings.Controls.Add(this.lblCurrentLoggedIn, 1, 7);
			this.tlpSettings.Controls.Add(this.lnklblCurrentLoggedIn, 3, 7);
			this.tlpSettings.Controls.Add(this.chbRecursive, 5, 3);
			this.tlpSettings.Controls.Add(this.btnSelectPath, 5, 1);
			this.tlpSettings.Controls.Add(this.btnAddPath, 7, 1);
			this.tlpSettings.Controls.Add(this.btnCancel, 7, 3);
			this.tlpSettings.Enabled = false;
			this.tlpSettings.Location = new System.Drawing.Point(0, 14);
			this.tlpSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tlpSettings.Name = "tlpSettings";
			this.tlpSettings.RowCount = 9;
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpSettings.Size = new System.Drawing.Size(990, 409);
			this.tlpSettings.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Pfad: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Dateifilter: ";
			// 
			// btnConnectYoutubeAccount
			// 
			this.btnConnectYoutubeAccount.AutoSize = true;
			this.btnConnectYoutubeAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnConnectYoutubeAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConnectYoutubeAccount.Location = new System.Drawing.Point(675, 372);
			this.btnConnectYoutubeAccount.Margin = new System.Windows.Forms.Padding(0);
			this.btnConnectYoutubeAccount.Name = "btnConnectYoutubeAccount";
			this.btnConnectYoutubeAccount.Size = new System.Drawing.Size(160, 27);
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
			this.btnStart.Location = new System.Drawing.Point(845, 372);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(135, 27);
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
			this.lvSelectedPaths.Location = new System.Drawing.Point(10, 84);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.Size = new System.Drawing.Size(970, 278);
			this.lvSelectedPaths.TabIndex = 9;
			this.lvSelectedPaths.UseCompatibleStateImageBehavior = false;
			this.lvSelectedPaths.View = System.Windows.Forms.View.Details;
			this.lvSelectedPaths.DoubleClick += new System.EventHandler(this.lvSelectedPathsDoubleClick);
			this.lvSelectedPaths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSelectedPathsKeyDown);
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
			// txtbxAddPath
			// 
			this.txtbxAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtbxAddPath.Location = new System.Drawing.Point(107, 12);
			this.txtbxAddPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddPath.Name = "txtbxAddPath";
			this.txtbxAddPath.Size = new System.Drawing.Size(558, 22);
			this.txtbxAddPath.TabIndex = 0;
			// 
			// txtbxAddFilter
			// 
			this.txtbxAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtbxAddFilter.Location = new System.Drawing.Point(107, 49);
			this.txtbxAddFilter.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddFilter.Name = "txtbxAddFilter";
			this.txtbxAddFilter.Size = new System.Drawing.Size(558, 22);
			this.txtbxAddFilter.TabIndex = 1;
			// 
			// lblCurrentLoggedIn
			// 
			this.lblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLoggedIn.AutoSize = true;
			this.lblCurrentLoggedIn.Location = new System.Drawing.Point(10, 377);
			this.lblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lblCurrentLoggedIn.Name = "lblCurrentLoggedIn";
			this.lblCurrentLoggedIn.Size = new System.Drawing.Size(87, 17);
			this.lblCurrentLoggedIn.TabIndex = 10;
			this.lblCurrentLoggedIn.Text = "Angemeldet:";
			this.lblCurrentLoggedIn.Visible = false;
			// 
			// lnklblCurrentLoggedIn
			// 
			this.lnklblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lnklblCurrentLoggedIn.Location = new System.Drawing.Point(107, 375);
			this.lnklblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lnklblCurrentLoggedIn.Name = "lnklblCurrentLoggedIn";
			this.lnklblCurrentLoggedIn.Size = new System.Drawing.Size(558, 21);
			this.lnklblCurrentLoggedIn.TabIndex = 11;
			this.lnklblCurrentLoggedIn.TabStop = true;
			this.lnklblCurrentLoggedIn.Text = "link";
			this.lnklblCurrentLoggedIn.Visible = false;
			this.lnklblCurrentLoggedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCurrentLoggedInLinkClicked);
			// 
			// chbRecursive
			// 
			this.chbRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbRecursive.AutoSize = true;
			this.chbRecursive.Location = new System.Drawing.Point(675, 50);
			this.chbRecursive.Margin = new System.Windows.Forms.Padding(0);
			this.chbRecursive.Name = "chbRecursive";
			this.chbRecursive.Size = new System.Drawing.Size(160, 21);
			this.chbRecursive.TabIndex = 12;
			this.chbRecursive.Text = "Unterverzeichnisse";
			this.chbRecursive.UseVisualStyleBackColor = true;
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectPath.AutoSize = true;
			this.btnSelectPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSelectPath.Location = new System.Drawing.Point(675, 10);
			this.btnSelectPath.Margin = new System.Windows.Forms.Padding(0);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(160, 27);
			this.btnSelectPath.TabIndex = 4;
			this.btnSelectPath.Text = "Pfad wählen";
			this.btnSelectPath.UseVisualStyleBackColor = true;
			this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPathClick);
			// 
			// btnAddPath
			// 
			this.btnAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPath.AutoSize = true;
			this.btnAddPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddPath.Location = new System.Drawing.Point(845, 10);
			this.btnAddPath.Margin = new System.Windows.Forms.Padding(0);
			this.btnAddPath.Name = "btnAddPath";
			this.btnAddPath.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
			this.btnAddPath.Size = new System.Drawing.Size(135, 27);
			this.btnAddPath.TabIndex = 5;
			this.btnAddPath.Text = "Speichern!";
			this.btnAddPath.UseVisualStyleBackColor = true;
			this.btnAddPath.Click += new System.EventHandler(this.btnAddPathToWatchClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.Location = new System.Drawing.Point(845, 47);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(135, 27);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Bitte wähle den Ordner aus, in dem sich die Videos befinden, die du hochladen möc" +
    "htest.";
			// 
			// tlpRunning
			// 
			this.tlpRunning.AutoSize = true;
			this.tlpRunning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpRunning.ColumnCount = 5;
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.Controls.Add(this.statusLabel, 1, 1);
			this.tlpRunning.Controls.Add(this.prgbarProgress, 1, 3);
			this.tlpRunning.Controls.Add(this.btnStop, 3, 3);
			this.tlpRunning.Location = new System.Drawing.Point(37, 582);
			this.tlpRunning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 5;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Size = new System.Drawing.Size(854, 74);
			this.tlpRunning.TabIndex = 1;
			this.tlpRunning.Visible = false;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 3);
			this.statusLabel.Location = new System.Drawing.Point(11, 10);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(832, 17);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Suche Dateien zum Upload...";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.prgbarProgress.Location = new System.Drawing.Point(11, 39);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.MarqueeAnimationSpeed = 10;
			this.prgbarProgress.Maximum = 10000;
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(731, 23);
			this.prgbarProgress.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(753, 37);
			this.btnStop.Margin = new System.Windows.Forms.Padding(0);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(90, 27);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Abbrechen!";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStopClick);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimerTick);
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
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1005, 690);
			this.Controls.Add(this.tlpRunning);
			this.Controls.Add(this.tlpSettings);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AutoUploader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tlpSettings.ResumeLayout(false);
			this.tlpSettings.PerformLayout();
			this.tlpRunning.ResumeLayout(false);
			this.tlpRunning.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpSettings;
		private System.Windows.Forms.TextBox txtbxAddPath;
		private System.Windows.Forms.TextBox txtbxAddFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelectPath;
		private System.Windows.Forms.Button btnAddPath;
		private System.Windows.Forms.Button btnConnectYoutubeAccount;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ListView lvSelectedPaths;
		private System.Windows.Forms.ColumnHeader chPath;
		private System.Windows.Forms.ColumnHeader chFilter;
		private System.Windows.Forms.TableLayoutPanel tlpRunning;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ProgressBar prgbarProgress;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Timer refreshTimer;
		private System.ComponentModel.BackgroundWorker bgwCreateUploader;
		private System.Windows.Forms.Label lblCurrentLoggedIn;
		private System.Windows.Forms.LinkLabel lnklblCurrentLoggedIn;
		private System.Windows.Forms.ColumnHeader chRecursive;
		private System.Windows.Forms.CheckBox chbRecursive;
		private System.Windows.Forms.Button btnCancel;
	}
}

