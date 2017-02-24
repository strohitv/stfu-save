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
			this.btnSelectPath = new System.Windows.Forms.Button();
			this.btnAddPathToWatch = new System.Windows.Forms.Button();
			this.btnConnectYoutubeAccount = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.lvSelectedPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtbxAddPath = new System.Windows.Forms.TextBox();
			this.txtbxAddFilter = new System.Windows.Forms.TextBox();
			this.lblCurrentLoggedIn = new System.Windows.Forms.Label();
			this.btnRevokeAccess = new System.Windows.Forms.Button();
			this.lnklblCurrentLoggedIn = new System.Windows.Forms.LinkLabel();
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
			this.tlpSettings.ColumnCount = 11;
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.Controls.Add(this.label1, 1, 1);
			this.tlpSettings.Controls.Add(this.label2, 1, 3);
			this.tlpSettings.Controls.Add(this.btnSelectPath, 9, 1);
			this.tlpSettings.Controls.Add(this.btnAddPathToWatch, 9, 3);
			this.tlpSettings.Controls.Add(this.btnConnectYoutubeAccount, 7, 7);
			this.tlpSettings.Controls.Add(this.btnStart, 9, 7);
			this.tlpSettings.Controls.Add(this.lvSelectedPaths, 1, 5);
			this.tlpSettings.Controls.Add(this.txtbxAddPath, 3, 1);
			this.tlpSettings.Controls.Add(this.txtbxAddFilter, 3, 3);
			this.tlpSettings.Controls.Add(this.lblCurrentLoggedIn, 1, 7);
			this.tlpSettings.Controls.Add(this.btnRevokeAccess, 5, 7);
			this.tlpSettings.Controls.Add(this.lnklblCurrentLoggedIn, 3, 7);
			this.tlpSettings.Enabled = false;
			this.tlpSettings.Location = new System.Drawing.Point(0, 11);
			this.tlpSettings.Margin = new System.Windows.Forms.Padding(2);
			this.tlpSettings.Name = "tlpSettings";
			this.tlpSettings.RowCount = 9;
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpSettings.Size = new System.Drawing.Size(713, 348);
			this.tlpSettings.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Pfad: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 44);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Dateifilter: ";
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectPath.AutoSize = true;
			this.btnSelectPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSelectPath.Location = new System.Drawing.Point(629, 8);
			this.btnSelectPath.Margin = new System.Windows.Forms.Padding(0);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(76, 23);
			this.btnSelectPath.TabIndex = 4;
			this.btnSelectPath.Text = "Pfad wählen";
			this.btnSelectPath.UseVisualStyleBackColor = true;
			this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPathClick);
			// 
			// btnAddPathToWatch
			// 
			this.btnAddPathToWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPathToWatch.AutoSize = true;
			this.btnAddPathToWatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddPathToWatch.Location = new System.Drawing.Point(629, 39);
			this.btnAddPathToWatch.Margin = new System.Windows.Forms.Padding(0);
			this.btnAddPathToWatch.Name = "btnAddPathToWatch";
			this.btnAddPathToWatch.Size = new System.Drawing.Size(76, 23);
			this.btnAddPathToWatch.TabIndex = 5;
			this.btnAddPathToWatch.Text = "Hinzufügen!";
			this.btnAddPathToWatch.UseVisualStyleBackColor = true;
			this.btnAddPathToWatch.Click += new System.EventHandler(this.btnAddPathToWatchClick);
			// 
			// btnConnectYoutubeAccount
			// 
			this.btnConnectYoutubeAccount.AutoSize = true;
			this.btnConnectYoutubeAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnConnectYoutubeAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConnectYoutubeAccount.Location = new System.Drawing.Point(497, 317);
			this.btnConnectYoutubeAccount.Margin = new System.Windows.Forms.Padding(0);
			this.btnConnectYoutubeAccount.Name = "btnConnectYoutubeAccount";
			this.btnConnectYoutubeAccount.Size = new System.Drawing.Size(124, 23);
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
			this.btnStart.Location = new System.Drawing.Point(629, 317);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(76, 23);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Start!";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStartClick);
			// 
			// lvSelectedPaths
			// 
			this.lvSelectedPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath,
            this.chFilter});
			this.tlpSettings.SetColumnSpan(this.lvSelectedPaths, 9);
			this.lvSelectedPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSelectedPaths.FullRowSelect = true;
			this.lvSelectedPaths.Location = new System.Drawing.Point(8, 70);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.Size = new System.Drawing.Size(697, 239);
			this.lvSelectedPaths.TabIndex = 9;
			this.lvSelectedPaths.UseCompatibleStateImageBehavior = false;
			this.lvSelectedPaths.View = System.Windows.Forms.View.Details;
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
			// txtbxAddPath
			// 
			this.txtbxAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.txtbxAddPath, 5);
			this.txtbxAddPath.Location = new System.Drawing.Point(82, 9);
			this.txtbxAddPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddPath.Name = "txtbxAddPath";
			this.txtbxAddPath.Size = new System.Drawing.Size(539, 20);
			this.txtbxAddPath.TabIndex = 0;
			// 
			// txtbxAddFilter
			// 
			this.txtbxAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.txtbxAddFilter, 5);
			this.txtbxAddFilter.Location = new System.Drawing.Point(82, 40);
			this.txtbxAddFilter.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddFilter.Name = "txtbxAddFilter";
			this.txtbxAddFilter.Size = new System.Drawing.Size(539, 20);
			this.txtbxAddFilter.TabIndex = 1;
			// 
			// lblCurrentLoggedIn
			// 
			this.lblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLoggedIn.AutoSize = true;
			this.lblCurrentLoggedIn.Location = new System.Drawing.Point(8, 322);
			this.lblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lblCurrentLoggedIn.Name = "lblCurrentLoggedIn";
			this.lblCurrentLoggedIn.Size = new System.Drawing.Size(66, 13);
			this.lblCurrentLoggedIn.TabIndex = 10;
			this.lblCurrentLoggedIn.Text = "Angemeldet:";
			this.lblCurrentLoggedIn.Visible = false;
			// 
			// btnRevokeAccess
			// 
			this.btnRevokeAccess.AutoSize = true;
			this.btnRevokeAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRevokeAccess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRevokeAccess.Location = new System.Drawing.Point(379, 317);
			this.btnRevokeAccess.Margin = new System.Windows.Forms.Padding(0);
			this.btnRevokeAccess.Name = "btnRevokeAccess";
			this.btnRevokeAccess.Size = new System.Drawing.Size(110, 23);
			this.btnRevokeAccess.TabIndex = 8;
			this.btnRevokeAccess.Text = "Verbindung trennen";
			this.btnRevokeAccess.UseVisualStyleBackColor = true;
			this.btnRevokeAccess.Visible = false;
			this.btnRevokeAccess.Click += new System.EventHandler(this.btnRevokeAccessClick);
			// 
			// lnklblCurrentLoggedIn
			// 
			this.lnklblCurrentLoggedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lnklblCurrentLoggedIn.AutoSize = true;
			this.lnklblCurrentLoggedIn.Location = new System.Drawing.Point(82, 322);
			this.lnklblCurrentLoggedIn.Margin = new System.Windows.Forms.Padding(0);
			this.lnklblCurrentLoggedIn.Name = "lnklblCurrentLoggedIn";
			this.lnklblCurrentLoggedIn.Size = new System.Drawing.Size(289, 13);
			this.lnklblCurrentLoggedIn.TabIndex = 11;
			this.lnklblCurrentLoggedIn.TabStop = true;
			this.lnklblCurrentLoggedIn.Text = "link";
			this.lnklblCurrentLoggedIn.Visible = false;
			this.lnklblCurrentLoggedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCurrentLoggedInLinkClicked);
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
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.Controls.Add(this.statusLabel, 1, 1);
			this.tlpRunning.Controls.Add(this.prgbarProgress, 1, 3);
			this.tlpRunning.Controls.Add(this.btnStop, 3, 3);
			this.tlpRunning.Location = new System.Drawing.Point(28, 473);
			this.tlpRunning.Margin = new System.Windows.Forms.Padding(2);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 5;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tlpRunning.Size = new System.Drawing.Size(662, 60);
			this.tlpRunning.TabIndex = 1;
			this.tlpRunning.Visible = false;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 3);
			this.statusLabel.Location = new System.Drawing.Point(8, 8);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(646, 13);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Suche Dateien zum Upload...";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.prgbarProgress.Location = new System.Drawing.Point(8, 31);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.MarqueeAnimationSpeed = 10;
			this.prgbarProgress.Maximum = 10000;
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(566, 19);
			this.prgbarProgress.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(582, 29);
			this.btnStop.Margin = new System.Windows.Forms.Padding(0);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(72, 23);
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
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(754, 561);
			this.Controls.Add(this.tlpRunning);
			this.Controls.Add(this.tlpSettings);
			this.Margin = new System.Windows.Forms.Padding(2);
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
		private System.Windows.Forms.Button btnAddPathToWatch;
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
		private System.Windows.Forms.Button btnRevokeAccess;
		private System.ComponentModel.BackgroundWorker bgwCreateUploader;
		private System.Windows.Forms.Label lblCurrentLoggedIn;
		private System.Windows.Forms.LinkLabel lnklblCurrentLoggedIn;
	}
}

