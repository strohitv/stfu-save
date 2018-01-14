namespace STFU.AutoUploader
{
	partial class AddAccountForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountForm));
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.useBrowserGroupBox = new System.Windows.Forms.GroupBox();
			this.useBrowserTlp = new System.Windows.Forms.TableLayoutPanel();
			this.showBrowserButton = new System.Windows.Forms.Button();
			this.useExternalGroupBox = new System.Windows.Forms.GroupBox();
			this.useExternalTlp = new System.Windows.Forms.TableLayoutPanel();
			this.useExternalDescLabel = new System.Windows.Forms.Label();
			this.useExternalCodeLabel = new System.Windows.Forms.Label();
			this.useExternalExplanationLabel = new System.Windows.Forms.Label();
			this.useExternalLinkLabel = new System.Windows.Forms.LinkLabel();
			this.useExternalLinkTextbox = new System.Windows.Forms.TextBox();
			this.useExternalCodeTextbox = new System.Windows.Forms.TextBox();
			this.signInButton = new System.Windows.Forms.Button();
			this.mainTlp.SuspendLayout();
			this.useBrowserGroupBox.SuspendLayout();
			this.useBrowserTlp.SuspendLayout();
			this.useExternalGroupBox.SuspendLayout();
			this.useExternalTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.ColumnCount = 3;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Controls.Add(this.useBrowserGroupBox, 1, 1);
			this.mainTlp.Controls.Add(this.useExternalGroupBox, 1, 3);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 5;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Size = new System.Drawing.Size(583, 349);
			this.mainTlp.TabIndex = 0;
			// 
			// useBrowserGroupBox
			// 
			this.useBrowserGroupBox.AutoSize = true;
			this.useBrowserGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.useBrowserGroupBox.Controls.Add(this.useBrowserTlp);
			this.useBrowserGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useBrowserGroupBox.Location = new System.Drawing.Point(13, 13);
			this.useBrowserGroupBox.Name = "useBrowserGroupBox";
			this.useBrowserGroupBox.Size = new System.Drawing.Size(557, 100);
			this.useBrowserGroupBox.TabIndex = 0;
			this.useBrowserGroupBox.TabStop = false;
			this.useBrowserGroupBox.Text = "Anmeldung direkt im Programm";
			// 
			// useBrowserTlp
			// 
			this.useBrowserTlp.ColumnCount = 3;
			this.useBrowserTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.useBrowserTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.useBrowserTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
			this.useBrowserTlp.Controls.Add(this.showBrowserButton, 1, 1);
			this.useBrowserTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useBrowserTlp.Location = new System.Drawing.Point(3, 18);
			this.useBrowserTlp.Name = "useBrowserTlp";
			this.useBrowserTlp.RowCount = 3;
			this.useBrowserTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.useBrowserTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useBrowserTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
			this.useBrowserTlp.Size = new System.Drawing.Size(551, 79);
			this.useBrowserTlp.TabIndex = 0;
			// 
			// showBrowserButton
			// 
			this.showBrowserButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.showBrowserButton.AutoSize = true;
			this.showBrowserButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.showBrowserButton.Location = new System.Drawing.Point(53, 22);
			this.showBrowserButton.Margin = new System.Windows.Forms.Padding(0);
			this.showBrowserButton.Name = "showBrowserButton";
			this.showBrowserButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.showBrowserButton.Size = new System.Drawing.Size(444, 33);
			this.showBrowserButton.TabIndex = 0;
			this.showBrowserButton.Text = "Direkt im Programm anmelden (funktioniert nur unter Windows)";
			this.showBrowserButton.UseVisualStyleBackColor = true;
			this.showBrowserButton.Click += new System.EventHandler(this.showBrowserButtonClick);
			// 
			// useExternalGroupBox
			// 
			this.useExternalGroupBox.Controls.Add(this.useExternalTlp);
			this.useExternalGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useExternalGroupBox.Location = new System.Drawing.Point(13, 129);
			this.useExternalGroupBox.Name = "useExternalGroupBox";
			this.useExternalGroupBox.Size = new System.Drawing.Size(557, 206);
			this.useExternalGroupBox.TabIndex = 1;
			this.useExternalGroupBox.TabStop = false;
			this.useExternalGroupBox.Text = "Anmeldung über einen externen Browser";
			// 
			// useExternalTlp
			// 
			this.useExternalTlp.ColumnCount = 7;
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.useExternalTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.Controls.Add(this.useExternalDescLabel, 1, 3);
			this.useExternalTlp.Controls.Add(this.useExternalCodeLabel, 1, 7);
			this.useExternalTlp.Controls.Add(this.useExternalExplanationLabel, 1, 1);
			this.useExternalTlp.Controls.Add(this.useExternalLinkLabel, 3, 5);
			this.useExternalTlp.Controls.Add(this.useExternalLinkTextbox, 3, 3);
			this.useExternalTlp.Controls.Add(this.useExternalCodeTextbox, 3, 7);
			this.useExternalTlp.Controls.Add(this.signInButton, 5, 7);
			this.useExternalTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useExternalTlp.Location = new System.Drawing.Point(3, 18);
			this.useExternalTlp.Name = "useExternalTlp";
			this.useExternalTlp.RowCount = 9;
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.Size = new System.Drawing.Size(551, 185);
			this.useExternalTlp.TabIndex = 0;
			// 
			// useExternalDescLabel
			// 
			this.useExternalDescLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalDescLabel.AutoSize = true;
			this.useExternalDescLabel.Location = new System.Drawing.Point(10, 85);
			this.useExternalDescLabel.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalDescLabel.Name = "useExternalDescLabel";
			this.useExternalDescLabel.Size = new System.Drawing.Size(157, 17);
			this.useExternalDescLabel.TabIndex = 0;
			this.useExternalDescLabel.Text = "Folgenden Link öffnen: ";
			// 
			// useExternalCodeLabel
			// 
			this.useExternalCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalCodeLabel.AutoSize = true;
			this.useExternalCodeLabel.Location = new System.Drawing.Point(10, 150);
			this.useExternalCodeLabel.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalCodeLabel.Name = "useExternalCodeLabel";
			this.useExternalCodeLabel.Size = new System.Drawing.Size(157, 17);
			this.useExternalCodeLabel.TabIndex = 0;
			this.useExternalCodeLabel.Text = "Code eintragen: ";
			// 
			// useExternalExplanationLabel
			// 
			this.useExternalExplanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalExplanationLabel.AutoSize = true;
			this.useExternalTlp.SetColumnSpan(this.useExternalExplanationLabel, 5);
			this.useExternalExplanationLabel.Location = new System.Drawing.Point(13, 10);
			this.useExternalExplanationLabel.Name = "useExternalExplanationLabel";
			this.useExternalExplanationLabel.Size = new System.Drawing.Size(525, 63);
			this.useExternalExplanationLabel.TabIndex = 1;
			this.useExternalExplanationLabel.Text = resources.GetString("useExternalExplanationLabel.Text");
			// 
			// useExternalLinkLabel
			// 
			this.useExternalLinkLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.useExternalLinkLabel.AutoSize = true;
			this.useExternalTlp.SetColumnSpan(this.useExternalLinkLabel, 3);
			this.useExternalLinkLabel.Location = new System.Drawing.Point(177, 115);
			this.useExternalLinkLabel.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalLinkLabel.Name = "useExternalLinkLabel";
			this.useExternalLinkLabel.Size = new System.Drawing.Size(151, 17);
			this.useExternalLinkLabel.TabIndex = 2;
			this.useExternalLinkLabel.TabStop = true;
			this.useExternalLinkLabel.Text = "Link im Browser öffnen";
			this.useExternalLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.useExternalLinkLabelLinkClicked);
			// 
			// useExternalLinkTextbox
			// 
			this.useExternalLinkTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalLinkTextbox.BackColor = System.Drawing.SystemColors.Window;
			this.useExternalTlp.SetColumnSpan(this.useExternalLinkTextbox, 3);
			this.useExternalLinkTextbox.Location = new System.Drawing.Point(177, 83);
			this.useExternalLinkTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalLinkTextbox.Name = "useExternalLinkTextbox";
			this.useExternalLinkTextbox.ReadOnly = true;
			this.useExternalLinkTextbox.Size = new System.Drawing.Size(364, 22);
			this.useExternalLinkTextbox.TabIndex = 3;
			// 
			// useExternalCodeTextbox
			// 
			this.useExternalCodeTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalCodeTextbox.Location = new System.Drawing.Point(177, 147);
			this.useExternalCodeTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalCodeTextbox.Name = "useExternalCodeTextbox";
			this.useExternalCodeTextbox.Size = new System.Drawing.Size(240, 22);
			this.useExternalCodeTextbox.TabIndex = 3;
			// 
			// signInButton
			// 
			this.signInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.signInButton.AutoSize = true;
			this.signInButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.signInButton.Location = new System.Drawing.Point(427, 142);
			this.signInButton.Margin = new System.Windows.Forms.Padding(0);
			this.signInButton.Name = "signInButton";
			this.signInButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.signInButton.Size = new System.Drawing.Size(114, 33);
			this.signInButton.TabIndex = 4;
			this.signInButton.Text = "Anmelden!";
			this.signInButton.UseVisualStyleBackColor = true;
			this.signInButton.Click += new System.EventHandler(this.signInButtonClick);
			// 
			// AddAccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 349);
			this.Controls.Add(this.mainTlp);
			this.Name = "AddAccountForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Youtube-Account anmelden";
			this.Load += new System.EventHandler(this.AddAccountFormLoad);
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.useBrowserGroupBox.ResumeLayout(false);
			this.useBrowserTlp.ResumeLayout(false);
			this.useBrowserTlp.PerformLayout();
			this.useExternalGroupBox.ResumeLayout(false);
			this.useExternalTlp.ResumeLayout(false);
			this.useExternalTlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.GroupBox useBrowserGroupBox;
		private System.Windows.Forms.TableLayoutPanel useBrowserTlp;
		private System.Windows.Forms.Button showBrowserButton;
		private System.Windows.Forms.GroupBox useExternalGroupBox;
		private System.Windows.Forms.TableLayoutPanel useExternalTlp;
		private System.Windows.Forms.Label useExternalDescLabel;
		private System.Windows.Forms.Label useExternalCodeLabel;
		private System.Windows.Forms.Label useExternalExplanationLabel;
		private System.Windows.Forms.LinkLabel useExternalLinkLabel;
		private System.Windows.Forms.TextBox useExternalLinkTextbox;
		private System.Windows.Forms.TextBox useExternalCodeTextbox;
		private System.Windows.Forms.Button signInButton;
	}
}