namespace STFU.Executable.StandardUploader.Forms
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.startButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.successfulActionCombobox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.channelLinkLabel = new System.Windows.Forms.LinkLabel();
			this.programmBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 13;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 5, 5);
			this.tableLayoutPanel1.Controls.Add(this.successfulActionCombobox, 7, 5);
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.channelLinkLabel, 3, 5);
			this.tableLayoutPanel1.Controls.Add(this.startButton, 11, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1128, 702);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 13);
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmBeendenToolStripMenuItem});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.dateiToolStripMenuItem.Text = "Datei";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label1, 11);
			this.label1.Location = new System.Drawing.Point(10, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1108, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Warteschlange:";
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.AutoSize = true;
			this.startButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.startButton.Location = new System.Drawing.Point(1046, 663);
			this.startButton.Margin = new System.Windows.Forms.Padding(0);
			this.startButton.Name = "startButton";
			this.startButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.startButton.Size = new System.Drawing.Size(72, 29);
			this.startButton.TabIndex = 2;
			this.startButton.Text = "Start!";
			this.startButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(141, 671);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Nach erfolgreichem Upload: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// successfulActionCombobox
			// 
			this.successfulActionCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.successfulActionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.successfulActionCombobox.FormattingEnabled = true;
			this.successfulActionCombobox.Items.AddRange(new object[] {
            "Nichts tun",
            "Programm schließen",
            "Herunterfahren"});
			this.successfulActionCombobox.Location = new System.Drawing.Point(293, 667);
			this.successfulActionCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.successfulActionCombobox.Name = "successfulActionCombobox";
			this.successfulActionCombobox.Size = new System.Drawing.Size(162, 21);
			this.successfulActionCombobox.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 671);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Eingeloggt als: ";
			// 
			// channelLinkLabel
			// 
			this.channelLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.channelLinkLabel.AutoSize = true;
			this.channelLinkLabel.Location = new System.Drawing.Point(99, 671);
			this.channelLinkLabel.Margin = new System.Windows.Forms.Padding(0);
			this.channelLinkLabel.Name = "channelLinkLabel";
			this.channelLinkLabel.Size = new System.Drawing.Size(32, 13);
			this.channelLinkLabel.TabIndex = 8;
			this.channelLinkLabel.TabStop = true;
			this.channelLinkLabel.Text = "strohi";
			// 
			// programmBeendenToolStripMenuItem
			// 
			this.programmBeendenToolStripMenuItem.Name = "programmBeendenToolStripMenuItem";
			this.programmBeendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.programmBeendenToolStripMenuItem.Text = "Programm beenden";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1128, 702);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox successfulActionCombobox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel channelLinkLabel;
		private System.Windows.Forms.ToolStripMenuItem programmBeendenToolStripMenuItem;
	}
}