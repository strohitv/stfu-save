namespace STFU.AutoUploader
{
	partial class UploadForm
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
			this.tlpRunning = new System.Windows.Forms.TableLayoutPanel();
			this.statusStaticLabel = new System.Windows.Forms.Label();
			this.prgbarProgress = new System.Windows.Forms.ProgressBar();
			this.finishActionLabel = new System.Windows.Forms.Label();
			this.cmbbxFinishAction = new System.Windows.Forms.ComboBox();
			this.chbChoseProcesses = new System.Windows.Forms.CheckBox();
			this.btnChoseProcs = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.fileStaticLabel = new System.Windows.Forms.Label();
			this.fileLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.tlpRunning.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpRunning
			// 
			this.tlpRunning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpRunning.ColumnCount = 11;
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Controls.Add(this.statusStaticLabel, 1, 3);
			this.tlpRunning.Controls.Add(this.prgbarProgress, 1, 5);
			this.tlpRunning.Controls.Add(this.finishActionLabel, 1, 7);
			this.tlpRunning.Controls.Add(this.cmbbxFinishAction, 3, 7);
			this.tlpRunning.Controls.Add(this.chbChoseProcesses, 5, 7);
			this.tlpRunning.Controls.Add(this.btnChoseProcs, 7, 7);
			this.tlpRunning.Controls.Add(this.btnStop, 9, 5);
			this.tlpRunning.Controls.Add(this.fileStaticLabel, 1, 1);
			this.tlpRunning.Controls.Add(this.fileLabel, 3, 1);
			this.tlpRunning.Controls.Add(this.statusLabel, 3, 3);
			this.tlpRunning.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpRunning.Location = new System.Drawing.Point(0, 0);
			this.tlpRunning.Margin = new System.Windows.Forms.Padding(2);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 9;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Size = new System.Drawing.Size(648, 167);
			this.tlpRunning.TabIndex = 2;
			// 
			// statusStaticLabel
			// 
			this.statusStaticLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusStaticLabel.AutoSize = true;
			this.statusStaticLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStaticLabel.Location = new System.Drawing.Point(10, 38);
			this.statusStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusStaticLabel.Name = "statusStaticLabel";
			this.statusStaticLabel.Size = new System.Drawing.Size(88, 18);
			this.statusStaticLabel.TabIndex = 0;
			this.statusStaticLabel.Text = "Status: ";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpRunning.SetColumnSpan(this.prgbarProgress, 7);
			this.prgbarProgress.Location = new System.Drawing.Point(10, 99);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.MarqueeAnimationSpeed = 10;
			this.prgbarProgress.Maximum = 10000;
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(546, 19);
			this.prgbarProgress.TabIndex = 1;
			// 
			// finishActionLabel
			// 
			this.finishActionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.finishActionLabel.AutoSize = true;
			this.finishActionLabel.Location = new System.Drawing.Point(10, 137);
			this.finishActionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.finishActionLabel.Name = "finishActionLabel";
			this.finishActionLabel.Size = new System.Drawing.Size(88, 13);
			this.finishActionLabel.TabIndex = 0;
			this.finishActionLabel.Text = "Am Ende: ";
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
			this.cmbbxFinishAction.Location = new System.Drawing.Point(108, 133);
			this.cmbbxFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.cmbbxFinishAction.Name = "cmbbxFinishAction";
			this.cmbbxFinishAction.Size = new System.Drawing.Size(242, 21);
			this.cmbbxFinishAction.TabIndex = 16;
			this.cmbbxFinishAction.SelectedIndexChanged += new System.EventHandler(this.cmbbxFinishActionSelectedIndexChanged);
			// 
			// chbChoseProcesses
			// 
			this.chbChoseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbChoseProcesses.AutoSize = true;
			this.chbChoseProcesses.Enabled = false;
			this.chbChoseProcesses.Location = new System.Drawing.Point(360, 135);
			this.chbChoseProcesses.Margin = new System.Windows.Forms.Padding(0);
			this.chbChoseProcesses.Name = "chbChoseProcesses";
			this.chbChoseProcesses.Size = new System.Drawing.Size(150, 17);
			this.chbChoseProcesses.TabIndex = 17;
			this.chbChoseProcesses.Text = "Programmenden abwarten";
			this.chbChoseProcesses.UseVisualStyleBackColor = true;
			this.chbChoseProcesses.CheckedChanged += new System.EventHandler(this.chbChoseProcessesCheckedChanged);
			// 
			// btnChoseProcs
			// 
			this.btnChoseProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChoseProcs.AutoSize = true;
			this.btnChoseProcs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnChoseProcs.Enabled = false;
			this.btnChoseProcs.Location = new System.Drawing.Point(520, 130);
			this.btnChoseProcs.Margin = new System.Windows.Forms.Padding(0);
			this.btnChoseProcs.Name = "btnChoseProcs";
			this.btnChoseProcs.Padding = new System.Windows.Forms.Padding(2);
			this.btnChoseProcs.Size = new System.Drawing.Size(36, 27);
			this.btnChoseProcs.TabIndex = 18;
			this.btnChoseProcs.Text = "[...]";
			this.btnChoseProcs.UseVisualStyleBackColor = true;
			this.btnChoseProcs.Click += new System.EventHandler(this.btnChoseProcsClick);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(566, 97);
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
			this.refreshTimer.Enabled = true;
			this.refreshTimer.Interval = 10;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimerTick);
			// 
			// fileStaticLabel
			// 
			this.fileStaticLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.fileStaticLabel.AutoSize = true;
			this.fileStaticLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileStaticLabel.Location = new System.Drawing.Point(10, 10);
			this.fileStaticLabel.Margin = new System.Windows.Forms.Padding(0);
			this.fileStaticLabel.Name = "fileStaticLabel";
			this.fileStaticLabel.Size = new System.Drawing.Size(88, 18);
			this.fileStaticLabel.TabIndex = 0;
			this.fileStaticLabel.Text = "Video: ";
			// 
			// fileLabel
			// 
			this.fileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.fileLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.fileLabel, 7);
			this.fileLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileLabel.Location = new System.Drawing.Point(108, 10);
			this.fileLabel.Margin = new System.Windows.Forms.Padding(0);
			this.fileLabel.Name = "fileLabel";
			this.fileLabel.Size = new System.Drawing.Size(530, 18);
			this.fileLabel.TabIndex = 0;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 7);
			this.statusLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(108, 38);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(530, 18);
			this.statusLabel.TabIndex = 0;
			// 
			// UploadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(648, 167);
			this.ControlBox = false;
			this.Controls.Add(this.tlpRunning);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UploadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lade Dateien hoch...";
			this.Load += new System.EventHandler(this.UploadFormLoad);
			this.tlpRunning.ResumeLayout(false);
			this.tlpRunning.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpRunning;
		private System.Windows.Forms.Label statusStaticLabel;
		private System.Windows.Forms.ProgressBar prgbarProgress;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Label finishActionLabel;
		private System.Windows.Forms.ComboBox cmbbxFinishAction;
		private System.Windows.Forms.CheckBox chbChoseProcesses;
		private System.Windows.Forms.Button btnChoseProcs;
		private System.Windows.Forms.Label fileStaticLabel;
		private System.Windows.Forms.Label fileLabel;
		private System.Windows.Forms.Label statusLabel;
	}
}