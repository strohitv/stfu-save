namespace STFU.Executable.AutoUploader.Controls
{
	partial class UploaderControl
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
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.lblFinishAction = new System.Windows.Forms.Label();
			this.cmbbxFinishAction = new System.Windows.Forms.ComboBox();
			this.chbChoseProcesses = new System.Windows.Forms.CheckBox();
			this.btnChoseProcs = new System.Windows.Forms.Button();
			this.queueStatusLabel = new System.Windows.Forms.Label();
			this.queueStatusButton = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.startAutouploaderbutton = new System.Windows.Forms.Button();
			this.autoUploaderStateLabel = new System.Windows.Forms.Label();
			this.mainTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.AutoSize = true;
			this.mainTlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTlp.ColumnCount = 11;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTlp.Controls.Add(this.lblFinishAction, 0, 0);
			this.mainTlp.Controls.Add(this.cmbbxFinishAction, 2, 0);
			this.mainTlp.Controls.Add(this.chbChoseProcesses, 4, 0);
			this.mainTlp.Controls.Add(this.btnChoseProcs, 6, 0);
			this.mainTlp.Controls.Add(this.queueStatusLabel, 8, 0);
			this.mainTlp.Controls.Add(this.queueStatusButton, 10, 0);
			this.mainTlp.Controls.Add(this.startAutouploaderbutton, 10, 2);
			this.mainTlp.Controls.Add(this.autoUploaderStateLabel, 4, 2);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Margin = new System.Windows.Forms.Padding(0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 4;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.Size = new System.Drawing.Size(794, 64);
			this.mainTlp.TabIndex = 0;
			// 
			// lblFinishAction
			// 
			this.lblFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFinishAction.Location = new System.Drawing.Point(0, 7);
			this.lblFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.lblFinishAction.Name = "lblFinishAction";
			this.lblFinishAction.Size = new System.Drawing.Size(53, 13);
			this.lblFinishAction.TabIndex = 15;
			this.lblFinishAction.Text = "Am Ende:";
			// 
			// cmbbxFinishAction
			// 
			this.cmbbxFinishAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbbxFinishAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbxFinishAction.FormattingEnabled = true;
			this.cmbbxFinishAction.Items.AddRange(new object[] {
            "Nichts tun",
            "Programm schließen",
            "Herunterfahren"});
			this.cmbbxFinishAction.Location = new System.Drawing.Point(63, 3);
			this.cmbbxFinishAction.Margin = new System.Windows.Forms.Padding(0);
			this.cmbbxFinishAction.Name = "cmbbxFinishAction";
			this.cmbbxFinishAction.Size = new System.Drawing.Size(286, 21);
			this.cmbbxFinishAction.TabIndex = 16;
			// 
			// chbChoseProcesses
			// 
			this.chbChoseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbChoseProcesses.Enabled = false;
			this.chbChoseProcesses.Location = new System.Drawing.Point(359, 5);
			this.chbChoseProcesses.Margin = new System.Windows.Forms.Padding(0);
			this.chbChoseProcesses.Name = "chbChoseProcesses";
			this.chbChoseProcesses.Size = new System.Drawing.Size(150, 17);
			this.chbChoseProcesses.TabIndex = 17;
			this.chbChoseProcesses.Text = "Programmenden abwarten";
			this.chbChoseProcesses.UseVisualStyleBackColor = true;
			// 
			// btnChoseProcs
			// 
			this.btnChoseProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChoseProcs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnChoseProcs.Enabled = false;
			this.btnChoseProcs.Location = new System.Drawing.Point(519, 0);
			this.btnChoseProcs.Margin = new System.Windows.Forms.Padding(0);
			this.btnChoseProcs.Name = "btnChoseProcs";
			this.btnChoseProcs.Padding = new System.Windows.Forms.Padding(2);
			this.btnChoseProcs.Size = new System.Drawing.Size(36, 27);
			this.btnChoseProcs.TabIndex = 18;
			this.btnChoseProcs.Text = "[...]";
			this.btnChoseProcs.UseVisualStyleBackColor = true;
			// 
			// queueStatusLabel
			// 
			this.queueStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.queueStatusLabel.AutoSize = true;
			this.queueStatusLabel.Location = new System.Drawing.Point(565, 7);
			this.queueStatusLabel.Margin = new System.Windows.Forms.Padding(0);
			this.queueStatusLabel.Name = "queueStatusLabel";
			this.queueStatusLabel.Size = new System.Drawing.Size(155, 13);
			this.queueStatusLabel.TabIndex = 20;
			this.queueStatusLabel.Text = "Die Warteschlange ist gestoppt";
			// 
			// queueStatusButton
			// 
			this.queueStatusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.queueStatusButton.AutoSize = true;
			this.queueStatusButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.queueStatusButton.Enabled = false;
			this.queueStatusButton.Location = new System.Drawing.Point(730, 0);
			this.queueStatusButton.Margin = new System.Windows.Forms.Padding(0);
			this.queueStatusButton.Name = "queueStatusButton";
			this.queueStatusButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.queueStatusButton.Size = new System.Drawing.Size(64, 27);
			this.queueStatusButton.TabIndex = 21;
			this.queueStatusButton.Text = "Start!";
			this.queueStatusButton.UseVisualStyleBackColor = true;
			this.queueStatusButton.Click += new System.EventHandler(this.queueStatusButton_Click);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
			// 
			// startAutouploaderbutton
			// 
			this.startAutouploaderbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.startAutouploaderbutton.AutoSize = true;
			this.startAutouploaderbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.startAutouploaderbutton.Enabled = false;
			this.startAutouploaderbutton.Location = new System.Drawing.Point(730, 37);
			this.startAutouploaderbutton.Margin = new System.Windows.Forms.Padding(0);
			this.startAutouploaderbutton.Name = "startAutouploaderbutton";
			this.startAutouploaderbutton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.startAutouploaderbutton.Size = new System.Drawing.Size(64, 27);
			this.startAutouploaderbutton.TabIndex = 22;
			this.startAutouploaderbutton.Text = "Start!";
			this.startAutouploaderbutton.UseVisualStyleBackColor = true;
			this.startAutouploaderbutton.Click += new System.EventHandler(this.startAutouploaderbutton_Click);
			// 
			// autoUploaderStateLabel
			// 
			this.autoUploaderStateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.autoUploaderStateLabel.AutoSize = true;
			this.mainTlp.SetColumnSpan(this.autoUploaderStateLabel, 5);
			this.autoUploaderStateLabel.Location = new System.Drawing.Point(481, 44);
			this.autoUploaderStateLabel.Margin = new System.Windows.Forms.Padding(0);
			this.autoUploaderStateLabel.Name = "autoUploaderStateLabel";
			this.autoUploaderStateLabel.Size = new System.Drawing.Size(239, 13);
			this.autoUploaderStateLabel.TabIndex = 23;
			this.autoUploaderStateLabel.Text = "Es werden keine Videos automatisch hinzugefügt";
			// 
			// UploaderControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mainTlp);
			this.Name = "UploaderControl";
			this.Size = new System.Drawing.Size(794, 64);
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.Label lblFinishAction;
		private System.Windows.Forms.ComboBox cmbbxFinishAction;
		private System.Windows.Forms.CheckBox chbChoseProcesses;
		private System.Windows.Forms.Button btnChoseProcs;
		private System.Windows.Forms.Label queueStatusLabel;
		private System.Windows.Forms.Button queueStatusButton;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Button startAutouploaderbutton;
		private System.Windows.Forms.Label autoUploaderStateLabel;
	}
}
