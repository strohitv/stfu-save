namespace STFU.Lib.GUI.Forms
{
	partial class AddYoutubeAccountForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddYoutubeAccountForm));
			this.useExternalGroupBox = new System.Windows.Forms.GroupBox();
			this.useExternalTlp = new System.Windows.Forms.TableLayoutPanel();
			this.useExternalDescLabel = new System.Windows.Forms.Label();
			this.useExternalExplanationLabel = new System.Windows.Forms.Label();
			this.useExternalLinkLabel = new System.Windows.Forms.LinkLabel();
			this.useExternalLinkTextbox = new System.Windows.Forms.TextBox();
			this.allowMailingCheckbox = new System.Windows.Forms.CheckBox();
			this.checkLoginTimer = new System.Windows.Forms.Timer(this.components);
			this.useExternalGroupBox.SuspendLayout();
			this.useExternalTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// useExternalGroupBox
			// 
			this.useExternalGroupBox.Controls.Add(this.useExternalTlp);
			this.useExternalGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useExternalGroupBox.Location = new System.Drawing.Point(0, 0);
			this.useExternalGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.useExternalGroupBox.Name = "useExternalGroupBox";
			this.useExternalGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.useExternalGroupBox.Size = new System.Drawing.Size(437, 205);
			this.useExternalGroupBox.TabIndex = 2;
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
			this.useExternalTlp.Controls.Add(this.useExternalDescLabel, 1, 4);
			this.useExternalTlp.Controls.Add(this.useExternalExplanationLabel, 1, 1);
			this.useExternalTlp.Controls.Add(this.useExternalLinkLabel, 3, 6);
			this.useExternalTlp.Controls.Add(this.useExternalLinkTextbox, 3, 4);
			this.useExternalTlp.Controls.Add(this.allowMailingCheckbox, 1, 2);
			this.useExternalTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useExternalTlp.Location = new System.Drawing.Point(2, 15);
			this.useExternalTlp.Margin = new System.Windows.Forms.Padding(2);
			this.useExternalTlp.Name = "useExternalTlp";
			this.useExternalTlp.RowCount = 8;
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.useExternalTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.useExternalTlp.Size = new System.Drawing.Size(433, 188);
			this.useExternalTlp.TabIndex = 0;
			// 
			// useExternalDescLabel
			// 
			this.useExternalDescLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalDescLabel.AutoSize = true;
			this.useExternalDescLabel.Location = new System.Drawing.Point(10, 138);
			this.useExternalDescLabel.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalDescLabel.Name = "useExternalDescLabel";
			this.useExternalDescLabel.Size = new System.Drawing.Size(119, 13);
			this.useExternalDescLabel.TabIndex = 0;
			this.useExternalDescLabel.Text = "Folgenden Link öffnen: ";
			// 
			// useExternalExplanationLabel
			// 
			this.useExternalExplanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalExplanationLabel.AutoSize = true;
			this.useExternalTlp.SetColumnSpan(this.useExternalExplanationLabel, 5);
			this.useExternalExplanationLabel.Location = new System.Drawing.Point(12, 10);
			this.useExternalExplanationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.useExternalExplanationLabel.Name = "useExternalExplanationLabel";
			this.useExternalExplanationLabel.Size = new System.Drawing.Size(409, 88);
			this.useExternalExplanationLabel.TabIndex = 1;
			this.useExternalExplanationLabel.Text = resources.GetString("useExternalExplanationLabel.Text");
			// 
			// useExternalLinkLabel
			// 
			this.useExternalLinkLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.useExternalLinkLabel.AutoSize = true;
			this.useExternalTlp.SetColumnSpan(this.useExternalLinkLabel, 3);
			this.useExternalLinkLabel.Location = new System.Drawing.Point(139, 165);
			this.useExternalLinkLabel.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalLinkLabel.Name = "useExternalLinkLabel";
			this.useExternalLinkLabel.Size = new System.Drawing.Size(223, 13);
			this.useExternalLinkLabel.TabIndex = 2;
			this.useExternalLinkLabel.TabStop = true;
			this.useExternalLinkLabel.Text = "Anmelden mit Google (Link im Browser öffnen)";
			this.useExternalLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.useExternalLinkLabelLinkClicked);
			// 
			// useExternalLinkTextbox
			// 
			this.useExternalLinkTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExternalLinkTextbox.BackColor = System.Drawing.SystemColors.Window;
			this.useExternalTlp.SetColumnSpan(this.useExternalLinkTextbox, 3);
			this.useExternalLinkTextbox.Location = new System.Drawing.Point(139, 135);
			this.useExternalLinkTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.useExternalLinkTextbox.Name = "useExternalLinkTextbox";
			this.useExternalLinkTextbox.ReadOnly = true;
			this.useExternalLinkTextbox.Size = new System.Drawing.Size(284, 20);
			this.useExternalLinkTextbox.TabIndex = 3;
			// 
			// allowMailingCheckbox
			// 
			this.allowMailingCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.allowMailingCheckbox.AutoSize = true;
			this.useExternalTlp.SetColumnSpan(this.allowMailingCheckbox, 5);
			this.allowMailingCheckbox.Location = new System.Drawing.Point(10, 108);
			this.allowMailingCheckbox.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.allowMailingCheckbox.Name = "allowMailingCheckbox";
			this.allowMailingCheckbox.Size = new System.Drawing.Size(413, 17);
			this.allowMailingCheckbox.TabIndex = 5;
			this.allowMailingCheckbox.Text = "Mailversand aktivieren (=> NUR Mailversand, Postfach NICHT lesbar)";
			this.allowMailingCheckbox.UseVisualStyleBackColor = true;
			this.allowMailingCheckbox.CheckedChanged += new System.EventHandler(this.allowMailingCheckbox_CheckedChanged);
			// 
			// checkLoginTimer
			// 
			this.checkLoginTimer.Enabled = true;
			this.checkLoginTimer.Tick += new System.EventHandler(this.checkLoginTimer_Tick);
			// 
			// AddYoutubeAccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 205);
			this.Controls.Add(this.useExternalGroupBox);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "AddYoutubeAccountForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Youtube-Account anmelden";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddYoutubeAccountForm_FormClosing);
			this.Load += new System.EventHandler(this.AddAccountFormLoad);
			this.useExternalGroupBox.ResumeLayout(false);
			this.useExternalTlp.ResumeLayout(false);
			this.useExternalTlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox useExternalGroupBox;
		private System.Windows.Forms.TableLayoutPanel useExternalTlp;
		private System.Windows.Forms.Label useExternalDescLabel;
		private System.Windows.Forms.Label useExternalExplanationLabel;
		private System.Windows.Forms.LinkLabel useExternalLinkLabel;
		private System.Windows.Forms.TextBox useExternalLinkTextbox;
		private System.Windows.Forms.CheckBox allowMailingCheckbox;
		private System.Windows.Forms.Timer checkLoginTimer;
	}
}