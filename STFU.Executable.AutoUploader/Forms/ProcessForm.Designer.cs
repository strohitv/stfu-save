namespace STFU.Executable.AutoUploader.Forms
{
	partial class ProcessForm
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
			this.btnSubmit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lvProcs = new System.Windows.Forms.ListView();
			this.chSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chProcName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chProcDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Controls.Add(this.lblAllProcs, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 5, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.lvProcs, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 472);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblAllProcs
			// 
			this.lblAllProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAllProcs.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblAllProcs, 3);
			this.lblAllProcs.Location = new System.Drawing.Point(10, 10);
			this.lblAllProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lblAllProcs.Name = "lblAllProcs";
			this.lblAllProcs.Size = new System.Drawing.Size(508, 13);
			this.lblAllProcs.TabIndex = 0;
			this.lblAllProcs.Text = "Verfügbare Prozesse: ";
			// 
			// btnSubmit
			// 
			this.btnSubmit.AutoSize = true;
			this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSubmit.Location = new System.Drawing.Point(10, 435);
			this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.btnSubmit.Size = new System.Drawing.Size(249, 27);
			this.btnSubmit.TabIndex = 4;
			this.btnSubmit.Text = "Bestätigen";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmitClick);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCancel.Location = new System.Drawing.Point(528, 435);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.btnCancel.Size = new System.Drawing.Size(249, 27);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnRefresh
			// 
			this.btnRefresh.AutoSize = true;
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRefresh.Location = new System.Drawing.Point(269, 435);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(249, 27);
			this.btnRefresh.TabIndex = 6;
			this.btnRefresh.Text = "Aktualisieren";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefreshClick);
			// 
			// lvProcs
			// 
			this.lvProcs.CheckBoxes = true;
			this.lvProcs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSelected,
            this.chProcName,
            this.chProcDescription});
			this.tableLayoutPanel1.SetColumnSpan(this.lvProcs, 5);
			this.lvProcs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvProcs.FullRowSelect = true;
			this.lvProcs.GridLines = true;
			this.lvProcs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvProcs.Location = new System.Drawing.Point(10, 23);
			this.lvProcs.Margin = new System.Windows.Forms.Padding(0);
			this.lvProcs.MultiSelect = false;
			this.lvProcs.Name = "lvProcs";
			this.lvProcs.ShowGroups = false;
			this.lvProcs.Size = new System.Drawing.Size(767, 402);
			this.lvProcs.TabIndex = 7;
			this.lvProcs.UseCompatibleStateImageBehavior = false;
			this.lvProcs.View = System.Windows.Forms.View.Details;
			this.lvProcs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvProcsItemChecked);
			// 
			// chSelected
			// 
			this.chSelected.Text = "";
			this.chSelected.Width = 31;
			// 
			// chProcName
			// 
			this.chProcName.Text = "Name";
			this.chProcName.Width = 31;
			// 
			// chProcDescription
			// 
			this.chProcDescription.Text = "Beschreibung";
			this.chProcDescription.Width = 950;
			// 
			// ProcessForm
			// 
			this.AcceptButton = this.btnSubmit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(788, 472);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "ProcessForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prozesse wählen";
			this.Load += new System.EventHandler(this.ProcessFormLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblAllProcs;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ListView lvProcs;
		private System.Windows.Forms.ColumnHeader chSelected;
		private System.Windows.Forms.ColumnHeader chProcName;
		private System.Windows.Forms.ColumnHeader chProcDescription;
	}
}