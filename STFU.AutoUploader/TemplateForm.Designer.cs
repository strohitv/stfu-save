namespace STFU.AutoUploader
{
	partial class TemplateForm
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
			this.addPathButton = new System.Windows.Forms.Button();
			this.movePathUpButton = new System.Windows.Forms.Button();
			this.movePathDownButton = new System.Windows.Forms.Button();
			this.deletePathButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.templateListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.addPathButton, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.movePathUpButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.movePathDownButton, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.deletePathButton, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.clearButton, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.templateListView, 3, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 12;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 707);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// addPathButton
			// 
			this.addPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addPathButton.AutoSize = true;
			this.addPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addPathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addPathButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addPathButton.Location = new System.Drawing.Point(10, 10);
			this.addPathButton.Margin = new System.Windows.Forms.Padding(0);
			this.addPathButton.Name = "addPathButton";
			this.addPathButton.Size = new System.Drawing.Size(47, 48);
			this.addPathButton.TabIndex = 2;
			this.addPathButton.Text = "+";
			this.addPathButton.UseVisualStyleBackColor = true;
			this.addPathButton.Click += new System.EventHandler(this.addPathButtonClick);
			// 
			// movePathUpButton
			// 
			this.movePathUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.movePathUpButton.AutoSize = true;
			this.movePathUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.movePathUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.movePathUpButton.Location = new System.Drawing.Point(10, 68);
			this.movePathUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathUpButton.Name = "movePathUpButton";
			this.movePathUpButton.Size = new System.Drawing.Size(47, 48);
			this.movePathUpButton.TabIndex = 3;
			this.movePathUpButton.Text = "↑";
			this.movePathUpButton.UseVisualStyleBackColor = true;
			// 
			// movePathDownButton
			// 
			this.movePathDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.movePathDownButton.AutoSize = true;
			this.movePathDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.movePathDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.movePathDownButton.Location = new System.Drawing.Point(10, 126);
			this.movePathDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathDownButton.Name = "movePathDownButton";
			this.movePathDownButton.Size = new System.Drawing.Size(47, 48);
			this.movePathDownButton.TabIndex = 4;
			this.movePathDownButton.Text = "↓";
			this.movePathDownButton.UseVisualStyleBackColor = true;
			// 
			// deletePathButton
			// 
			this.deletePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.deletePathButton.AutoSize = true;
			this.deletePathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deletePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deletePathButton.ForeColor = System.Drawing.Color.Red;
			this.deletePathButton.Location = new System.Drawing.Point(10, 184);
			this.deletePathButton.Margin = new System.Windows.Forms.Padding(0);
			this.deletePathButton.Name = "deletePathButton";
			this.deletePathButton.Size = new System.Drawing.Size(47, 48);
			this.deletePathButton.TabIndex = 5;
			this.deletePathButton.Text = "-";
			this.deletePathButton.UseVisualStyleBackColor = true;
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.AutoSize = true;
			this.clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearButton.ForeColor = System.Drawing.Color.Red;
			this.clearButton.Location = new System.Drawing.Point(10, 242);
			this.clearButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(47, 48);
			this.clearButton.TabIndex = 6;
			this.clearButton.Text = "x";
			this.clearButton.UseVisualStyleBackColor = true;
			// 
			// templateListView
			// 
			this.templateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.templateListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateListView.FullRowSelect = true;
			this.templateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.templateListView.Location = new System.Drawing.Point(67, 10);
			this.templateListView.Margin = new System.Windows.Forms.Padding(0);
			this.templateListView.MinimumSize = new System.Drawing.Size(250, 4);
			this.templateListView.MultiSelect = false;
			this.templateListView.Name = "templateListView";
			this.tableLayoutPanel1.SetRowSpan(this.templateListView, 10);
			this.templateListView.ShowGroups = false;
			this.templateListView.Size = new System.Drawing.Size(271, 687);
			this.templateListView.TabIndex = 7;
			this.templateListView.UseCompatibleStateImageBehavior = false;
			this.templateListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Template";
			this.columnHeader1.Width = 240;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel2.ColumnCount = 8;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.Controls.Add(this.label1, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.textBox1, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.button1, 4, 7);
			this.tableLayoutPanel2.Controls.Add(this.button2, 6, 7);
			this.tableLayoutPanel2.Controls.Add(this.tabControl1, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 9;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(889, 707);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name: ";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.SetColumnSpan(this.textBox1, 4);
			this.textBox1.Location = new System.Drawing.Point(73, 37);
			this.textBox1.Margin = new System.Windows.Forms.Padding(0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(806, 22);
			this.textBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.Location = new System.Drawing.Point(645, 664);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.button1.Size = new System.Drawing.Size(112, 33);
			this.button1.TabIndex = 2;
			this.button1.Text = "Speichern";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Location = new System.Drawing.Point(767, 664);
			this.button2.Margin = new System.Windows.Forms.Padding(0);
			this.button2.Name = "button2";
			this.button2.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.button2.Size = new System.Drawing.Size(112, 33);
			this.button2.TabIndex = 3;
			this.button2.Text = "Verwerfen";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 6);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(10, 69);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(869, 585);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(861, 556);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Allgemein";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(866, 556);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Veröffentlichung";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(866, 556);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Sonstiges";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.label2, 6);
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 10);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(869, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Template bearbeiten: ";
			// 
			// splitContainer
			// 
			this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer.Size = new System.Drawing.Size(1252, 707);
			this.splitContainer.SplitterDistance = 348;
			this.splitContainer.SplitterWidth = 15;
			this.splitContainer.TabIndex = 1;
			// 
			// TemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1252, 707);
			this.Controls.Add(this.splitContainer);
			this.Name = "TemplateForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Templates bearbeiten";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button addPathButton;
		private System.Windows.Forms.Button movePathUpButton;
		private System.Windows.Forms.Button movePathDownButton;
		private System.Windows.Forms.Button deletePathButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView templateListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.SplitContainer splitContainer;
	}
}