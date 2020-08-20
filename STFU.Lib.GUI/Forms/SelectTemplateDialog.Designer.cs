namespace STFU.Lib.GUI.Forms
{
	partial class SelectTemplateDialog
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
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.explanationLabel = new System.Windows.Forms.Label();
			this.templatesCombobox = new System.Windows.Forms.ComboBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.mainTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.AutoSize = true;
			this.mainTlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTlp.ColumnCount = 6;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Controls.Add(this.explanationLabel, 1, 1);
			this.mainTlp.Controls.Add(this.templatesCombobox, 1, 3);
			this.mainTlp.Controls.Add(this.saveButton, 2, 5);
			this.mainTlp.Controls.Add(this.cancelButton, 4, 5);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 8;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.Size = new System.Drawing.Size(457, 105);
			this.mainTlp.TabIndex = 0;
			// 
			// explanationLabel
			// 
			this.explanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.explanationLabel.AutoSize = true;
			this.mainTlp.SetColumnSpan(this.explanationLabel, 4);
			this.explanationLabel.Location = new System.Drawing.Point(10, 10);
			this.explanationLabel.Margin = new System.Windows.Forms.Padding(0);
			this.explanationLabel.Name = "explanationLabel";
			this.explanationLabel.Size = new System.Drawing.Size(437, 13);
			this.explanationLabel.TabIndex = 0;
			this.explanationLabel.Text = "Bitte wähle ein Template aus, das in die ausgewählten Videos eingefügt werden sol" +
    "l.";
			// 
			// templatesCombobox
			// 
			this.templatesCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mainTlp.SetColumnSpan(this.templatesCombobox, 4);
			this.templatesCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.templatesCombobox.FormattingEnabled = true;
			this.templatesCombobox.Location = new System.Drawing.Point(10, 33);
			this.templatesCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.templatesCombobox.Name = "templatesCombobox";
			this.templatesCombobox.Size = new System.Drawing.Size(437, 21);
			this.templatesCombobox.TabIndex = 1;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.AutoSize = true;
			this.saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveButton.Location = new System.Drawing.Point(243, 64);
			this.saveButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveButton.Name = "saveButton";
			this.saveButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.saveButton.Size = new System.Drawing.Size(95, 29);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Einspielen";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(348, 64);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.cancelButton.Size = new System.Drawing.Size(99, 29);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Abbrechen";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// SelectTemplateDialog
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(457, 105);
			this.Controls.Add(this.mainTlp);
			this.Name = "SelectTemplateDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Template zum Einspielen auswählen";
			this.Load += new System.EventHandler(this.SelectTemplateDialog_Load);
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.Label explanationLabel;
		private System.Windows.Forms.ComboBox templatesCombobox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
	}
}