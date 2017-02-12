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
			this.btnRevokeAccess = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tlpRunning = new System.Windows.Forms.TableLayoutPanel();
			this.statusLabel = new System.Windows.Forms.Label();
			this.prgbarProgress = new System.Windows.Forms.ProgressBar();
			this.btnStop = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
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
			this.tlpSettings.Controls.Add(this.label1, 1, 1);
			this.tlpSettings.Controls.Add(this.label2, 1, 3);
			this.tlpSettings.Controls.Add(this.btnSelectPath, 7, 1);
			this.tlpSettings.Controls.Add(this.btnAddPathToWatch, 7, 3);
			this.tlpSettings.Controls.Add(this.btnConnectYoutubeAccount, 5, 7);
			this.tlpSettings.Controls.Add(this.btnStart, 7, 7);
			this.tlpSettings.Controls.Add(this.lvSelectedPaths, 1, 5);
			this.tlpSettings.Controls.Add(this.txtbxAddPath, 3, 1);
			this.tlpSettings.Controls.Add(this.txtbxAddFilter, 3, 3);
			this.tlpSettings.Controls.Add(this.btnRevokeAccess, 3, 7);
			this.tlpSettings.Location = new System.Drawing.Point(38, 27);
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
			this.tlpSettings.Size = new System.Drawing.Size(872, 419);
			this.tlpSettings.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
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
			this.label2.Size = new System.Drawing.Size(76, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Dateifilter: ";
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectPath.AutoSize = true;
			this.btnSelectPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSelectPath.Location = new System.Drawing.Point(767, 10);
			this.btnSelectPath.Margin = new System.Windows.Forms.Padding(0);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(95, 27);
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
			this.btnAddPathToWatch.Location = new System.Drawing.Point(767, 47);
			this.btnAddPathToWatch.Margin = new System.Windows.Forms.Padding(0);
			this.btnAddPathToWatch.Name = "btnAddPathToWatch";
			this.btnAddPathToWatch.Size = new System.Drawing.Size(95, 27);
			this.btnAddPathToWatch.TabIndex = 5;
			this.btnAddPathToWatch.Text = "Hinzufügen!";
			this.btnAddPathToWatch.UseVisualStyleBackColor = true;
			this.btnAddPathToWatch.Click += new System.EventHandler(this.btnAddPathToWatchClick);
			// 
			// btnConnectYoutubeAccount
			// 
			this.btnConnectYoutubeAccount.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnConnectYoutubeAccount.AutoSize = true;
			this.btnConnectYoutubeAccount.Location = new System.Drawing.Point(597, 382);
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
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.AutoSize = true;
			this.btnStart.Location = new System.Drawing.Point(767, 382);
			this.btnStart.Margin = new System.Windows.Forms.Padding(0);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(95, 27);
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
			this.tlpSettings.SetColumnSpan(this.lvSelectedPaths, 7);
			this.lvSelectedPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSelectedPaths.FullRowSelect = true;
			this.lvSelectedPaths.Location = new System.Drawing.Point(10, 84);
			this.lvSelectedPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvSelectedPaths.Name = "lvSelectedPaths";
			this.lvSelectedPaths.Size = new System.Drawing.Size(852, 288);
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
			this.chFilter.Width = 200;
			// 
			// txtbxAddPath
			// 
			this.txtbxAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.txtbxAddPath, 3);
			this.txtbxAddPath.Location = new System.Drawing.Point(96, 12);
			this.txtbxAddPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddPath.Name = "txtbxAddPath";
			this.txtbxAddPath.Size = new System.Drawing.Size(661, 22);
			this.txtbxAddPath.TabIndex = 0;
			// 
			// txtbxAddFilter
			// 
			this.txtbxAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpSettings.SetColumnSpan(this.txtbxAddFilter, 3);
			this.txtbxAddFilter.Location = new System.Drawing.Point(96, 49);
			this.txtbxAddFilter.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddFilter.Name = "txtbxAddFilter";
			this.txtbxAddFilter.Size = new System.Drawing.Size(661, 22);
			this.txtbxAddFilter.TabIndex = 1;
			// 
			// btnRevokeAccess
			// 
			this.btnRevokeAccess.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnRevokeAccess.AutoSize = true;
			this.btnRevokeAccess.Location = new System.Drawing.Point(427, 382);
			this.btnRevokeAccess.Margin = new System.Windows.Forms.Padding(0);
			this.btnRevokeAccess.Name = "btnRevokeAccess";
			this.btnRevokeAccess.Size = new System.Drawing.Size(160, 27);
			this.btnRevokeAccess.TabIndex = 8;
			this.btnRevokeAccess.Text = "Verbindung trennen";
			this.btnRevokeAccess.UseVisualStyleBackColor = true;
			this.btnRevokeAccess.Visible = false;
			this.btnRevokeAccess.Click += new System.EventHandler(this.btnRevokeAccessClick);
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
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Controls.Add(this.statusLabel, 1, 1);
			this.tlpRunning.Controls.Add(this.prgbarProgress, 1, 3);
			this.tlpRunning.Controls.Add(this.btnStop, 3, 3);
			this.tlpRunning.Location = new System.Drawing.Point(38, 582);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 5;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Size = new System.Drawing.Size(862, 74);
			this.tlpRunning.TabIndex = 1;
			this.tlpRunning.Visible = false;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 3);
			this.statusLabel.Location = new System.Drawing.Point(10, 10);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(842, 17);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Suche Dateien zum Upload...";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.prgbarProgress.Location = new System.Drawing.Point(10, 39);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(742, 23);
			this.prgbarProgress.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(762, 37);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1753, 690);
			this.Controls.Add(this.tlpRunning);
			this.Controls.Add(this.tlpSettings);
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
	}
}

