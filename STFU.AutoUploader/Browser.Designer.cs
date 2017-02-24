namespace STFU.AutoUploader
{
	partial class Browser
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
			this.browserPanel.Name = "browserPanel";
			this.browserPanel.Size = new System.Drawing.Size(649, 623);
			this.browserPanel.TabIndex = 1;
			// 
			// Browser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(649, 623);
			this.Controls.Add(this.browserPanel);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Browser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Browser";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserFormClosing);
			this.Load += new System.EventHandler(this.BrowserLoad);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel browserPanel;
	}
}