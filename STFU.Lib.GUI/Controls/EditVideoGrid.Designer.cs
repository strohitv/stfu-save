namespace STFU.Lib.GUI.Controls
{
	partial class EditVideoGrid
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
			this.mainTlp = new System.Windows.Forms.TableLayoutPanel();
			this.mainSettingsGroupbox = new System.Windows.Forms.GroupBox();
			this.mainSettingsTlp = new System.Windows.Forms.TableLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.tagsLabel = new System.Windows.Forms.Label();
			this.thumbnailLabel = new System.Windows.Forms.Label();
			this.privacyLabel = new System.Windows.Forms.Label();
			this.titleTextbox = new System.Windows.Forms.TextBox();
			this.descriptionTextbox = new System.Windows.Forms.TextBox();
			this.tagsTextbox = new System.Windows.Forms.TextBox();
			this.thumbnailTextbox = new System.Windows.Forms.TextBox();
			this.thumbnailButton = new System.Windows.Forms.Button();
			this.publishAtDatetimepicker = new System.Windows.Forms.DateTimePicker();
			this.publishAtCheckbox = new System.Windows.Forms.CheckBox();
			this.privacyCombobox = new System.Windows.Forms.ComboBox();
			this.otherSettingsGroupbox = new System.Windows.Forms.GroupBox();
			this.otherSettingsTlp = new System.Windows.Forms.TableLayoutPanel();
			this.licenseCombobox = new System.Windows.Forms.ComboBox();
			this.licenseLabel = new System.Windows.Forms.Label();
			this.isEmbeddableCheckbox = new System.Windows.Forms.CheckBox();
			this.publicStatsViewableCheckbox = new System.Windows.Forms.CheckBox();
			this.defaultLanguageLabel = new System.Windows.Forms.Label();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.categoryCombobox = new System.Windows.Forms.ComboBox();
			this.defaultLanguageCombobox = new System.Windows.Forms.ComboBox();
			this.autoLevelsCheckbox = new System.Windows.Forms.CheckBox();
			this.stabilizeCheckbox = new System.Windows.Forms.CheckBox();
			this.notifySubscribersCheckbox = new System.Windows.Forms.CheckBox();
			this.selectVideoDialog = new System.Windows.Forms.OpenFileDialog();
			this.mainTlp.SuspendLayout();
			this.mainSettingsGroupbox.SuspendLayout();
			this.mainSettingsTlp.SuspendLayout();
			this.otherSettingsGroupbox.SuspendLayout();
			this.otherSettingsTlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTlp
			// 
			this.mainTlp.ColumnCount = 3;
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Controls.Add(this.mainSettingsGroupbox, 1, 1);
			this.mainTlp.Controls.Add(this.otherSettingsGroupbox, 1, 3);
			this.mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTlp.Location = new System.Drawing.Point(0, 0);
			this.mainTlp.Name = "mainTlp";
			this.mainTlp.RowCount = 5;
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainTlp.Size = new System.Drawing.Size(1150, 824);
			this.mainTlp.TabIndex = 1;
			// 
			// mainSettingsGroupbox
			// 
			this.mainSettingsGroupbox.Controls.Add(this.mainSettingsTlp);
			this.mainSettingsGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSettingsGroupbox.Location = new System.Drawing.Point(10, 10);
			this.mainSettingsGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.mainSettingsGroupbox.Name = "mainSettingsGroupbox";
			this.mainSettingsGroupbox.Size = new System.Drawing.Size(1130, 522);
			this.mainSettingsGroupbox.TabIndex = 0;
			this.mainSettingsGroupbox.TabStop = false;
			this.mainSettingsGroupbox.Text = "Allgemeine Einstellungen";
			// 
			// mainSettingsTlp
			// 
			this.mainSettingsTlp.ColumnCount = 7;
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.Controls.Add(this.titleLabel, 1, 1);
			this.mainSettingsTlp.Controls.Add(this.descriptionLabel, 1, 3);
			this.mainSettingsTlp.Controls.Add(this.tagsLabel, 1, 6);
			this.mainSettingsTlp.Controls.Add(this.thumbnailLabel, 1, 9);
			this.mainSettingsTlp.Controls.Add(this.privacyLabel, 1, 11);
			this.mainSettingsTlp.Controls.Add(this.titleTextbox, 3, 1);
			this.mainSettingsTlp.Controls.Add(this.descriptionTextbox, 1, 4);
			this.mainSettingsTlp.Controls.Add(this.tagsTextbox, 1, 7);
			this.mainSettingsTlp.Controls.Add(this.thumbnailTextbox, 3, 9);
			this.mainSettingsTlp.Controls.Add(this.thumbnailButton, 5, 9);
			this.mainSettingsTlp.Controls.Add(this.publishAtDatetimepicker, 3, 13);
			this.mainSettingsTlp.Controls.Add(this.publishAtCheckbox, 1, 13);
			this.mainSettingsTlp.Controls.Add(this.privacyCombobox, 3, 11);
			this.mainSettingsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSettingsTlp.Location = new System.Drawing.Point(3, 16);
			this.mainSettingsTlp.Name = "mainSettingsTlp";
			this.mainSettingsTlp.RowCount = 15;
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.mainSettingsTlp.Size = new System.Drawing.Size(1124, 503);
			this.mainSettingsTlp.TabIndex = 0;
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(10, 16);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(176, 13);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Titel:";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionLabel.AutoSize = true;
			this.mainSettingsTlp.SetColumnSpan(this.descriptionLabel, 5);
			this.descriptionLabel.Location = new System.Drawing.Point(10, 46);
			this.descriptionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(1104, 13);
			this.descriptionLabel.TabIndex = 1;
			this.descriptionLabel.Text = "Beschreibung:";
			// 
			// tagsLabel
			// 
			this.tagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tagsLabel.AutoSize = true;
			this.mainSettingsTlp.SetColumnSpan(this.tagsLabel, 5);
			this.tagsLabel.Location = new System.Drawing.Point(10, 219);
			this.tagsLabel.Margin = new System.Windows.Forms.Padding(0);
			this.tagsLabel.Name = "tagsLabel";
			this.tagsLabel.Size = new System.Drawing.Size(1104, 13);
			this.tagsLabel.TabIndex = 2;
			this.tagsLabel.Text = "Tags:";
			// 
			// thumbnailLabel
			// 
			this.thumbnailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailLabel.AutoSize = true;
			this.thumbnailLabel.Location = new System.Drawing.Point(10, 400);
			this.thumbnailLabel.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailLabel.Name = "thumbnailLabel";
			this.thumbnailLabel.Size = new System.Drawing.Size(176, 13);
			this.thumbnailLabel.TabIndex = 3;
			this.thumbnailLabel.Text = "Thumbnail:";
			// 
			// privacyLabel
			// 
			this.privacyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.privacyLabel.AutoSize = true;
			this.privacyLabel.Location = new System.Drawing.Point(10, 437);
			this.privacyLabel.Margin = new System.Windows.Forms.Padding(0);
			this.privacyLabel.Name = "privacyLabel";
			this.privacyLabel.Size = new System.Drawing.Size(176, 13);
			this.privacyLabel.TabIndex = 4;
			this.privacyLabel.Text = "Sichtbarkeit:";
			// 
			// titleTextbox
			// 
			this.titleTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mainSettingsTlp.SetColumnSpan(this.titleTextbox, 3);
			this.titleTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleTextbox.Location = new System.Drawing.Point(196, 10);
			this.titleTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.titleTextbox.Name = "titleTextbox";
			this.titleTextbox.Size = new System.Drawing.Size(918, 26);
			this.titleTextbox.TabIndex = 6;
			this.titleTextbox.TextChanged += new System.EventHandler(this.titleTextbox_TextChanged);
			// 
			// descriptionTextbox
			// 
			this.descriptionTextbox.AcceptsReturn = true;
			this.mainSettingsTlp.SetColumnSpan(this.descriptionTextbox, 5);
			this.descriptionTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descriptionTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.descriptionTextbox.Location = new System.Drawing.Point(10, 59);
			this.descriptionTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.descriptionTextbox.Multiline = true;
			this.descriptionTextbox.Name = "descriptionTextbox";
			this.descriptionTextbox.Size = new System.Drawing.Size(1104, 150);
			this.descriptionTextbox.TabIndex = 7;
			this.descriptionTextbox.TextChanged += new System.EventHandler(this.descriptionTextbox_TextChanged);
			// 
			// tagsTextbox
			// 
			this.tagsTextbox.AcceptsReturn = true;
			this.mainSettingsTlp.SetColumnSpan(this.tagsTextbox, 5);
			this.tagsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tagsTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tagsTextbox.Location = new System.Drawing.Point(10, 232);
			this.tagsTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.tagsTextbox.Multiline = true;
			this.tagsTextbox.Name = "tagsTextbox";
			this.tagsTextbox.Size = new System.Drawing.Size(1104, 150);
			this.tagsTextbox.TabIndex = 8;
			this.tagsTextbox.TextChanged += new System.EventHandler(this.tagsTextbox_TextChanged);
			// 
			// thumbnailTextbox
			// 
			this.thumbnailTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.thumbnailTextbox.Location = new System.Drawing.Point(196, 393);
			this.thumbnailTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailTextbox.Name = "thumbnailTextbox";
			this.thumbnailTextbox.Size = new System.Drawing.Size(846, 26);
			this.thumbnailTextbox.TabIndex = 9;
			this.thumbnailTextbox.TextChanged += new System.EventHandler(this.thumbnailTextbox_TextChanged);
			// 
			// thumbnailButton
			// 
			this.thumbnailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailButton.AutoSize = true;
			this.thumbnailButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.thumbnailButton.Location = new System.Drawing.Point(1052, 392);
			this.thumbnailButton.Margin = new System.Windows.Forms.Padding(0);
			this.thumbnailButton.Name = "thumbnailButton";
			this.thumbnailButton.Padding = new System.Windows.Forms.Padding(15, 3, 15, 3);
			this.thumbnailButton.Size = new System.Drawing.Size(62, 29);
			this.thumbnailButton.TabIndex = 10;
			this.thumbnailButton.Text = "[...]";
			this.thumbnailButton.UseVisualStyleBackColor = true;
			// 
			// publishAtDatetimepicker
			// 
			this.publishAtDatetimepicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mainSettingsTlp.SetColumnSpan(this.publishAtDatetimepicker, 3);
			this.publishAtDatetimepicker.CustomFormat = "dd.MM.yyyy HH:mm";
			this.publishAtDatetimepicker.Enabled = false;
			this.publishAtDatetimepicker.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.publishAtDatetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.publishAtDatetimepicker.Location = new System.Drawing.Point(196, 467);
			this.publishAtDatetimepicker.Margin = new System.Windows.Forms.Padding(0);
			this.publishAtDatetimepicker.Name = "publishAtDatetimepicker";
			this.publishAtDatetimepicker.Size = new System.Drawing.Size(918, 26);
			this.publishAtDatetimepicker.TabIndex = 12;
			this.publishAtDatetimepicker.ValueChanged += new System.EventHandler(this.publishAtDatetimepicker_ValueChanged);
			// 
			// publishAtCheckbox
			// 
			this.publishAtCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.publishAtCheckbox.AutoSize = true;
			this.publishAtCheckbox.Enabled = false;
			this.publishAtCheckbox.Location = new System.Drawing.Point(13, 471);
			this.publishAtCheckbox.Name = "publishAtCheckbox";
			this.publishAtCheckbox.Size = new System.Drawing.Size(170, 17);
			this.publishAtCheckbox.TabIndex = 13;
			this.publishAtCheckbox.Text = "Video geplant veröffentlichen: ";
			this.publishAtCheckbox.UseVisualStyleBackColor = true;
			this.publishAtCheckbox.CheckedChanged += new System.EventHandler(this.publishAtCheckbox_CheckedChanged);
			// 
			// privacyCombobox
			// 
			this.mainSettingsTlp.SetColumnSpan(this.privacyCombobox, 3);
			this.privacyCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.privacyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.privacyCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.privacyCombobox.FormattingEnabled = true;
			this.privacyCombobox.Items.AddRange(new object[] {
            "Öffentlich",
            "Nicht gelistet",
            "Privat"});
			this.privacyCombobox.Location = new System.Drawing.Point(196, 431);
			this.privacyCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.privacyCombobox.Name = "privacyCombobox";
			this.privacyCombobox.Size = new System.Drawing.Size(918, 26);
			this.privacyCombobox.TabIndex = 11;
			this.privacyCombobox.SelectedIndexChanged += new System.EventHandler(this.privacyCombobox_SelectedIndexChanged);
			// 
			// otherSettingsGroupbox
			// 
			this.otherSettingsGroupbox.AutoSize = true;
			this.otherSettingsGroupbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.otherSettingsGroupbox.Controls.Add(this.otherSettingsTlp);
			this.otherSettingsGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.otherSettingsGroupbox.Location = new System.Drawing.Point(10, 542);
			this.otherSettingsGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.otherSettingsGroupbox.Name = "otherSettingsGroupbox";
			this.otherSettingsGroupbox.Size = new System.Drawing.Size(1130, 272);
			this.otherSettingsGroupbox.TabIndex = 1;
			this.otherSettingsGroupbox.TabStop = false;
			this.otherSettingsGroupbox.Text = "Weitere Einstellungen";
			// 
			// otherSettingsTlp
			// 
			this.otherSettingsTlp.AutoSize = true;
			this.otherSettingsTlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.otherSettingsTlp.ColumnCount = 5;
			this.otherSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.otherSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.otherSettingsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.Controls.Add(this.licenseCombobox, 3, 5);
			this.otherSettingsTlp.Controls.Add(this.licenseLabel, 1, 5);
			this.otherSettingsTlp.Controls.Add(this.isEmbeddableCheckbox, 1, 7);
			this.otherSettingsTlp.Controls.Add(this.publicStatsViewableCheckbox, 1, 9);
			this.otherSettingsTlp.Controls.Add(this.defaultLanguageLabel, 1, 3);
			this.otherSettingsTlp.Controls.Add(this.categoryLabel, 1, 1);
			this.otherSettingsTlp.Controls.Add(this.categoryCombobox, 3, 1);
			this.otherSettingsTlp.Controls.Add(this.defaultLanguageCombobox, 3, 3);
			this.otherSettingsTlp.Controls.Add(this.autoLevelsCheckbox, 1, 13);
			this.otherSettingsTlp.Controls.Add(this.stabilizeCheckbox, 1, 15);
			this.otherSettingsTlp.Controls.Add(this.notifySubscribersCheckbox, 1, 11);
			this.otherSettingsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.otherSettingsTlp.Location = new System.Drawing.Point(3, 16);
			this.otherSettingsTlp.Name = "otherSettingsTlp";
			this.otherSettingsTlp.RowCount = 17;
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.otherSettingsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.otherSettingsTlp.Size = new System.Drawing.Size(1124, 253);
			this.otherSettingsTlp.TabIndex = 0;
			// 
			// licenseCombobox
			// 
			this.licenseCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.licenseCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.licenseCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.licenseCombobox.FormattingEnabled = true;
			this.licenseCombobox.Items.AddRange(new object[] {
            "Standard-Youtube-Lizenz",
            "Creative-Commons - Namensnennung"});
			this.licenseCombobox.Location = new System.Drawing.Point(178, 82);
			this.licenseCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.licenseCombobox.Name = "licenseCombobox";
			this.licenseCombobox.Size = new System.Drawing.Size(936, 26);
			this.licenseCombobox.TabIndex = 18;
			this.licenseCombobox.SelectedIndexChanged += new System.EventHandler(this.licenseCombobox_SelectedIndexChanged);
			// 
			// licenseLabel
			// 
			this.licenseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.licenseLabel.AutoSize = true;
			this.licenseLabel.Location = new System.Drawing.Point(10, 88);
			this.licenseLabel.Margin = new System.Windows.Forms.Padding(0);
			this.licenseLabel.Name = "licenseLabel";
			this.licenseLabel.Size = new System.Drawing.Size(158, 13);
			this.licenseLabel.TabIndex = 10;
			this.licenseLabel.Text = "Lizenzen und Eigentumsrechte: ";
			// 
			// isEmbeddableCheckbox
			// 
			this.isEmbeddableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.isEmbeddableCheckbox.AutoSize = true;
			this.otherSettingsTlp.SetColumnSpan(this.isEmbeddableCheckbox, 3);
			this.isEmbeddableCheckbox.Location = new System.Drawing.Point(10, 118);
			this.isEmbeddableCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.isEmbeddableCheckbox.Name = "isEmbeddableCheckbox";
			this.isEmbeddableCheckbox.Size = new System.Drawing.Size(1104, 17);
			this.isEmbeddableCheckbox.TabIndex = 11;
			this.isEmbeddableCheckbox.Text = "Einbetten zulassen";
			this.isEmbeddableCheckbox.UseVisualStyleBackColor = true;
			this.isEmbeddableCheckbox.CheckedChanged += new System.EventHandler(this.isEmbeddableCheckbox_CheckedChanged);
			// 
			// publicStatsViewableCheckbox
			// 
			this.publicStatsViewableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.publicStatsViewableCheckbox.AutoSize = true;
			this.otherSettingsTlp.SetColumnSpan(this.publicStatsViewableCheckbox, 3);
			this.publicStatsViewableCheckbox.Location = new System.Drawing.Point(10, 145);
			this.publicStatsViewableCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.publicStatsViewableCheckbox.Name = "publicStatsViewableCheckbox";
			this.publicStatsViewableCheckbox.Size = new System.Drawing.Size(1104, 17);
			this.publicStatsViewableCheckbox.TabIndex = 15;
			this.publicStatsViewableCheckbox.Text = "Videostatistik auf der Wiedergabeseite öffentlich sichtbar machen";
			this.publicStatsViewableCheckbox.UseVisualStyleBackColor = true;
			this.publicStatsViewableCheckbox.CheckedChanged += new System.EventHandler(this.publicStatsViewableCheckbox_CheckedChanged);
			// 
			// defaultLanguageLabel
			// 
			this.defaultLanguageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.defaultLanguageLabel.AutoSize = true;
			this.defaultLanguageLabel.Location = new System.Drawing.Point(10, 52);
			this.defaultLanguageLabel.Margin = new System.Windows.Forms.Padding(0);
			this.defaultLanguageLabel.Name = "defaultLanguageLabel";
			this.defaultLanguageLabel.Size = new System.Drawing.Size(158, 13);
			this.defaultLanguageLabel.TabIndex = 9;
			this.defaultLanguageLabel.Text = "Videosprache: ";
			// 
			// categoryLabel
			// 
			this.categoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.Location = new System.Drawing.Point(10, 16);
			this.categoryLabel.Margin = new System.Windows.Forms.Padding(0);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(158, 13);
			this.categoryLabel.TabIndex = 8;
			this.categoryLabel.Text = "Kategorie: ";
			// 
			// categoryCombobox
			// 
			this.categoryCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.categoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.categoryCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.categoryCombobox.FormattingEnabled = true;
			this.categoryCombobox.Location = new System.Drawing.Point(178, 10);
			this.categoryCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.categoryCombobox.Name = "categoryCombobox";
			this.categoryCombobox.Size = new System.Drawing.Size(936, 26);
			this.categoryCombobox.TabIndex = 16;
			this.categoryCombobox.SelectedIndexChanged += new System.EventHandler(this.categoryCombobox_SelectedIndexChanged);
			// 
			// defaultLanguageCombobox
			// 
			this.defaultLanguageCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.defaultLanguageCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.defaultLanguageCombobox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.defaultLanguageCombobox.FormattingEnabled = true;
			this.defaultLanguageCombobox.Location = new System.Drawing.Point(178, 46);
			this.defaultLanguageCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.defaultLanguageCombobox.Name = "defaultLanguageCombobox";
			this.defaultLanguageCombobox.Size = new System.Drawing.Size(936, 26);
			this.defaultLanguageCombobox.TabIndex = 17;
			this.defaultLanguageCombobox.SelectedIndexChanged += new System.EventHandler(this.defaultLanguageCombobox_SelectedIndexChanged);
			// 
			// autoLevelsCheckbox
			// 
			this.autoLevelsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.autoLevelsCheckbox.AutoSize = true;
			this.otherSettingsTlp.SetColumnSpan(this.autoLevelsCheckbox, 3);
			this.autoLevelsCheckbox.Location = new System.Drawing.Point(10, 199);
			this.autoLevelsCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.autoLevelsCheckbox.Name = "autoLevelsCheckbox";
			this.autoLevelsCheckbox.Size = new System.Drawing.Size(1104, 17);
			this.autoLevelsCheckbox.TabIndex = 13;
			this.autoLevelsCheckbox.Text = "Helligkeit und Farben automatisch von Youtube verbessern lassen";
			this.autoLevelsCheckbox.UseVisualStyleBackColor = true;
			this.autoLevelsCheckbox.CheckedChanged += new System.EventHandler(this.autoLevelsCheckbox_CheckedChanged);
			// 
			// stabilizeCheckbox
			// 
			this.stabilizeCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.stabilizeCheckbox.AutoSize = true;
			this.otherSettingsTlp.SetColumnSpan(this.stabilizeCheckbox, 3);
			this.stabilizeCheckbox.Location = new System.Drawing.Point(10, 226);
			this.stabilizeCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.stabilizeCheckbox.Name = "stabilizeCheckbox";
			this.stabilizeCheckbox.Size = new System.Drawing.Size(1104, 17);
			this.stabilizeCheckbox.TabIndex = 14;
			this.stabilizeCheckbox.Text = "Bildstabilisierung automatisch von Youtube durchführen lassen";
			this.stabilizeCheckbox.UseVisualStyleBackColor = true;
			this.stabilizeCheckbox.CheckedChanged += new System.EventHandler(this.stabilizeCheckbox_CheckedChanged);
			// 
			// notifySubscribersCheckbox
			// 
			this.notifySubscribersCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.notifySubscribersCheckbox.AutoSize = true;
			this.otherSettingsTlp.SetColumnSpan(this.notifySubscribersCheckbox, 3);
			this.notifySubscribersCheckbox.Location = new System.Drawing.Point(10, 172);
			this.notifySubscribersCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.notifySubscribersCheckbox.Name = "notifySubscribersCheckbox";
			this.notifySubscribersCheckbox.Size = new System.Drawing.Size(1104, 17);
			this.notifySubscribersCheckbox.TabIndex = 12;
			this.notifySubscribersCheckbox.Text = "Im Abofeed veröffentlichen und Abonnenten benachrichtigen";
			this.notifySubscribersCheckbox.UseVisualStyleBackColor = true;
			this.notifySubscribersCheckbox.CheckedChanged += new System.EventHandler(this.notifySubscribersCheckbox_CheckedChanged);
			// 
			// selectVideoDialog
			// 
			this.selectVideoDialog.Filter = "Video-Dateien|*.mkv;*.mp4;*.mov;*.avi;*.flv;*.webm|MKV-Videos|*.mkv|MP4-Videos|*." +
    "mp4;|MOV-Videos|*.mov|AVI-Videos|*.avi|Flash-Videos|*.flv|WEBM-Videos|*.flv|Alle" +
    " Dateien|*.*";
			this.selectVideoDialog.Title = "Bitte Video zum Upload auswählen...";
			// 
			// EditVideoGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainTlp);
			this.Name = "EditVideoGrid";
			this.Size = new System.Drawing.Size(1150, 824);
			this.mainTlp.ResumeLayout(false);
			this.mainTlp.PerformLayout();
			this.mainSettingsGroupbox.ResumeLayout(false);
			this.mainSettingsTlp.ResumeLayout(false);
			this.mainSettingsTlp.PerformLayout();
			this.otherSettingsGroupbox.ResumeLayout(false);
			this.otherSettingsGroupbox.PerformLayout();
			this.otherSettingsTlp.ResumeLayout(false);
			this.otherSettingsTlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTlp;
		private System.Windows.Forms.GroupBox mainSettingsGroupbox;
		private System.Windows.Forms.GroupBox otherSettingsGroupbox;
		private System.Windows.Forms.TableLayoutPanel mainSettingsTlp;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.Label tagsLabel;
		private System.Windows.Forms.Label thumbnailLabel;
		private System.Windows.Forms.Label privacyLabel;
		private System.Windows.Forms.TextBox titleTextbox;
		private System.Windows.Forms.TextBox descriptionTextbox;
		private System.Windows.Forms.TextBox tagsTextbox;
		private System.Windows.Forms.TextBox thumbnailTextbox;
		private System.Windows.Forms.Button thumbnailButton;
		private System.Windows.Forms.ComboBox privacyCombobox;
		private System.Windows.Forms.DateTimePicker publishAtDatetimepicker;
		private System.Windows.Forms.CheckBox publishAtCheckbox;
		private System.Windows.Forms.TableLayoutPanel otherSettingsTlp;
		private System.Windows.Forms.CheckBox stabilizeCheckbox;
		private System.Windows.Forms.CheckBox notifySubscribersCheckbox;
		private System.Windows.Forms.Label defaultLanguageLabel;
		private System.Windows.Forms.ComboBox licenseCombobox;
		private System.Windows.Forms.Label licenseLabel;
		private System.Windows.Forms.CheckBox isEmbeddableCheckbox;
		private System.Windows.Forms.CheckBox autoLevelsCheckbox;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.CheckBox publicStatsViewableCheckbox;
		private System.Windows.Forms.ComboBox defaultLanguageCombobox;
		private System.Windows.Forms.ComboBox categoryCombobox;
		private System.Windows.Forms.OpenFileDialog selectVideoDialog;
	}
}
