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
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.tlpRunning.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpRunning
			// 
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
			this.tlpRunning.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpRunning.Location = new System.Drawing.Point(0, 0);
			this.tlpRunning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tlpRunning.Name = "tlpRunning";
			this.tlpRunning.RowCount = 5;
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpRunning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpRunning.Size = new System.Drawing.Size(864, 92);
			this.tlpRunning.TabIndex = 2;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.AutoSize = true;
			this.tlpRunning.SetColumnSpan(this.statusLabel, 3);
			this.statusLabel.Location = new System.Drawing.Point(11, 19);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(842, 17);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Suche Dateien zum Upload...";
			// 
			// prgbarProgress
			// 
			this.prgbarProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.prgbarProgress.Location = new System.Drawing.Point(11, 57);
			this.prgbarProgress.Margin = new System.Windows.Forms.Padding(0);
			this.prgbarProgress.MarqueeAnimationSpeed = 10;
			this.prgbarProgress.Maximum = 10000;
			this.prgbarProgress.Name = "prgbarProgress";
			this.prgbarProgress.Size = new System.Drawing.Size(741, 23);
			this.prgbarProgress.TabIndex = 1;
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.AutoSize = true;
			this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnStop.Location = new System.Drawing.Point(763, 55);
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
			this.refreshTimer.Enabled = true;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimerTick);
			// 
			// UploadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 92);
			this.ControlBox = false;
			this.Controls.Add(this.tlpRunning);
			this.Name = "UploadForm";
			this.ShowInTaskbar = false;
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
	}
}