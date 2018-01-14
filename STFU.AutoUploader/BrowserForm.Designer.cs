namespace STFU.AutoUploader
{
	partial class BrowserForm
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
			this.browserPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// browserPanel
			// 
			this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browserPanel.Location = new System.Drawing.Point(0, 0);
			this.browserPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.browserPanel.Name = "browserPanel";
			this.browserPanel.Size = new System.Drawing.Size(865, 767);
			this.browserPanel.TabIndex = 1;
			// 
			// BrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(865, 767);
			this.Controls.Add(this.browserPanel);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "BrowserForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Youtube-Account anmelden";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserFormClosing);
			this.Load += new System.EventHandler(this.BrowserLoad);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel browserPanel;
	}
}