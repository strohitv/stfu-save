namespace STFU.AutoUploader
{
	partial class ProcessWindow
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
			this.lblAllProcs = new System.Windows.Forms.Label();
			this.lblSelectedProcs = new System.Windows.Forms.Label();
			this.lbAllProcs = new System.Windows.Forms.ListBox();
			this.lbSelectedProcs = new System.Windows.Forms.ListBox();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 13;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
			this.tableLayoutPanel1.Controls.Add(this.lblAllProcs, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblSelectedProcs, 7, 1);
			this.tableLayoutPanel1.Controls.Add(this.lbAllProcs, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lbSelectedProcs, 7, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 9, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 5, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 581);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblAllProcs
			// 
			this.lblAllProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAllProcs.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblAllProcs, 5);
			this.lblAllProcs.Location = new System.Drawing.Point(10, 10);
			this.lblAllProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lblAllProcs.Name = "lblAllProcs";
			this.lblAllProcs.Size = new System.Drawing.Size(506, 17);
			this.lblAllProcs.TabIndex = 0;
			this.lblAllProcs.Text = "Verfügbare Prozesse: ";
			// 
			// lblSelectedProcs
			// 
			this.lblSelectedProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedProcs.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblSelectedProcs, 5);
			this.lblSelectedProcs.Location = new System.Drawing.Point(526, 10);
			this.lblSelectedProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lblSelectedProcs.Name = "lblSelectedProcs";
			this.lblSelectedProcs.Size = new System.Drawing.Size(506, 17);
			this.lblSelectedProcs.TabIndex = 1;
			this.lblSelectedProcs.Text = "Ausgewählte Prozesse: ";
			// 
			// lbAllProcs
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lbAllProcs, 5);
			this.lbAllProcs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbAllProcs.FormattingEnabled = true;
			this.lbAllProcs.ItemHeight = 16;
			this.lbAllProcs.Location = new System.Drawing.Point(10, 27);
			this.lbAllProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lbAllProcs.Name = "lbAllProcs";
			this.lbAllProcs.Size = new System.Drawing.Size(506, 501);
			this.lbAllProcs.TabIndex = 2;
			// 
			// lbSelectedProcs
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lbSelectedProcs, 5);
			this.lbSelectedProcs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbSelectedProcs.FormattingEnabled = true;
			this.lbSelectedProcs.ItemHeight = 16;
			this.lbSelectedProcs.Location = new System.Drawing.Point(526, 27);
			this.lbSelectedProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lbSelectedProcs.Name = "lbSelectedProcs";
			this.lbSelectedProcs.Size = new System.Drawing.Size(506, 501);
			this.lbSelectedProcs.TabIndex = 3;
			// 
			// btnSubmit
			// 
			this.btnSubmit.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.btnSubmit, 3);
			this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSubmit.Location = new System.Drawing.Point(10, 538);
			this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btnSubmit.Size = new System.Drawing.Size(334, 33);
			this.btnSubmit.TabIndex = 4;
			this.btnSubmit.Text = "Bestätigen";
			this.btnSubmit.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 3);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCancel.Location = new System.Drawing.Point(698, 538);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btnCancel.Size = new System.Drawing.Size(334, 33);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnRefresh
			// 
			this.btnRefresh.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.btnRefresh, 3);
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRefresh.Location = new System.Drawing.Point(354, 538);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(334, 33);
			this.btnRefresh.TabIndex = 6;
			this.btnRefresh.Text = "Aktualisieren";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// ProcessWindow
			// 
			this.AcceptButton = this.btnSubmit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1051, 581);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ProcessWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ProcessWindow";
			this.Load += new System.EventHandler(this.ProcessWindowLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblAllProcs;
		private System.Windows.Forms.Label lblSelectedProcs;
		private System.Windows.Forms.ListBox lbAllProcs;
		private System.Windows.Forms.ListBox lbSelectedProcs;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRefresh;
	}
}