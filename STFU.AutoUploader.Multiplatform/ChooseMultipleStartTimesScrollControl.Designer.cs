﻿namespace STFU.AutoUploader
{
	partial class ChooseMultipleStartTimesScrollControl
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
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.borderPanel = new System.Windows.Forms.Panel();
			this.borderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.AutoSize = true;
			this.mainTlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainTlp.BackColor = System.Drawing.Color.White;
			this.mainTlp.ColumnCount = 1;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Top;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Margin = new System.Windows.Forms.Padding(0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 1;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.Size = new System.Drawing.Size(725, 0);
			this.mainTlp.TabIndex = 2;
			// 
			// borderPanel
			// 
			this.borderPanel.AutoScroll = true;
			this.borderPanel.BackColor = System.Drawing.Color.White;
			this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.borderPanel.Controls.Add(this.mainTlp);
			this.borderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.borderPanel.Location = new System.Drawing.Point(0, 0);
			this.borderPanel.Name = "borderPanel";
			this.borderPanel.Size = new System.Drawing.Size(727, 399);
			this.borderPanel.TabIndex = 3;
			// 
			// ChooseMultipleStartTimesScrollControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.borderPanel);
			this.Name = "ChooseMultipleStartTimesScrollControl";
			this.Size = new System.Drawing.Size(727, 399);
			this.Load += new System.EventHandler(this.ChooseMultipleStartTimesScrollControlLoad);
			this.borderPanel.ResumeLayout(false);
			this.borderPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.Panel borderPanel;
	}
}
