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
			this.statusLabel = new System.Windows.Forms.Label();
			this.prgbarProgress = new System.Windows.Forms.ProgressBar();
			this.btnStop = new System.Windows.Forms.Button();
			this.finishActionLabel = new System.Windows.Forms.Label();
			this.cmbbxFinishAction = new System.Windows.Forms.ComboBox();
			this.chbChoseProcesses = new System.Windows.Forms.CheckBox();
			this.btnChoseProcs = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.tlpRunning.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpRunning
			// 
			this.tlpRunning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpRunning.ColumnCount = 9;
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpRunning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Controls.Add(this.statusLabel, 1, 1);
			this.tlpRunning.Controls.Add(this.prgbarProgress, 1, 3);
			this.tlpRunning.Controls.Add(this.btnStop, 7, 3);
			this.tlpRunning.Controls.Add(this.finishActionLabel, 1, 5);
			this.tlpRunning.Controls.Add(this.cmbbxFinishAction, 3, 5);
			this.tlpRunning.Controls.Add(this.chbChoseProcesses, 5, 5);
			this.tlpRunning.Controls.Add(this.btnChoseProcs, 7, 5);
			this.tlpRunning.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpRunning.Location = new System.Drawing.Point(0, 0);
			this.tlpRunning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 7;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Size = new System.Drawing.Size(864, 133);
			this.tlpRunning.TabIndex = 2;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 7);
			this.statusLabel.Location = new System.Drawing.Point(11, 19);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(843, 17);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Suche Dateien zum Upload...";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpRunning.SetColumnSpan(this.prgbarProgress, 5);
			this.prgbarProgress.Location = new System.Drawing.Point(11, 57);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.MarqueeAnimationSpeed = 10;
			this.prgbarProgress.Maximum = 10000;
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(743, 23);
			this.prgbarProgress.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(764, 55);
			this.btnStop.Margin = new System.Windows.Forms.Padding(0);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(90, 27);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Abbrechen!";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStopClick);
			// 
			// finishActionLabel
			// 
			this.finishActionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.finishActionLabel.AutoSize = true;
			this.finishActionLabel.Location = new System.Drawing.Point(11, 99);
			this.finishActionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.finishActionLabel.Name = "finishActionLabel";
			this.finishActionLabel.Size = new System.Drawing.Size(73, 17);
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
            "Programm schließen",
            "Herunterfahren"});
			this.cmbbxFinishAction.Location = new System.Drawing.Point(95, 95);
			this.cmbbxFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.cmbbxFinishAction.Name = "cmbbxFinishAction";
			this.cmbbxFinishAction.Size = new System.Drawing.Size(451, 24);
			this.cmbbxFinishAction.TabIndex = 16;
			this.cmbbxFinishAction.SelectedIndexChanged += new System.EventHandler(this.cmbbxFinishActionSelectedIndexChanged);
			// 
			// chbChoseProcesses
			// 
			this.chbChoseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbChoseProcesses.AutoSize = true;
			this.chbChoseProcesses.Enabled = false;
			this.chbChoseProcesses.Location = new System.Drawing.Point(557, 97);
			this.chbChoseProcesses.Margin = new System.Windows.Forms.Padding(0);
			this.chbChoseProcesses.Name = "chbChoseProcesses";
			this.chbChoseProcesses.Size = new System.Drawing.Size(197, 21);
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
			this.btnChoseProcs.Location = new System.Drawing.Point(764, 92);
			this.btnChoseProcs.Margin = new System.Windows.Forms.Padding(0);
			this.btnChoseProcs.Name = "btnChoseProcs";
			this.btnChoseProcs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnChoseProcs.Size = new System.Drawing.Size(90, 31);
			this.btnChoseProcs.TabIndex = 18;
			this.btnChoseProcs.Text = "[...]";
			this.btnChoseProcs.UseVisualStyleBackColor = true;
			this.btnChoseProcs.Click += new System.EventHandler(this.btnChoseProcsClick);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Enabled = true;
			this.refreshTimer.Interval = 10;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimerTick);
			// 
			// UploadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 133);
			this.ControlBox = false;
			this.Controls.Add(this.tlpRunning);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ProgressBar prgbarProgress;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Label finishActionLabel;
		private System.Windows.Forms.ComboBox cmbbxFinishAction;
		private System.Windows.Forms.CheckBox chbChoseProcesses;
		private System.Windows.Forms.Button btnChoseProcs;
	}
}