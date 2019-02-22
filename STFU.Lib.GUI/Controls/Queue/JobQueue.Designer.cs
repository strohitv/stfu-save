namespace STFU.Lib.GUI.Controls.Queue
{
	partial class JobQueue
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
			this.borderPanel = new System.Windows.Forms.Panel();
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.borderPanel.SuspendLayout();
			this.SuspendLayout();
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
			this.borderPanel.Size = new System.Drawing.Size(232, 118);
			this.borderPanel.TabIndex = 4;
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
			this.mainTlp.Size = new System.Drawing.Size(230, 0);
			this.mainTlp.TabIndex = 2;
			// 
			// JobQueue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.borderPanel);
			this.Name = "JobQueue";
			this.Size = new System.Drawing.Size(232, 118);
			this.Load += new System.EventHandler(this.JobQueue_Load);
			this.borderPanel.ResumeLayout(false);
			this.borderPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel borderPanel;
		private System.Windows.Forms.TableLayoutPanel mainTlp;
	}
}
