namespace STFU.Executable.AutoUploader.Forms
{
	partial class PathForm
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
			this.chosePathTlp = new System.Windows.Forms.TableLayoutPanel();
			this.lvPaths = new System.Windows.Forms.ListView();
			this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTemplate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbInactive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbMoveAfterUpload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.addPathButton = new System.Windows.Forms.Button();
			this.movePathUpButton = new System.Windows.Forms.Button();
			this.movePathDownButton = new System.Windows.Forms.Button();
			this.deletePathButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.editPathGroupbox = new System.Windows.Forms.GroupBox();
			this.tlpEditPaths = new System.Windows.Forms.TableLayoutPanel();
			this.txtbxAddPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSelectPath = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbxAddFilter = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.cobSelectedTemplate = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.deactivateCheckbox = new System.Windows.Forms.CheckBox();
			this.chbRecursive = new System.Windows.Forms.CheckBox();
			this.chbHidden = new System.Windows.Forms.CheckBox();
			this.btnMarkAsRead = new System.Windows.Forms.Button();
			this.moveAfterUploadCheckbox = new System.Windows.Forms.CheckBox();
			this.moveAfterUploadTextbox = new System.Windows.Forms.TextBox();
			this.moveAfterUploadButton = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.selectMovePathDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.searchOrderCombobox = new System.Windows.Forms.ComboBox();
			this.chosePathTlp.SuspendLayout();
			this.editPathGroupbox.SuspendLayout();
			this.tlpEditPaths.SuspendLayout();
			this.SuspendLayout();
			// 
			// chosePathTlp
			// 
			this.chosePathTlp.ColumnCount = 7;
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.chosePathTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.Controls.Add(this.lvPaths, 3, 3);
			this.chosePathTlp.Controls.Add(this.addPathButton, 1, 3);
			this.chosePathTlp.Controls.Add(this.movePathUpButton, 1, 5);
			this.chosePathTlp.Controls.Add(this.movePathDownButton, 1, 7);
			this.chosePathTlp.Controls.Add(this.deletePathButton, 1, 9);
			this.chosePathTlp.Controls.Add(this.clearButton, 1, 11);
			this.chosePathTlp.Controls.Add(this.editPathGroupbox, 1, 14);
			this.chosePathTlp.Controls.Add(this.label1, 1, 1);
			this.chosePathTlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chosePathTlp.Location = new System.Drawing.Point(0, 0);
			this.chosePathTlp.Margin = new System.Windows.Forms.Padding(2);
			this.chosePathTlp.Name = "chosePathTlp";
			this.chosePathTlp.RowCount = 16;
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.chosePathTlp.Size = new System.Drawing.Size(1107, 641);
			this.chosePathTlp.TabIndex = 0;
			// 
			// lvPaths
			// 
			this.lvPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath,
            this.chFilter,
            this.chTemplate,
            this.chRecursive,
            this.chHidden,
            this.cbInactive,
            this.cbMoveAfterUpload});
			this.chosePathTlp.SetColumnSpan(this.lvPaths, 3);
			this.lvPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvPaths.FullRowSelect = true;
			this.lvPaths.GridLines = true;
			this.lvPaths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPaths.HideSelection = false;
			this.lvPaths.Location = new System.Drawing.Point(56, 28);
			this.lvPaths.Margin = new System.Windows.Forms.Padding(0);
			this.lvPaths.MultiSelect = false;
			this.lvPaths.Name = "lvPaths";
			this.chosePathTlp.SetRowSpan(this.lvPaths, 10);
			this.lvPaths.ShowGroups = false;
			this.lvPaths.Size = new System.Drawing.Size(1041, 373);
			this.lvPaths.TabIndex = 10;
			this.lvPaths.UseCompatibleStateImageBehavior = false;
			this.lvPaths.View = System.Windows.Forms.View.Details;
			this.lvPaths.SelectedIndexChanged += new System.EventHandler(this.lvSelectedPathsSelectedIndexChanged);
			this.lvPaths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSelectedPathsKeyDown);
			// 
			// chPath
			// 
			this.chPath.Text = "Pfad";
			this.chPath.Width = 337;
			// 
			// chFilter
			// 
			this.chFilter.Text = "Filter";
			this.chFilter.Width = 150;
			// 
			// chTemplate
			// 
			this.chTemplate.Text = "Template";
			this.chTemplate.Width = 150;
			// 
			// chRecursive
			// 
			this.chRecursive.Text = "Unterverzeichnisse";
			this.chRecursive.Width = 150;
			// 
			// chHidden
			// 
			this.chHidden.Text = "Versteckte";
			this.chHidden.Width = 80;
			// 
			// cbInactive
			// 
			this.cbInactive.Text = "Inaktiv";
			// 
			// cbMoveAfterUpload
			// 
			this.cbMoveAfterUpload.Text = "Verschieben";
			this.cbMoveAfterUpload.Width = 80;
			// 
			// addPathButton
			// 
			this.addPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.addPathButton.AutoSize = true;
			this.addPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addPathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addPathButton.ForeColor = System.Drawing.Color.ForestGreen;
			this.addPathButton.Location = new System.Drawing.Point(10, 28);
			this.addPathButton.Margin = new System.Windows.Forms.Padding(0);
			this.addPathButton.Name = "addPathButton";
			this.addPathButton.Size = new System.Drawing.Size(41, 41);
			this.addPathButton.TabIndex = 1;
			this.addPathButton.Text = "+";
			this.toolTip.SetToolTip(this.addPathButton, "Fügt einen neuen Pfad hinzu");
			this.addPathButton.UseVisualStyleBackColor = true;
			this.addPathButton.Click += new System.EventHandler(this.AddPathButtonClick);
			// 
			// movePathUpButton
			// 
			this.movePathUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.movePathUpButton.AutoSize = true;
			this.movePathUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.movePathUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.movePathUpButton.Location = new System.Drawing.Point(10, 74);
			this.movePathUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathUpButton.Name = "movePathUpButton";
			this.movePathUpButton.Size = new System.Drawing.Size(41, 41);
			this.movePathUpButton.TabIndex = 1;
			this.movePathUpButton.Text = "↑";
			this.toolTip.SetToolTip(this.movePathUpButton, "Schiebt den markierten Pfad um eine Stelle nach oben");
			this.movePathUpButton.UseVisualStyleBackColor = true;
			this.movePathUpButton.Click += new System.EventHandler(this.movePathUpButtonClick);
			// 
			// movePathDownButton
			// 
			this.movePathDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.movePathDownButton.AutoSize = true;
			this.movePathDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.movePathDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.movePathDownButton.Location = new System.Drawing.Point(10, 120);
			this.movePathDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.movePathDownButton.Name = "movePathDownButton";
			this.movePathDownButton.Size = new System.Drawing.Size(41, 41);
			this.movePathDownButton.TabIndex = 1;
			this.movePathDownButton.Text = "↓";
			this.toolTip.SetToolTip(this.movePathDownButton, "Schiebt den markierten Pfad um eine Stelle nach unten");
			this.movePathDownButton.UseVisualStyleBackColor = true;
			this.movePathDownButton.Click += new System.EventHandler(this.movePathDownButtonClick);
			// 
			// deletePathButton
			// 
			this.deletePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.deletePathButton.AutoSize = true;
			this.deletePathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deletePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deletePathButton.ForeColor = System.Drawing.Color.Red;
			this.deletePathButton.Location = new System.Drawing.Point(10, 166);
			this.deletePathButton.Margin = new System.Windows.Forms.Padding(0);
			this.deletePathButton.Name = "deletePathButton";
			this.deletePathButton.Size = new System.Drawing.Size(41, 41);
			this.deletePathButton.TabIndex = 1;
			this.deletePathButton.Text = "-";
			this.toolTip.SetToolTip(this.deletePathButton, "Löscht den markierten Pfad");
			this.deletePathButton.UseVisualStyleBackColor = true;
			this.deletePathButton.Click += new System.EventHandler(this.deletePathButtonClick);
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.AutoSize = true;
			this.clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearButton.ForeColor = System.Drawing.Color.Red;
			this.clearButton.Location = new System.Drawing.Point(10, 212);
			this.clearButton.Margin = new System.Windows.Forms.Padding(0);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(41, 41);
			this.clearButton.TabIndex = 1;
			this.clearButton.Text = "x";
			this.toolTip.SetToolTip(this.clearButton, "Löscht alle Pfade");
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButtonClick);
			// 
			// editPathGroupbox
			// 
			this.editPathGroupbox.AutoSize = true;
			this.editPathGroupbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.chosePathTlp.SetColumnSpan(this.editPathGroupbox, 5);
			this.editPathGroupbox.Controls.Add(this.tlpEditPaths);
			this.editPathGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editPathGroupbox.Location = new System.Drawing.Point(10, 411);
			this.editPathGroupbox.Margin = new System.Windows.Forms.Padding(0);
			this.editPathGroupbox.Name = "editPathGroupbox";
			this.editPathGroupbox.Padding = new System.Windows.Forms.Padding(2);
			this.editPathGroupbox.Size = new System.Drawing.Size(1087, 220);
			this.editPathGroupbox.TabIndex = 13;
			this.editPathGroupbox.TabStop = false;
			this.editPathGroupbox.Text = "Pfad bearbeiten";
			// 
			// tlpEditPaths
			// 
			this.tlpEditPaths.AutoSize = true;
			this.tlpEditPaths.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpEditPaths.ColumnCount = 15;
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpEditPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.Controls.Add(this.txtbxAddPath, 5, 1);
			this.tlpEditPaths.Controls.Add(this.label2, 1, 1);
			this.tlpEditPaths.Controls.Add(this.btnSelectPath, 13, 1);
			this.tlpEditPaths.Controls.Add(this.label3, 1, 3);
			this.tlpEditPaths.Controls.Add(this.txtbxAddFilter, 5, 3);
			this.tlpEditPaths.Controls.Add(this.btnSave, 1, 11);
			this.tlpEditPaths.Controls.Add(this.cobSelectedTemplate, 5, 5);
			this.tlpEditPaths.Controls.Add(this.label4, 1, 5);
			this.tlpEditPaths.Controls.Add(this.deactivateCheckbox, 13, 5);
			this.tlpEditPaths.Controls.Add(this.chbRecursive, 11, 3);
			this.tlpEditPaths.Controls.Add(this.chbHidden, 13, 3);
			this.tlpEditPaths.Controls.Add(this.btnMarkAsRead, 9, 5);
			this.tlpEditPaths.Controls.Add(this.moveAfterUploadCheckbox, 1, 7);
			this.tlpEditPaths.Controls.Add(this.moveAfterUploadTextbox, 5, 7);
			this.tlpEditPaths.Controls.Add(this.moveAfterUploadButton, 13, 7);
			this.tlpEditPaths.Controls.Add(this.btnCancel, 3, 11);
			this.tlpEditPaths.Controls.Add(this.label5, 1, 9);
			this.tlpEditPaths.Controls.Add(this.searchOrderCombobox, 5, 9);
			this.tlpEditPaths.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpEditPaths.Enabled = false;
			this.tlpEditPaths.Location = new System.Drawing.Point(2, 15);
			this.tlpEditPaths.Margin = new System.Windows.Forms.Padding(0);
			this.tlpEditPaths.Name = "tlpEditPaths";
			this.tlpEditPaths.RowCount = 13;
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpEditPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpEditPaths.Size = new System.Drawing.Size(1083, 203);
			this.tlpEditPaths.TabIndex = 0;
			// 
			// txtbxAddPath
			// 
			this.txtbxAddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEditPaths.SetColumnSpan(this.txtbxAddPath, 7);
			this.txtbxAddPath.Location = new System.Drawing.Point(186, 11);
			this.txtbxAddPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddPath.Name = "txtbxAddPath";
			this.txtbxAddPath.Size = new System.Drawing.Size(765, 20);
			this.txtbxAddPath.TabIndex = 12;
			this.toolTip.SetToolTip(this.txtbxAddPath, "Der zu überwachende Pfad");
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 15);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Pfad: ";
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSelectPath.Location = new System.Drawing.Point(961, 10);
			this.btnSelectPath.Margin = new System.Windows.Forms.Padding(0);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(112, 23);
			this.btnSelectPath.TabIndex = 13;
			this.btnSelectPath.Text = "Pfad wählen";
			this.btnSelectPath.UseVisualStyleBackColor = true;
			this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPathClick);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 46);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Dateifilter: ";
			// 
			// txtbxAddFilter
			// 
			this.txtbxAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEditPaths.SetColumnSpan(this.txtbxAddFilter, 5);
			this.txtbxAddFilter.Location = new System.Drawing.Point(186, 43);
			this.txtbxAddFilter.Margin = new System.Windows.Forms.Padding(0);
			this.txtbxAddFilter.Name = "txtbxAddFilter";
			this.txtbxAddFilter.Size = new System.Drawing.Size(639, 20);
			this.txtbxAddFilter.TabIndex = 15;
			this.toolTip.SetToolTip(this.txtbxAddFilter, "Hier kannst du einstellen, nach welchen Kriterien die Videos gesucht werden solle" +
        "n.");
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSave.Location = new System.Drawing.Point(10, 170);
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
			this.btnSave.Size = new System.Drawing.Size(103, 23);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSaveClick);
			// 
			// cobSelectedTemplate
			// 
			this.cobSelectedTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEditPaths.SetColumnSpan(this.cobSelectedTemplate, 3);
			this.cobSelectedTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobSelectedTemplate.FormattingEnabled = true;
			this.cobSelectedTemplate.Location = new System.Drawing.Point(186, 74);
			this.cobSelectedTemplate.Margin = new System.Windows.Forms.Padding(0);
			this.cobSelectedTemplate.Name = "cobSelectedTemplate";
			this.cobSelectedTemplate.Size = new System.Drawing.Size(518, 21);
			this.cobSelectedTemplate.TabIndex = 19;
			this.toolTip.SetToolTip(this.cobSelectedTemplate, "Das Template, dass auf gefundene Videodateien unterhalb dieses Pfades angewandt w" +
        "erden soll.");
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 78);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Template: ";
			// 
			// deactivateCheckbox
			// 
			this.deactivateCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.deactivateCheckbox.AutoSize = true;
			this.deactivateCheckbox.Location = new System.Drawing.Point(961, 76);
			this.deactivateCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.deactivateCheckbox.Name = "deactivateCheckbox";
			this.deactivateCheckbox.Size = new System.Drawing.Size(112, 17);
			this.deactivateCheckbox.TabIndex = 16;
			this.deactivateCheckbox.Text = "Inaktiv";
			this.toolTip.SetToolTip(this.deactivateCheckbox, "Wenn diese Option gewählt wird, wird der Pfad deaktiviert. Er wird bis zum Entfer" +
        "nen des Hakens vom Uploader nicht mehr berücksichtigt.");
			this.deactivateCheckbox.UseVisualStyleBackColor = true;
			// 
			// chbRecursive
			// 
			this.chbRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbRecursive.AutoSize = true;
			this.chbRecursive.Location = new System.Drawing.Point(835, 44);
			this.chbRecursive.Margin = new System.Windows.Forms.Padding(0);
			this.chbRecursive.Name = "chbRecursive";
			this.chbRecursive.Size = new System.Drawing.Size(116, 17);
			this.chbRecursive.TabIndex = 16;
			this.chbRecursive.Text = "Unterverzeichnisse";
			this.toolTip.SetToolTip(this.chbRecursive, "Wenn diese Option gewählt wird, werden alle unter dem Verzeichnis liegenden Ordne" +
        "r (und deren Unterordner usw.) durchsucht.");
			this.chbRecursive.UseVisualStyleBackColor = true;
			this.chbRecursive.CheckedChanged += new System.EventHandler(this.chbRecursiveCheckedChanged);
			// 
			// chbHidden
			// 
			this.chbHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbHidden.AutoSize = true;
			this.chbHidden.Location = new System.Drawing.Point(961, 44);
			this.chbHidden.Margin = new System.Windows.Forms.Padding(0);
			this.chbHidden.Name = "chbHidden";
			this.chbHidden.Size = new System.Drawing.Size(112, 17);
			this.chbHidden.TabIndex = 16;
			this.chbHidden.Text = "Versteckte Ordner";
			this.toolTip.SetToolTip(this.chbHidden, "Wenn diese Option gewählt wird, werden auch versteckte Unterordner durchsucht.");
			this.chbHidden.UseVisualStyleBackColor = true;
			// 
			// btnMarkAsRead
			// 
			this.btnMarkAsRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMarkAsRead.AutoSize = true;
			this.tlpEditPaths.SetColumnSpan(this.btnMarkAsRead, 3);
			this.btnMarkAsRead.Location = new System.Drawing.Point(714, 73);
			this.btnMarkAsRead.Margin = new System.Windows.Forms.Padding(0);
			this.btnMarkAsRead.Name = "btnMarkAsRead";
			this.btnMarkAsRead.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
			this.btnMarkAsRead.Size = new System.Drawing.Size(237, 23);
			this.btnMarkAsRead.TabIndex = 17;
			this.btnMarkAsRead.Text = "Alle Videos als hochgeladen markieren";
			this.btnMarkAsRead.UseVisualStyleBackColor = true;
			this.btnMarkAsRead.Click += new System.EventHandler(this.btnMarkAsReadClick);
			// 
			// moveAfterUploadCheckbox
			// 
			this.moveAfterUploadCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.moveAfterUploadCheckbox.AutoSize = true;
			this.tlpEditPaths.SetColumnSpan(this.moveAfterUploadCheckbox, 3);
			this.moveAfterUploadCheckbox.Location = new System.Drawing.Point(10, 109);
			this.moveAfterUploadCheckbox.Margin = new System.Windows.Forms.Padding(0);
			this.moveAfterUploadCheckbox.Name = "moveAfterUploadCheckbox";
			this.moveAfterUploadCheckbox.Size = new System.Drawing.Size(166, 17);
			this.moveAfterUploadCheckbox.TabIndex = 16;
			this.moveAfterUploadCheckbox.Text = "Nach Upload verschieben: ";
			this.moveAfterUploadCheckbox.UseVisualStyleBackColor = true;
			this.moveAfterUploadCheckbox.CheckedChanged += new System.EventHandler(this.moveAfterUploadCheckbox_CheckedChanged);
			// 
			// moveAfterUploadTextbox
			// 
			this.moveAfterUploadTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEditPaths.SetColumnSpan(this.moveAfterUploadTextbox, 7);
			this.moveAfterUploadTextbox.Enabled = false;
			this.moveAfterUploadTextbox.Location = new System.Drawing.Point(186, 107);
			this.moveAfterUploadTextbox.Margin = new System.Windows.Forms.Padding(0);
			this.moveAfterUploadTextbox.Name = "moveAfterUploadTextbox";
			this.moveAfterUploadTextbox.Size = new System.Drawing.Size(765, 20);
			this.moveAfterUploadTextbox.TabIndex = 12;
			// 
			// moveAfterUploadButton
			// 
			this.moveAfterUploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.moveAfterUploadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moveAfterUploadButton.Enabled = false;
			this.moveAfterUploadButton.Location = new System.Drawing.Point(961, 106);
			this.moveAfterUploadButton.Margin = new System.Windows.Forms.Padding(0);
			this.moveAfterUploadButton.Name = "moveAfterUploadButton";
			this.moveAfterUploadButton.Size = new System.Drawing.Size(112, 23);
			this.moveAfterUploadButton.TabIndex = 13;
			this.moveAfterUploadButton.Text = "Zielordner wählen";
			this.moveAfterUploadButton.UseVisualStyleBackColor = true;
			this.moveAfterUploadButton.Click += new System.EventHandler(this.moveAfterUploadButton_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpEditPaths.SetColumnSpan(this.btnCancel, 3);
			this.btnCancel.Location = new System.Drawing.Point(123, 170);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
			this.btnCancel.Size = new System.Drawing.Size(107, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.chosePathTlp.SetColumnSpan(this.label1, 5);
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Eingestellte Pfade:";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Bitte wähle den Ordner aus, in dem sich die Videos befinden, die du hochladen möc" +
    "htest.";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.ReshowDelay = 100;
			this.toolTip.ShowAlways = true;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.tlpEditPaths.SetColumnSpan(this.label5, 3);
			this.label5.Location = new System.Drawing.Point(10, 143);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(166, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Reihenfolge hinzugefügte Videos:";
			// 
			// searchOrderCombobox
			// 
			this.searchOrderCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEditPaths.SetColumnSpan(this.searchOrderCombobox, 9);
			this.searchOrderCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.searchOrderCombobox.FormattingEnabled = true;
			this.searchOrderCombobox.Items.AddRange(new object[] {
            "Dateiname (aufsteigend)",
            "Dateiname (absteigend)",
            "Erstelldatum (ältestes Video zuerst)",
            "Erstelldatum (neustes Video zuerst)",
            "Änderungsdatum (ältestes Video zuerst)",
            "Änderungsdatum (neustes Video zuerst)",
            "Dateigröße (kleinstes Video zuerst)",
            "Dateigröße (größtes Video zuerst)"});
			this.searchOrderCombobox.Location = new System.Drawing.Point(186, 139);
			this.searchOrderCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.searchOrderCombobox.Name = "searchOrderCombobox";
			this.searchOrderCombobox.Size = new System.Drawing.Size(887, 21);
			this.searchOrderCombobox.TabIndex = 19;
			// 
			// PathForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1107, 641);
			this.Controls.Add(this.chosePathTlp);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "PathForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pfade bearbeiten";
			this.Load += new System.EventHandler(this.PathFormLoad);
			this.chosePathTlp.ResumeLayout(false);
			this.chosePathTlp.PerformLayout();
			this.editPathGroupbox.ResumeLayout(false);
			this.editPathGroupbox.PerformLayout();
			this.tlpEditPaths.ResumeLayout(false);
			this.tlpEditPaths.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel chosePathTlp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button deletePathButton;
		private System.Windows.Forms.ListView lvPaths;
		private System.Windows.Forms.ColumnHeader chPath;
		private System.Windows.Forms.ColumnHeader chFilter;
		private System.Windows.Forms.ColumnHeader chRecursive;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox editPathGroupbox;
		private System.Windows.Forms.TableLayoutPanel tlpEditPaths;
		private System.Windows.Forms.TextBox txtbxAddPath;
		private System.Windows.Forms.Button btnSelectPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtbxAddFilter;
		private System.Windows.Forms.CheckBox chbRecursive;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button addPathButton;
		private System.Windows.Forms.ComboBox cobSelectedTemplate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button movePathUpButton;
		private System.Windows.Forms.Button movePathDownButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.ColumnHeader chTemplate;
		private System.Windows.Forms.CheckBox chbHidden;
		private System.Windows.Forms.ColumnHeader chHidden;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox deactivateCheckbox;
		private System.Windows.Forms.ColumnHeader cbInactive;
		private System.Windows.Forms.Button btnMarkAsRead;
		private System.Windows.Forms.CheckBox moveAfterUploadCheckbox;
		private System.Windows.Forms.TextBox moveAfterUploadTextbox;
		private System.Windows.Forms.Button moveAfterUploadButton;
		private System.Windows.Forms.FolderBrowserDialog selectMovePathDialog;
		private System.Windows.Forms.ColumnHeader cbMoveAfterUpload;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox searchOrderCombobox;
	}
}