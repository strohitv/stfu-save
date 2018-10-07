namespace STFU.Executable.AutoUploader.Controls
{
	partial class ChooseSingleStartTimeControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainGroupbox = new System.Windows.Forms.GroupBox();
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.shouldOverridePublishAtCheckbox = new System.Windows.Forms.CheckBox();
			this.customStartPointCombobox = new System.Windows.Forms.ComboBox();
			this.customStartPointCheckbox = new System.Windows.Forms.CheckBox();
			this.overrideDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.dontObservePathCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadVideosPrivateCheckbox = new System.Windows.Forms.CheckBox();
			this.explanationTextbox = new System.Windows.Forms.TextBox();
			this.mainGroupbox.SuspendLayout();
			this.mainTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainGroupbox
			// 
			this.mainGroupbox.AutoSize = true;
			this.mainGroupbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainGroupbox.Controls.Add(this.mainTlp);
			this.mainGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainGroupbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainGroupbox.Location = new System.Drawing.Point(5, 5);
			this.mainGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.mainGroupbox.Name = "mainGroupbox";
			this.mainGroupbox.Size = new System.Drawing.Size(914, 236);
			this.mainGroupbox.TabIndex = 6;
			this.mainGroupbox.TabStop = false;
			this.mainGroupbox.Text = "Für alle nicht eingestellen Pfade:";
			// 
			// mainTlp
			// 
			this.mainTlp.AutoSize = true;
			this.mainTlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTlp.ColumnCount = 5;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTlp.Controls.Add(this.shouldOverridePublishAtCheckbox, 1, 6);
			this.mainTlp.Controls.Add(this.customStartPointCombobox, 3, 7);
			this.mainTlp.Controls.Add(this.customStartPointCheckbox, 1, 7);
			this.mainTlp.Controls.Add(this.overrideDateTimePicker, 3, 6);
			this.mainTlp.Controls.Add(this.dontObservePathCheckbox, 1, 2);
			this.mainTlp.Controls.Add(this.uploadVideosPrivateCheckbox, 1, 4);
			this.mainTlp.Controls.Add(this.explanationTextbox, 1, 1);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(3, 25);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 9;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.Size = new System.Drawing.Size(908, 208);
			this.mainTlp.TabIndex = 0;
			// 
			// shouldOverridePublishAtCheckbox
			// 
			this.shouldOverridePublishAtCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.shouldOverridePublishAtCheckbox.AutoSize = true;
			this.shouldOverridePublishAtCheckbox.Checked = true;
			this.shouldOverridePublishAtCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.shouldOverridePublishAtCheckbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.shouldOverridePublishAtCheckbox.Location = new System.Drawing.Point(7, 135);
			this.shouldOverridePublishAtCheckbox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 7);
			this.shouldOverridePublishAtCheckbox.Name = "shouldOverridePublishAtCheckbox";
			this.shouldOverridePublishAtCheckbox.Size = new System.Drawing.Size(293, 25);
			this.shouldOverridePublishAtCheckbox.TabIndex = 1;
			this.shouldOverridePublishAtCheckbox.Text = "Eigener Startzeitpunkt: ";
			this.shouldOverridePublishAtCheckbox.UseVisualStyleBackColor = true;
			this.shouldOverridePublishAtCheckbox.CheckedChanged += new System.EventHandler(this.shouldOverridePublishAtCheckboxCheckedChanged);
			// 
			// customStartPointCombobox
			// 
			this.customStartPointCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.customStartPointCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.customStartPointCombobox.Enabled = false;
			this.customStartPointCombobox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customStartPointCombobox.FormattingEnabled = true;
			this.customStartPointCombobox.Location = new System.Drawing.Point(310, 172);
			this.customStartPointCombobox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 7);
			this.customStartPointCombobox.Name = "customStartPointCombobox";
			this.customStartPointCombobox.Size = new System.Drawing.Size(591, 29);
			this.customStartPointCombobox.TabIndex = 4;
			// 
			// customStartPointCheckbox
			// 
			this.customStartPointCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.customStartPointCheckbox.AutoSize = true;
			this.customStartPointCheckbox.Enabled = false;
			this.customStartPointCheckbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customStartPointCheckbox.Location = new System.Drawing.Point(7, 174);
			this.customStartPointCheckbox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 7);
			this.customStartPointCheckbox.Name = "customStartPointCheckbox";
			this.customStartPointCheckbox.Size = new System.Drawing.Size(293, 25);
			this.customStartPointCheckbox.TabIndex = 3;
			this.customStartPointCheckbox.Text = "Eigener Starttag: ";
			this.customStartPointCheckbox.UseVisualStyleBackColor = true;
			this.customStartPointCheckbox.CheckedChanged += new System.EventHandler(this.customStartPointCheckboxCheckedChanged);
			// 
			// overrideDateTimePicker
			// 
			this.overrideDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.overrideDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
			this.overrideDateTimePicker.Enabled = false;
			this.overrideDateTimePicker.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.overrideDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.overrideDateTimePicker.Location = new System.Drawing.Point(310, 133);
			this.overrideDateTimePicker.Margin = new System.Windows.Forms.Padding(0, 3, 0, 7);
			this.overrideDateTimePicker.Name = "overrideDateTimePicker";
			this.overrideDateTimePicker.Size = new System.Drawing.Size(591, 29);
			this.overrideDateTimePicker.TabIndex = 2;
			// 
			// dontObservePathCheckbox
			// 
			this.dontObservePathCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.dontObservePathCheckbox.AutoSize = true;
			this.mainTlp.SetColumnSpan(this.dontObservePathCheckbox, 3);
			this.dontObservePathCheckbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dontObservePathCheckbox.Location = new System.Drawing.Point(7, 63);
			this.dontObservePathCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.dontObservePathCheckbox.Name = "dontObservePathCheckbox";
			this.dontObservePathCheckbox.Size = new System.Drawing.Size(894, 25);
			this.dontObservePathCheckbox.TabIndex = 5;
			this.dontObservePathCheckbox.Text = "Pfad dieses mal nicht überwachen";
			this.dontObservePathCheckbox.UseVisualStyleBackColor = true;
			this.dontObservePathCheckbox.CheckedChanged += new System.EventHandler(this.dontObservePathCheckboxCheckedChanged);
			// 
			// uploadVideosPrivateCheckbox
			// 
			this.uploadVideosPrivateCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.uploadVideosPrivateCheckbox.AutoSize = true;
			this.mainTlp.SetColumnSpan(this.uploadVideosPrivateCheckbox, 3);
			this.uploadVideosPrivateCheckbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadVideosPrivateCheckbox.Location = new System.Drawing.Point(7, 98);
			this.uploadVideosPrivateCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadVideosPrivateCheckbox.Name = "uploadVideosPrivateCheckbox";
			this.uploadVideosPrivateCheckbox.Size = new System.Drawing.Size(894, 25);
			this.uploadVideosPrivateCheckbox.TabIndex = 6;
			this.uploadVideosPrivateCheckbox.Text = "Videos privat hochladen";
			this.uploadVideosPrivateCheckbox.UseVisualStyleBackColor = true;
			this.uploadVideosPrivateCheckbox.CheckedChanged += new System.EventHandler(this.uploadVideosPrivateCheckboxCheckedChanged);
			// 
			// explanationTextbox
			// 
			this.explanationTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mainTlp.SetColumnSpan(this.explanationTextbox, 3);
			this.explanationTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.explanationTextbox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.explanationTextbox.Location = new System.Drawing.Point(7, 7);
			this.explanationTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.explanationTextbox.MinimumSize = new System.Drawing.Size(0, 30);
			this.explanationTextbox.Multiline = true;
			this.explanationTextbox.Name = "explanationTextbox";
			this.explanationTextbox.ReadOnly = true;
			this.explanationTextbox.Size = new System.Drawing.Size(894, 56);
			this.explanationTextbox.TabIndex = 7;
			this.explanationTextbox.Text = "Die hier gesetzten Einstellungen zählen für alle Pfade, für die nichts anderes an" +
    "gegeben wird.";
			// 
			// ChooseSingleStartTimeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mainGroupbox);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ChooseSingleStartTimeControl";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(924, 246);
			this.Load += new System.EventHandler(this.ChooseSingleStartTimeControlLoad);
			this.mainGroupbox.ResumeLayout(false);
			this.mainGroupbox.PerformLayout();
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox mainGroupbox;
		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.CheckBox shouldOverridePublishAtCheckbox;
		private System.Windows.Forms.ComboBox customStartPointCombobox;
		private System.Windows.Forms.CheckBox customStartPointCheckbox;
		private System.Windows.Forms.DateTimePicker overrideDateTimePicker;
		private System.Windows.Forms.CheckBox dontObservePathCheckbox;
		private System.Windows.Forms.CheckBox uploadVideosPrivateCheckbox;
		private System.Windows.Forms.TextBox explanationTextbox;
	}
}
