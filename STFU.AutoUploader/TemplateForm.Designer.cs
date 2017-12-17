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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Montag");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Dienstag");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Mittwoch");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Donnerstag");
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Freitag");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Samstag");
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Sonntag");
			this.templateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.addPathButton = new System.Windows.Forms.Button();
			this.movePathUpButton = new System.Windows.Forms.Button();
			this.movePathDownButton = new System.Windows.Forms.Button();
			this.deletePathButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.templateListView = new System.Windows.Forms.ListView();
			this.templateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.editTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.nameLabel = new System.Windows.Forms.Label();
			this.templateNameTextBox = new System.Windows.Forms.TextBox();
			this.saveTemplateButton = new System.Windows.Forms.Button();
			this.resetTemplateButton = new System.Windows.Forms.Button();
			this.templateDetailsTabControl = new System.Windows.Forms.TabControl();
			this.commonsTabPage = new System.Windows.Forms.TabPage();
			this.commonsTableLayoutPannel = new System.Windows.Forms.TableLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.tagsLabel = new System.Windows.Forms.Label();
			this.tagsTextBox = new System.Windows.Forms.TextBox();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.publishingTabPage = new System.Windows.Forms.TabPage();
			this.publishingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.privacyLabel = new System.Windows.Forms.Label();
			this.publishAtGroupBox = new System.Windows.Forms.GroupBox();
			this.publishAtTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.addTimeButton = new System.Windows.Forms.Button();
			this.removeTimeButton = new System.Windows.Forms.Button();
			this.newTimePicker = new System.Windows.Forms.DateTimePicker();
			this.saveTimeButton = new System.Windows.Forms.Button();
			this.skipPublishAtTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.skipPublishTimesLabel = new System.Windows.Forms.Label();
			this.skipPublishTimesUpDown = new System.Windows.Forms.NumericUpDown();
			this.publishingDaysListView = new System.Windows.Forms.ListView();
			this.daysColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.publishingTimesListView = new System.Windows.Forms.ListView();
			this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.privacyCombobox = new System.Windows.Forms.ComboBox();
			this.shouldPublishAtCheckBox = new System.Windows.Forms.CheckBox();
			this.otherTabPage = new System.Windows.Forms.TabPage();
			this.captionLabel = new System.Windows.Forms.Label();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.templateTableLayoutPanel.SuspendLayout();
			this.editTableLayoutPanel.SuspendLayout();
			this.templateDetailsTabControl.SuspendLayout();
			this.commonsTabPage.SuspendLayout();
			this.commonsTableLayoutPannel.SuspendLayout();
			this.publishingTabPage.SuspendLayout();
			this.publishingTableLayoutPanel.SuspendLayout();
			this.publishAtGroupBox.SuspendLayout();
			this.publishAtTableLayoutPanel.SuspendLayout();
			this.skipPublishAtTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.skipPublishTimesUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// templateTableLayoutPanel
			// 
			this.templateTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
			this.templateTableLayoutPanel.ColumnCount = 5;
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.templateTableLayoutPanel.Controls.Add(this.addPathButton, 1, 1);
			this.templateTableLayoutPanel.Controls.Add(this.movePathUpButton, 1, 3);
			this.templateTableLayoutPanel.Controls.Add(this.movePathDownButton, 1, 5);
			this.templateTableLayoutPanel.Controls.Add(this.deletePathButton, 1, 7);
			this.templateTableLayoutPanel.Controls.Add(this.clearButton, 1, 9);
			this.templateTableLayoutPanel.Controls.Add(this.templateListView, 3, 1);
			this.templateTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.templateTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
			this.templateTableLayoutPanel.Name = "templateTableLayoutPanel";
			this.templateTableLayoutPanel.RowCount = 12;
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.templateTableLayoutPanel.Size = new System.Drawing.Size(324, 559);
			this.templateTableLayoutPanel.TabIndex = 0;
			// 
			// addPathButton
			// 
			this.addPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addPathButton.AutoSize = true;
			this.addPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addPathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addPathButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addPathButton.Location = new System.Drawing.Point(8, 8);
			this.addPathButton.Margin = new System.Windows.Forms.Padding(0);
			this.addPathButton.Name = "addPathButton";
			this.addPathButton.Size = new System.Drawing.Size(52, 41);
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
			this.movePathUpButton.Location = new System.Drawing.Point(8, 57);
			this.movePathUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathUpButton.Name = "movePathUpButton";
			this.movePathUpButton.Size = new System.Drawing.Size(52, 41);
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
			this.movePathDownButton.Location = new System.Drawing.Point(8, 106);
			this.movePathDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathDownButton.Name = "movePathDownButton";
			this.movePathDownButton.Size = new System.Drawing.Size(52, 41);
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
			this.deletePathButton.Location = new System.Drawing.Point(8, 155);
			this.deletePathButton.Margin = new System.Windows.Forms.Padding(0);
			this.deletePathButton.Name = "deletePathButton";
			this.deletePathButton.Size = new System.Drawing.Size(52, 41);
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
			this.clearButton.Location = new System.Drawing.Point(8, 204);
			this.clearButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(52, 41);
			this.clearButton.TabIndex = 6;
			this.clearButton.Text = "x";
			this.clearButton.UseVisualStyleBackColor = true;
			// 
			// templateListView
			// 
			this.templateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.templateColumnHeader});
			this.templateListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateListView.FullRowSelect = true;
			this.templateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.templateListView.Location = new System.Drawing.Point(68, 8);
			this.templateListView.Margin = new System.Windows.Forms.Padding(0);
			this.templateListView.MinimumSize = new System.Drawing.Size(188, 4);
			this.templateListView.MultiSelect = false;
			this.templateListView.Name = "templateListView";
			this.templateTableLayoutPanel.SetRowSpan(this.templateListView, 10);
			this.templateListView.ShowGroups = false;
			this.templateListView.Size = new System.Drawing.Size(248, 543);
			this.templateListView.TabIndex = 7;
			this.templateListView.UseCompatibleStateImageBehavior = false;
			this.templateListView.View = System.Windows.Forms.View.Details;
			this.templateListView.SelectedIndexChanged += new System.EventHandler(this.templateListViewSelectedIndexChanged);
			// 
			// templateColumnHeader
			// 
			this.templateColumnHeader.Text = "Template";
			this.templateColumnHeader.Width = 240;
			// 
			// editTableLayoutPanel
			// 
			this.editTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
			this.editTableLayoutPanel.ColumnCount = 8;
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.Controls.Add(this.nameLabel, 1, 3);
			this.editTableLayoutPanel.Controls.Add(this.templateNameTextBox, 3, 3);
			this.editTableLayoutPanel.Controls.Add(this.saveTemplateButton, 4, 7);
			this.editTableLayoutPanel.Controls.Add(this.resetTemplateButton, 6, 7);
			this.editTableLayoutPanel.Controls.Add(this.templateDetailsTabControl, 1, 5);
			this.editTableLayoutPanel.Controls.Add(this.captionLabel, 1, 1);
			this.editTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editTableLayoutPanel.Enabled = false;
			this.editTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.editTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.editTableLayoutPanel.Name = "editTableLayoutPanel";
			this.editTableLayoutPanel.RowCount = 9;
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.editTableLayoutPanel.Size = new System.Drawing.Size(598, 559);
			this.editTableLayoutPanel.TabIndex = 0;
			// 
			// nameLabel
			// 
			this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(8, 32);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(41, 13);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name: ";
			// 
			// templateNameTextBox
			// 
			this.templateNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.editTableLayoutPanel.SetColumnSpan(this.templateNameTextBox, 4);
			this.templateNameTextBox.Location = new System.Drawing.Point(57, 29);
			this.templateNameTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.templateNameTextBox.Name = "templateNameTextBox";
			this.templateNameTextBox.Size = new System.Drawing.Size(533, 20);
			this.templateNameTextBox.TabIndex = 1;
			// 
			// saveTemplateButton
			// 
			this.saveTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.saveTemplateButton.AutoSize = true;
			this.saveTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveTemplateButton.Location = new System.Drawing.Point(408, 524);
			this.saveTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveTemplateButton.Name = "saveTemplateButton";
			this.saveTemplateButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.saveTemplateButton.Size = new System.Drawing.Size(87, 27);
			this.saveTemplateButton.TabIndex = 2;
			this.saveTemplateButton.Text = "Speichern";
			this.saveTemplateButton.UseVisualStyleBackColor = true;
			// 
			// resetTemplateButton
			// 
			this.resetTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.resetTemplateButton.AutoSize = true;
			this.resetTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.resetTemplateButton.Location = new System.Drawing.Point(503, 524);
			this.resetTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.resetTemplateButton.Name = "resetTemplateButton";
			this.resetTemplateButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.resetTemplateButton.Size = new System.Drawing.Size(87, 27);
			this.resetTemplateButton.TabIndex = 3;
			this.resetTemplateButton.Text = "Verwerfen";
			this.resetTemplateButton.UseVisualStyleBackColor = true;
			// 
			// templateDetailsTabControl
			// 
			this.editTableLayoutPanel.SetColumnSpan(this.templateDetailsTabControl, 6);
			this.templateDetailsTabControl.Controls.Add(this.commonsTabPage);
			this.templateDetailsTabControl.Controls.Add(this.publishingTabPage);
			this.templateDetailsTabControl.Controls.Add(this.otherTabPage);
			this.templateDetailsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateDetailsTabControl.Location = new System.Drawing.Point(8, 57);
			this.templateDetailsTabControl.Margin = new System.Windows.Forms.Padding(0);
			this.templateDetailsTabControl.Name = "templateDetailsTabControl";
			this.templateDetailsTabControl.SelectedIndex = 0;
			this.templateDetailsTabControl.Size = new System.Drawing.Size(582, 459);
			this.templateDetailsTabControl.TabIndex = 4;
			// 
			// commonsTabPage
			// 
			this.commonsTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.commonsTabPage.Controls.Add(this.commonsTableLayoutPannel);
			this.commonsTabPage.Location = new System.Drawing.Point(4, 22);
			this.commonsTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.commonsTabPage.Name = "commonsTabPage";
			this.commonsTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.commonsTabPage.Size = new System.Drawing.Size(574, 433);
			this.commonsTabPage.TabIndex = 0;
			this.commonsTabPage.Text = "Allgemein";
			// 
			// commonsTableLayoutPannel
			// 
			this.commonsTableLayoutPannel.ColumnCount = 5;
			this.commonsTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.commonsTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.commonsTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.Controls.Add(this.titleLabel, 1, 1);
			this.commonsTableLayoutPannel.Controls.Add(this.descriptionLabel, 1, 3);
			this.commonsTableLayoutPannel.Controls.Add(this.tagsLabel, 1, 6);
			this.commonsTableLayoutPannel.Controls.Add(this.tagsTextBox, 1, 7);
			this.commonsTableLayoutPannel.Controls.Add(this.descriptionTextBox, 1, 4);
			this.commonsTableLayoutPannel.Controls.Add(this.titleTextBox, 3, 1);
			this.commonsTableLayoutPannel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commonsTableLayoutPannel.Location = new System.Drawing.Point(2, 2);
			this.commonsTableLayoutPannel.Margin = new System.Windows.Forms.Padding(0);
			this.commonsTableLayoutPannel.Name = "commonsTableLayoutPannel";
			this.commonsTableLayoutPannel.RowCount = 9;
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.commonsTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.commonsTableLayoutPannel.Size = new System.Drawing.Size(570, 429);
			this.commonsTableLayoutPannel.TabIndex = 0;
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(10, 13);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(33, 13);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Titel: ";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionLabel.AutoSize = true;
			this.commonsTableLayoutPannel.SetColumnSpan(this.descriptionLabel, 3);
			this.descriptionLabel.Location = new System.Drawing.Point(10, 40);
			this.descriptionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(550, 13);
			this.descriptionLabel.TabIndex = 1;
			this.descriptionLabel.Text = "Beschreibung: ";
			// 
			// tagsLabel
			// 
			this.tagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tagsLabel.AutoSize = true;
			this.commonsTableLayoutPannel.SetColumnSpan(this.tagsLabel, 3);
			this.tagsLabel.Location = new System.Drawing.Point(10, 337);
			this.tagsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.tagsLabel.Name = "tagsLabel";
			this.tagsLabel.Size = new System.Drawing.Size(550, 13);
			this.tagsLabel.TabIndex = 2;
			this.tagsLabel.Text = "Tags: ";
			// 
			// tagsTextBox
			// 
			this.commonsTableLayoutPannel.SetColumnSpan(this.tagsTextBox, 3);
			this.tagsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tagsTextBox.Location = new System.Drawing.Point(10, 350);
			this.tagsTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.tagsTextBox.Multiline = true;
			this.tagsTextBox.Name = "tagsTextBox";
			this.tagsTextBox.Size = new System.Drawing.Size(550, 68);
			this.tagsTextBox.TabIndex = 3;
			// 
			// descriptionTextBox
			// 
			this.commonsTableLayoutPannel.SetColumnSpan(this.descriptionTextBox, 3);
			this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descriptionTextBox.Location = new System.Drawing.Point(10, 53);
			this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionTextBox.MaxLength = 5000;
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descriptionTextBox.Size = new System.Drawing.Size(550, 274);
			this.descriptionTextBox.TabIndex = 4;
			// 
			// titleTextBox
			// 
			this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.titleTextBox.Location = new System.Drawing.Point(53, 10);
			this.titleTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size(507, 20);
			this.titleTextBox.TabIndex = 5;
			// 
			// publishingTabPage
			// 
			this.publishingTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.publishingTabPage.Controls.Add(this.publishingTableLayoutPanel);
			this.publishingTabPage.Location = new System.Drawing.Point(4, 22);
			this.publishingTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.publishingTabPage.Name = "publishingTabPage";
			this.publishingTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.publishingTabPage.Size = new System.Drawing.Size(574, 433);
			this.publishingTabPage.TabIndex = 1;
			this.publishingTabPage.Text = "Veröffentlichung";
			// 
			// publishingTableLayoutPanel
			// 
			this.publishingTableLayoutPanel.ColumnCount = 5;
			this.publishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.Controls.Add(this.privacyLabel, 1, 1);
			this.publishingTableLayoutPanel.Controls.Add(this.publishAtGroupBox, 1, 5);
			this.publishingTableLayoutPanel.Controls.Add(this.privacyCombobox, 3, 1);
			this.publishingTableLayoutPanel.Controls.Add(this.shouldPublishAtCheckBox, 1, 3);
			this.publishingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishingTableLayoutPanel.Location = new System.Drawing.Point(2, 2);
			this.publishingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.publishingTableLayoutPanel.Name = "publishingTableLayoutPanel";
			this.publishingTableLayoutPanel.RowCount = 7;
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishingTableLayoutPanel.Size = new System.Drawing.Size(570, 429);
			this.publishingTableLayoutPanel.TabIndex = 0;
			// 
			// privacyLabel
			// 
			this.privacyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.privacyLabel.AutoSize = true;
			this.privacyLabel.Location = new System.Drawing.Point(10, 14);
			this.privacyLabel.Margin = new System.Windows.Forms.Padding(0);
			this.privacyLabel.Name = "privacyLabel";
			this.privacyLabel.Size = new System.Drawing.Size(69, 13);
			this.privacyLabel.TabIndex = 0;
			this.privacyLabel.Text = "Sichtbarkeit: ";
			// 
			// publishAtGroupBox
			// 
			this.publishingTableLayoutPanel.SetColumnSpan(this.publishAtGroupBox, 3);
			this.publishAtGroupBox.Controls.Add(this.publishAtTableLayoutPanel);
			this.publishAtGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishAtGroupBox.Enabled = false;
			this.publishAtGroupBox.Location = new System.Drawing.Point(10, 68);
			this.publishAtGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.publishAtGroupBox.Name = "publishAtGroupBox";
			this.publishAtGroupBox.Size = new System.Drawing.Size(550, 351);
			this.publishAtGroupBox.TabIndex = 1;
			this.publishAtGroupBox.TabStop = false;
			this.publishAtGroupBox.Text = "Veröffentlichungszeiträume einstellen:";
			// 
			// publishAtTableLayoutPanel
			// 
			this.publishAtTableLayoutPanel.ColumnCount = 9;
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.publishAtTableLayoutPanel.Controls.Add(this.addTimeButton, 7, 1);
			this.publishAtTableLayoutPanel.Controls.Add(this.removeTimeButton, 7, 3);
			this.publishAtTableLayoutPanel.Controls.Add(this.newTimePicker, 3, 6);
			this.publishAtTableLayoutPanel.Controls.Add(this.saveTimeButton, 5, 6);
			this.publishAtTableLayoutPanel.Controls.Add(this.skipPublishAtTableLayoutPanel, 1, 8);
			this.publishAtTableLayoutPanel.Controls.Add(this.publishingDaysListView, 1, 1);
			this.publishAtTableLayoutPanel.Controls.Add(this.publishingTimesListView, 3, 1);
			this.publishAtTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishAtTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
			this.publishAtTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.publishAtTableLayoutPanel.Name = "publishAtTableLayoutPanel";
			this.publishAtTableLayoutPanel.RowCount = 10;
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishAtTableLayoutPanel.Size = new System.Drawing.Size(544, 332);
			this.publishAtTableLayoutPanel.TabIndex = 0;
			// 
			// addTimeButton
			// 
			this.addTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTimeButton.AutoSize = true;
			this.addTimeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addTimeButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addTimeButton.Location = new System.Drawing.Point(495, 7);
			this.addTimeButton.Margin = new System.Windows.Forms.Padding(0);
			this.addTimeButton.Name = "addTimeButton";
			this.addTimeButton.Size = new System.Drawing.Size(41, 41);
			this.addTimeButton.TabIndex = 2;
			this.addTimeButton.Text = "+";
			this.addTimeButton.UseVisualStyleBackColor = true;
			this.addTimeButton.Click += new System.EventHandler(this.addTimeButtonClick);
			// 
			// removeTimeButton
			// 
			this.removeTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.removeTimeButton.AutoSize = true;
			this.removeTimeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.removeTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.removeTimeButton.ForeColor = System.Drawing.Color.Red;
			this.removeTimeButton.Location = new System.Drawing.Point(495, 53);
			this.removeTimeButton.Margin = new System.Windows.Forms.Padding(0);
			this.removeTimeButton.Name = "removeTimeButton";
			this.removeTimeButton.Size = new System.Drawing.Size(41, 41);
			this.removeTimeButton.TabIndex = 5;
			this.removeTimeButton.Text = "-";
			this.removeTimeButton.UseVisualStyleBackColor = true;
			// 
			// newTimePicker
			// 
			this.newTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.newTimePicker.CustomFormat = "HH:mm";
			this.newTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.newTimePicker.Location = new System.Drawing.Point(251, 267);
			this.newTimePicker.Margin = new System.Windows.Forms.Padding(0);
			this.newTimePicker.Name = "newTimePicker";
			this.newTimePicker.ShowUpDown = true;
			this.newTimePicker.Size = new System.Drawing.Size(117, 20);
			this.newTimePicker.TabIndex = 2;
			this.newTimePicker.Value = new System.DateTime(2017, 4, 7, 15, 0, 0, 0);
			// 
			// saveTimeButton
			// 
			this.saveTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.saveTimeButton.Location = new System.Drawing.Point(373, 266);
			this.saveTimeButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveTimeButton.Name = "saveTimeButton";
			this.saveTimeButton.Size = new System.Drawing.Size(117, 23);
			this.saveTimeButton.TabIndex = 3;
			this.saveTimeButton.Text = "Speichern!";
			this.saveTimeButton.UseVisualStyleBackColor = true;
			// 
			// skipPublishAtTableLayoutPanel
			// 
			this.skipPublishAtTableLayoutPanel.AutoSize = true;
			this.skipPublishAtTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.skipPublishAtTableLayoutPanel.ColumnCount = 4;
			this.publishAtTableLayoutPanel.SetColumnSpan(this.skipPublishAtTableLayoutPanel, 7);
			this.skipPublishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.skipPublishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.skipPublishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.skipPublishAtTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.skipPublishAtTableLayoutPanel.Controls.Add(this.skipPublishTimesLabel, 1, 0);
			this.skipPublishAtTableLayoutPanel.Controls.Add(this.skipPublishTimesUpDown, 2, 0);
			this.skipPublishAtTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skipPublishAtTableLayoutPanel.Location = new System.Drawing.Point(10, 302);
			this.skipPublishAtTableLayoutPanel.Name = "skipPublishAtTableLayoutPanel";
			this.skipPublishAtTableLayoutPanel.RowCount = 1;
			this.skipPublishAtTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.skipPublishAtTableLayoutPanel.Size = new System.Drawing.Size(523, 20);
			this.skipPublishAtTableLayoutPanel.TabIndex = 7;
			// 
			// skipPublishTimesLabel
			// 
			this.skipPublishTimesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.skipPublishTimesLabel.AutoSize = true;
			this.skipPublishTimesLabel.Location = new System.Drawing.Point(49, 3);
			this.skipPublishTimesLabel.Margin = new System.Windows.Forms.Padding(0);
			this.skipPublishTimesLabel.Name = "skipPublishTimesLabel";
			this.skipPublishTimesLabel.Size = new System.Drawing.Size(327, 13);
			this.skipPublishTimesLabel.TabIndex = 0;
			this.skipPublishTimesLabel.Text = "Nach jeder gesetzten Veröffentlichung so viele Zeiten überspringen:";
			// 
			// skipPublishTimesUpDown
			// 
			this.skipPublishTimesUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.skipPublishTimesUpDown.Location = new System.Drawing.Point(376, 0);
			this.skipPublishTimesUpDown.Margin = new System.Windows.Forms.Padding(0);
			this.skipPublishTimesUpDown.Name = "skipPublishTimesUpDown";
			this.skipPublishTimesUpDown.Size = new System.Drawing.Size(97, 20);
			this.skipPublishTimesUpDown.TabIndex = 1;
			// 
			// publishingDaysListView
			// 
			this.publishingDaysListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.daysColumnHeader});
			this.publishingDaysListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishingDaysListView.FullRowSelect = true;
			this.publishingDaysListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.publishingDaysListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
			this.publishingDaysListView.Location = new System.Drawing.Point(7, 7);
			this.publishingDaysListView.Margin = new System.Windows.Forms.Padding(0);
			this.publishingDaysListView.MultiSelect = false;
			this.publishingDaysListView.Name = "publishingDaysListView";
			this.publishAtTableLayoutPanel.SetRowSpan(this.publishingDaysListView, 6);
			this.publishingDaysListView.Size = new System.Drawing.Size(234, 282);
			this.publishingDaysListView.TabIndex = 8;
			this.publishingDaysListView.UseCompatibleStateImageBehavior = false;
			this.publishingDaysListView.View = System.Windows.Forms.View.Details;
			// 
			// daysColumnHeader
			// 
			this.daysColumnHeader.Text = "Wochentag";
			this.daysColumnHeader.Width = 200;
			// 
			// publishingTimesListView
			// 
			this.publishingTimesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader});
			this.publishAtTableLayoutPanel.SetColumnSpan(this.publishingTimesListView, 3);
			this.publishingTimesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishingTimesListView.FullRowSelect = true;
			this.publishingTimesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.publishingTimesListView.Location = new System.Drawing.Point(251, 7);
			this.publishingTimesListView.Margin = new System.Windows.Forms.Padding(0);
			this.publishingTimesListView.MultiSelect = false;
			this.publishingTimesListView.Name = "publishingTimesListView";
			this.publishAtTableLayoutPanel.SetRowSpan(this.publishingTimesListView, 4);
			this.publishingTimesListView.Size = new System.Drawing.Size(239, 249);
			this.publishingTimesListView.TabIndex = 9;
			this.publishingTimesListView.UseCompatibleStateImageBehavior = false;
			this.publishingTimesListView.View = System.Windows.Forms.View.Details;
			this.publishingTimesListView.SelectedIndexChanged += new System.EventHandler(this.publishingTimesListViewSelectedIndexChanged);
			// 
			// timeColumnHeader
			// 
			this.timeColumnHeader.Text = "Veröffentlichungszeit";
			this.timeColumnHeader.Width = 200;
			// 
			// privacyCombobox
			// 
			this.privacyCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.privacyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.privacyCombobox.FormattingEnabled = true;
			this.privacyCombobox.Items.AddRange(new object[] {
            "Öffentlich",
            "Nicht sichtbar",
            "Privat"});
			this.privacyCombobox.Location = new System.Drawing.Point(89, 10);
			this.privacyCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.privacyCombobox.Name = "privacyCombobox";
			this.privacyCombobox.Size = new System.Drawing.Size(471, 21);
			this.privacyCombobox.TabIndex = 2;
			// 
			// shouldPublishAtCheckBox
			// 
			this.shouldPublishAtCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.shouldPublishAtCheckBox.AutoSize = true;
			this.publishingTableLayoutPanel.SetColumnSpan(this.shouldPublishAtCheckBox, 3);
			this.shouldPublishAtCheckBox.Location = new System.Drawing.Point(10, 41);
			this.shouldPublishAtCheckBox.Margin = new System.Windows.Forms.Padding(0);
			this.shouldPublishAtCheckBox.Name = "shouldPublishAtCheckBox";
			this.shouldPublishAtCheckBox.Size = new System.Drawing.Size(550, 17);
			this.shouldPublishAtCheckBox.TabIndex = 3;
			this.shouldPublishAtCheckBox.Text = "Geplant veröffentlichen";
			this.shouldPublishAtCheckBox.UseVisualStyleBackColor = true;
			this.shouldPublishAtCheckBox.CheckedChanged += new System.EventHandler(this.shouldPublishAtCheckBoxCheckedChanged);
			// 
			// otherTabPage
			// 
			this.otherTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.otherTabPage.Location = new System.Drawing.Point(4, 22);
			this.otherTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.otherTabPage.Name = "otherTabPage";
			this.otherTabPage.Size = new System.Drawing.Size(574, 433);
			this.otherTabPage.TabIndex = 2;
			this.otherTabPage.Text = "Sonstiges";
			// 
			// captionLabel
			// 
			this.captionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.captionLabel.AutoSize = true;
			this.editTableLayoutPanel.SetColumnSpan(this.captionLabel, 6);
			this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captionLabel.Location = new System.Drawing.Point(8, 8);
			this.captionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.captionLabel.Name = "captionLabel";
			this.captionLabel.Size = new System.Drawing.Size(582, 13);
			this.captionLabel.TabIndex = 0;
			this.captionLabel.Text = "Template bearbeiten: ";
			// 
			// splitContainer
			// 
			this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.templateTableLayoutPanel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.editTableLayoutPanel);
			this.splitContainer.Size = new System.Drawing.Size(933, 559);
			this.splitContainer.SplitterDistance = 324;
			this.splitContainer.SplitterWidth = 11;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerPaint);
			// 
			// TemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 559);
			this.Controls.Add(this.splitContainer);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "TemplateForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Templates bearbeiten";
			this.Load += new System.EventHandler(this.TemplateFormLoad);
			this.templateTableLayoutPanel.ResumeLayout(false);
			this.templateTableLayoutPanel.PerformLayout();
			this.editTableLayoutPanel.ResumeLayout(false);
			this.editTableLayoutPanel.PerformLayout();
			this.templateDetailsTabControl.ResumeLayout(false);
			this.commonsTabPage.ResumeLayout(false);
			this.commonsTableLayoutPannel.ResumeLayout(false);
			this.commonsTableLayoutPannel.PerformLayout();
			this.publishingTabPage.ResumeLayout(false);
			this.publishingTableLayoutPanel.ResumeLayout(false);
			this.publishingTableLayoutPanel.PerformLayout();
			this.publishAtGroupBox.ResumeLayout(false);
			this.publishAtTableLayoutPanel.ResumeLayout(false);
			this.publishAtTableLayoutPanel.PerformLayout();
			this.skipPublishAtTableLayoutPanel.ResumeLayout(false);
			this.skipPublishAtTableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.skipPublishTimesUpDown)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel templateTableLayoutPanel;
		private System.Windows.Forms.Button addPathButton;
		private System.Windows.Forms.Button movePathUpButton;
		private System.Windows.Forms.Button movePathDownButton;
		private System.Windows.Forms.Button deletePathButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.TableLayoutPanel editTableLayoutPanel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox templateNameTextBox;
		private System.Windows.Forms.Button saveTemplateButton;
		private System.Windows.Forms.Button resetTemplateButton;
		private System.Windows.Forms.TabControl templateDetailsTabControl;
		private System.Windows.Forms.TabPage commonsTabPage;
		private System.Windows.Forms.TabPage publishingTabPage;
		private System.Windows.Forms.ListView templateListView;
		private System.Windows.Forms.ColumnHeader templateColumnHeader;
		private System.Windows.Forms.TabPage otherTabPage;
		private System.Windows.Forms.Label captionLabel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.TableLayoutPanel commonsTableLayoutPannel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.Label tagsLabel;
		private System.Windows.Forms.TextBox tagsTextBox;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.TableLayoutPanel publishingTableLayoutPanel;
		private System.Windows.Forms.Label privacyLabel;
		private System.Windows.Forms.GroupBox publishAtGroupBox;
		private System.Windows.Forms.ComboBox privacyCombobox;
		private System.Windows.Forms.CheckBox shouldPublishAtCheckBox;
		private System.Windows.Forms.TableLayoutPanel publishAtTableLayoutPanel;
		private System.Windows.Forms.Button addTimeButton;
		private System.Windows.Forms.Button removeTimeButton;
		private System.Windows.Forms.DateTimePicker newTimePicker;
		private System.Windows.Forms.Button saveTimeButton;
		private System.Windows.Forms.TableLayoutPanel skipPublishAtTableLayoutPanel;
		private System.Windows.Forms.Label skipPublishTimesLabel;
		private System.Windows.Forms.NumericUpDown skipPublishTimesUpDown;
		private System.Windows.Forms.ListView publishingDaysListView;
		private System.Windows.Forms.ListView publishingTimesListView;
		private System.Windows.Forms.ColumnHeader daysColumnHeader;
		private System.Windows.Forms.ColumnHeader timeColumnHeader;
	}
}