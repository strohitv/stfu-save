namespace STFU.Executable.AutoUploader.Forms
{
	partial class RefreshPlaylistsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefreshPlaylistsForm));
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.refreshButton = new System.Windows.Forms.Button();
			this.playlistsListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mainTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.ColumnCount = 5;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Controls.Add(this.descriptionLabel, 1, 1);
			this.mainTlp.Controls.Add(this.refreshButton, 3, 5);
			this.mainTlp.Controls.Add(this.playlistsListView, 1, 3);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 7;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Size = new System.Drawing.Size(967, 599);
			this.mainTlp.TabIndex = 0;
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionLabel.AutoSize = true;
			this.mainTlp.SetColumnSpan(this.descriptionLabel, 3);
			this.descriptionLabel.Location = new System.Drawing.Point(10, 10);
			this.descriptionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(947, 52);
			this.descriptionLabel.TabIndex = 0;
			this.descriptionLabel.Text = resources.GetString("descriptionLabel.Text");
			// 
			// refreshButton
			// 
			this.refreshButton.AutoSize = true;
			this.refreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.refreshButton.Location = new System.Drawing.Point(808, 560);
			this.refreshButton.Margin = new System.Windows.Forms.Padding(0);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.refreshButton.Size = new System.Drawing.Size(149, 29);
			this.refreshButton.TabIndex = 1;
			this.refreshButton.Text = "Playlists aktualisieren!";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// listView1
			// 
			this.playlistsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.mainTlp.SetColumnSpan(this.playlistsListView, 3);
			this.playlistsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playlistsListView.Location = new System.Drawing.Point(10, 67);
			this.playlistsListView.Margin = new System.Windows.Forms.Padding(0);
			this.playlistsListView.Name = "listView1";
			this.playlistsListView.Size = new System.Drawing.Size(947, 483);
			this.playlistsListView.TabIndex = 2;
			this.playlistsListView.UseCompatibleStateImageBehavior = false;
			this.playlistsListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Titel";
			this.columnHeader1.Width = 500;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Id";
			this.columnHeader2.Width = 300;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Erstelldatum";
			this.columnHeader3.Width = 120;
			// 
			// RefreshPlaylistsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(967, 599);
			this.Controls.Add(this.mainTlp);
			this.Name = "RefreshPlaylistsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Playlists verwalten";
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.ListView playlistsListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}