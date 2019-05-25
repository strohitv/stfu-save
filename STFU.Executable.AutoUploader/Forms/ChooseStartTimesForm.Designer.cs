namespace STFU.Executable.AutoUploader.Forms
{
	partial class ChooseStartTimesForm
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
			this.chooseCustomTimesControl = new STFU.Executable.AutoUploader.Controls.ChooseMultipleStartTimesScrollControl();
			this.startButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.globalSettingsControl = new STFU.Executable.AutoUploader.Controls.ChooseSingleStartTimeControl();
			this.mainTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.ColumnCount = 7;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Controls.Add(this.chooseCustomTimesControl, 1, 3);
			this.mainTlp.Controls.Add(this.startButton, 3, 5);
			this.mainTlp.Controls.Add(this.cancelButton, 5, 5);
			this.mainTlp.Controls.Add(this.globalSettingsControl, 1, 1);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 7;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Size = new System.Drawing.Size(958, 728);
			this.mainTlp.TabIndex = 0;
			// 
			// chooseCustomTimesControl
			// 
			this.mainTlp.SetColumnSpan(this.chooseCustomTimesControl, 5);
			this.chooseCustomTimesControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chooseCustomTimesControl.Location = new System.Drawing.Point(13, 269);
			this.chooseCustomTimesControl.Name = "chooseCustomTimesControl";
			this.chooseCustomTimesControl.Size = new System.Drawing.Size(932, 407);
			this.chooseCustomTimesControl.TabIndex = 0;
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.AutoSize = true;
			this.startButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.startButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.startButton.Location = new System.Drawing.Point(740, 689);
			this.startButton.Margin = new System.Windows.Forms.Padding(0);
			this.startButton.Name = "startButton";
			this.startButton.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.startButton.Size = new System.Drawing.Size(99, 29);
			this.startButton.TabIndex = 1;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(849, 689);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.cancelButton.Size = new System.Drawing.Size(99, 29);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Abbrechen";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// globalSettingsControl
			// 
			this.globalSettingsControl.AutoSize = true;
			this.globalSettingsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTlp.SetColumnSpan(this.globalSettingsControl, 5);
			this.globalSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.globalSettingsControl.Location = new System.Drawing.Point(10, 10);
			this.globalSettingsControl.Margin = new System.Windows.Forms.Padding(0);
			this.globalSettingsControl.Name = "globalSettingsControl";
			this.globalSettingsControl.Padding = new System.Windows.Forms.Padding(5);
			this.globalSettingsControl.Size = new System.Drawing.Size(938, 246);
			this.globalSettingsControl.TabIndex = 3;
			// 
			// ChooseStartTimesForm
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(958, 728);
			this.Controls.Add(this.mainTlp);
			this.Name = "ChooseStartTimesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Veröffentlichungsstartzeiten wählen";
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private Controls.ChooseMultipleStartTimesScrollControl chooseCustomTimesControl;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button cancelButton;
		private Controls.ChooseSingleStartTimeControl globalSettingsControl;
	}
}