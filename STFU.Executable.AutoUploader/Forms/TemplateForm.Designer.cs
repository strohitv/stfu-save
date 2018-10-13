using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace STFU.Executable.AutoUploader.Forms
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
			this.templateOverviewTableLayouPanel = new System.Windows.Forms.TableLayoutPanel();
			this.addTemplateButton = new System.Windows.Forms.Button();
			this.moveTemplateUpButton = new System.Windows.Forms.Button();
			this.moveTemplateDownButton = new System.Windows.Forms.Button();
			this.deleteTemplateButton = new System.Windows.Forms.Button();
			this.clearTemplatesButton = new System.Windows.Forms.Button();
			this.templateListView = new System.Windows.Forms.ListView();
			this.templatesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.duplicateTemplateButton = new System.Windows.Forms.Button();
			this.editTemplateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.templateNameLabel = new System.Windows.Forms.Label();
			this.templateNameTextbox = new System.Windows.Forms.TextBox();
			this.saveTemplateButton = new System.Windows.Forms.Button();
			this.resetTemplateButton = new System.Windows.Forms.Button();
			this.templateValuesTabControl = new System.Windows.Forms.TabControl();
			this.commonTabPage = new System.Windows.Forms.TabPage();
			this.templateCommonTableLayoutPannel = new System.Windows.Forms.TableLayoutPanel();
			this.templateTitleLabel = new System.Windows.Forms.Label();
			this.templateDescriptionLabel = new System.Windows.Forms.Label();
			this.templateTagsLabel = new System.Windows.Forms.Label();
			this.templateTitleTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
			this.templateDescriptionTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
			this.templateTagsTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
			this.maxTitleLengthLabel = new System.Windows.Forms.Label();
			this.maxDescriptionLengthLabel = new System.Windows.Forms.Label();
			this.maxTagsLengthLabel = new System.Windows.Forms.Label();
			this.publishTabPage = new System.Windows.Forms.TabPage();
			this.publishTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.privacyLabel = new System.Windows.Forms.Label();
			this.publishAtCheckbox = new System.Windows.Forms.CheckBox();
			this.privacyComboBox = new System.Windows.Forms.ComboBox();
			this.publishGroupbox = new System.Windows.Forms.GroupBox();
			this.publishPanel = new System.Windows.Forms.TableLayoutPanel();
			this.timesListView = new System.Windows.Forms.ListView();
			this.weekdayColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skipDaysHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.moveTimeUpButton = new System.Windows.Forms.Button();
			this.moveTimeDownButton = new System.Windows.Forms.Button();
			this.addOneDayButton = new System.Windows.Forms.Button();
			this.substractOneDayButton = new System.Windows.Forms.Button();
			this.clearTimesButton = new System.Windows.Forms.Button();
			this.deleteTimeButton = new System.Windows.Forms.Button();
			this.addOneWeekButton = new System.Windows.Forms.Button();
			this.substractOneWeekButton = new System.Windows.Forms.Button();
			this.addTimeLabel = new System.Windows.Forms.Label();
			this.addTimeButton = new System.Windows.Forms.Button();
			this.addWeekdayCombobox = new System.Windows.Forms.ComboBox();
			this.addTimeTimePicker = new System.Windows.Forms.DateTimePicker();
			this.addWeekdayLabel = new System.Windows.Forms.Label();
			this.otherTabPage = new System.Windows.Forms.TabPage();
			this.otherTlp = new System.Windows.Forms.TableLayoutPanel();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.defaultLanguageLabel = new System.Windows.Forms.Label();
			this.licenseLabel = new System.Windows.Forms.Label();
			this.isEmbeddableCheckbox = new System.Windows.Forms.CheckBox();
			this.publicStatsViewableCheckbox = new System.Windows.Forms.CheckBox();
			this.categoryCombobox = new System.Windows.Forms.ComboBox();
			this.defaultLanguageCombobox = new System.Windows.Forms.ComboBox();
			this.licenseCombobox = new System.Windows.Forms.ComboBox();
			this.thumbnailLabel = new System.Windows.Forms.Label();
			this.thumbnailTextbox = new FastColoredTextBoxNS.FastColoredTextBox();
			this.chooseThumbnailPathButton = new System.Windows.Forms.Button();
			this.notifySubscribersCheckbox = new System.Windows.Forms.CheckBox();
			this.autoLevelsCheckbox = new System.Windows.Forms.CheckBox();
			this.stabilizeCheckbox = new System.Windows.Forms.CheckBox();
			this.planVideosTabpage = new System.Windows.Forms.TabPage();
			this.planVideosTlp = new System.Windows.Forms.TableLayoutPanel();
			this.addFilenameButton = new System.Windows.Forms.Button();
			this.removeFilenameButton = new System.Windows.Forms.Button();
			this.clearFilenamesButton = new System.Windows.Forms.Button();
			this.filenamesListView = new System.Windows.Forms.ListView();
			this.varNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.varContentColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.filenamesLabel = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fillFieldsTlp = new System.Windows.Forms.TableLayoutPanel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.filenameFieldLabel = new System.Windows.Forms.Label();
			this.filenameValueLabel = new System.Windows.Forms.Label();
			this.filenameFieldTxbx = new System.Windows.Forms.TextBox();
			this.filenameValueTxbx = new System.Windows.Forms.TextBox();
			this.cSharpTabPage = new System.Windows.Forms.TabPage();
			this.csTlp = new System.Windows.Forms.TableLayoutPanel();
			this.cSharpCleanupFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.cSharpPrepareFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.csDescriptionTxbx = new System.Windows.Forms.TextBox();
			this.globalPrepareScriptLabel = new System.Windows.Forms.Label();
			this.globalAfterScriptsLabel = new System.Windows.Forms.Label();
			this.editTemplateLabel = new System.Windows.Forms.Label();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.openThumbnailDialog = new System.Windows.Forms.OpenFileDialog();
			this.templateOverviewTableLayouPanel.SuspendLayout();
			this.editTemplateTableLayoutPanel.SuspendLayout();
			this.templateValuesTabControl.SuspendLayout();
			this.commonTabPage.SuspendLayout();
			this.templateCommonTableLayoutPannel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.templateTitleTextbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateDescriptionTextbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateTagsTextbox)).BeginInit();
			this.publishTabPage.SuspendLayout();
			this.publishTableLayoutPanel.SuspendLayout();
			this.publishGroupbox.SuspendLayout();
			this.publishPanel.SuspendLayout();
			this.otherTabPage.SuspendLayout();
			this.otherTlp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailTextbox)).BeginInit();
			this.planVideosTabpage.SuspendLayout();
			this.planVideosTlp.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.fillFieldsTlp.SuspendLayout();
			this.cSharpTabPage.SuspendLayout();
			this.csTlp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cSharpCleanupFctb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSharpPrepareFctb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// templateOverviewTableLayouPanel
			// 
			this.templateOverviewTableLayouPanel.BackColor = System.Drawing.SystemColors.Control;
			this.templateOverviewTableLayouPanel.ColumnCount = 5;
			this.templateOverviewTableLayouPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.templateOverviewTableLayouPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.templateOverviewTableLayouPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.Controls.Add(this.addTemplateButton, 1, 1);
			this.templateOverviewTableLayouPanel.Controls.Add(this.moveTemplateUpButton, 1, 5);
			this.templateOverviewTableLayouPanel.Controls.Add(this.moveTemplateDownButton, 1, 7);
			this.templateOverviewTableLayouPanel.Controls.Add(this.deleteTemplateButton, 1, 9);
			this.templateOverviewTableLayouPanel.Controls.Add(this.clearTemplatesButton, 1, 11);
			this.templateOverviewTableLayouPanel.Controls.Add(this.templateListView, 3, 1);
			this.templateOverviewTableLayouPanel.Controls.Add(this.duplicateTemplateButton, 1, 3);
			this.templateOverviewTableLayouPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateOverviewTableLayouPanel.Location = new System.Drawing.Point(0, 0);
			this.templateOverviewTableLayouPanel.Margin = new System.Windows.Forms.Padding(2);
			this.templateOverviewTableLayouPanel.Name = "templateOverviewTableLayouPanel";
			this.templateOverviewTableLayouPanel.RowCount = 14;
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.templateOverviewTableLayouPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateOverviewTableLayouPanel.Size = new System.Drawing.Size(264, 770);
			this.templateOverviewTableLayouPanel.TabIndex = 0;
			// 
			// addTemplateButton
			// 
			this.addTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTemplateButton.AutoSize = true;
			this.addTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addTemplateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addTemplateButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addTemplateButton.Location = new System.Drawing.Point(10, 10);
			this.addTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.addTemplateButton.Name = "addTemplateButton";
			this.addTemplateButton.Size = new System.Drawing.Size(45, 41);
			this.addTemplateButton.TabIndex = 2;
			this.addTemplateButton.Text = "+";
			this.tooltip.SetToolTip(this.addTemplateButton, "Neues Template hinzufügen");
			this.addTemplateButton.UseVisualStyleBackColor = true;
			this.addTemplateButton.Click += new System.EventHandler(this.addTemplateButtonClick);
			// 
			// moveTemplateUpButton
			// 
			this.moveTemplateUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.moveTemplateUpButton.AutoSize = true;
			this.moveTemplateUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveTemplateUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moveTemplateUpButton.Location = new System.Drawing.Point(10, 112);
			this.moveTemplateUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveTemplateUpButton.Name = "moveTemplateUpButton";
			this.moveTemplateUpButton.Size = new System.Drawing.Size(45, 41);
			this.moveTemplateUpButton.TabIndex = 3;
			this.moveTemplateUpButton.Text = "↑";
			this.tooltip.SetToolTip(this.moveTemplateUpButton, "Markiertes Template um eine Position nach oben verschieben");
			this.moveTemplateUpButton.UseVisualStyleBackColor = true;
			this.moveTemplateUpButton.Click += new System.EventHandler(this.moveTemplateUpButtonClick);
			// 
			// moveTemplateDownButton
			// 
			this.moveTemplateDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.moveTemplateDownButton.AutoSize = true;
			this.moveTemplateDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveTemplateDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moveTemplateDownButton.Location = new System.Drawing.Point(10, 163);
			this.moveTemplateDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveTemplateDownButton.Name = "moveTemplateDownButton";
			this.moveTemplateDownButton.Size = new System.Drawing.Size(45, 41);
			this.moveTemplateDownButton.TabIndex = 4;
			this.moveTemplateDownButton.Text = "↓";
			this.tooltip.SetToolTip(this.moveTemplateDownButton, "Markiertes Template um eine Position nach unten verschieben");
			this.moveTemplateDownButton.UseVisualStyleBackColor = true;
			this.moveTemplateDownButton.Click += new System.EventHandler(this.moveTemplateDownButtonClick);
			// 
			// deleteTemplateButton
			// 
			this.deleteTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteTemplateButton.AutoSize = true;
			this.deleteTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deleteTemplateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deleteTemplateButton.ForeColor = System.Drawing.Color.Red;
			this.deleteTemplateButton.Location = new System.Drawing.Point(10, 214);
			this.deleteTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.deleteTemplateButton.Name = "deleteTemplateButton";
			this.deleteTemplateButton.Size = new System.Drawing.Size(45, 41);
			this.deleteTemplateButton.TabIndex = 5;
			this.deleteTemplateButton.Text = "-";
			this.tooltip.SetToolTip(this.deleteTemplateButton, "Markiertes Template löschen");
			this.deleteTemplateButton.UseVisualStyleBackColor = true;
			this.deleteTemplateButton.Click += new System.EventHandler(this.deleteTemplateButtonClick);
			// 
			// clearTemplatesButton
			// 
			this.clearTemplatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.clearTemplatesButton.AutoSize = true;
			this.clearTemplatesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearTemplatesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearTemplatesButton.ForeColor = System.Drawing.Color.Red;
			this.clearTemplatesButton.Location = new System.Drawing.Point(10, 265);
			this.clearTemplatesButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearTemplatesButton.Name = "clearTemplatesButton";
			this.clearTemplatesButton.Size = new System.Drawing.Size(45, 41);
			this.clearTemplatesButton.TabIndex = 6;
			this.clearTemplatesButton.Text = "x";
			this.tooltip.SetToolTip(this.clearTemplatesButton, "Alle Templates löschen");
			this.clearTemplatesButton.UseVisualStyleBackColor = true;
			this.clearTemplatesButton.Click += new System.EventHandler(this.clearTemplatesButtonClick);
			// 
			// templateListView
			// 
			this.templateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.templatesColumnHeader});
			this.templateListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateListView.FullRowSelect = true;
			this.templateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.templateListView.HideSelection = false;
			this.templateListView.Location = new System.Drawing.Point(65, 10);
			this.templateListView.Margin = new System.Windows.Forms.Padding(0);
			this.templateListView.MinimumSize = new System.Drawing.Size(188, 4);
			this.templateListView.MultiSelect = false;
			this.templateListView.Name = "templateListView";
			this.templateOverviewTableLayouPanel.SetRowSpan(this.templateListView, 12);
			this.templateListView.ShowGroups = false;
			this.templateListView.Size = new System.Drawing.Size(189, 750);
			this.templateListView.TabIndex = 7;
			this.templateListView.UseCompatibleStateImageBehavior = false;
			this.templateListView.View = System.Windows.Forms.View.Details;
			this.templateListView.SelectedIndexChanged += new System.EventHandler(this.templateListViewSelectedIndexChanged);
			// 
			// templatesColumnHeader
			// 
			this.templatesColumnHeader.Text = "Template";
			this.templatesColumnHeader.Width = 150;
			// 
			// duplicateTemplateButton
			// 
			this.duplicateTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.duplicateTemplateButton.AutoSize = true;
			this.duplicateTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.duplicateTemplateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.duplicateTemplateButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.duplicateTemplateButton.Location = new System.Drawing.Point(10, 61);
			this.duplicateTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.duplicateTemplateButton.Name = "duplicateTemplateButton";
			this.duplicateTemplateButton.Size = new System.Drawing.Size(45, 41);
			this.duplicateTemplateButton.TabIndex = 2;
			this.duplicateTemplateButton.Text = "⁂";
			this.tooltip.SetToolTip(this.duplicateTemplateButton, "Erstellt eine Kopie des ausgewählten Templates");
			this.duplicateTemplateButton.UseVisualStyleBackColor = true;
			this.duplicateTemplateButton.Click += new System.EventHandler(this.duplicateTemplateButtonClick);
			// 
			// editTemplateTableLayoutPanel
			// 
			this.editTemplateTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
			this.editTemplateTableLayoutPanel.ColumnCount = 8;
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.editTemplateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.Controls.Add(this.templateNameLabel, 1, 3);
			this.editTemplateTableLayoutPanel.Controls.Add(this.templateNameTextbox, 3, 3);
			this.editTemplateTableLayoutPanel.Controls.Add(this.saveTemplateButton, 4, 7);
			this.editTemplateTableLayoutPanel.Controls.Add(this.resetTemplateButton, 6, 7);
			this.editTemplateTableLayoutPanel.Controls.Add(this.templateValuesTabControl, 1, 5);
			this.editTemplateTableLayoutPanel.Controls.Add(this.editTemplateLabel, 1, 1);
			this.editTemplateTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editTemplateTableLayoutPanel.Enabled = false;
			this.editTemplateTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.editTemplateTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.editTemplateTableLayoutPanel.Name = "editTemplateTableLayoutPanel";
			this.editTemplateTableLayoutPanel.RowCount = 9;
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.editTemplateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.editTemplateTableLayoutPanel.Size = new System.Drawing.Size(930, 770);
			this.editTemplateTableLayoutPanel.TabIndex = 0;
			// 
			// templateNameLabel
			// 
			this.templateNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateNameLabel.AutoSize = true;
			this.templateNameLabel.Location = new System.Drawing.Point(10, 39);
			this.templateNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.templateNameLabel.Name = "templateNameLabel";
			this.templateNameLabel.Size = new System.Drawing.Size(41, 13);
			this.templateNameLabel.TabIndex = 0;
			this.templateNameLabel.Text = "Name: ";
			// 
			// templateNameTextbox
			// 
			this.templateNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateNameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.editTemplateTableLayoutPanel.SetColumnSpan(this.templateNameTextbox, 4);
			this.templateNameTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.templateNameTextbox.Location = new System.Drawing.Point(61, 33);
			this.templateNameTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateNameTextbox.Name = "templateNameTextbox";
			this.templateNameTextbox.Size = new System.Drawing.Size(859, 26);
			this.templateNameTextbox.TabIndex = 1;
			this.templateNameTextbox.TextChanged += new System.EventHandler(this.templateNameTextboxTextChanged);
			// 
			// saveTemplateButton
			// 
			this.saveTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.saveTemplateButton.AutoSize = true;
			this.saveTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveTemplateButton.Location = new System.Drawing.Point(736, 733);
			this.saveTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.saveTemplateButton.Name = "saveTemplateButton";
			this.saveTemplateButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.saveTemplateButton.Size = new System.Drawing.Size(87, 27);
			this.saveTemplateButton.TabIndex = 2;
			this.saveTemplateButton.Text = "Speichern";
			this.saveTemplateButton.UseVisualStyleBackColor = true;
			this.saveTemplateButton.Click += new System.EventHandler(this.saveTemplateButtonClick);
			// 
			// resetTemplateButton
			// 
			this.resetTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.resetTemplateButton.AutoSize = true;
			this.resetTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.resetTemplateButton.Location = new System.Drawing.Point(833, 733);
			this.resetTemplateButton.Margin = new System.Windows.Forms.Padding(0);
			this.resetTemplateButton.Name = "resetTemplateButton";
			this.resetTemplateButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.resetTemplateButton.Size = new System.Drawing.Size(87, 27);
			this.resetTemplateButton.TabIndex = 3;
			this.resetTemplateButton.Text = "Verwerfen";
			this.resetTemplateButton.UseVisualStyleBackColor = true;
			this.resetTemplateButton.Click += new System.EventHandler(this.resetTemplateButtonClick);
			// 
			// templateValuesTabControl
			// 
			this.editTemplateTableLayoutPanel.SetColumnSpan(this.templateValuesTabControl, 6);
			this.templateValuesTabControl.Controls.Add(this.commonTabPage);
			this.templateValuesTabControl.Controls.Add(this.publishTabPage);
			this.templateValuesTabControl.Controls.Add(this.otherTabPage);
			this.templateValuesTabControl.Controls.Add(this.planVideosTabpage);
			this.templateValuesTabControl.Controls.Add(this.cSharpTabPage);
			this.templateValuesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateValuesTabControl.Location = new System.Drawing.Point(10, 69);
			this.templateValuesTabControl.Margin = new System.Windows.Forms.Padding(0);
			this.templateValuesTabControl.Name = "templateValuesTabControl";
			this.templateValuesTabControl.SelectedIndex = 0;
			this.templateValuesTabControl.Size = new System.Drawing.Size(910, 654);
			this.templateValuesTabControl.TabIndex = 4;
			// 
			// commonTabPage
			// 
			this.commonTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.commonTabPage.Controls.Add(this.templateCommonTableLayoutPannel);
			this.commonTabPage.Location = new System.Drawing.Point(4, 22);
			this.commonTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.commonTabPage.Name = "commonTabPage";
			this.commonTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.commonTabPage.Size = new System.Drawing.Size(902, 628);
			this.commonTabPage.TabIndex = 0;
			this.commonTabPage.Text = "Allgemein";
			// 
			// templateCommonTableLayoutPannel
			// 
			this.templateCommonTableLayoutPannel.ColumnCount = 5;
			this.templateCommonTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.templateCommonTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.templateCommonTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateCommonTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.templateCommonTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateTitleLabel, 1, 1);
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateDescriptionLabel, 1, 5);
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateTagsLabel, 1, 10);
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateTitleTextbox, 3, 1);
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateDescriptionTextbox, 1, 6);
			this.templateCommonTableLayoutPannel.Controls.Add(this.templateTagsTextbox, 1, 11);
			this.templateCommonTableLayoutPannel.Controls.Add(this.maxTitleLengthLabel, 3, 3);
			this.templateCommonTableLayoutPannel.Controls.Add(this.maxDescriptionLengthLabel, 3, 8);
			this.templateCommonTableLayoutPannel.Controls.Add(this.maxTagsLengthLabel, 3, 13);
			this.templateCommonTableLayoutPannel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateCommonTableLayoutPannel.Location = new System.Drawing.Point(2, 2);
			this.templateCommonTableLayoutPannel.Margin = new System.Windows.Forms.Padding(0);
			this.templateCommonTableLayoutPannel.Name = "templateCommonTableLayoutPannel";
			this.templateCommonTableLayoutPannel.RowCount = 15;
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.templateCommonTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.templateCommonTableLayoutPannel.Size = new System.Drawing.Size(898, 624);
			this.templateCommonTableLayoutPannel.TabIndex = 0;
			// 
			// templateTitleLabel
			// 
			this.templateTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTitleLabel.AutoSize = true;
			this.templateTitleLabel.Location = new System.Drawing.Point(5, 13);
			this.templateTitleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.templateTitleLabel.Name = "templateTitleLabel";
			this.templateTitleLabel.Size = new System.Drawing.Size(33, 13);
			this.templateTitleLabel.TabIndex = 0;
			this.templateTitleLabel.Text = "Titel: ";
			// 
			// templateDescriptionLabel
			// 
			this.templateDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateDescriptionLabel.AutoSize = true;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateDescriptionLabel, 3);
			this.templateDescriptionLabel.Location = new System.Drawing.Point(5, 61);
			this.templateDescriptionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.templateDescriptionLabel.Name = "templateDescriptionLabel";
			this.templateDescriptionLabel.Size = new System.Drawing.Size(888, 13);
			this.templateDescriptionLabel.TabIndex = 1;
			this.templateDescriptionLabel.Text = "Beschreibung: ";
			// 
			// templateTagsLabel
			// 
			this.templateTagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTagsLabel.AutoSize = true;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateTagsLabel, 3);
			this.templateTagsLabel.Location = new System.Drawing.Point(5, 447);
			this.templateTagsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.templateTagsLabel.Name = "templateTagsLabel";
			this.templateTagsLabel.Size = new System.Drawing.Size(888, 13);
			this.templateTagsLabel.TabIndex = 2;
			this.templateTagsLabel.Text = "Tags: ";
			// 
			// templateTitleTextbox
			// 
			this.templateTitleTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTitleTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.templateTitleTextbox.AutoScrollMinSize = new System.Drawing.Size(2, 18);
			this.templateTitleTextbox.BackBrush = null;
			this.templateTitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateTitleTextbox.CharHeight = 18;
			this.templateTitleTextbox.CharWidth = 10;
			this.templateTitleTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateTitleTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.templateTitleTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateTitleTextbox.IsReplaceMode = false;
			this.templateTitleTextbox.Location = new System.Drawing.Point(48, 7);
			this.templateTitleTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateTitleTextbox.Multiline = false;
			this.templateTitleTextbox.Name = "templateTitleTextbox";
			this.templateTitleTextbox.Paddings = new System.Windows.Forms.Padding(0);
			this.templateTitleTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.templateTitleTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("templateTitleTextbox.ServiceColors")));
			this.templateTitleTextbox.ShowLineNumbers = false;
			this.templateTitleTextbox.ShowScrollBars = false;
			this.templateTitleTextbox.Size = new System.Drawing.Size(845, 26);
			this.templateTitleTextbox.TabIndex = 3;
			this.templateTitleTextbox.WordWrapIndent = 4;
			this.templateTitleTextbox.Zoom = 100;
			this.templateTitleTextbox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.templateTitleTextboxTextChanged);
			// 
			// templateDescriptionTextbox
			// 
			this.templateDescriptionTextbox.AutoCompleteBrackets = true;
			this.templateDescriptionTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.templateDescriptionTextbox.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.templateDescriptionTextbox.AutoScrollMinSize = new System.Drawing.Size(0, 18);
			this.templateDescriptionTextbox.BackBrush = null;
			this.templateDescriptionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateDescriptionTextbox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.templateDescriptionTextbox.CharHeight = 18;
			this.templateDescriptionTextbox.CharWidth = 10;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateDescriptionTextbox, 3);
			this.templateDescriptionTextbox.CurrentLineColor = System.Drawing.Color.LightGray;
			this.templateDescriptionTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateDescriptionTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.templateDescriptionTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateDescriptionTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateDescriptionTextbox.IsReplaceMode = false;
			this.templateDescriptionTextbox.Language = FastColoredTextBoxNS.Language.CSharp;
			this.templateDescriptionTextbox.LeftBracket = '(';
			this.templateDescriptionTextbox.LeftBracket2 = '{';
			this.templateDescriptionTextbox.Location = new System.Drawing.Point(5, 74);
			this.templateDescriptionTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateDescriptionTextbox.Name = "templateDescriptionTextbox";
			this.templateDescriptionTextbox.Paddings = new System.Windows.Forms.Padding(0);
			this.templateDescriptionTextbox.RightBracket = ')';
			this.templateDescriptionTextbox.RightBracket2 = '}';
			this.templateDescriptionTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.templateDescriptionTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("templateDescriptionTextbox.ServiceColors")));
			this.templateDescriptionTextbox.Size = new System.Drawing.Size(888, 345);
			this.templateDescriptionTextbox.TabIndex = 4;
			this.templateDescriptionTextbox.WordWrap = true;
			this.templateDescriptionTextbox.WordWrapIndent = 6;
			this.templateDescriptionTextbox.Zoom = 100;
			this.templateDescriptionTextbox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.templateDescriptionTextboxTextChanged);
			// 
			// templateTagsTextbox
			// 
			this.templateTagsTextbox.AutoCompleteBrackets = true;
			this.templateTagsTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.templateTagsTextbox.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.templateTagsTextbox.AutoScrollMinSize = new System.Drawing.Size(0, 18);
			this.templateTagsTextbox.BackBrush = null;
			this.templateTagsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateTagsTextbox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.templateTagsTextbox.CharHeight = 18;
			this.templateTagsTextbox.CharWidth = 10;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateTagsTextbox, 3);
			this.templateTagsTextbox.CurrentLineColor = System.Drawing.Color.LightGray;
			this.templateTagsTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateTagsTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.templateTagsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateTagsTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateTagsTextbox.IsReplaceMode = false;
			this.templateTagsTextbox.Language = FastColoredTextBoxNS.Language.CSharp;
			this.templateTagsTextbox.LeftBracket = '(';
			this.templateTagsTextbox.LeftBracket2 = '{';
			this.templateTagsTextbox.Location = new System.Drawing.Point(5, 460);
			this.templateTagsTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateTagsTextbox.Name = "templateTagsTextbox";
			this.templateTagsTextbox.Paddings = new System.Windows.Forms.Padding(0);
			this.templateTagsTextbox.RightBracket = ')';
			this.templateTagsTextbox.RightBracket2 = '}';
			this.templateTagsTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.templateTagsTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("templateTagsTextbox.ServiceColors")));
			this.templateTagsTextbox.Size = new System.Drawing.Size(888, 138);
			this.templateTagsTextbox.TabIndex = 5;
			this.templateTagsTextbox.WordWrap = true;
			this.templateTagsTextbox.WordWrapIndent = 6;
			this.templateTagsTextbox.Zoom = 100;
			this.templateTagsTextbox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.templateTagsTextboxTextChanged);
			// 
			// maxTitleLengthLabel
			// 
			this.maxTitleLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxTitleLengthLabel.AutoSize = true;
			this.maxTitleLengthLabel.Location = new System.Drawing.Point(48, 38);
			this.maxTitleLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxTitleLengthLabel.Name = "maxTitleLengthLabel";
			this.maxTitleLengthLabel.Size = new System.Drawing.Size(845, 13);
			this.maxTitleLengthLabel.TabIndex = 6;
			this.maxTitleLengthLabel.Text = "Länge Titel: 0 / 100 Zeichen";
			// 
			// maxDescriptionLengthLabel
			// 
			this.maxDescriptionLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxDescriptionLengthLabel.AutoSize = true;
			this.maxDescriptionLengthLabel.Location = new System.Drawing.Point(48, 424);
			this.maxDescriptionLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxDescriptionLengthLabel.Name = "maxDescriptionLengthLabel";
			this.maxDescriptionLengthLabel.Size = new System.Drawing.Size(845, 13);
			this.maxDescriptionLengthLabel.TabIndex = 7;
			this.maxDescriptionLengthLabel.Text = "Länge Beschreibung: 0 / 5000 Zeichen";
			// 
			// maxTagsLengthLabel
			// 
			this.maxTagsLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxTagsLengthLabel.AutoSize = true;
			this.maxTagsLengthLabel.Location = new System.Drawing.Point(48, 603);
			this.maxTagsLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxTagsLengthLabel.Name = "maxTagsLengthLabel";
			this.maxTagsLengthLabel.Size = new System.Drawing.Size(845, 13);
			this.maxTagsLengthLabel.TabIndex = 8;
			this.maxTagsLengthLabel.Text = "Länge Tags: 0 / 500 Zeichen";
			// 
			// publishTabPage
			// 
			this.publishTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.publishTabPage.Controls.Add(this.publishTableLayoutPanel);
			this.publishTabPage.Location = new System.Drawing.Point(4, 22);
			this.publishTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.publishTabPage.Name = "publishTabPage";
			this.publishTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.publishTabPage.Size = new System.Drawing.Size(902, 628);
			this.publishTabPage.TabIndex = 1;
			this.publishTabPage.Text = "Veröffentlichung";
			// 
			// publishTableLayoutPanel
			// 
			this.publishTableLayoutPanel.ColumnCount = 5;
			this.publishTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishTableLayoutPanel.Controls.Add(this.privacyLabel, 1, 1);
			this.publishTableLayoutPanel.Controls.Add(this.publishAtCheckbox, 1, 3);
			this.publishTableLayoutPanel.Controls.Add(this.privacyComboBox, 3, 1);
			this.publishTableLayoutPanel.Controls.Add(this.publishGroupbox, 1, 5);
			this.publishTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishTableLayoutPanel.Location = new System.Drawing.Point(2, 2);
			this.publishTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.publishTableLayoutPanel.Name = "publishTableLayoutPanel";
			this.publishTableLayoutPanel.RowCount = 15;
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishTableLayoutPanel.Size = new System.Drawing.Size(898, 624);
			this.publishTableLayoutPanel.TabIndex = 0;
			// 
			// privacyLabel
			// 
			this.privacyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.privacyLabel.AutoSize = true;
			this.privacyLabel.Location = new System.Drawing.Point(5, 13);
			this.privacyLabel.Margin = new System.Windows.Forms.Padding(0);
			this.privacyLabel.Name = "privacyLabel";
			this.privacyLabel.Size = new System.Drawing.Size(69, 13);
			this.privacyLabel.TabIndex = 11;
			this.privacyLabel.Text = "Sichtbarkeit: ";
			// 
			// publishAtCheckbox
			// 
			this.publishAtCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.publishAtCheckbox.AutoSize = true;
			this.publishTableLayoutPanel.SetColumnSpan(this.publishAtCheckbox, 3);
			this.publishAtCheckbox.Enabled = false;
			this.publishAtCheckbox.Location = new System.Drawing.Point(7, 45);
			this.publishAtCheckbox.Margin = new System.Windows.Forms.Padding(2);
			this.publishAtCheckbox.Name = "publishAtCheckbox";
			this.publishAtCheckbox.Size = new System.Drawing.Size(884, 17);
			this.publishAtCheckbox.TabIndex = 13;
			this.publishAtCheckbox.Text = "Video geplant veröffentlichen";
			this.publishAtCheckbox.UseVisualStyleBackColor = true;
			this.publishAtCheckbox.CheckedChanged += new System.EventHandler(this.publishAtCheckboxCheckedChanged);
			// 
			// privacyComboBox
			// 
			this.privacyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.privacyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.privacyComboBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.privacyComboBox.FormattingEnabled = true;
			this.privacyComboBox.Items.AddRange(new object[] {
            "Öffentlich",
            "Nicht sichtbar",
            "Privat"});
			this.privacyComboBox.Location = new System.Drawing.Point(84, 7);
			this.privacyComboBox.Margin = new System.Windows.Forms.Padding(0);
			this.privacyComboBox.Name = "privacyComboBox";
			this.privacyComboBox.Size = new System.Drawing.Size(809, 26);
			this.privacyComboBox.TabIndex = 12;
			this.privacyComboBox.SelectedIndexChanged += new System.EventHandler(this.privacyComboBoxSelectedIndexChanged);
			// 
			// publishGroupbox
			// 
			this.publishGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.publishTableLayoutPanel.SetColumnSpan(this.publishGroupbox, 3);
			this.publishGroupbox.Controls.Add(this.publishPanel);
			this.publishGroupbox.Enabled = false;
			this.publishGroupbox.Location = new System.Drawing.Point(5, 74);
			this.publishGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.publishGroupbox.Name = "publishGroupbox";
			this.publishGroupbox.Padding = new System.Windows.Forms.Padding(2);
			this.publishTableLayoutPanel.SetRowSpan(this.publishGroupbox, 9);
			this.publishGroupbox.Size = new System.Drawing.Size(888, 543);
			this.publishGroupbox.TabIndex = 14;
			this.publishGroupbox.TabStop = false;
			this.publishGroupbox.Text = "Veröffentlichungszeiten";
			// 
			// publishPanel
			// 
			this.publishPanel.AutoSize = true;
			this.publishPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.publishPanel.ColumnCount = 14;
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.publishPanel.Controls.Add(this.timesListView, 3, 1);
			this.publishPanel.Controls.Add(this.moveTimeUpButton, 1, 1);
			this.publishPanel.Controls.Add(this.moveTimeDownButton, 1, 3);
			this.publishPanel.Controls.Add(this.addOneDayButton, 1, 5);
			this.publishPanel.Controls.Add(this.substractOneDayButton, 1, 7);
			this.publishPanel.Controls.Add(this.clearTimesButton, 1, 15);
			this.publishPanel.Controls.Add(this.deleteTimeButton, 1, 13);
			this.publishPanel.Controls.Add(this.addOneWeekButton, 1, 9);
			this.publishPanel.Controls.Add(this.substractOneWeekButton, 1, 11);
			this.publishPanel.Controls.Add(this.addTimeLabel, 7, 18);
			this.publishPanel.Controls.Add(this.addTimeButton, 11, 18);
			this.publishPanel.Controls.Add(this.addWeekdayCombobox, 5, 18);
			this.publishPanel.Controls.Add(this.addTimeTimePicker, 9, 18);
			this.publishPanel.Controls.Add(this.addWeekdayLabel, 3, 18);
			this.publishPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishPanel.Location = new System.Drawing.Point(2, 15);
			this.publishPanel.Margin = new System.Windows.Forms.Padding(2);
			this.publishPanel.Name = "publishPanel";
			this.publishPanel.RowCount = 20;
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishPanel.Size = new System.Drawing.Size(884, 526);
			this.publishPanel.TabIndex = 0;
			// 
			// timesListView
			// 
			this.timesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.timesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.weekdayColumnHeader,
            this.timeColumnHeader,
            this.skipDaysHeader});
			this.publishPanel.SetColumnSpan(this.timesListView, 10);
			this.timesListView.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timesListView.FullRowSelect = true;
			this.timesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.timesListView.HideSelection = false;
			this.timesListView.Location = new System.Drawing.Point(53, 7);
			this.timesListView.Margin = new System.Windows.Forms.Padding(0);
			this.timesListView.Name = "timesListView";
			this.publishPanel.SetRowSpan(this.timesListView, 16);
			this.timesListView.ShowGroups = false;
			this.timesListView.Size = new System.Drawing.Size(826, 475);
			this.timesListView.TabIndex = 8;
			this.timesListView.UseCompatibleStateImageBehavior = false;
			this.timesListView.View = System.Windows.Forms.View.Details;
			// 
			// weekdayColumnHeader
			// 
			this.weekdayColumnHeader.Text = "Wochentag";
			this.weekdayColumnHeader.Width = 160;
			// 
			// timeColumnHeader
			// 
			this.timeColumnHeader.Text = "Zeit";
			this.timeColumnHeader.Width = 160;
			// 
			// skipDaysHeader
			// 
			this.skipDaysHeader.Text = "Tage überspringen";
			this.skipDaysHeader.Width = 190;
			// 
			// moveTimeUpButton
			// 
			this.moveTimeUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.moveTimeUpButton.AutoSize = true;
			this.moveTimeUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveTimeUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moveTimeUpButton.Location = new System.Drawing.Point(5, 7);
			this.moveTimeUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveTimeUpButton.Name = "moveTimeUpButton";
			this.moveTimeUpButton.Size = new System.Drawing.Size(43, 41);
			this.moveTimeUpButton.TabIndex = 3;
			this.moveTimeUpButton.Text = "↑";
			this.tooltip.SetToolTip(this.moveTimeUpButton, "Markierte Zeiten um eine Position nach oben verschieben");
			this.moveTimeUpButton.UseVisualStyleBackColor = true;
			this.moveTimeUpButton.Click += new System.EventHandler(this.moveTimeUpButtonClick);
			// 
			// moveTimeDownButton
			// 
			this.moveTimeDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.moveTimeDownButton.AutoSize = true;
			this.moveTimeDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveTimeDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moveTimeDownButton.Location = new System.Drawing.Point(5, 58);
			this.moveTimeDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveTimeDownButton.Name = "moveTimeDownButton";
			this.moveTimeDownButton.Size = new System.Drawing.Size(43, 41);
			this.moveTimeDownButton.TabIndex = 4;
			this.moveTimeDownButton.Text = "↓";
			this.tooltip.SetToolTip(this.moveTimeDownButton, "Markierte Zeiten um eine Position nach unten verschieben");
			this.moveTimeDownButton.UseVisualStyleBackColor = true;
			this.moveTimeDownButton.Click += new System.EventHandler(this.moveTimeDownButtonClick);
			// 
			// addOneDayButton
			// 
			this.addOneDayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.addOneDayButton.AutoSize = true;
			this.addOneDayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addOneDayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addOneDayButton.Location = new System.Drawing.Point(5, 109);
			this.addOneDayButton.Margin = new System.Windows.Forms.Padding(0);
			this.addOneDayButton.Name = "addOneDayButton";
			this.addOneDayButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.addOneDayButton.Size = new System.Drawing.Size(43, 42);
			this.addOneDayButton.TabIndex = 3;
			this.addOneDayButton.Text = "+1";
			this.tooltip.SetToolTip(this.addOneDayButton, "Nach Veröffentlichung zu markierten Zeiten einen Tag mehr vor der nächsen Veröffe" +
        "ntlichung warten");
			this.addOneDayButton.UseVisualStyleBackColor = true;
			this.addOneDayButton.Click += new System.EventHandler(this.addOneDayButtonClick);
			// 
			// substractOneDayButton
			// 
			this.substractOneDayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.substractOneDayButton.AutoSize = true;
			this.substractOneDayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.substractOneDayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.substractOneDayButton.Location = new System.Drawing.Point(5, 161);
			this.substractOneDayButton.Margin = new System.Windows.Forms.Padding(0);
			this.substractOneDayButton.Name = "substractOneDayButton";
			this.substractOneDayButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.substractOneDayButton.Size = new System.Drawing.Size(43, 42);
			this.substractOneDayButton.TabIndex = 4;
			this.substractOneDayButton.Text = "-1";
			this.tooltip.SetToolTip(this.substractOneDayButton, "Nach Veröffentlichung zu markierten Zeiten einen Tag weniger vor der nächsen Verö" +
        "ffentlichung warten");
			this.substractOneDayButton.UseVisualStyleBackColor = true;
			this.substractOneDayButton.Click += new System.EventHandler(this.substractOneDayButtonClick);
			// 
			// clearTimesButton
			// 
			this.clearTimesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.clearTimesButton.AutoSize = true;
			this.clearTimesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearTimesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearTimesButton.ForeColor = System.Drawing.Color.Red;
			this.clearTimesButton.Location = new System.Drawing.Point(5, 368);
			this.clearTimesButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearTimesButton.Name = "clearTimesButton";
			this.clearTimesButton.Size = new System.Drawing.Size(43, 41);
			this.clearTimesButton.TabIndex = 6;
			this.clearTimesButton.Text = "x";
			this.tooltip.SetToolTip(this.clearTimesButton, "Alle Zeiten löschen");
			this.clearTimesButton.UseVisualStyleBackColor = true;
			this.clearTimesButton.Click += new System.EventHandler(this.clearTimesButtonClick);
			// 
			// deleteTimeButton
			// 
			this.deleteTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteTimeButton.AutoSize = true;
			this.deleteTimeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deleteTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deleteTimeButton.ForeColor = System.Drawing.Color.Red;
			this.deleteTimeButton.Location = new System.Drawing.Point(5, 317);
			this.deleteTimeButton.Margin = new System.Windows.Forms.Padding(0);
			this.deleteTimeButton.Name = "deleteTimeButton";
			this.deleteTimeButton.Size = new System.Drawing.Size(43, 41);
			this.deleteTimeButton.TabIndex = 5;
			this.deleteTimeButton.Text = "-";
			this.tooltip.SetToolTip(this.deleteTimeButton, "Markierte Zeiten löschen");
			this.deleteTimeButton.UseVisualStyleBackColor = true;
			this.deleteTimeButton.Click += new System.EventHandler(this.deleteTimeButtonClick);
			// 
			// addOneWeekButton
			// 
			this.addOneWeekButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.addOneWeekButton.AutoSize = true;
			this.addOneWeekButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addOneWeekButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addOneWeekButton.Location = new System.Drawing.Point(5, 213);
			this.addOneWeekButton.Margin = new System.Windows.Forms.Padding(0);
			this.addOneWeekButton.Name = "addOneWeekButton";
			this.addOneWeekButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.addOneWeekButton.Size = new System.Drawing.Size(43, 42);
			this.addOneWeekButton.TabIndex = 3;
			this.addOneWeekButton.Text = "+7";
			this.tooltip.SetToolTip(this.addOneWeekButton, "Nach Veröffentlichung zu markierten Zeiten eine Woche mehr vor der nächsen Veröff" +
        "entlichung warten");
			this.addOneWeekButton.UseVisualStyleBackColor = true;
			this.addOneWeekButton.Click += new System.EventHandler(this.addOneWeekButtonClick);
			// 
			// substractOneWeekButton
			// 
			this.substractOneWeekButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.substractOneWeekButton.AutoSize = true;
			this.substractOneWeekButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.substractOneWeekButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.substractOneWeekButton.Location = new System.Drawing.Point(5, 265);
			this.substractOneWeekButton.Margin = new System.Windows.Forms.Padding(0);
			this.substractOneWeekButton.Name = "substractOneWeekButton";
			this.substractOneWeekButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.substractOneWeekButton.Size = new System.Drawing.Size(43, 42);
			this.substractOneWeekButton.TabIndex = 4;
			this.substractOneWeekButton.Text = "-7";
			this.tooltip.SetToolTip(this.substractOneWeekButton, "Nach Veröffentlichung zu markierten Zeiten eine Woche weniger vor der nächsen Ver" +
        "öffentlichung warten");
			this.substractOneWeekButton.UseVisualStyleBackColor = true;
			this.substractOneWeekButton.Click += new System.EventHandler(this.substractOneWeekButtonClick);
			// 
			// addTimeLabel
			// 
			this.addTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTimeLabel.AutoSize = true;
			this.addTimeLabel.Location = new System.Drawing.Point(250, 499);
			this.addTimeLabel.Margin = new System.Windows.Forms.Padding(0);
			this.addTimeLabel.Name = "addTimeLabel";
			this.addTimeLabel.Size = new System.Drawing.Size(31, 13);
			this.addTimeLabel.TabIndex = 10;
			this.addTimeLabel.Text = "Zeit: ";
			// 
			// addTimeButton
			// 
			this.addTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTimeButton.AutoSize = true;
			this.addTimeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addTimeButton.Location = new System.Drawing.Point(375, 492);
			this.addTimeButton.Margin = new System.Windows.Forms.Padding(0);
			this.addTimeButton.Name = "addTimeButton";
			this.addTimeButton.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
			this.addTimeButton.Size = new System.Drawing.Size(93, 27);
			this.addTimeButton.TabIndex = 11;
			this.addTimeButton.Text = "Hinzufügen";
			this.addTimeButton.UseVisualStyleBackColor = true;
			this.addTimeButton.Click += new System.EventHandler(this.addTimeButtonClick);
			// 
			// addWeekdayCombobox
			// 
			this.addWeekdayCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addWeekdayCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.addWeekdayCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addWeekdayCombobox.FormattingEnabled = true;
			this.addWeekdayCombobox.Items.AddRange(new object[] {
            "Täglich",
            "Montag",
            "Dienstag",
            "Mittwoch",
            "Donnerstag",
            "Freitag",
            "Samstag",
            "Sonntag"});
			this.addWeekdayCombobox.Location = new System.Drawing.Point(132, 492);
			this.addWeekdayCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.addWeekdayCombobox.Name = "addWeekdayCombobox";
			this.addWeekdayCombobox.Size = new System.Drawing.Size(108, 26);
			this.addWeekdayCombobox.TabIndex = 12;
			// 
			// addTimeTimePicker
			// 
			this.addTimeTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTimeTimePicker.CustomFormat = "HH:mm";
			this.addTimeTimePicker.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addTimeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.addTimeTimePicker.Location = new System.Drawing.Point(291, 492);
			this.addTimeTimePicker.Margin = new System.Windows.Forms.Padding(0);
			this.addTimeTimePicker.Name = "addTimeTimePicker";
			this.addTimeTimePicker.ShowUpDown = true;
			this.addTimeTimePicker.Size = new System.Drawing.Size(74, 26);
			this.addTimeTimePicker.TabIndex = 13;
			this.addTimeTimePicker.Value = new System.DateTime(2018, 1, 13, 15, 0, 0, 0);
			// 
			// addWeekdayLabel
			// 
			this.addWeekdayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addWeekdayLabel.AutoSize = true;
			this.addWeekdayLabel.Location = new System.Drawing.Point(53, 499);
			this.addWeekdayLabel.Margin = new System.Windows.Forms.Padding(0);
			this.addWeekdayLabel.Name = "addWeekdayLabel";
			this.addWeekdayLabel.Size = new System.Drawing.Size(69, 13);
			this.addWeekdayLabel.TabIndex = 9;
			this.addWeekdayLabel.Text = "Wochentag: ";
			// 
			// otherTabPage
			// 
			this.otherTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.otherTabPage.Controls.Add(this.otherTlp);
			this.otherTabPage.Location = new System.Drawing.Point(4, 22);
			this.otherTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.otherTabPage.Name = "otherTabPage";
			this.otherTabPage.Size = new System.Drawing.Size(902, 628);
			this.otherTabPage.TabIndex = 2;
			this.otherTabPage.Text = "Sonstiges";
			// 
			// otherTlp
			// 
			this.otherTlp.ColumnCount = 7;
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.otherTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.Controls.Add(this.categoryLabel, 1, 1);
			this.otherTlp.Controls.Add(this.defaultLanguageLabel, 1, 3);
			this.otherTlp.Controls.Add(this.licenseLabel, 1, 5);
			this.otherTlp.Controls.Add(this.isEmbeddableCheckbox, 1, 7);
			this.otherTlp.Controls.Add(this.publicStatsViewableCheckbox, 1, 9);
			this.otherTlp.Controls.Add(this.categoryCombobox, 3, 1);
			this.otherTlp.Controls.Add(this.defaultLanguageCombobox, 3, 3);
			this.otherTlp.Controls.Add(this.licenseCombobox, 3, 5);
			this.otherTlp.Controls.Add(this.thumbnailLabel, 1, 11);
			this.otherTlp.Controls.Add(this.thumbnailTextbox, 3, 11);
			this.otherTlp.Controls.Add(this.chooseThumbnailPathButton, 5, 11);
			this.otherTlp.Controls.Add(this.notifySubscribersCheckbox, 1, 13);
			this.otherTlp.Controls.Add(this.autoLevelsCheckbox, 1, 15);
			this.otherTlp.Controls.Add(this.stabilizeCheckbox, 1, 17);
			this.otherTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.otherTlp.Location = new System.Drawing.Point(0, 0);
			this.otherTlp.Margin = new System.Windows.Forms.Padding(0);
			this.otherTlp.Name = "otherTlp";
			this.otherTlp.RowCount = 19;
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.otherTlp.Size = new System.Drawing.Size(902, 628);
			this.otherTlp.TabIndex = 0;
			// 
			// categoryLabel
			// 
			this.categoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.Location = new System.Drawing.Point(10, 16);
			this.categoryLabel.Margin = new System.Windows.Forms.Padding(0);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(158, 13);
			this.categoryLabel.TabIndex = 0;
			this.categoryLabel.Text = "Kategorie: ";
			// 
			// defaultLanguageLabel
			// 
			this.defaultLanguageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.defaultLanguageLabel.AutoSize = true;
			this.defaultLanguageLabel.Location = new System.Drawing.Point(10, 52);
			this.defaultLanguageLabel.Margin = new System.Windows.Forms.Padding(0);
			this.defaultLanguageLabel.Name = "defaultLanguageLabel";
			this.defaultLanguageLabel.Size = new System.Drawing.Size(158, 13);
			this.defaultLanguageLabel.TabIndex = 1;
			this.defaultLanguageLabel.Text = "Videosprache: ";
			// 
			// licenseLabel
			// 
			this.licenseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.licenseLabel.AutoSize = true;
			this.licenseLabel.Location = new System.Drawing.Point(10, 88);
			this.licenseLabel.Margin = new System.Windows.Forms.Padding(0);
			this.licenseLabel.Name = "licenseLabel";
			this.licenseLabel.Size = new System.Drawing.Size(158, 13);
			this.licenseLabel.TabIndex = 2;
			this.licenseLabel.Text = "Lizenzen und Eigentumsrechte: ";
			// 
			// isEmbeddableCheckbox
			// 
			this.isEmbeddableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.isEmbeddableCheckbox.AutoSize = true;
			this.otherTlp.SetColumnSpan(this.isEmbeddableCheckbox, 5);
			this.isEmbeddableCheckbox.Location = new System.Drawing.Point(10, 118);
			this.isEmbeddableCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.isEmbeddableCheckbox.Name = "isEmbeddableCheckbox";
			this.isEmbeddableCheckbox.Size = new System.Drawing.Size(882, 17);
			this.isEmbeddableCheckbox.TabIndex = 3;
			this.isEmbeddableCheckbox.Text = "Einbetten zulassen";
			this.isEmbeddableCheckbox.UseVisualStyleBackColor = true;
			this.isEmbeddableCheckbox.CheckedChanged += new System.EventHandler(this.isEmbeddableCheckboxCheckedChanged);
			// 
			// publicStatsViewableCheckbox
			// 
			this.publicStatsViewableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.publicStatsViewableCheckbox.AutoSize = true;
			this.otherTlp.SetColumnSpan(this.publicStatsViewableCheckbox, 5);
			this.publicStatsViewableCheckbox.Location = new System.Drawing.Point(10, 145);
			this.publicStatsViewableCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.publicStatsViewableCheckbox.Name = "publicStatsViewableCheckbox";
			this.publicStatsViewableCheckbox.Size = new System.Drawing.Size(882, 17);
			this.publicStatsViewableCheckbox.TabIndex = 4;
			this.publicStatsViewableCheckbox.Text = "Videostatistik auf der Wiedergabeseite öffentlich sichtbar machen";
			this.publicStatsViewableCheckbox.UseVisualStyleBackColor = true;
			this.publicStatsViewableCheckbox.CheckedChanged += new System.EventHandler(this.publicStatsViewableCheckboxCheckedChanged);
			// 
			// categoryCombobox
			// 
			this.categoryCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.otherTlp.SetColumnSpan(this.categoryCombobox, 3);
			this.categoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.categoryCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.categoryCombobox.FormattingEnabled = true;
			this.categoryCombobox.Location = new System.Drawing.Point(178, 10);
			this.categoryCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.categoryCombobox.Name = "categoryCombobox";
			this.categoryCombobox.Size = new System.Drawing.Size(714, 26);
			this.categoryCombobox.TabIndex = 5;
			this.categoryCombobox.SelectedIndexChanged += new System.EventHandler(this.categoryComboboxSelectedIndexChanged);
			// 
			// defaultLanguageCombobox
			// 
			this.defaultLanguageCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.otherTlp.SetColumnSpan(this.defaultLanguageCombobox, 3);
			this.defaultLanguageCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.defaultLanguageCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.defaultLanguageCombobox.FormattingEnabled = true;
			this.defaultLanguageCombobox.Location = new System.Drawing.Point(178, 46);
			this.defaultLanguageCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.defaultLanguageCombobox.Name = "defaultLanguageCombobox";
			this.defaultLanguageCombobox.Size = new System.Drawing.Size(714, 26);
			this.defaultLanguageCombobox.TabIndex = 6;
			this.defaultLanguageCombobox.SelectedIndexChanged += new System.EventHandler(this.defaultLanguageComboboxSelectedIndexChanged);
			// 
			// licenseCombobox
			// 
			this.licenseCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.otherTlp.SetColumnSpan(this.licenseCombobox, 3);
			this.licenseCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.licenseCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.licenseCombobox.FormattingEnabled = true;
			this.licenseCombobox.Items.AddRange(new object[] {
            "Standard-Youtube-Lizenz",
            "Creative-Commons - Namensnennung"});
			this.licenseCombobox.Location = new System.Drawing.Point(178, 82);
			this.licenseCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.licenseCombobox.Name = "licenseCombobox";
			this.licenseCombobox.Size = new System.Drawing.Size(714, 26);
			this.licenseCombobox.TabIndex = 7;
			this.licenseCombobox.SelectedIndexChanged += new System.EventHandler(this.licenseComboboxSelectedIndexChanged);
			// 
			// thumbnailLabel
			// 
			this.thumbnailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailLabel.AutoSize = true;
			this.thumbnailLabel.Location = new System.Drawing.Point(10, 178);
			this.thumbnailLabel.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailLabel.Name = "thumbnailLabel";
			this.thumbnailLabel.Size = new System.Drawing.Size(158, 13);
			this.thumbnailLabel.TabIndex = 8;
			this.thumbnailLabel.Text = "Thumbnail: ";
			// 
			// thumbnailTextbox
			// 
			this.thumbnailTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailTextbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.thumbnailTextbox.AutoScrollMinSize = new System.Drawing.Size(2, 18);
			this.thumbnailTextbox.BackBrush = null;
			this.thumbnailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.thumbnailTextbox.CharHeight = 18;
			this.thumbnailTextbox.CharWidth = 10;
			this.thumbnailTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.thumbnailTextbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.thumbnailTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.thumbnailTextbox.IsReplaceMode = false;
			this.thumbnailTextbox.Location = new System.Drawing.Point(178, 172);
			this.thumbnailTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailTextbox.Multiline = false;
			this.thumbnailTextbox.Name = "thumbnailTextbox";
			this.thumbnailTextbox.Paddings = new System.Windows.Forms.Padding(0);
			this.thumbnailTextbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.thumbnailTextbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("thumbnailTextbox.ServiceColors")));
			this.thumbnailTextbox.ShowLineNumbers = false;
			this.thumbnailTextbox.ShowScrollBars = false;
			this.thumbnailTextbox.Size = new System.Drawing.Size(683, 26);
			this.thumbnailTextbox.TabIndex = 9;
			this.thumbnailTextbox.Zoom = 100;
			this.thumbnailTextbox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.thumbnailTextboxTextChanged);
			// 
			// chooseThumbnailPathButton
			// 
			this.chooseThumbnailPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseThumbnailPathButton.AutoSize = true;
			this.chooseThumbnailPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.chooseThumbnailPathButton.Location = new System.Drawing.Point(866, 172);
			this.chooseThumbnailPathButton.Margin = new System.Windows.Forms.Padding(0);
			this.chooseThumbnailPathButton.Name = "chooseThumbnailPathButton";
			this.chooseThumbnailPathButton.Size = new System.Drawing.Size(26, 26);
			this.chooseThumbnailPathButton.TabIndex = 10;
			this.chooseThumbnailPathButton.Text = "...";
			this.chooseThumbnailPathButton.UseVisualStyleBackColor = true;
			this.chooseThumbnailPathButton.Click += new System.EventHandler(this.chooseThumbnailPathButtonClick);
			// 
			// notifySubscribersCheckbox
			// 
			this.notifySubscribersCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.notifySubscribersCheckbox.AutoSize = true;
			this.otherTlp.SetColumnSpan(this.notifySubscribersCheckbox, 5);
			this.notifySubscribersCheckbox.Location = new System.Drawing.Point(10, 208);
			this.notifySubscribersCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.notifySubscribersCheckbox.Name = "notifySubscribersCheckbox";
			this.notifySubscribersCheckbox.Size = new System.Drawing.Size(882, 17);
			this.notifySubscribersCheckbox.TabIndex = 3;
			this.notifySubscribersCheckbox.Text = "Im Abofeed veröffentlichen und Abonnenten benachrichtigen";
			this.notifySubscribersCheckbox.UseVisualStyleBackColor = true;
			this.notifySubscribersCheckbox.CheckedChanged += new System.EventHandler(this.notifySubscribersCheckboxCheckedChanged);
			// 
			// autoLevelsCheckbox
			// 
			this.autoLevelsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.autoLevelsCheckbox.AutoSize = true;
			this.otherTlp.SetColumnSpan(this.autoLevelsCheckbox, 5);
			this.autoLevelsCheckbox.Location = new System.Drawing.Point(10, 235);
			this.autoLevelsCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.autoLevelsCheckbox.Name = "autoLevelsCheckbox";
			this.autoLevelsCheckbox.Size = new System.Drawing.Size(882, 17);
			this.autoLevelsCheckbox.TabIndex = 3;
			this.autoLevelsCheckbox.Text = "Helligkeit und Farben automatisch von Youtube verbessern lassen";
			this.autoLevelsCheckbox.UseVisualStyleBackColor = true;
			this.autoLevelsCheckbox.CheckedChanged += new System.EventHandler(this.autoLevelsCheckboxCheckedChanged);
			// 
			// stabilizeCheckbox
			// 
			this.stabilizeCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.stabilizeCheckbox.AutoSize = true;
			this.otherTlp.SetColumnSpan(this.stabilizeCheckbox, 5);
			this.stabilizeCheckbox.Location = new System.Drawing.Point(10, 262);
			this.stabilizeCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.stabilizeCheckbox.Name = "stabilizeCheckbox";
			this.stabilizeCheckbox.Size = new System.Drawing.Size(882, 17);
			this.stabilizeCheckbox.TabIndex = 3;
			this.stabilizeCheckbox.Text = "Bildstabilisierung automatisch von Youtube durchführen lassen";
			this.stabilizeCheckbox.UseVisualStyleBackColor = true;
			this.stabilizeCheckbox.CheckedChanged += new System.EventHandler(this.stabilizeCheckboxCheckedChanged);
			// 
			// planVideosTabpage
			// 
			this.planVideosTabpage.BackColor = System.Drawing.SystemColors.Control;
			this.planVideosTabpage.Controls.Add(this.planVideosTlp);
			this.planVideosTabpage.Location = new System.Drawing.Point(4, 22);
			this.planVideosTabpage.Margin = new System.Windows.Forms.Padding(2);
			this.planVideosTabpage.Name = "planVideosTabpage";
			this.planVideosTabpage.Padding = new System.Windows.Forms.Padding(2);
			this.planVideosTabpage.Size = new System.Drawing.Size(902, 628);
			this.planVideosTabpage.TabIndex = 3;
			this.planVideosTabpage.Text = "Videos planen";
			// 
			// planVideosTlp
			// 
			this.planVideosTlp.ColumnCount = 5;
			this.planVideosTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.planVideosTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.planVideosTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.Controls.Add(this.addFilenameButton, 1, 3);
			this.planVideosTlp.Controls.Add(this.removeFilenameButton, 1, 5);
			this.planVideosTlp.Controls.Add(this.clearFilenamesButton, 1, 7);
			this.planVideosTlp.Controls.Add(this.filenamesListView, 3, 3);
			this.planVideosTlp.Controls.Add(this.filenamesLabel, 1, 1);
			this.planVideosTlp.Controls.Add(this.groupBox1, 1, 10);
			this.planVideosTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.planVideosTlp.Location = new System.Drawing.Point(2, 2);
			this.planVideosTlp.Margin = new System.Windows.Forms.Padding(0);
			this.planVideosTlp.Name = "planVideosTlp";
			this.planVideosTlp.RowCount = 12;
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.36735F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.63265F));
			this.planVideosTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.planVideosTlp.Size = new System.Drawing.Size(898, 624);
			this.planVideosTlp.TabIndex = 0;
			// 
			// addFilenameButton
			// 
			this.addFilenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addFilenameButton.AutoSize = true;
			this.addFilenameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addFilenameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addFilenameButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addFilenameButton.Location = new System.Drawing.Point(10, 28);
			this.addFilenameButton.Margin = new System.Windows.Forms.Padding(0);
			this.addFilenameButton.Name = "addFilenameButton";
			this.addFilenameButton.Size = new System.Drawing.Size(41, 41);
			this.addFilenameButton.TabIndex = 2;
			this.addFilenameButton.Text = "+";
			this.addFilenameButton.UseVisualStyleBackColor = true;
			// 
			// removeFilenameButton
			// 
			this.removeFilenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.removeFilenameButton.AutoSize = true;
			this.removeFilenameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.removeFilenameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.removeFilenameButton.ForeColor = System.Drawing.Color.Red;
			this.removeFilenameButton.Location = new System.Drawing.Point(10, 79);
			this.removeFilenameButton.Margin = new System.Windows.Forms.Padding(0);
			this.removeFilenameButton.Name = "removeFilenameButton";
			this.removeFilenameButton.Size = new System.Drawing.Size(41, 41);
			this.removeFilenameButton.TabIndex = 5;
			this.removeFilenameButton.Text = "-";
			this.removeFilenameButton.UseVisualStyleBackColor = true;
			// 
			// clearFilenamesButton
			// 
			this.clearFilenamesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.clearFilenamesButton.AutoSize = true;
			this.clearFilenamesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearFilenamesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearFilenamesButton.ForeColor = System.Drawing.Color.Red;
			this.clearFilenamesButton.Location = new System.Drawing.Point(10, 130);
			this.clearFilenamesButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearFilenamesButton.Name = "clearFilenamesButton";
			this.clearFilenamesButton.Size = new System.Drawing.Size(41, 41);
			this.clearFilenamesButton.TabIndex = 6;
			this.clearFilenamesButton.Text = "x";
			this.clearFilenamesButton.UseVisualStyleBackColor = true;
			// 
			// filenamesListView
			// 
			this.filenamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filenamesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.varNameColumnHeader,
            this.varContentColumnHeader});
			this.filenamesListView.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filenamesListView.FullRowSelect = true;
			this.filenamesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.filenamesListView.HideSelection = false;
			this.filenamesListView.Location = new System.Drawing.Point(61, 28);
			this.filenamesListView.Margin = new System.Windows.Forms.Padding(0);
			this.filenamesListView.Name = "filenamesListView";
			this.planVideosTlp.SetRowSpan(this.filenamesListView, 6);
			this.filenamesListView.ShowGroups = false;
			this.filenamesListView.Size = new System.Drawing.Size(827, 222);
			this.filenamesListView.TabIndex = 9;
			this.filenamesListView.UseCompatibleStateImageBehavior = false;
			this.filenamesListView.View = System.Windows.Forms.View.Details;
			// 
			// varNameColumnHeader
			// 
			this.varNameColumnHeader.Text = "Dateiname";
			this.varNameColumnHeader.Width = 400;
			// 
			// varContentColumnHeader
			// 
			this.varContentColumnHeader.Text = "Alle Felder ausgefüllt";
			this.varContentColumnHeader.Width = 250;
			// 
			// filenamesLabel
			// 
			this.filenamesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenamesLabel.AutoSize = true;
			this.planVideosTlp.SetColumnSpan(this.filenamesLabel, 3);
			this.filenamesLabel.Location = new System.Drawing.Point(13, 10);
			this.filenamesLabel.Name = "filenamesLabel";
			this.filenamesLabel.Size = new System.Drawing.Size(872, 13);
			this.filenamesLabel.TabIndex = 12;
			this.filenamesLabel.Text = "Dateien:";
			// 
			// groupBox1
			// 
			this.planVideosTlp.SetColumnSpan(this.groupBox1, 3);
			this.groupBox1.Controls.Add(this.fillFieldsTlp);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(10, 260);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(878, 353);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Felder ausfüllen: ";
			// 
			// fillFieldsTlp
			// 
			this.fillFieldsTlp.ColumnCount = 5;
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.Controls.Add(this.listView1, 1, 1);
			this.fillFieldsTlp.Controls.Add(this.filenameFieldLabel, 1, 3);
			this.fillFieldsTlp.Controls.Add(this.filenameValueLabel, 1, 5);
			this.fillFieldsTlp.Controls.Add(this.filenameFieldTxbx, 3, 3);
			this.fillFieldsTlp.Controls.Add(this.filenameValueTxbx, 3, 5);
			this.fillFieldsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fillFieldsTlp.Location = new System.Drawing.Point(3, 16);
			this.fillFieldsTlp.Name = "fillFieldsTlp";
			this.fillFieldsTlp.RowCount = 7;
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fillFieldsTlp.Size = new System.Drawing.Size(872, 334);
			this.fillFieldsTlp.TabIndex = 0;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.fillFieldsTlp.SetColumnSpan(this.listView1, 3);
			this.listView1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(10, 10);
			this.listView1.Margin = new System.Windows.Forms.Padding(0);
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.Size = new System.Drawing.Size(852, 181);
			this.listView1.TabIndex = 9;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Feld";
			this.columnHeader1.Width = 250;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Wert";
			this.columnHeader2.Width = 400;
			// 
			// filenameFieldLabel
			// 
			this.filenameFieldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenameFieldLabel.AutoSize = true;
			this.filenameFieldLabel.Location = new System.Drawing.Point(10, 207);
			this.filenameFieldLabel.Margin = new System.Windows.Forms.Padding(0);
			this.filenameFieldLabel.Name = "filenameFieldLabel";
			this.filenameFieldLabel.Size = new System.Drawing.Size(33, 13);
			this.filenameFieldLabel.TabIndex = 10;
			this.filenameFieldLabel.Text = "Feld:";
			// 
			// filenameValueLabel
			// 
			this.filenameValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenameValueLabel.AutoSize = true;
			this.filenameValueLabel.Location = new System.Drawing.Point(10, 243);
			this.filenameValueLabel.Margin = new System.Windows.Forms.Padding(0);
			this.filenameValueLabel.Name = "filenameValueLabel";
			this.filenameValueLabel.Size = new System.Drawing.Size(33, 13);
			this.filenameValueLabel.TabIndex = 10;
			this.filenameValueLabel.Text = "Wert:";
			// 
			// filenameFieldTxbx
			// 
			this.filenameFieldTxbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenameFieldTxbx.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filenameFieldTxbx.Location = new System.Drawing.Point(53, 201);
			this.filenameFieldTxbx.Margin = new System.Windows.Forms.Padding(0);
			this.filenameFieldTxbx.Name = "filenameFieldTxbx";
			this.filenameFieldTxbx.ReadOnly = true;
			this.filenameFieldTxbx.Size = new System.Drawing.Size(809, 26);
			this.filenameFieldTxbx.TabIndex = 11;
			// 
			// filenameValueTxbx
			// 
			this.filenameValueTxbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenameValueTxbx.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filenameValueTxbx.Location = new System.Drawing.Point(53, 237);
			this.filenameValueTxbx.Margin = new System.Windows.Forms.Padding(0);
			this.filenameValueTxbx.Name = "filenameValueTxbx";
			this.filenameValueTxbx.Size = new System.Drawing.Size(809, 26);
			this.filenameValueTxbx.TabIndex = 11;
			// 
			// cSharpTabPage
			// 
			this.cSharpTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.cSharpTabPage.Controls.Add(this.csTlp);
			this.cSharpTabPage.Location = new System.Drawing.Point(4, 22);
			this.cSharpTabPage.Name = "cSharpTabPage";
			this.cSharpTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cSharpTabPage.Size = new System.Drawing.Size(902, 628);
			this.cSharpTabPage.TabIndex = 4;
			this.cSharpTabPage.Text = "C#-Scripting";
			// 
			// csTlp
			// 
			this.csTlp.ColumnCount = 3;
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.Controls.Add(this.cSharpCleanupFctb, 1, 7);
			this.csTlp.Controls.Add(this.cSharpPrepareFctb, 1, 4);
			this.csTlp.Controls.Add(this.csDescriptionTxbx, 1, 1);
			this.csTlp.Controls.Add(this.globalPrepareScriptLabel, 1, 3);
			this.csTlp.Controls.Add(this.globalAfterScriptsLabel, 1, 6);
			this.csTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csTlp.Location = new System.Drawing.Point(3, 3);
			this.csTlp.Name = "csTlp";
			this.csTlp.RowCount = 9;
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.Size = new System.Drawing.Size(896, 622);
			this.csTlp.TabIndex = 0;
			// 
			// cSharpCleanupFctb
			// 
			this.cSharpCleanupFctb.AutoCompleteBrackets = true;
			this.cSharpCleanupFctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.cSharpCleanupFctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.cSharpCleanupFctb.AutoScrollMinSize = new System.Drawing.Size(0, 18);
			this.cSharpCleanupFctb.BackBrush = null;
			this.cSharpCleanupFctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cSharpCleanupFctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.cSharpCleanupFctb.CharHeight = 18;
			this.cSharpCleanupFctb.CharWidth = 10;
			this.cSharpCleanupFctb.CurrentLineColor = System.Drawing.Color.LightGray;
			this.cSharpCleanupFctb.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.cSharpCleanupFctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.cSharpCleanupFctb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cSharpCleanupFctb.Font = new System.Drawing.Font("Courier New", 12F);
			this.cSharpCleanupFctb.IsReplaceMode = false;
			this.cSharpCleanupFctb.Language = FastColoredTextBoxNS.Language.CSharp;
			this.cSharpCleanupFctb.LeftBracket = '(';
			this.cSharpCleanupFctb.LeftBracket2 = '{';
			this.cSharpCleanupFctb.Location = new System.Drawing.Point(10, 379);
			this.cSharpCleanupFctb.Margin = new System.Windows.Forms.Padding(0);
			this.cSharpCleanupFctb.Name = "cSharpCleanupFctb";
			this.cSharpCleanupFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.cSharpCleanupFctb.RightBracket = ')';
			this.cSharpCleanupFctb.RightBracket2 = '}';
			this.cSharpCleanupFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.cSharpCleanupFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpCleanupFctb.ServiceColors")));
			this.cSharpCleanupFctb.Size = new System.Drawing.Size(876, 231);
			this.cSharpCleanupFctb.TabIndex = 14;
			this.cSharpCleanupFctb.WordWrap = true;
			this.cSharpCleanupFctb.WordWrapIndent = 6;
			this.cSharpCleanupFctb.Zoom = 100;
			this.cSharpCleanupFctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.cSharpCleanupFctbTextChanged);
			// 
			// cSharpPrepareFctb
			// 
			this.cSharpPrepareFctb.AutoCompleteBrackets = true;
			this.cSharpPrepareFctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.cSharpPrepareFctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.cSharpPrepareFctb.AutoScrollMinSize = new System.Drawing.Size(0, 18);
			this.cSharpPrepareFctb.BackBrush = null;
			this.cSharpPrepareFctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cSharpPrepareFctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.cSharpPrepareFctb.CharHeight = 18;
			this.cSharpPrepareFctb.CharWidth = 10;
			this.cSharpPrepareFctb.CurrentLineColor = System.Drawing.Color.LightGray;
			this.cSharpPrepareFctb.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.cSharpPrepareFctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.cSharpPrepareFctb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cSharpPrepareFctb.Font = new System.Drawing.Font("Courier New", 12F);
			this.cSharpPrepareFctb.IsReplaceMode = false;
			this.cSharpPrepareFctb.Language = FastColoredTextBoxNS.Language.CSharp;
			this.cSharpPrepareFctb.LeftBracket = '(';
			this.cSharpPrepareFctb.LeftBracket2 = '{';
			this.cSharpPrepareFctb.Location = new System.Drawing.Point(10, 125);
			this.cSharpPrepareFctb.Margin = new System.Windows.Forms.Padding(0);
			this.cSharpPrepareFctb.Name = "cSharpPrepareFctb";
			this.cSharpPrepareFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.cSharpPrepareFctb.RightBracket = ')';
			this.cSharpPrepareFctb.RightBracket2 = '}';
			this.cSharpPrepareFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.cSharpPrepareFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpPrepareFctb.ServiceColors")));
			this.cSharpPrepareFctb.Size = new System.Drawing.Size(876, 231);
			this.cSharpPrepareFctb.TabIndex = 13;
			this.cSharpPrepareFctb.WordWrap = true;
			this.cSharpPrepareFctb.WordWrapIndent = 6;
			this.cSharpPrepareFctb.Zoom = 100;
			this.cSharpPrepareFctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.cSharpPrepareFctbTextChanged);
			// 
			// csDescriptionTxbx
			// 
			this.csDescriptionTxbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.csDescriptionTxbx.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.csDescriptionTxbx.Location = new System.Drawing.Point(10, 10);
			this.csDescriptionTxbx.Margin = new System.Windows.Forms.Padding(0);
			this.csDescriptionTxbx.Multiline = true;
			this.csDescriptionTxbx.Name = "csDescriptionTxbx";
			this.csDescriptionTxbx.ReadOnly = true;
			this.csDescriptionTxbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.csDescriptionTxbx.Size = new System.Drawing.Size(876, 92);
			this.csDescriptionTxbx.TabIndex = 12;
			this.csDescriptionTxbx.TabStop = false;
			this.csDescriptionTxbx.Text = resources.GetString("csDescriptionTxbx.Text");
			// 
			// globalPrepareScriptLabel
			// 
			this.globalPrepareScriptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.globalPrepareScriptLabel.AutoSize = true;
			this.globalPrepareScriptLabel.Location = new System.Drawing.Point(10, 112);
			this.globalPrepareScriptLabel.Margin = new System.Windows.Forms.Padding(0);
			this.globalPrepareScriptLabel.Name = "globalPrepareScriptLabel";
			this.globalPrepareScriptLabel.Size = new System.Drawing.Size(876, 13);
			this.globalPrepareScriptLabel.TabIndex = 15;
			this.globalPrepareScriptLabel.Text = "Globales Vorbereitungsskript:";
			// 
			// globalAfterScriptsLabel
			// 
			this.globalAfterScriptsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.globalAfterScriptsLabel.AutoSize = true;
			this.globalAfterScriptsLabel.Location = new System.Drawing.Point(10, 366);
			this.globalAfterScriptsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.globalAfterScriptsLabel.Name = "globalAfterScriptsLabel";
			this.globalAfterScriptsLabel.Size = new System.Drawing.Size(876, 13);
			this.globalAfterScriptsLabel.TabIndex = 15;
			this.globalAfterScriptsLabel.Text = "Globales Nachbereitungsskript:";
			// 
			// editTemplateLabel
			// 
			this.editTemplateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.editTemplateLabel.AutoSize = true;
			this.editTemplateTableLayoutPanel.SetColumnSpan(this.editTemplateLabel, 6);
			this.editTemplateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editTemplateLabel.Location = new System.Drawing.Point(10, 10);
			this.editTemplateLabel.Margin = new System.Windows.Forms.Padding(0);
			this.editTemplateLabel.Name = "editTemplateLabel";
			this.editTemplateLabel.Size = new System.Drawing.Size(910, 13);
			this.editTemplateLabel.TabIndex = 0;
			this.editTemplateLabel.Text = "Template bearbeiten: ";
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
			this.splitContainer.Panel1.Controls.Add(this.templateOverviewTableLayouPanel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.editTemplateTableLayoutPanel);
			this.splitContainer.Size = new System.Drawing.Size(1205, 770);
			this.splitContainer.SplitterDistance = 264;
			this.splitContainer.SplitterWidth = 11;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerPaint);
			// 
			// openThumbnailDialog
			// 
			this.openThumbnailDialog.CheckFileExists = false;
			this.openThumbnailDialog.CheckPathExists = false;
			this.openThumbnailDialog.Filter = "Alle unterstützten Dateitypen|*.jpg;*.jpeg;*.png|JPEG-Dateien|*.jpg;*.jpeg|PNG-Da" +
    "teien|*.png";
			this.openThumbnailDialog.Title = "Bitte wähle das entsprechende Thumbnail aus...";
			// 
			// TemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1205, 770);
			this.Controls.Add(this.splitContainer);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "TemplateForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Templates bearbeiten";
			this.Load += new System.EventHandler(this.TemplateFormLoad);
			this.templateOverviewTableLayouPanel.ResumeLayout(false);
			this.templateOverviewTableLayouPanel.PerformLayout();
			this.editTemplateTableLayoutPanel.ResumeLayout(false);
			this.editTemplateTableLayoutPanel.PerformLayout();
			this.templateValuesTabControl.ResumeLayout(false);
			this.commonTabPage.ResumeLayout(false);
			this.templateCommonTableLayoutPannel.ResumeLayout(false);
			this.templateCommonTableLayoutPannel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.templateTitleTextbox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateDescriptionTextbox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateTagsTextbox)).EndInit();
			this.publishTabPage.ResumeLayout(false);
			this.publishTableLayoutPanel.ResumeLayout(false);
			this.publishTableLayoutPanel.PerformLayout();
			this.publishGroupbox.ResumeLayout(false);
			this.publishGroupbox.PerformLayout();
			this.publishPanel.ResumeLayout(false);
			this.publishPanel.PerformLayout();
			this.otherTabPage.ResumeLayout(false);
			this.otherTlp.ResumeLayout(false);
			this.otherTlp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumbnailTextbox)).EndInit();
			this.planVideosTabpage.ResumeLayout(false);
			this.planVideosTlp.ResumeLayout(false);
			this.planVideosTlp.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.fillFieldsTlp.ResumeLayout(false);
			this.fillFieldsTlp.PerformLayout();
			this.cSharpTabPage.ResumeLayout(false);
			this.csTlp.ResumeLayout(false);
			this.csTlp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cSharpCleanupFctb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSharpPrepareFctb)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel templateOverviewTableLayouPanel;
		private System.Windows.Forms.Button addTemplateButton;
		private System.Windows.Forms.Button moveTemplateUpButton;
		private System.Windows.Forms.Button moveTemplateDownButton;
		private System.Windows.Forms.Button deleteTemplateButton;
		private System.Windows.Forms.Button clearTemplatesButton;
		private System.Windows.Forms.TableLayoutPanel editTemplateTableLayoutPanel;
		private System.Windows.Forms.Label templateNameLabel;
		private System.Windows.Forms.TextBox templateNameTextbox;
		private System.Windows.Forms.Button saveTemplateButton;
		private System.Windows.Forms.Button resetTemplateButton;
		private System.Windows.Forms.TabControl templateValuesTabControl;
		private System.Windows.Forms.TabPage commonTabPage;
		private System.Windows.Forms.TabPage publishTabPage;
		private System.Windows.Forms.ListView templateListView;
		private System.Windows.Forms.ColumnHeader templatesColumnHeader;
		private System.Windows.Forms.TabPage otherTabPage;
		private System.Windows.Forms.Label editTemplateLabel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.TableLayoutPanel templateCommonTableLayoutPannel;
		private System.Windows.Forms.Label templateTitleLabel;
		private System.Windows.Forms.Label templateDescriptionLabel;
		private System.Windows.Forms.Label templateTagsLabel;
		private FastColoredTextBoxNS.FastColoredTextBox templateTitleTextbox;
		private FastColoredTextBox templateDescriptionTextbox;
		private FastColoredTextBoxNS.FastColoredTextBox templateTagsTextbox;
		private System.Windows.Forms.TableLayoutPanel publishTableLayoutPanel;
		private System.Windows.Forms.ListView timesListView;
		private System.Windows.Forms.ColumnHeader weekdayColumnHeader;
		private System.Windows.Forms.Label privacyLabel;
		private System.Windows.Forms.CheckBox publishAtCheckbox;
		private System.Windows.Forms.GroupBox publishGroupbox;
		private System.Windows.Forms.TableLayoutPanel publishPanel;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.ComboBox privacyComboBox;
		private System.Windows.Forms.Button moveTimeUpButton;
		private System.Windows.Forms.Button moveTimeDownButton;
		private System.Windows.Forms.Button deleteTimeButton;
		private System.Windows.Forms.Button clearTimesButton;
		private System.Windows.Forms.ColumnHeader timeColumnHeader;
		private System.Windows.Forms.ColumnHeader skipDaysHeader;
		private System.Windows.Forms.Button addOneDayButton;
		private System.Windows.Forms.Button substractOneDayButton;
		private System.Windows.Forms.Button addOneWeekButton;
		private System.Windows.Forms.Button substractOneWeekButton;
		private System.Windows.Forms.Label addWeekdayLabel;
		private System.Windows.Forms.Label addTimeLabel;
		private System.Windows.Forms.Button addTimeButton;
		private System.Windows.Forms.ComboBox addWeekdayCombobox;
		private System.Windows.Forms.DateTimePicker addTimeTimePicker;
		private System.Windows.Forms.Label maxTitleLengthLabel;
		private System.Windows.Forms.Label maxDescriptionLengthLabel;
		private System.Windows.Forms.Label maxTagsLengthLabel;
		private System.Windows.Forms.TableLayoutPanel otherTlp;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.Label defaultLanguageLabel;
		private System.Windows.Forms.Label licenseLabel;
		private System.Windows.Forms.CheckBox isEmbeddableCheckbox;
		private System.Windows.Forms.CheckBox publicStatsViewableCheckbox;
		private System.Windows.Forms.ComboBox categoryCombobox;
		private System.Windows.Forms.ComboBox defaultLanguageCombobox;
		private System.Windows.Forms.ComboBox licenseCombobox;
		private System.Windows.Forms.Label thumbnailLabel;
		private FastColoredTextBoxNS.FastColoredTextBox thumbnailTextbox;
		private System.Windows.Forms.Button chooseThumbnailPathButton;
		private System.Windows.Forms.CheckBox notifySubscribersCheckbox;
		private System.Windows.Forms.CheckBox autoLevelsCheckbox;
		private System.Windows.Forms.CheckBox stabilizeCheckbox;
		private System.Windows.Forms.TabPage planVideosTabpage;
		private System.Windows.Forms.TableLayoutPanel planVideosTlp;
		private System.Windows.Forms.Button addFilenameButton;
		private System.Windows.Forms.Button removeFilenameButton;
		private System.Windows.Forms.Button clearFilenamesButton;
		private System.Windows.Forms.ListView filenamesListView;
		private System.Windows.Forms.ColumnHeader varNameColumnHeader;
		private System.Windows.Forms.ColumnHeader varContentColumnHeader;
		private System.Windows.Forms.Label filenamesLabel;
		private System.Windows.Forms.Button duplicateTemplateButton;
		private System.Windows.Forms.OpenFileDialog openThumbnailDialog;
		private TabPage cSharpTabPage;
		private TableLayoutPanel csTlp;
		private FastColoredTextBox cSharpCleanupFctb;
		private FastColoredTextBox cSharpPrepareFctb;
		private TextBox csDescriptionTxbx;
		private Label globalPrepareScriptLabel;
		private Label globalAfterScriptsLabel;
		private GroupBox groupBox1;
		private TableLayoutPanel fillFieldsTlp;
		private ListView listView1;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private Label filenameFieldLabel;
		private Label filenameValueLabel;
		private TextBox filenameFieldTxbx;
		private TextBox filenameValueTxbx;
	}
}