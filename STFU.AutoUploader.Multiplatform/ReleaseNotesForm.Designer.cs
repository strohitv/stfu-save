namespace STFU.AutoUploader
{
	partial class ReleaseNotesForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.releaseNotesBox = new System.Windows.Forms.RichTextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.disableNotesCheckbox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.releaseNotesBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.closeButton, 5, 5);
			this.tableLayoutPanel1.Controls.Add(this.disableNotesCheckbox, 3, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 651);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label1, 5);
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(326, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Neue Funktionen dieser Version:";
			// 
			// releaseNotesBox
			// 
			this.releaseNotesBox.BackColor = System.Drawing.Color.White;
			this.releaseNotesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel1.SetColumnSpan(this.releaseNotesBox, 5);
			this.releaseNotesBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.releaseNotesBox.Location = new System.Drawing.Point(10, 45);
			this.releaseNotesBox.Margin = new System.Windows.Forms.Padding(0);
			this.releaseNotesBox.Name = "releaseNotesBox";
			this.releaseNotesBox.ReadOnly = true;
			this.releaseNotesBox.Size = new System.Drawing.Size(911, 557);
			this.releaseNotesBox.TabIndex = 1;
			this.releaseNotesBox.Text = "";
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.AutoSize = true;
			this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.closeButton.Location = new System.Drawing.Point(827, 612);
			this.closeButton.Margin = new System.Windows.Forms.Padding(0);
			this.closeButton.Name = "closeButton";
			this.closeButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.closeButton.Size = new System.Drawing.Size(94, 29);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Schließen";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButtonClick);
			// 
			// disableNotesCheckbox
			// 
			this.disableNotesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.disableNotesCheckbox.AutoSize = true;
			this.disableNotesCheckbox.Location = new System.Drawing.Point(650, 618);
			this.disableNotesCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.disableNotesCheckbox.Name = "disableNotesCheckbox";
			this.disableNotesCheckbox.Size = new System.Drawing.Size(167, 17);
			this.disableNotesCheckbox.TabIndex = 3;
			this.disableNotesCheckbox.Text = "Beim nächsten Start anzeigen";
			this.disableNotesCheckbox.UseVisualStyleBackColor = true;
			// 
			// ReleaseNotesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 651);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ReleaseNotesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Neue Funktionen des STFU";
			this.Load += new System.EventHandler(this.ReleaseNotesFormLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox releaseNotesBox;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.CheckBox disableNotesCheckbox;
	}
}