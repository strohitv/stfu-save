namespace STFU.Lib.GUI.Controls.Queue
{
	partial class JobControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.uploadTitle = new System.Windows.Forms.Label();
			this.uploadStateLabel = new System.Windows.Forms.Label();
			this.actionsButton = new System.Windows.Forms.Button();
			this.thumbnailBox = new System.Windows.Forms.PictureBox();
			this.actionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.startenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pausierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fortsetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.überspringenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abbrechenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.detailsBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nachObenSchiebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nachUntenSchiebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).BeginInit();
			this.actionsContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.AutoSize = true;
			this.mainTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTableLayoutPanel.ColumnCount = 6;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.Controls.Add(this.progressBar, 1, 3);
			this.mainTableLayoutPanel.Controls.Add(this.uploadTitle, 2, 1);
			this.mainTableLayoutPanel.Controls.Add(this.uploadStateLabel, 2, 2);
			this.mainTableLayoutPanel.Controls.Add(this.actionsButton, 4, 1);
			this.mainTableLayoutPanel.Controls.Add(this.thumbnailBox, 1, 1);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 6;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(550, 159);
			this.mainTableLayoutPanel.TabIndex = 0;
			// 
			// progressBar
			// 
			this.mainTableLayoutPanel.SetColumnSpan(this.progressBar, 4);
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBar.Location = new System.Drawing.Point(10, 110);
			this.progressBar.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.progressBar.Maximum = 10000;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(530, 29);
			this.progressBar.TabIndex = 0;
			this.progressBar.Visible = false;
			// 
			// uploadTitle
			// 
			this.uploadTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadTitle.AutoSize = true;
			this.uploadTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadTitle.Location = new System.Drawing.Point(120, 10);
			this.uploadTitle.Margin = new System.Windows.Forms.Padding(0);
			this.uploadTitle.Name = "uploadTitle";
			this.uploadTitle.Size = new System.Drawing.Size(321, 40);
			this.uploadTitle.TabIndex = 1;
			this.uploadTitle.Text = "Titel\r\nzweizeilig";
			// 
			// uploadStateLabel
			// 
			this.uploadStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadStateLabel.AutoSize = true;
			this.mainTableLayoutPanel.SetColumnSpan(this.uploadStateLabel, 3);
			this.uploadStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadStateLabel.Location = new System.Drawing.Point(120, 60);
			this.uploadStateLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.uploadStateLabel.Name = "uploadStateLabel";
			this.uploadStateLabel.Size = new System.Drawing.Size(420, 40);
			this.uploadStateLabel.TabIndex = 2;
			this.uploadStateLabel.Text = "Uploadstatus\r\nZweite Zeile";
			this.uploadStateLabel.Visible = false;
			// 
			// actionsButton
			// 
			this.actionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.actionsButton.AutoSize = true;
			this.actionsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.actionsButton.Location = new System.Drawing.Point(451, 15);
			this.actionsButton.Margin = new System.Windows.Forms.Padding(0);
			this.actionsButton.Name = "actionsButton";
			this.actionsButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.actionsButton.Size = new System.Drawing.Size(89, 29);
			this.actionsButton.TabIndex = 3;
			this.actionsButton.Text = "Aktionen";
			this.actionsButton.UseVisualStyleBackColor = true;
			this.actionsButton.Click += new System.EventHandler(this.actionsButton_Click);
			// 
			// thumbnailBox
			// 
			this.thumbnailBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.thumbnailBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thumbnailBox.Location = new System.Drawing.Point(10, 10);
			this.thumbnailBox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.thumbnailBox.MaximumSize = new System.Drawing.Size(200, 0);
			this.thumbnailBox.Name = "thumbnailBox";
			this.mainTableLayoutPanel.SetRowSpan(this.thumbnailBox, 2);
			this.thumbnailBox.Size = new System.Drawing.Size(100, 90);
			this.thumbnailBox.TabIndex = 4;
			this.thumbnailBox.TabStop = false;
			// 
			// actionsContextMenuStrip
			// 
			this.actionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startenToolStripMenuItem,
            this.pausierenToolStripMenuItem,
            this.fortsetzenToolStripMenuItem,
            this.überspringenToolStripMenuItem,
            this.abbrechenToolStripMenuItem,
            this.toolStripSeparator1,
            this.detailsBearbeitenToolStripMenuItem,
            this.nachObenSchiebenToolStripMenuItem,
            this.nachUntenSchiebenToolStripMenuItem,
            this.toolStripSeparator2,
            this.löschenToolStripMenuItem});
			this.actionsContextMenuStrip.Name = "actionsContextMenuStrip";
			this.actionsContextMenuStrip.Size = new System.Drawing.Size(187, 236);
			// 
			// startenToolStripMenuItem
			// 
			this.startenToolStripMenuItem.Name = "startenToolStripMenuItem";
			this.startenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.startenToolStripMenuItem.Text = "Starten";
			this.startenToolStripMenuItem.Click += new System.EventHandler(this.startenToolStripMenuItem_Click);
			// 
			// pausierenToolStripMenuItem
			// 
			this.pausierenToolStripMenuItem.Enabled = false;
			this.pausierenToolStripMenuItem.Name = "pausierenToolStripMenuItem";
			this.pausierenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.pausierenToolStripMenuItem.Text = "Pausieren";
			this.pausierenToolStripMenuItem.Click += new System.EventHandler(this.pausierenToolStripMenuItem_Click);
			// 
			// fortsetzenToolStripMenuItem
			// 
			this.fortsetzenToolStripMenuItem.Enabled = false;
			this.fortsetzenToolStripMenuItem.Name = "fortsetzenToolStripMenuItem";
			this.fortsetzenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.fortsetzenToolStripMenuItem.Text = "Fortsetzen";
			this.fortsetzenToolStripMenuItem.Click += new System.EventHandler(this.fortsetzenToolStripMenuItem_Click);
			// 
			// überspringenToolStripMenuItem
			// 
			this.überspringenToolStripMenuItem.CheckOnClick = true;
			this.überspringenToolStripMenuItem.Name = "überspringenToolStripMenuItem";
			this.überspringenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.überspringenToolStripMenuItem.Text = "Überspringen";
			this.überspringenToolStripMenuItem.CheckedChanged += new System.EventHandler(this.überspringenToolStripMenuItem_CheckedChanged);
			// 
			// abbrechenToolStripMenuItem
			// 
			this.abbrechenToolStripMenuItem.Enabled = false;
			this.abbrechenToolStripMenuItem.Name = "abbrechenToolStripMenuItem";
			this.abbrechenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.abbrechenToolStripMenuItem.Text = "Abbrechen";
			this.abbrechenToolStripMenuItem.Click += new System.EventHandler(this.abbrechenToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
			// 
			// detailsBearbeitenToolStripMenuItem
			// 
			this.detailsBearbeitenToolStripMenuItem.Name = "detailsBearbeitenToolStripMenuItem";
			this.detailsBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.detailsBearbeitenToolStripMenuItem.Text = "Details bearbeiten";
			this.detailsBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.detailsBearbeitenToolStripMenuItem_Click);
			// 
			// nachObenSchiebenToolStripMenuItem
			// 
			this.nachObenSchiebenToolStripMenuItem.Name = "nachObenSchiebenToolStripMenuItem";
			this.nachObenSchiebenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.nachObenSchiebenToolStripMenuItem.Text = "Nach oben schieben";
			this.nachObenSchiebenToolStripMenuItem.Click += new System.EventHandler(this.nachObenSchiebenToolStripMenuItem_Click);
			// 
			// nachUntenSchiebenToolStripMenuItem
			// 
			this.nachUntenSchiebenToolStripMenuItem.Name = "nachUntenSchiebenToolStripMenuItem";
			this.nachUntenSchiebenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.nachUntenSchiebenToolStripMenuItem.Text = "Nach unten schieben";
			this.nachUntenSchiebenToolStripMenuItem.Click += new System.EventHandler(this.nachUntenSchiebenToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
			// 
			// löschenToolStripMenuItem
			// 
			this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
			this.löschenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.löschenToolStripMenuItem.Text = "Aus der Liste entfernen";
			this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
			// 
			// JobControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "JobControl";
			this.Size = new System.Drawing.Size(550, 159);
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailBox)).EndInit();
			this.actionsContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label uploadTitle;
		private System.Windows.Forms.Label uploadStateLabel;
		private System.Windows.Forms.Button actionsButton;
		private System.Windows.Forms.ContextMenuStrip actionsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem detailsBearbeitenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem überspringenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pausierenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abbrechenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fortsetzenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem nachObenSchiebenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nachUntenSchiebenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.PictureBox thumbnailBox;
	}
}
