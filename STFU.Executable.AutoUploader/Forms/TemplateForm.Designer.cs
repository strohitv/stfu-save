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
			this.templateTitleTextbox = new System.Windows.Forms.TextBox();
			this.templateDescriptionTextbox = new System.Windows.Forms.TextBox();
			this.templateTagsTextbox = new System.Windows.Forms.TextBox();
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
			this.nextPublishTimeLabel = new System.Windows.Forms.Label();
			this.nextPublishTimeDtp = new System.Windows.Forms.DateTimePicker();
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
			this.thumbnailTextbox = new System.Windows.Forms.TextBox();
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
			this.fillFieldsGroupbox = new System.Windows.Forms.GroupBox();
			this.fillFieldsTlp = new System.Windows.Forms.TableLayoutPanel();
			this.fillFieldsListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.filenameFieldLabel = new System.Windows.Forms.Label();
			this.filenameValueLabel = new System.Windows.Forms.Label();
			this.fieldNameTxbx = new System.Windows.Forms.TextBox();
			this.fieldValueTxbx = new System.Windows.Forms.TextBox();
			this.sendMailTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.sendMailTlp = new System.Windows.Forms.TableLayoutPanel();
			this.mailRecipientTextbox = new System.Windows.Forms.TextBox();
			this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.newVideoDNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadStartedDNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadFinishedDNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadFailedDNCheckbox = new System.Windows.Forms.CheckBox();
			this.newVideoMNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadStartedMNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadFinishedMNCheckbox = new System.Windows.Forms.CheckBox();
			this.uploadFailedMNCheckbox = new System.Windows.Forms.CheckBox();
			this.mailRecipientLabel = new System.Windows.Forms.Label();
			this.connectMailNotificationLabel = new System.Windows.Forms.Label();
			this.cSharpTabPage = new System.Windows.Forms.TabPage();
			this.csTlp = new System.Windows.Forms.TableLayoutPanel();
			this.csDescriptionLabel = new System.Windows.Forms.Label();
			this.cSharpScriptingTabControl = new System.Windows.Forms.TabControl();
			this.systemFunctionsTabPage = new System.Windows.Forms.TabPage();
			this.cSharpSystemFunctionsFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.usableVariablesTabPage = new System.Windows.Forms.TabPage();
			this.globalVarsFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.referencedAssembliesTabPage = new System.Windows.Forms.TabPage();
			this.assemblyReferencesFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.preparationScriptTabPage = new System.Windows.Forms.TabPage();
			this.cSharpPrepareFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.cleanUpScriptTabPage = new System.Windows.Forms.TabPage();
			this.cSharpCleanupFctb = new FastColoredTextBoxNS.FastColoredTextBox();
			this.editTemplateLabel = new System.Windows.Forms.Label();
			this.useExpertmodeCheckbox = new System.Windows.Forms.CheckBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.openThumbnailDialog = new System.Windows.Forms.OpenFileDialog();
			this.templateOverviewTableLayouPanel.SuspendLayout();
			this.editTemplateTableLayoutPanel.SuspendLayout();
			this.templateValuesTabControl.SuspendLayout();
			this.commonTabPage.SuspendLayout();
			this.templateCommonTableLayoutPannel.SuspendLayout();
			this.publishTabPage.SuspendLayout();
			this.publishTableLayoutPanel.SuspendLayout();
			this.publishGroupbox.SuspendLayout();
			this.publishPanel.SuspendLayout();
			this.otherTabPage.SuspendLayout();
			this.otherTlp.SuspendLayout();
			this.planVideosTabpage.SuspendLayout();
			this.planVideosTlp.SuspendLayout();
			this.fillFieldsGroupbox.SuspendLayout();
			this.fillFieldsTlp.SuspendLayout();
			this.sendMailTabPage.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.sendMailTlp.SuspendLayout();
			this.notificationsGroupBox.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.cSharpTabPage.SuspendLayout();
			this.csTlp.SuspendLayout();
			this.cSharpScriptingTabControl.SuspendLayout();
			this.systemFunctionsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cSharpSystemFunctionsFctb)).BeginInit();
			this.usableVariablesTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.globalVarsFctb)).BeginInit();
			this.referencedAssembliesTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.assemblyReferencesFctb)).BeginInit();
			this.preparationScriptTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cSharpPrepareFctb)).BeginInit();
			this.cleanUpScriptTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cSharpCleanupFctb)).BeginInit();
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
			this.templateOverviewTableLayouPanel.Size = new System.Drawing.Size(295, 762);
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
			this.addTemplateButton.Size = new System.Drawing.Size(52, 41);
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
			this.moveTemplateUpButton.Size = new System.Drawing.Size(52, 41);
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
			this.moveTemplateDownButton.Size = new System.Drawing.Size(52, 41);
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
			this.deleteTemplateButton.Size = new System.Drawing.Size(52, 41);
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
			this.clearTemplatesButton.Size = new System.Drawing.Size(52, 41);
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
			this.templateListView.Location = new System.Drawing.Point(72, 10);
			this.templateListView.Margin = new System.Windows.Forms.Padding(0);
			this.templateListView.MinimumSize = new System.Drawing.Size(188, 4);
			this.templateListView.MultiSelect = false;
			this.templateListView.Name = "templateListView";
			this.templateOverviewTableLayouPanel.SetRowSpan(this.templateListView, 12);
			this.templateListView.ShowGroups = false;
			this.templateListView.Size = new System.Drawing.Size(213, 742);
			this.templateListView.TabIndex = 7;
			this.templateListView.UseCompatibleStateImageBehavior = false;
			this.templateListView.View = System.Windows.Forms.View.Details;
			this.templateListView.SelectedIndexChanged += new System.EventHandler(this.templateListViewSelectedIndexChanged);
			// 
			// templatesColumnHeader
			// 
			this.templatesColumnHeader.Text = "Template";
			this.templatesColumnHeader.Width = 250;
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
			this.duplicateTemplateButton.Size = new System.Drawing.Size(52, 41);
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
			this.editTemplateTableLayoutPanel.Controls.Add(this.useExpertmodeCheckbox, 4, 3);
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
			this.editTemplateTableLayoutPanel.Size = new System.Drawing.Size(1041, 762);
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
			this.templateNameTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.templateNameTextbox.Location = new System.Drawing.Point(61, 33);
			this.templateNameTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateNameTextbox.Name = "templateNameTextbox";
			this.templateNameTextbox.Size = new System.Drawing.Size(786, 26);
			this.templateNameTextbox.TabIndex = 1;
			this.templateNameTextbox.TextChanged += new System.EventHandler(this.templateNameTextboxTextChanged);
			// 
			// saveTemplateButton
			// 
			this.saveTemplateButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.saveTemplateButton.AutoSize = true;
			this.saveTemplateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveTemplateButton.Enabled = false;
			this.saveTemplateButton.Location = new System.Drawing.Point(847, 725);
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
			this.resetTemplateButton.Enabled = false;
			this.resetTemplateButton.Location = new System.Drawing.Point(944, 725);
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
			this.templateValuesTabControl.Controls.Add(this.sendMailTabPage);
			this.templateValuesTabControl.Controls.Add(this.cSharpTabPage);
			this.templateValuesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateValuesTabControl.Location = new System.Drawing.Point(10, 69);
			this.templateValuesTabControl.Margin = new System.Windows.Forms.Padding(0);
			this.templateValuesTabControl.Name = "templateValuesTabControl";
			this.templateValuesTabControl.SelectedIndex = 0;
			this.templateValuesTabControl.Size = new System.Drawing.Size(1021, 646);
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
			this.commonTabPage.Size = new System.Drawing.Size(1013, 620);
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
			this.templateCommonTableLayoutPannel.Size = new System.Drawing.Size(1009, 616);
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
			this.templateDescriptionLabel.Size = new System.Drawing.Size(999, 13);
			this.templateDescriptionLabel.TabIndex = 1;
			this.templateDescriptionLabel.Text = "Beschreibung: ";
			// 
			// templateTagsLabel
			// 
			this.templateTagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTagsLabel.AutoSize = true;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateTagsLabel, 3);
			this.templateTagsLabel.Location = new System.Drawing.Point(5, 442);
			this.templateTagsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.templateTagsLabel.Name = "templateTagsLabel";
			this.templateTagsLabel.Size = new System.Drawing.Size(999, 13);
			this.templateTagsLabel.TabIndex = 2;
			this.templateTagsLabel.Text = "Tags: ";
			// 
			// templateTitleTextbox
			// 
			this.templateTitleTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateTitleTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateTitleTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateTitleTextbox.Location = new System.Drawing.Point(48, 7);
			this.templateTitleTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateTitleTextbox.Name = "templateTitleTextbox";
			this.templateTitleTextbox.Size = new System.Drawing.Size(956, 26);
			this.templateTitleTextbox.TabIndex = 3;
			this.templateTitleTextbox.TextChanged += new System.EventHandler(this.templateTitleTextboxTextChanged);
			// 
			// templateDescriptionTextbox
			// 
			this.templateDescriptionTextbox.AcceptsReturn = true;
			this.templateDescriptionTextbox.AcceptsTab = true;
			this.templateDescriptionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateDescriptionTextbox, 3);
			this.templateDescriptionTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateDescriptionTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateDescriptionTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateDescriptionTextbox.Location = new System.Drawing.Point(5, 74);
			this.templateDescriptionTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateDescriptionTextbox.Multiline = true;
			this.templateDescriptionTextbox.Name = "templateDescriptionTextbox";
			this.templateDescriptionTextbox.Size = new System.Drawing.Size(999, 340);
			this.templateDescriptionTextbox.TabIndex = 4;
			this.templateDescriptionTextbox.TextChanged += new System.EventHandler(this.templateDescriptionTextboxTextChanged);
			// 
			// templateTagsTextbox
			// 
			this.templateTagsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.templateCommonTableLayoutPannel.SetColumnSpan(this.templateTagsTextbox, 3);
			this.templateTagsTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.templateTagsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateTagsTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.templateTagsTextbox.Location = new System.Drawing.Point(5, 455);
			this.templateTagsTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.templateTagsTextbox.Multiline = true;
			this.templateTagsTextbox.Name = "templateTagsTextbox";
			this.templateTagsTextbox.Size = new System.Drawing.Size(999, 136);
			this.templateTagsTextbox.TabIndex = 5;
			this.templateTagsTextbox.TextChanged += new System.EventHandler(this.templateTagsTextboxTextChanged);
			// 
			// maxTitleLengthLabel
			// 
			this.maxTitleLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxTitleLengthLabel.AutoSize = true;
			this.maxTitleLengthLabel.Location = new System.Drawing.Point(48, 38);
			this.maxTitleLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxTitleLengthLabel.Name = "maxTitleLengthLabel";
			this.maxTitleLengthLabel.Size = new System.Drawing.Size(956, 13);
			this.maxTitleLengthLabel.TabIndex = 6;
			this.maxTitleLengthLabel.Text = "Länge Titel: 0 / 100 Zeichen";
			// 
			// maxDescriptionLengthLabel
			// 
			this.maxDescriptionLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxDescriptionLengthLabel.AutoSize = true;
			this.maxDescriptionLengthLabel.Location = new System.Drawing.Point(48, 419);
			this.maxDescriptionLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxDescriptionLengthLabel.Name = "maxDescriptionLengthLabel";
			this.maxDescriptionLengthLabel.Size = new System.Drawing.Size(956, 13);
			this.maxDescriptionLengthLabel.TabIndex = 7;
			this.maxDescriptionLengthLabel.Text = "Länge Beschreibung: 0 / 5000 Zeichen";
			// 
			// maxTagsLengthLabel
			// 
			this.maxTagsLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.maxTagsLengthLabel.AutoSize = true;
			this.maxTagsLengthLabel.Location = new System.Drawing.Point(48, 596);
			this.maxTagsLengthLabel.Margin = new System.Windows.Forms.Padding(0);
			this.maxTagsLengthLabel.Name = "maxTagsLengthLabel";
			this.maxTagsLengthLabel.Size = new System.Drawing.Size(956, 13);
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
			this.publishTabPage.Size = new System.Drawing.Size(1013, 620);
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
			this.publishTableLayoutPanel.Size = new System.Drawing.Size(1009, 616);
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
			this.publishAtCheckbox.Size = new System.Drawing.Size(995, 17);
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
			this.privacyComboBox.Size = new System.Drawing.Size(920, 26);
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
			this.publishGroupbox.Size = new System.Drawing.Size(999, 535);
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
			this.publishPanel.Controls.Add(this.nextPublishTimeLabel, 3, 20);
			this.publishPanel.Controls.Add(this.nextPublishTimeDtp, 7, 20);
			this.publishPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.publishPanel.Location = new System.Drawing.Point(2, 15);
			this.publishPanel.Margin = new System.Windows.Forms.Padding(2);
			this.publishPanel.Name = "publishPanel";
			this.publishPanel.RowCount = 22;
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
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.publishPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
			this.publishPanel.Size = new System.Drawing.Size(995, 518);
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
			this.timesListView.Location = new System.Drawing.Point(62, 7);
			this.timesListView.Margin = new System.Windows.Forms.Padding(0);
			this.timesListView.Name = "timesListView";
			this.publishPanel.SetRowSpan(this.timesListView, 16);
			this.timesListView.ShowGroups = false;
			this.timesListView.Size = new System.Drawing.Size(928, 431);
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
			this.moveTimeUpButton.Size = new System.Drawing.Size(52, 41);
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
			this.moveTimeDownButton.Size = new System.Drawing.Size(52, 41);
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
			this.addOneDayButton.Size = new System.Drawing.Size(52, 42);
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
			this.substractOneDayButton.Size = new System.Drawing.Size(52, 42);
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
			this.clearTimesButton.Size = new System.Drawing.Size(52, 41);
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
			this.deleteTimeButton.Size = new System.Drawing.Size(52, 41);
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
			this.addOneWeekButton.Size = new System.Drawing.Size(52, 42);
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
			this.substractOneWeekButton.Size = new System.Drawing.Size(52, 42);
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
			this.addTimeLabel.Location = new System.Drawing.Point(269, 455);
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
			this.addTimeButton.Location = new System.Drawing.Point(394, 448);
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
			this.addWeekdayCombobox.Location = new System.Drawing.Point(141, 448);
			this.addWeekdayCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.addWeekdayCombobox.Name = "addWeekdayCombobox";
			this.addWeekdayCombobox.Size = new System.Drawing.Size(118, 26);
			this.addWeekdayCombobox.TabIndex = 12;
			// 
			// addTimeTimePicker
			// 
			this.addTimeTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addTimeTimePicker.CustomFormat = "HH:mm";
			this.addTimeTimePicker.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addTimeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.addTimeTimePicker.Location = new System.Drawing.Point(310, 448);
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
			this.addWeekdayLabel.Location = new System.Drawing.Point(62, 455);
			this.addWeekdayLabel.Margin = new System.Windows.Forms.Padding(0);
			this.addWeekdayLabel.Name = "addWeekdayLabel";
			this.addWeekdayLabel.Size = new System.Drawing.Size(69, 13);
			this.addWeekdayLabel.TabIndex = 9;
			this.addWeekdayLabel.Text = "Wochentag: ";
			// 
			// nextPublishTimeLabel
			// 
			this.nextPublishTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nextPublishTimeLabel.AutoSize = true;
			this.publishPanel.SetColumnSpan(this.nextPublishTimeLabel, 3);
			this.nextPublishTimeLabel.Location = new System.Drawing.Point(62, 491);
			this.nextPublishTimeLabel.Margin = new System.Windows.Forms.Padding(0);
			this.nextPublishTimeLabel.Name = "nextPublishTimeLabel";
			this.nextPublishTimeLabel.Size = new System.Drawing.Size(197, 13);
			this.nextPublishTimeLabel.TabIndex = 9;
			this.nextPublishTimeLabel.Text = "Veröffentlichungsdatum nächstes Video:";
			// 
			// nextPublishTimeDtp
			// 
			this.nextPublishTimeDtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.publishPanel.SetColumnSpan(this.nextPublishTimeDtp, 5);
			this.nextPublishTimeDtp.CustomFormat = "dd.MM.yyyy HH:mm";
			this.nextPublishTimeDtp.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nextPublishTimeDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.nextPublishTimeDtp.Location = new System.Drawing.Point(269, 485);
			this.nextPublishTimeDtp.Margin = new System.Windows.Forms.Padding(0);
			this.nextPublishTimeDtp.Name = "nextPublishTimeDtp";
			this.nextPublishTimeDtp.Size = new System.Drawing.Size(218, 26);
			this.nextPublishTimeDtp.TabIndex = 14;
			this.nextPublishTimeDtp.ValueChanged += new System.EventHandler(this.nextPublishTimeDtp_ValueChanged);
			// 
			// otherTabPage
			// 
			this.otherTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.otherTabPage.Controls.Add(this.otherTlp);
			this.otherTabPage.Location = new System.Drawing.Point(4, 22);
			this.otherTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.otherTabPage.Name = "otherTabPage";
			this.otherTabPage.Size = new System.Drawing.Size(1013, 620);
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
			this.otherTlp.Size = new System.Drawing.Size(1013, 620);
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
			this.isEmbeddableCheckbox.Size = new System.Drawing.Size(993, 17);
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
			this.publicStatsViewableCheckbox.Size = new System.Drawing.Size(993, 17);
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
			this.categoryCombobox.Size = new System.Drawing.Size(825, 26);
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
			this.defaultLanguageCombobox.Size = new System.Drawing.Size(825, 26);
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
			this.licenseCombobox.Size = new System.Drawing.Size(825, 26);
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
			this.thumbnailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.thumbnailTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.thumbnailTextbox.Font = new System.Drawing.Font("Courier New", 12F);
			this.thumbnailTextbox.Location = new System.Drawing.Point(178, 172);
			this.thumbnailTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailTextbox.Name = "thumbnailTextbox";
			this.thumbnailTextbox.Size = new System.Drawing.Size(794, 26);
			this.thumbnailTextbox.TabIndex = 9;
			this.thumbnailTextbox.TextChanged += new System.EventHandler(this.thumbnailTextboxTextChanged);
			// 
			// chooseThumbnailPathButton
			// 
			this.chooseThumbnailPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseThumbnailPathButton.AutoSize = true;
			this.chooseThumbnailPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.chooseThumbnailPathButton.Location = new System.Drawing.Point(977, 172);
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
			this.notifySubscribersCheckbox.Size = new System.Drawing.Size(993, 17);
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
			this.autoLevelsCheckbox.Size = new System.Drawing.Size(993, 17);
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
			this.stabilizeCheckbox.Size = new System.Drawing.Size(993, 17);
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
			this.planVideosTabpage.Size = new System.Drawing.Size(1013, 620);
			this.planVideosTabpage.TabIndex = 3;
			this.planVideosTabpage.Text = "Videos planen";
			this.planVideosTabpage.Enter += new System.EventHandler(this.planVideosTabpageEntered);
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
			this.planVideosTlp.Controls.Add(this.fillFieldsGroupbox, 1, 10);
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
			this.planVideosTlp.Size = new System.Drawing.Size(1009, 616);
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
			this.addFilenameButton.Click += new System.EventHandler(this.addFilenameButtonClick);
			// 
			// removeFilenameButton
			// 
			this.removeFilenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.removeFilenameButton.AutoSize = true;
			this.removeFilenameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.removeFilenameButton.Enabled = false;
			this.removeFilenameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.removeFilenameButton.ForeColor = System.Drawing.Color.Red;
			this.removeFilenameButton.Location = new System.Drawing.Point(10, 79);
			this.removeFilenameButton.Margin = new System.Windows.Forms.Padding(0);
			this.removeFilenameButton.Name = "removeFilenameButton";
			this.removeFilenameButton.Size = new System.Drawing.Size(41, 41);
			this.removeFilenameButton.TabIndex = 5;
			this.removeFilenameButton.Text = "-";
			this.removeFilenameButton.UseVisualStyleBackColor = true;
			this.removeFilenameButton.Click += new System.EventHandler(this.removeFilenameButtonClick);
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
			this.clearFilenamesButton.Click += new System.EventHandler(this.clearFilenamesButtonClick);
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
			this.filenamesListView.Size = new System.Drawing.Size(938, 221);
			this.filenamesListView.TabIndex = 9;
			this.filenamesListView.UseCompatibleStateImageBehavior = false;
			this.filenamesListView.View = System.Windows.Forms.View.Details;
			this.filenamesListView.SelectedIndexChanged += new System.EventHandler(this.filenamesListViewSelectedIndexChanged);
			// 
			// varNameColumnHeader
			// 
			this.varNameColumnHeader.Text = "Dateiname";
			this.varNameColumnHeader.Width = 400;
			// 
			// varContentColumnHeader
			// 
			this.varContentColumnHeader.Text = "Alles ausgefüllt";
			this.varContentColumnHeader.Width = 250;
			// 
			// filenamesLabel
			// 
			this.filenamesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filenamesLabel.AutoSize = true;
			this.planVideosTlp.SetColumnSpan(this.filenamesLabel, 3);
			this.filenamesLabel.Location = new System.Drawing.Point(13, 10);
			this.filenamesLabel.Name = "filenamesLabel";
			this.filenamesLabel.Size = new System.Drawing.Size(983, 13);
			this.filenamesLabel.TabIndex = 12;
			this.filenamesLabel.Text = "Dateien:";
			// 
			// fillFieldsGroupbox
			// 
			this.planVideosTlp.SetColumnSpan(this.fillFieldsGroupbox, 3);
			this.fillFieldsGroupbox.Controls.Add(this.fillFieldsTlp);
			this.fillFieldsGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fillFieldsGroupbox.Enabled = false;
			this.fillFieldsGroupbox.Location = new System.Drawing.Point(10, 259);
			this.fillFieldsGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.fillFieldsGroupbox.Name = "fillFieldsGroupbox";
			this.fillFieldsGroupbox.Size = new System.Drawing.Size(989, 346);
			this.fillFieldsGroupbox.TabIndex = 13;
			this.fillFieldsGroupbox.TabStop = false;
			this.fillFieldsGroupbox.Text = "Platzhalter ausfüllen: ";
			// 
			// fillFieldsTlp
			// 
			this.fillFieldsTlp.ColumnCount = 5;
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fillFieldsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.fillFieldsTlp.Controls.Add(this.fillFieldsListView, 1, 1);
			this.fillFieldsTlp.Controls.Add(this.filenameFieldLabel, 1, 3);
			this.fillFieldsTlp.Controls.Add(this.filenameValueLabel, 1, 5);
			this.fillFieldsTlp.Controls.Add(this.fieldNameTxbx, 3, 3);
			this.fillFieldsTlp.Controls.Add(this.fieldValueTxbx, 3, 5);
			this.fillFieldsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fillFieldsTlp.Location = new System.Drawing.Point(3, 16);
			this.fillFieldsTlp.Name = "fillFieldsTlp";
			this.fillFieldsTlp.RowCount = 7;
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fillFieldsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.fillFieldsTlp.Size = new System.Drawing.Size(983, 327);
			this.fillFieldsTlp.TabIndex = 0;
			// 
			// fillFieldsListView
			// 
			this.fillFieldsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fillFieldsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.fillFieldsTlp.SetColumnSpan(this.fillFieldsListView, 3);
			this.fillFieldsListView.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fillFieldsListView.FullRowSelect = true;
			this.fillFieldsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.fillFieldsListView.HideSelection = false;
			this.fillFieldsListView.Location = new System.Drawing.Point(10, 10);
			this.fillFieldsListView.Margin = new System.Windows.Forms.Padding(0);
			this.fillFieldsListView.Name = "fillFieldsListView";
			this.fillFieldsListView.ShowGroups = false;
			this.fillFieldsListView.Size = new System.Drawing.Size(973, 181);
			this.fillFieldsListView.TabIndex = 9;
			this.fillFieldsListView.UseCompatibleStateImageBehavior = false;
			this.fillFieldsListView.View = System.Windows.Forms.View.Details;
			this.fillFieldsListView.SelectedIndexChanged += new System.EventHandler(this.fillFieldsListViewSelectedIndexChanged);
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
			this.filenameFieldLabel.Size = new System.Drawing.Size(105, 13);
			this.filenameFieldLabel.TabIndex = 10;
			this.filenameFieldLabel.Text = "Platzhalter: ";
			// 
			// filenameValueLabel
			// 
			this.filenameValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filenameValueLabel.AutoSize = true;
			this.filenameValueLabel.Location = new System.Drawing.Point(10, 244);
			this.filenameValueLabel.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
			this.filenameValueLabel.Name = "filenameValueLabel";
			this.filenameValueLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.filenameValueLabel.Size = new System.Drawing.Size(105, 19);
			this.filenameValueLabel.TabIndex = 10;
			this.filenameValueLabel.Text = "Einzufügender Text: ";
			// 
			// fieldNameTxbx
			// 
			this.fieldNameTxbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.fieldNameTxbx.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fieldNameTxbx.Location = new System.Drawing.Point(125, 201);
			this.fieldNameTxbx.Margin = new System.Windows.Forms.Padding(0);
			this.fieldNameTxbx.Name = "fieldNameTxbx";
			this.fieldNameTxbx.ReadOnly = true;
			this.fieldNameTxbx.Size = new System.Drawing.Size(858, 26);
			this.fieldNameTxbx.TabIndex = 11;
			// 
			// fieldValueTxbx
			// 
			this.fieldValueTxbx.AcceptsReturn = true;
			this.fieldValueTxbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fieldValueTxbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.fieldValueTxbx.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.fieldValueTxbx.Font = new System.Drawing.Font("Courier New", 12F);
			this.fieldValueTxbx.Location = new System.Drawing.Point(125, 237);
			this.fieldValueTxbx.Margin = new System.Windows.Forms.Padding(0);
			this.fieldValueTxbx.Name = "fieldValueTxbx";
			this.fieldValueTxbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.fieldValueTxbx.Size = new System.Drawing.Size(858, 26);
			this.fieldValueTxbx.TabIndex = 11;
			this.fieldValueTxbx.TextChanged += new System.EventHandler(this.fieldValueTxbxTextChanged);
			// 
			// sendMailTabPage
			// 
			this.sendMailTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.sendMailTabPage.Controls.Add(this.tableLayoutPanel1);
			this.sendMailTabPage.Location = new System.Drawing.Point(4, 22);
			this.sendMailTabPage.Name = "sendMailTabPage";
			this.sendMailTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.sendMailTabPage.Size = new System.Drawing.Size(1013, 620);
			this.sendMailTabPage.TabIndex = 5;
			this.sendMailTabPage.Text = "Benachrichtigungen";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.sendMailTlp, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.connectMailNotificationLabel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 614);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// sendMailTlp
			// 
			this.sendMailTlp.ColumnCount = 5;
			this.sendMailTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.sendMailTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.sendMailTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.Controls.Add(this.mailRecipientTextbox, 3, 2);
			this.sendMailTlp.Controls.Add(this.notificationsGroupBox, 1, 4);
			this.sendMailTlp.Controls.Add(this.mailRecipientLabel, 1, 2);
			this.sendMailTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sendMailTlp.Location = new System.Drawing.Point(3, 53);
			this.sendMailTlp.Name = "sendMailTlp";
			this.sendMailTlp.RowCount = 6;
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.sendMailTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.sendMailTlp.Size = new System.Drawing.Size(1001, 558);
			this.sendMailTlp.TabIndex = 0;
			// 
			// mailRecipientTextbox
			// 
			this.mailRecipientTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mailRecipientTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mailRecipientTextbox.Location = new System.Drawing.Point(208, 10);
			this.mailRecipientTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.mailRecipientTextbox.Name = "mailRecipientTextbox";
			this.mailRecipientTextbox.Size = new System.Drawing.Size(783, 26);
			this.mailRecipientTextbox.TabIndex = 3;
			this.mailRecipientTextbox.TextChanged += new System.EventHandler(this.mailRecipientTextbox_TextChanged);
			// 
			// notificationsGroupBox
			// 
			this.sendMailTlp.SetColumnSpan(this.notificationsGroupBox, 3);
			this.notificationsGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.notificationsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notificationsGroupBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notificationsGroupBox.Location = new System.Drawing.Point(10, 46);
			this.notificationsGroupBox.Margin = new System.Windows.Forms.Padding(0);
			this.notificationsGroupBox.Name = "notificationsGroupBox";
			this.notificationsGroupBox.Size = new System.Drawing.Size(981, 502);
			this.notificationsGroupBox.TabIndex = 4;
			this.notificationsGroupBox.TabStop = false;
			this.notificationsGroupBox.Text = "Benachrichtigungen verwalten: ";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 7;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label2, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.label3, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.label4, 1, 7);
			this.tableLayoutPanel2.Controls.Add(this.newVideoDNCheckbox, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.uploadFailedDNCheckbox, 3, 7);
			this.tableLayoutPanel2.Controls.Add(this.newVideoMNCheckbox, 5, 1);
			this.tableLayoutPanel2.Controls.Add(this.uploadStartedMNCheckbox, 5, 3);
			this.tableLayoutPanel2.Controls.Add(this.uploadFinishedMNCheckbox, 5, 5);
			this.tableLayoutPanel2.Controls.Add(this.uploadFailedMNCheckbox, 5, 7);
			this.tableLayoutPanel2.Controls.Add(this.uploadStartedDNCheckbox, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.uploadFinishedDNCheckbox, 3, 5);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 10;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(975, 477);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(378, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Neues Video gefunden: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 44);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(378, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Video-Upload begonnen: ";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 76);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(378, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Video erfolgreich hochgeladen: ";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 108);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(378, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "Video-Upload mit Fehler abgebrochen: ";
			// 
			// newVideoDNCheckbox
			// 
			this.newVideoDNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.newVideoDNCheckbox.AutoSize = true;
			this.newVideoDNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.newVideoDNCheckbox.Location = new System.Drawing.Point(403, 10);
			this.newVideoDNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.newVideoDNCheckbox.Name = "newVideoDNCheckbox";
			this.newVideoDNCheckbox.Size = new System.Drawing.Size(267, 22);
			this.newVideoDNCheckbox.TabIndex = 1;
			this.newVideoDNCheckbox.Text = "Desktop-Benachrichtigung";
			this.newVideoDNCheckbox.UseVisualStyleBackColor = true;
			this.newVideoDNCheckbox.CheckedChanged += new System.EventHandler(this.newVideoDNCheckbox_CheckedChanged);
			// 
			// uploadStartedDNCheckbox
			// 
			this.uploadStartedDNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadStartedDNCheckbox.AutoSize = true;
			this.uploadStartedDNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadStartedDNCheckbox.Location = new System.Drawing.Point(403, 42);
			this.uploadStartedDNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadStartedDNCheckbox.Name = "uploadStartedDNCheckbox";
			this.uploadStartedDNCheckbox.Size = new System.Drawing.Size(267, 22);
			this.uploadStartedDNCheckbox.TabIndex = 1;
			this.uploadStartedDNCheckbox.Text = "Desktop-Benachrichtigung";
			this.uploadStartedDNCheckbox.UseVisualStyleBackColor = true;
			this.uploadStartedDNCheckbox.CheckedChanged += new System.EventHandler(this.uploadStartedDNCheckbox_CheckedChanged);
			// 
			// uploadFinishedDNCheckbox
			// 
			this.uploadFinishedDNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadFinishedDNCheckbox.AutoSize = true;
			this.uploadFinishedDNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadFinishedDNCheckbox.Location = new System.Drawing.Point(403, 74);
			this.uploadFinishedDNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadFinishedDNCheckbox.Name = "uploadFinishedDNCheckbox";
			this.uploadFinishedDNCheckbox.Size = new System.Drawing.Size(267, 22);
			this.uploadFinishedDNCheckbox.TabIndex = 1;
			this.uploadFinishedDNCheckbox.Text = "Desktop-Benachrichtigung";
			this.uploadFinishedDNCheckbox.UseVisualStyleBackColor = true;
			this.uploadFinishedDNCheckbox.CheckedChanged += new System.EventHandler(this.uploadFinishedDNCheckbox_CheckedChanged);
			// 
			// uploadFailedDNCheckbox
			// 
			this.uploadFailedDNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadFailedDNCheckbox.AutoSize = true;
			this.uploadFailedDNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadFailedDNCheckbox.Location = new System.Drawing.Point(403, 106);
			this.uploadFailedDNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadFailedDNCheckbox.Name = "uploadFailedDNCheckbox";
			this.uploadFailedDNCheckbox.Size = new System.Drawing.Size(267, 22);
			this.uploadFailedDNCheckbox.TabIndex = 1;
			this.uploadFailedDNCheckbox.Text = "Desktop-Benachrichtigung";
			this.uploadFailedDNCheckbox.UseVisualStyleBackColor = true;
			this.uploadFailedDNCheckbox.CheckedChanged += new System.EventHandler(this.uploadFailedDNCheckbox_CheckedChanged);
			// 
			// newVideoMNCheckbox
			// 
			this.newVideoMNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.newVideoMNCheckbox.AutoSize = true;
			this.newVideoMNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.newVideoMNCheckbox.Location = new System.Drawing.Point(696, 10);
			this.newVideoMNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.newVideoMNCheckbox.Name = "newVideoMNCheckbox";
			this.newVideoMNCheckbox.Size = new System.Drawing.Size(257, 22);
			this.newVideoMNCheckbox.TabIndex = 1;
			this.newVideoMNCheckbox.Text = "E-Mail-Benachrichtigung";
			this.newVideoMNCheckbox.UseVisualStyleBackColor = true;
			this.newVideoMNCheckbox.CheckedChanged += new System.EventHandler(this.newVideoMNCheckbox_CheckedChanged);
			// 
			// uploadStartedMNCheckbox
			// 
			this.uploadStartedMNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadStartedMNCheckbox.AutoSize = true;
			this.uploadStartedMNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadStartedMNCheckbox.Location = new System.Drawing.Point(696, 42);
			this.uploadStartedMNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadStartedMNCheckbox.Name = "uploadStartedMNCheckbox";
			this.uploadStartedMNCheckbox.Size = new System.Drawing.Size(257, 22);
			this.uploadStartedMNCheckbox.TabIndex = 1;
			this.uploadStartedMNCheckbox.Text = "E-Mail-Benachrichtigung";
			this.uploadStartedMNCheckbox.UseVisualStyleBackColor = true;
			this.uploadStartedMNCheckbox.CheckedChanged += new System.EventHandler(this.uploadStartedMNCheckbox_CheckedChanged);
			// 
			// uploadFinishedMNCheckbox
			// 
			this.uploadFinishedMNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadFinishedMNCheckbox.AutoSize = true;
			this.uploadFinishedMNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadFinishedMNCheckbox.Location = new System.Drawing.Point(696, 74);
			this.uploadFinishedMNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadFinishedMNCheckbox.Name = "uploadFinishedMNCheckbox";
			this.uploadFinishedMNCheckbox.Size = new System.Drawing.Size(257, 22);
			this.uploadFinishedMNCheckbox.TabIndex = 1;
			this.uploadFinishedMNCheckbox.Text = "E-Mail-Benachrichtigung";
			this.uploadFinishedMNCheckbox.UseVisualStyleBackColor = true;
			this.uploadFinishedMNCheckbox.CheckedChanged += new System.EventHandler(this.uploadFinishedMNCheckbox_CheckedChanged);
			// 
			// uploadFailedMNCheckbox
			// 
			this.uploadFailedMNCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.uploadFailedMNCheckbox.AutoSize = true;
			this.uploadFailedMNCheckbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadFailedMNCheckbox.Location = new System.Drawing.Point(696, 106);
			this.uploadFailedMNCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.uploadFailedMNCheckbox.Name = "uploadFailedMNCheckbox";
			this.uploadFailedMNCheckbox.Size = new System.Drawing.Size(257, 22);
			this.uploadFailedMNCheckbox.TabIndex = 1;
			this.uploadFailedMNCheckbox.Text = "E-Mail-Benachrichtigung";
			this.uploadFailedMNCheckbox.UseVisualStyleBackColor = true;
			this.uploadFailedMNCheckbox.CheckedChanged += new System.EventHandler(this.uploadFailedMNCheckbox_CheckedChanged);
			// 
			// mailRecipientLabel
			// 
			this.mailRecipientLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mailRecipientLabel.AutoSize = true;
			this.mailRecipientLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mailRecipientLabel.Location = new System.Drawing.Point(10, 14);
			this.mailRecipientLabel.Margin = new System.Windows.Forms.Padding(0);
			this.mailRecipientLabel.Name = "mailRecipientLabel";
			this.mailRecipientLabel.Size = new System.Drawing.Size(188, 18);
			this.mailRecipientLabel.TabIndex = 1;
			this.mailRecipientLabel.Text = "E-Mail-Empfänger: ";
			// 
			// connectMailNotificationLabel
			// 
			this.connectMailNotificationLabel.AutoSize = true;
			this.connectMailNotificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectMailNotificationLabel.ForeColor = System.Drawing.Color.Red;
			this.connectMailNotificationLabel.Location = new System.Drawing.Point(0, 0);
			this.connectMailNotificationLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.connectMailNotificationLabel.Name = "connectMailNotificationLabel";
			this.connectMailNotificationLabel.Size = new System.Drawing.Size(984, 40);
			this.connectMailNotificationLabel.TabIndex = 1;
			this.connectMailNotificationLabel.Text = "Wenn du mit dem Uploader Mails verschicken möchtest, musst du den Account mit akt" +
    "iviertem Haken für den Mailversand neu verknüpfen!";
			this.connectMailNotificationLabel.Visible = false;
			// 
			// cSharpTabPage
			// 
			this.cSharpTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.cSharpTabPage.Controls.Add(this.csTlp);
			this.cSharpTabPage.Location = new System.Drawing.Point(4, 22);
			this.cSharpTabPage.Name = "cSharpTabPage";
			this.cSharpTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cSharpTabPage.Size = new System.Drawing.Size(1013, 620);
			this.cSharpTabPage.TabIndex = 4;
			this.cSharpTabPage.Text = "C#-Scripting (Expertenmodus)";
			// 
			// csTlp
			// 
			this.csTlp.ColumnCount = 3;
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.csTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.Controls.Add(this.csDescriptionLabel, 1, 1);
			this.csTlp.Controls.Add(this.cSharpScriptingTabControl, 1, 3);
			this.csTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csTlp.Location = new System.Drawing.Point(3, 3);
			this.csTlp.Name = "csTlp";
			this.csTlp.RowCount = 5;
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.csTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.csTlp.Size = new System.Drawing.Size(1007, 614);
			this.csTlp.TabIndex = 0;
			// 
			// csDescriptionLabel
			// 
			this.csDescriptionLabel.AutoSize = true;
			this.csDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csDescriptionLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.csDescriptionLabel.Location = new System.Drawing.Point(10, 10);
			this.csDescriptionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.csDescriptionLabel.Name = "csDescriptionLabel";
			this.csDescriptionLabel.Size = new System.Drawing.Size(987, 144);
			this.csDescriptionLabel.TabIndex = 12;
			this.csDescriptionLabel.Text = resources.GetString("csDescriptionLabel.Text");
			// 
			// cSharpScriptingTabControl
			// 
			this.cSharpScriptingTabControl.Controls.Add(this.systemFunctionsTabPage);
			this.cSharpScriptingTabControl.Controls.Add(this.usableVariablesTabPage);
			this.cSharpScriptingTabControl.Controls.Add(this.referencedAssembliesTabPage);
			this.cSharpScriptingTabControl.Controls.Add(this.preparationScriptTabPage);
			this.cSharpScriptingTabControl.Controls.Add(this.cleanUpScriptTabPage);
			this.cSharpScriptingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cSharpScriptingTabControl.Location = new System.Drawing.Point(13, 167);
			this.cSharpScriptingTabControl.Name = "cSharpScriptingTabControl";
			this.cSharpScriptingTabControl.SelectedIndex = 0;
			this.cSharpScriptingTabControl.Size = new System.Drawing.Size(981, 434);
			this.cSharpScriptingTabControl.TabIndex = 16;
			// 
			// systemFunctionsTabPage
			// 
			this.systemFunctionsTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.systemFunctionsTabPage.Controls.Add(this.cSharpSystemFunctionsFctb);
			this.systemFunctionsTabPage.Location = new System.Drawing.Point(4, 22);
			this.systemFunctionsTabPage.Name = "systemFunctionsTabPage";
			this.systemFunctionsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.systemFunctionsTabPage.Size = new System.Drawing.Size(973, 408);
			this.systemFunctionsTabPage.TabIndex = 0;
			this.systemFunctionsTabPage.Text = "Systemfunktionen (read-only)";
			// 
			// cSharpSystemFunctionsFctb
			// 
			this.cSharpSystemFunctionsFctb.AutoCompleteBrackets = true;
			this.cSharpSystemFunctionsFctb.AutoCompleteBracketsList = new char[] {
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
			this.cSharpSystemFunctionsFctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.cSharpSystemFunctionsFctb.AutoScrollMinSize = new System.Drawing.Size(0, 18);
			this.cSharpSystemFunctionsFctb.BackBrush = null;
			this.cSharpSystemFunctionsFctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cSharpSystemFunctionsFctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.cSharpSystemFunctionsFctb.CharHeight = 18;
			this.cSharpSystemFunctionsFctb.CharWidth = 10;
			this.cSharpSystemFunctionsFctb.CurrentLineColor = System.Drawing.Color.LightGray;
			this.cSharpSystemFunctionsFctb.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.cSharpSystemFunctionsFctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.cSharpSystemFunctionsFctb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cSharpSystemFunctionsFctb.Font = new System.Drawing.Font("Courier New", 12F);
			this.cSharpSystemFunctionsFctb.IsReplaceMode = false;
			this.cSharpSystemFunctionsFctb.Language = FastColoredTextBoxNS.Language.CSharp;
			this.cSharpSystemFunctionsFctb.LeftBracket = '(';
			this.cSharpSystemFunctionsFctb.LeftBracket2 = '{';
			this.cSharpSystemFunctionsFctb.Location = new System.Drawing.Point(3, 3);
			this.cSharpSystemFunctionsFctb.Margin = new System.Windows.Forms.Padding(0);
			this.cSharpSystemFunctionsFctb.Name = "cSharpSystemFunctionsFctb";
			this.cSharpSystemFunctionsFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.cSharpSystemFunctionsFctb.ReadOnly = true;
			this.cSharpSystemFunctionsFctb.RightBracket = ')';
			this.cSharpSystemFunctionsFctb.RightBracket2 = '}';
			this.cSharpSystemFunctionsFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.cSharpSystemFunctionsFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpSystemFunctionsFctb.ServiceColors")));
			this.cSharpSystemFunctionsFctb.Size = new System.Drawing.Size(967, 402);
			this.cSharpSystemFunctionsFctb.TabIndex = 14;
			this.cSharpSystemFunctionsFctb.WordWrap = true;
			this.cSharpSystemFunctionsFctb.WordWrapIndent = 6;
			this.cSharpSystemFunctionsFctb.Zoom = 100;
			// 
			// usableVariablesTabPage
			// 
			this.usableVariablesTabPage.Controls.Add(this.globalVarsFctb);
			this.usableVariablesTabPage.Location = new System.Drawing.Point(4, 22);
			this.usableVariablesTabPage.Name = "usableVariablesTabPage";
			this.usableVariablesTabPage.Size = new System.Drawing.Size(973, 408);
			this.usableVariablesTabPage.TabIndex = 4;
			this.usableVariablesTabPage.Text = "Verwendbare Variablen (read-only)";
			this.usableVariablesTabPage.UseVisualStyleBackColor = true;
			// 
			// globalVarsFctb
			// 
			this.globalVarsFctb.AutoCompleteBrackets = true;
			this.globalVarsFctb.AutoCompleteBracketsList = new char[] {
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
			this.globalVarsFctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.globalVarsFctb.AutoScrollMinSize = new System.Drawing.Size(0, 342);
			this.globalVarsFctb.BackBrush = null;
			this.globalVarsFctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.globalVarsFctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.globalVarsFctb.CharHeight = 18;
			this.globalVarsFctb.CharWidth = 10;
			this.globalVarsFctb.CurrentLineColor = System.Drawing.Color.LightGray;
			this.globalVarsFctb.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.globalVarsFctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.globalVarsFctb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.globalVarsFctb.Font = new System.Drawing.Font("Courier New", 12F);
			this.globalVarsFctb.IsReplaceMode = false;
			this.globalVarsFctb.Language = FastColoredTextBoxNS.Language.CSharp;
			this.globalVarsFctb.LeftBracket = '(';
			this.globalVarsFctb.LeftBracket2 = '{';
			this.globalVarsFctb.Location = new System.Drawing.Point(0, 0);
			this.globalVarsFctb.Margin = new System.Windows.Forms.Padding(0);
			this.globalVarsFctb.Name = "globalVarsFctb";
			this.globalVarsFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.globalVarsFctb.ReadOnly = true;
			this.globalVarsFctb.RightBracket = ')';
			this.globalVarsFctb.RightBracket2 = '}';
			this.globalVarsFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.globalVarsFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("globalVarsFctb.ServiceColors")));
			this.globalVarsFctb.Size = new System.Drawing.Size(973, 408);
			this.globalVarsFctb.TabIndex = 15;
			this.globalVarsFctb.Text = resources.GetString("globalVarsFctb.Text");
			this.globalVarsFctb.WordWrap = true;
			this.globalVarsFctb.WordWrapIndent = 6;
			this.globalVarsFctb.Zoom = 100;
			// 
			// referencedAssembliesTabPage
			// 
			this.referencedAssembliesTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.referencedAssembliesTabPage.Controls.Add(this.assemblyReferencesFctb);
			this.referencedAssembliesTabPage.Location = new System.Drawing.Point(4, 22);
			this.referencedAssembliesTabPage.Name = "referencedAssembliesTabPage";
			this.referencedAssembliesTabPage.Size = new System.Drawing.Size(973, 408);
			this.referencedAssembliesTabPage.TabIndex = 5;
			this.referencedAssembliesTabPage.Text = "Referenzierte Assemblies";
			// 
			// assemblyReferencesFctb
			// 
			this.assemblyReferencesFctb.AutoCompleteBrackets = true;
			this.assemblyReferencesFctb.AutoCompleteBracketsList = new char[] {
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
			this.assemblyReferencesFctb.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
			this.assemblyReferencesFctb.AutoScrollMinSize = new System.Drawing.Size(0, 342);
			this.assemblyReferencesFctb.BackBrush = null;
			this.assemblyReferencesFctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.assemblyReferencesFctb.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.assemblyReferencesFctb.CharHeight = 18;
			this.assemblyReferencesFctb.CharWidth = 10;
			this.assemblyReferencesFctb.CurrentLineColor = System.Drawing.Color.LightGray;
			this.assemblyReferencesFctb.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.assemblyReferencesFctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.assemblyReferencesFctb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.assemblyReferencesFctb.Font = new System.Drawing.Font("Courier New", 12F);
			this.assemblyReferencesFctb.IsReplaceMode = false;
			this.assemblyReferencesFctb.Language = FastColoredTextBoxNS.Language.CSharp;
			this.assemblyReferencesFctb.LeftBracket = '(';
			this.assemblyReferencesFctb.LeftBracket2 = '{';
			this.assemblyReferencesFctb.Location = new System.Drawing.Point(0, 0);
			this.assemblyReferencesFctb.Margin = new System.Windows.Forms.Padding(0);
			this.assemblyReferencesFctb.Name = "assemblyReferencesFctb";
			this.assemblyReferencesFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.assemblyReferencesFctb.RightBracket = ')';
			this.assemblyReferencesFctb.RightBracket2 = '}';
			this.assemblyReferencesFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.assemblyReferencesFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("assemblyReferencesFctb.ServiceColors")));
			this.assemblyReferencesFctb.Size = new System.Drawing.Size(973, 408);
			this.assemblyReferencesFctb.TabIndex = 16;
			this.assemblyReferencesFctb.Text = resources.GetString("assemblyReferencesFctb.Text");
			this.assemblyReferencesFctb.WordWrap = true;
			this.assemblyReferencesFctb.WordWrapIndent = 6;
			this.assemblyReferencesFctb.Zoom = 100;
			this.assemblyReferencesFctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.assemblyReferencesFctb_TextChanged);
			// 
			// preparationScriptTabPage
			// 
			this.preparationScriptTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.preparationScriptTabPage.Controls.Add(this.cSharpPrepareFctb);
			this.preparationScriptTabPage.Location = new System.Drawing.Point(4, 22);
			this.preparationScriptTabPage.Name = "preparationScriptTabPage";
			this.preparationScriptTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.preparationScriptTabPage.Size = new System.Drawing.Size(973, 408);
			this.preparationScriptTabPage.TabIndex = 2;
			this.preparationScriptTabPage.Text = "Upload-Vorbereitungsskript";
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
			this.cSharpPrepareFctb.Location = new System.Drawing.Point(3, 3);
			this.cSharpPrepareFctb.Margin = new System.Windows.Forms.Padding(0);
			this.cSharpPrepareFctb.Name = "cSharpPrepareFctb";
			this.cSharpPrepareFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.cSharpPrepareFctb.RightBracket = ')';
			this.cSharpPrepareFctb.RightBracket2 = '}';
			this.cSharpPrepareFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.cSharpPrepareFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpPrepareFctb.ServiceColors")));
			this.cSharpPrepareFctb.Size = new System.Drawing.Size(967, 402);
			this.cSharpPrepareFctb.TabIndex = 14;
			this.cSharpPrepareFctb.WordWrap = true;
			this.cSharpPrepareFctb.WordWrapIndent = 6;
			this.cSharpPrepareFctb.Zoom = 100;
			this.cSharpPrepareFctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.cSharpPrepareFctbTextChanged);
			// 
			// cleanUpScriptTabPage
			// 
			this.cleanUpScriptTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.cleanUpScriptTabPage.Controls.Add(this.cSharpCleanupFctb);
			this.cleanUpScriptTabPage.Location = new System.Drawing.Point(4, 22);
			this.cleanUpScriptTabPage.Name = "cleanUpScriptTabPage";
			this.cleanUpScriptTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.cleanUpScriptTabPage.Size = new System.Drawing.Size(973, 408);
			this.cleanUpScriptTabPage.TabIndex = 3;
			this.cleanUpScriptTabPage.Text = "Upload-Nachbereitungsskript";
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
			this.cSharpCleanupFctb.Location = new System.Drawing.Point(3, 3);
			this.cSharpCleanupFctb.Margin = new System.Windows.Forms.Padding(0);
			this.cSharpCleanupFctb.Name = "cSharpCleanupFctb";
			this.cSharpCleanupFctb.Paddings = new System.Windows.Forms.Padding(0);
			this.cSharpCleanupFctb.RightBracket = ')';
			this.cSharpCleanupFctb.RightBracket2 = '}';
			this.cSharpCleanupFctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.cSharpCleanupFctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("cSharpCleanupFctb.ServiceColors")));
			this.cSharpCleanupFctb.Size = new System.Drawing.Size(967, 402);
			this.cSharpCleanupFctb.TabIndex = 15;
			this.cSharpCleanupFctb.WordWrap = true;
			this.cSharpCleanupFctb.WordWrapIndent = 6;
			this.cSharpCleanupFctb.Zoom = 100;
			this.cSharpCleanupFctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.cSharpCleanupFctbTextChanged);
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
			this.editTemplateLabel.Size = new System.Drawing.Size(1021, 13);
			this.editTemplateLabel.TabIndex = 0;
			this.editTemplateLabel.Text = "Template bearbeiten: ";
			// 
			// useExpertmodeCheckbox
			// 
			this.useExpertmodeCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.useExpertmodeCheckbox.AutoSize = true;
			this.editTemplateTableLayoutPanel.SetColumnSpan(this.useExpertmodeCheckbox, 3);
			this.useExpertmodeCheckbox.Location = new System.Drawing.Point(857, 37);
			this.useExpertmodeCheckbox.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.useExpertmodeCheckbox.Name = "useExpertmodeCheckbox";
			this.useExpertmodeCheckbox.Size = new System.Drawing.Size(174, 17);
			this.useExpertmodeCheckbox.TabIndex = 5;
			this.useExpertmodeCheckbox.Text = "Expertenmodus anzeigen";
			this.useExpertmodeCheckbox.UseVisualStyleBackColor = true;
			this.useExpertmodeCheckbox.CheckedChanged += new System.EventHandler(this.useExpertmodeCheckbox_CheckedChanged);
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
			this.splitContainer.Size = new System.Drawing.Size(1347, 762);
			this.splitContainer.SplitterDistance = 295;
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
			this.AcceptButton = this.saveTemplateButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1347, 762);
			this.Controls.Add(this.splitContainer);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "TemplateForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Templates bearbeiten";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateFormFormClosing);
			this.Load += new System.EventHandler(this.TemplateFormLoad);
			this.templateOverviewTableLayouPanel.ResumeLayout(false);
			this.templateOverviewTableLayouPanel.PerformLayout();
			this.editTemplateTableLayoutPanel.ResumeLayout(false);
			this.editTemplateTableLayoutPanel.PerformLayout();
			this.templateValuesTabControl.ResumeLayout(false);
			this.commonTabPage.ResumeLayout(false);
			this.templateCommonTableLayoutPannel.ResumeLayout(false);
			this.templateCommonTableLayoutPannel.PerformLayout();
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
			this.planVideosTabpage.ResumeLayout(false);
			this.planVideosTlp.ResumeLayout(false);
			this.planVideosTlp.PerformLayout();
			this.fillFieldsGroupbox.ResumeLayout(false);
			this.fillFieldsTlp.ResumeLayout(false);
			this.fillFieldsTlp.PerformLayout();
			this.sendMailTabPage.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.sendMailTlp.ResumeLayout(false);
			this.sendMailTlp.PerformLayout();
			this.notificationsGroupBox.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.cSharpTabPage.ResumeLayout(false);
			this.csTlp.ResumeLayout(false);
			this.csTlp.PerformLayout();
			this.cSharpScriptingTabControl.ResumeLayout(false);
			this.systemFunctionsTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cSharpSystemFunctionsFctb)).EndInit();
			this.usableVariablesTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.globalVarsFctb)).EndInit();
			this.referencedAssembliesTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.assemblyReferencesFctb)).EndInit();
			this.preparationScriptTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cSharpPrepareFctb)).EndInit();
			this.cleanUpScriptTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cSharpCleanupFctb)).EndInit();
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
		private System.Windows.Forms.TextBox templateTitleTextbox;
		private System.Windows.Forms.TextBox templateDescriptionTextbox;
		private System.Windows.Forms.TextBox templateTagsTextbox;
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
		private System.Windows.Forms.TextBox thumbnailTextbox;
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
		private Label csDescriptionLabel;
		private GroupBox fillFieldsGroupbox;
		private TableLayoutPanel fillFieldsTlp;
		private ListView fillFieldsListView;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private Label filenameFieldLabel;
		private Label filenameValueLabel;
		private TextBox fieldNameTxbx;
		private TextBox fieldValueTxbx;
		private TabControl cSharpScriptingTabControl;
		private TabPage systemFunctionsTabPage;
		private TabPage preparationScriptTabPage;
		private TabPage cleanUpScriptTabPage;
		private FastColoredTextBox cSharpSystemFunctionsFctb;
		private FastColoredTextBox cSharpPrepareFctb;
		private FastColoredTextBox cSharpCleanupFctb;
		private TabPage usableVariablesTabPage;
		private FastColoredTextBox globalVarsFctb;
		private CheckBox useExpertmodeCheckbox;
		private TabPage referencedAssembliesTabPage;
		private FastColoredTextBox assemblyReferencesFctb;
		private TabPage sendMailTabPage;
		private TableLayoutPanel sendMailTlp;
		private Label connectMailNotificationLabel;
		private TextBox mailRecipientTextbox;
		private GroupBox notificationsGroupBox;
		private Label mailRecipientLabel;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private CheckBox newVideoDNCheckbox;
		private CheckBox uploadStartedDNCheckbox;
		private CheckBox uploadFinishedDNCheckbox;
		private CheckBox uploadFailedDNCheckbox;
		private CheckBox newVideoMNCheckbox;
		private CheckBox uploadStartedMNCheckbox;
		private CheckBox uploadFinishedMNCheckbox;
		private CheckBox uploadFailedMNCheckbox;
		private TableLayoutPanel tableLayoutPanel1;
		private Label nextPublishTimeLabel;
		private DateTimePicker nextPublishTimeDtp;
	}
}