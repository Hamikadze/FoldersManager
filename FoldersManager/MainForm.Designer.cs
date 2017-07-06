namespace FoldersManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoldersListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.InputFoldersListView = new System.Windows.Forms.ListView();
            this.FolderNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedFolderRulesGroupBox = new System.Windows.Forms.GroupBox();
            this.InputRulesFolderLabel = new System.Windows.Forms.Label();
            this.CloseSelectedFolderRulesBtn = new System.Windows.Forms.Button();
            this.SelectedFolderRulesListView = new System.Windows.Forms.ListView();
            this.OutputFolderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilesTypesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FolderRulesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedFolderRulesLabel = new System.Windows.Forms.Label();
            this.InputRulesFolderBox = new System.Windows.Forms.TextBox();
            this.VisualizeRuleFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.RulesForFolderLabel = new System.Windows.Forms.Label();
            this.CloseVisualizeRuleFolderBtn = new System.Windows.Forms.Button();
            this.OutputRuleFolderLabel = new System.Windows.Forms.Label();
            this.ManageRuleValuesListTabControl = new System.Windows.Forms.TabControl();
            this.ManageRuleExpansionsTabPage = new System.Windows.Forms.TabPage();
            this.RuleExpansionBox = new System.Windows.Forms.TextBox();
            this.SaveRuleExpansionFromBoxBtn = new System.Windows.Forms.Button();
            this.VisualizeRuleExpansionsListView = new System.Windows.Forms.ListView();
            this.VisualizeExpansionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManageRuleNamesTabPage = new System.Windows.Forms.TabPage();
            this.RuleNameBox = new System.Windows.Forms.TextBox();
            this.SaveRuleNameFromBoxBtn = new System.Windows.Forms.Button();
            this.VisualizeRuleNamesListView = new System.Windows.Forms.ListView();
            this.VisualizeNamesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OutputRuleFolderBox = new System.Windows.Forms.TextBox();
            this.InputFoldersListGroupBox = new System.Windows.Forms.GroupBox();
            this.FileTypeOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.FoldersListViewContextMenuStrip.SuspendLayout();
            this.SelectedFolderRulesGroupBox.SuspendLayout();
            this.FolderRulesContextMenuStrip.SuspendLayout();
            this.VisualizeRuleFolderGroupBox.SuspendLayout();
            this.ManageRuleValuesListTabControl.SuspendLayout();
            this.ManageRuleExpansionsTabPage.SuspendLayout();
            this.ManageRuleNamesTabPage.SuspendLayout();
            this.InputFoldersListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Folders manager";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // NotifyIconContextMenuStrip
            // 
            this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(197, 48);
            // 
            // SortToolStripMenuItem
            // 
            this.SortToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SortToolStripMenuItem.Image")));
            this.SortToolStripMenuItem.Name = "SortToolStripMenuItem";
            this.SortToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SortToolStripMenuItem.Text = "Запустить сортировку";
            this.SortToolStripMenuItem.Click += new System.EventHandler(this.SortToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = global::FoldersManager.Properties.Resources.close;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FoldersListViewContextMenuStrip
            // 
            this.FoldersListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFolderToolStripMenuItem});
            this.FoldersListViewContextMenuStrip.Name = "FoldersListBoxContextMenuStrip";
            this.FoldersListViewContextMenuStrip.Size = new System.Drawing.Size(201, 26);
            this.FoldersListViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FoldersListViewContextMenuStrip_Opening);
            // 
            // AddFolderToolStripMenuItem
            // 
            this.AddFolderToolStripMenuItem.Image = global::FoldersManager.Properties.Resources.add;
            this.AddFolderToolStripMenuItem.Name = "AddFolderToolStripMenuItem";
            this.AddFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.AddFolderToolStripMenuItem.Text = "Добавить новую папку";
            this.AddFolderToolStripMenuItem.Click += new System.EventHandler(this.AddFolderToolStripMenuItem_Click);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "Выберите папку для её дальнейшего обслуживания.";
            this.FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // InputFoldersListView
            // 
            this.InputFoldersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFoldersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FolderNameColumnHeader});
            this.InputFoldersListView.ContextMenuStrip = this.FoldersListViewContextMenuStrip;
            this.InputFoldersListView.FullRowSelect = true;
            this.InputFoldersListView.HideSelection = false;
            this.InputFoldersListView.Location = new System.Drawing.Point(6, 19);
            this.InputFoldersListView.MultiSelect = false;
            this.InputFoldersListView.Name = "InputFoldersListView";
            this.InputFoldersListView.ShowItemToolTips = true;
            this.InputFoldersListView.Size = new System.Drawing.Size(263, 473);
            this.InputFoldersListView.TabIndex = 2;
            this.InputFoldersListView.UseCompatibleStateImageBehavior = false;
            this.InputFoldersListView.View = System.Windows.Forms.View.Details;
            this.InputFoldersListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputFoldersListView_KeyUp);
            this.InputFoldersListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.InputFoldersListView_MouseDoubleClick);
            // 
            // FolderNameColumnHeader
            // 
            this.FolderNameColumnHeader.Text = "Имя папки-источника";
            this.FolderNameColumnHeader.Width = 230;
            // 
            // SelectedFolderRulesGroupBox
            // 
            this.SelectedFolderRulesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedFolderRulesGroupBox.Controls.Add(this.InputRulesFolderLabel);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.CloseSelectedFolderRulesBtn);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.SelectedFolderRulesListView);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.SelectedFolderRulesLabel);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.InputRulesFolderBox);
            this.SelectedFolderRulesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.SelectedFolderRulesGroupBox.Name = "SelectedFolderRulesGroupBox";
            this.SelectedFolderRulesGroupBox.Size = new System.Drawing.Size(275, 498);
            this.SelectedFolderRulesGroupBox.TabIndex = 3;
            this.SelectedFolderRulesGroupBox.TabStop = false;
            this.SelectedFolderRulesGroupBox.Text = "Настройка правил и исходной папки";
            this.SelectedFolderRulesGroupBox.Visible = false;
            // 
            // InputRulesFolderLabel
            // 
            this.InputRulesFolderLabel.AutoSize = true;
            this.InputRulesFolderLabel.Location = new System.Drawing.Point(6, 16);
            this.InputRulesFolderLabel.Name = "InputRulesFolderLabel";
            this.InputRulesFolderLabel.Size = new System.Drawing.Size(89, 13);
            this.InputRulesFolderLabel.TabIndex = 6;
            this.InputRulesFolderLabel.Text = "Исходная папка";
            // 
            // CloseSelectedFolderRulesBtn
            // 
            this.CloseSelectedFolderRulesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseSelectedFolderRulesBtn.Location = new System.Drawing.Point(184, 469);
            this.CloseSelectedFolderRulesBtn.Name = "CloseSelectedFolderRulesBtn";
            this.CloseSelectedFolderRulesBtn.Size = new System.Drawing.Size(85, 23);
            this.CloseSelectedFolderRulesBtn.TabIndex = 5;
            this.CloseSelectedFolderRulesBtn.Text = "Закрыть";
            this.CloseSelectedFolderRulesBtn.UseVisualStyleBackColor = true;
            this.CloseSelectedFolderRulesBtn.Click += new System.EventHandler(this.CloseSelectedFolderRulesBtn_Click);
            this.CloseSelectedFolderRulesBtn.MouseHover += new System.EventHandler(this.CloseSelectedFolderRulesBtn_MouseHover);
            // 
            // SelectedFolderRulesListView
            // 
            this.SelectedFolderRulesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedFolderRulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OutputFolderColumnHeader,
            this.FilesTypesColumnHeader});
            this.SelectedFolderRulesListView.ContextMenuStrip = this.FolderRulesContextMenuStrip;
            this.SelectedFolderRulesListView.FullRowSelect = true;
            this.SelectedFolderRulesListView.HideSelection = false;
            this.SelectedFolderRulesListView.Location = new System.Drawing.Point(6, 71);
            this.SelectedFolderRulesListView.MultiSelect = false;
            this.SelectedFolderRulesListView.Name = "SelectedFolderRulesListView";
            this.SelectedFolderRulesListView.ShowItemToolTips = true;
            this.SelectedFolderRulesListView.Size = new System.Drawing.Size(263, 392);
            this.SelectedFolderRulesListView.TabIndex = 0;
            this.SelectedFolderRulesListView.UseCompatibleStateImageBehavior = false;
            this.SelectedFolderRulesListView.View = System.Windows.Forms.View.Details;
            this.SelectedFolderRulesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SelectedFolderRulesListView_KeyUp);
            this.SelectedFolderRulesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SelectedFolderRulesListView_MouseDoubleClick);
            // 
            // OutputFolderColumnHeader
            // 
            this.OutputFolderColumnHeader.Text = "Имя конечной папки";
            this.OutputFolderColumnHeader.Width = 147;
            // 
            // FilesTypesColumnHeader
            // 
            this.FilesTypesColumnHeader.Text = "Расширения";
            this.FilesTypesColumnHeader.Width = 85;
            // 
            // FolderRulesContextMenuStrip
            // 
            this.FolderRulesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRuleToolStripMenuItem});
            this.FolderRulesContextMenuStrip.Name = "FolderRulesContextMenuStrip";
            this.FolderRulesContextMenuStrip.Size = new System.Drawing.Size(213, 26);
            this.FolderRulesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FolderRulesContextMenuStrip_Opening);
            // 
            // AddRuleToolStripMenuItem
            // 
            this.AddRuleToolStripMenuItem.Image = global::FoldersManager.Properties.Resources.add;
            this.AddRuleToolStripMenuItem.Name = "AddRuleToolStripMenuItem";
            this.AddRuleToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.AddRuleToolStripMenuItem.Text = "Добавить новое правило";
            this.AddRuleToolStripMenuItem.Click += new System.EventHandler(this.AddRuleToolStripMenuItem_Click);
            // 
            // SelectedFolderRulesLabel
            // 
            this.SelectedFolderRulesLabel.AutoSize = true;
            this.SelectedFolderRulesLabel.Location = new System.Drawing.Point(3, 55);
            this.SelectedFolderRulesLabel.Name = "SelectedFolderRulesLabel";
            this.SelectedFolderRulesLabel.Size = new System.Drawing.Size(144, 13);
            this.SelectedFolderRulesLabel.TabIndex = 4;
            this.SelectedFolderRulesLabel.Text = "Конечные папки и правила";
            // 
            // InputRulesFolderBox
            // 
            this.InputRulesFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputRulesFolderBox.Location = new System.Drawing.Point(6, 32);
            this.InputRulesFolderBox.Name = "InputRulesFolderBox";
            this.InputRulesFolderBox.Size = new System.Drawing.Size(259, 20);
            this.InputRulesFolderBox.TabIndex = 5;
            this.InputRulesFolderBox.TextChanged += new System.EventHandler(this.InputRulesFolderBox_TextChanged);
            this.InputRulesFolderBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.InputRulesFolderBox_MouseDoubleClick);
            // 
            // VisualizeRuleFolderGroupBox
            // 
            this.VisualizeRuleFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualizeRuleFolderGroupBox.Controls.Add(this.RulesForFolderLabel);
            this.VisualizeRuleFolderGroupBox.Controls.Add(this.CloseVisualizeRuleFolderBtn);
            this.VisualizeRuleFolderGroupBox.Controls.Add(this.OutputRuleFolderLabel);
            this.VisualizeRuleFolderGroupBox.Controls.Add(this.ManageRuleValuesListTabControl);
            this.VisualizeRuleFolderGroupBox.Controls.Add(this.OutputRuleFolderBox);
            this.VisualizeRuleFolderGroupBox.Location = new System.Drawing.Point(12, 12);
            this.VisualizeRuleFolderGroupBox.Name = "VisualizeRuleFolderGroupBox";
            this.VisualizeRuleFolderGroupBox.Size = new System.Drawing.Size(275, 498);
            this.VisualizeRuleFolderGroupBox.TabIndex = 2;
            this.VisualizeRuleFolderGroupBox.TabStop = false;
            this.VisualizeRuleFolderGroupBox.Text = "Настройка правил для папки";
            this.VisualizeRuleFolderGroupBox.Visible = false;
            // 
            // RulesForFolderLabel
            // 
            this.RulesForFolderLabel.AutoSize = true;
            this.RulesForFolderLabel.Location = new System.Drawing.Point(7, 55);
            this.RulesForFolderLabel.Name = "RulesForFolderLabel";
            this.RulesForFolderLabel.Size = new System.Drawing.Size(105, 13);
            this.RulesForFolderLabel.TabIndex = 4;
            this.RulesForFolderLabel.Text = "Правила для папки";
            // 
            // CloseVisualizeRuleFolderBtn
            // 
            this.CloseVisualizeRuleFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseVisualizeRuleFolderBtn.Location = new System.Drawing.Point(180, 469);
            this.CloseVisualizeRuleFolderBtn.Name = "CloseVisualizeRuleFolderBtn";
            this.CloseVisualizeRuleFolderBtn.Size = new System.Drawing.Size(85, 23);
            this.CloseVisualizeRuleFolderBtn.TabIndex = 2;
            this.CloseVisualizeRuleFolderBtn.Text = "Закрыть";
            this.CloseVisualizeRuleFolderBtn.UseVisualStyleBackColor = true;
            this.CloseVisualizeRuleFolderBtn.Click += new System.EventHandler(this.CloseVisualizeRuleFolderBtn_Click);
            this.CloseVisualizeRuleFolderBtn.MouseHover += new System.EventHandler(this.CloseVisualizeRuleFolderBtn_MouseHover);
            // 
            // OutputRuleFolderLabel
            // 
            this.OutputRuleFolderLabel.AutoSize = true;
            this.OutputRuleFolderLabel.Location = new System.Drawing.Point(7, 16);
            this.OutputRuleFolderLabel.Name = "OutputRuleFolderLabel";
            this.OutputRuleFolderLabel.Size = new System.Drawing.Size(88, 13);
            this.OutputRuleFolderLabel.TabIndex = 3;
            this.OutputRuleFolderLabel.Text = "Конечная папка";
            // 
            // ManageRuleValuesListTabControl
            // 
            this.ManageRuleValuesListTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleExpansionsTabPage);
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleNamesTabPage);
            this.ManageRuleValuesListTabControl.Location = new System.Drawing.Point(6, 71);
            this.ManageRuleValuesListTabControl.Name = "ManageRuleValuesListTabControl";
            this.ManageRuleValuesListTabControl.SelectedIndex = 0;
            this.ManageRuleValuesListTabControl.Size = new System.Drawing.Size(263, 392);
            this.ManageRuleValuesListTabControl.TabIndex = 2;
            // 
            // ManageRuleExpansionsTabPage
            // 
            this.ManageRuleExpansionsTabPage.Controls.Add(this.RuleExpansionBox);
            this.ManageRuleExpansionsTabPage.Controls.Add(this.SaveRuleExpansionFromBoxBtn);
            this.ManageRuleExpansionsTabPage.Controls.Add(this.VisualizeRuleExpansionsListView);
            this.ManageRuleExpansionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ManageRuleExpansionsTabPage.Name = "ManageRuleExpansionsTabPage";
            this.ManageRuleExpansionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManageRuleExpansionsTabPage.Size = new System.Drawing.Size(255, 366);
            this.ManageRuleExpansionsTabPage.TabIndex = 0;
            this.ManageRuleExpansionsTabPage.Text = "Расширения файлов";
            this.ManageRuleExpansionsTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleExpansionBox
            // 
            this.RuleExpansionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleExpansionBox.Location = new System.Drawing.Point(6, 8);
            this.RuleExpansionBox.Name = "RuleExpansionBox";
            this.RuleExpansionBox.Size = new System.Drawing.Size(162, 20);
            this.RuleExpansionBox.TabIndex = 3;
            this.RuleExpansionBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RuleExpansionBox_MouseDoubleClick);
            // 
            // SaveRuleExpansionFromBoxBtn
            // 
            this.SaveRuleExpansionFromBoxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveRuleExpansionFromBoxBtn.Location = new System.Drawing.Point(174, 6);
            this.SaveRuleExpansionFromBoxBtn.Name = "SaveRuleExpansionFromBoxBtn";
            this.SaveRuleExpansionFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleExpansionFromBoxBtn.TabIndex = 2;
            this.SaveRuleExpansionFromBoxBtn.Text = "Сохранить";
            this.SaveRuleExpansionFromBoxBtn.UseVisualStyleBackColor = true;
            this.SaveRuleExpansionFromBoxBtn.Click += new System.EventHandler(this.SaveRuleExpansionFromBoxBtn_Click);
            // 
            // VisualizeRuleExpansionsListView
            // 
            this.VisualizeRuleExpansionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualizeRuleExpansionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VisualizeExpansionColumnHeader});
            this.VisualizeRuleExpansionsListView.FullRowSelect = true;
            this.VisualizeRuleExpansionsListView.Location = new System.Drawing.Point(6, 35);
            this.VisualizeRuleExpansionsListView.MultiSelect = false;
            this.VisualizeRuleExpansionsListView.Name = "VisualizeRuleExpansionsListView";
            this.VisualizeRuleExpansionsListView.Size = new System.Drawing.Size(243, 325);
            this.VisualizeRuleExpansionsListView.TabIndex = 0;
            this.VisualizeRuleExpansionsListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleExpansionsListView.View = System.Windows.Forms.View.Details;
            this.VisualizeRuleExpansionsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizeRuleExpansionsListView_KeyUp);
            this.VisualizeRuleExpansionsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VisualizeRuleExpansionsListView_MouseDoubleClick);
            // 
            // VisualizeExpansionColumnHeader
            // 
            this.VisualizeExpansionColumnHeader.Text = "Расширения файлов";
            this.VisualizeExpansionColumnHeader.Width = 210;
            // 
            // ManageRuleNamesTabPage
            // 
            this.ManageRuleNamesTabPage.Controls.Add(this.RuleNameBox);
            this.ManageRuleNamesTabPage.Controls.Add(this.SaveRuleNameFromBoxBtn);
            this.ManageRuleNamesTabPage.Controls.Add(this.VisualizeRuleNamesListView);
            this.ManageRuleNamesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ManageRuleNamesTabPage.Name = "ManageRuleNamesTabPage";
            this.ManageRuleNamesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManageRuleNamesTabPage.Size = new System.Drawing.Size(255, 366);
            this.ManageRuleNamesTabPage.TabIndex = 1;
            this.ManageRuleNamesTabPage.Text = "Имена файлов";
            this.ManageRuleNamesTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleNameBox
            // 
            this.RuleNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleNameBox.Location = new System.Drawing.Point(6, 8);
            this.RuleNameBox.Name = "RuleNameBox";
            this.RuleNameBox.Size = new System.Drawing.Size(162, 20);
            this.RuleNameBox.TabIndex = 5;
            // 
            // SaveRuleNameFromBoxBtn
            // 
            this.SaveRuleNameFromBoxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveRuleNameFromBoxBtn.Location = new System.Drawing.Point(174, 6);
            this.SaveRuleNameFromBoxBtn.Name = "SaveRuleNameFromBoxBtn";
            this.SaveRuleNameFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleNameFromBoxBtn.TabIndex = 4;
            this.SaveRuleNameFromBoxBtn.Text = "Сохранить";
            this.SaveRuleNameFromBoxBtn.UseVisualStyleBackColor = true;
            this.SaveRuleNameFromBoxBtn.Click += new System.EventHandler(this.SaveRuleNameFromBoxBtn_Click);
            // 
            // VisualizeRuleNamesListView
            // 
            this.VisualizeRuleNamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualizeRuleNamesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VisualizeNamesColumnHeader});
            this.VisualizeRuleNamesListView.FullRowSelect = true;
            this.VisualizeRuleNamesListView.Location = new System.Drawing.Point(6, 35);
            this.VisualizeRuleNamesListView.MultiSelect = false;
            this.VisualizeRuleNamesListView.Name = "VisualizeRuleNamesListView";
            this.VisualizeRuleNamesListView.Size = new System.Drawing.Size(243, 325);
            this.VisualizeRuleNamesListView.TabIndex = 3;
            this.VisualizeRuleNamesListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleNamesListView.View = System.Windows.Forms.View.Details;
            this.VisualizeRuleNamesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizeRuleNamesListView_KeyUp);
            this.VisualizeRuleNamesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VisualizeRuleNamesListView_MouseDoubleClick);
            // 
            // VisualizeNamesColumnHeader
            // 
            this.VisualizeNamesColumnHeader.Text = "Названия файлов";
            this.VisualizeNamesColumnHeader.Width = 210;
            // 
            // OutputRuleFolderBox
            // 
            this.OutputRuleFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputRuleFolderBox.Location = new System.Drawing.Point(10, 32);
            this.OutputRuleFolderBox.Name = "OutputRuleFolderBox";
            this.OutputRuleFolderBox.Size = new System.Drawing.Size(255, 20);
            this.OutputRuleFolderBox.TabIndex = 1;
            this.OutputRuleFolderBox.TextChanged += new System.EventHandler(this.OutputRuleFolderBox_TextChanged);
            this.OutputRuleFolderBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OutputRuleFolderBox_MouseDoubleClick);
            // 
            // InputFoldersListGroupBox
            // 
            this.InputFoldersListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFoldersListGroupBox.Controls.Add(this.InputFoldersListView);
            this.InputFoldersListGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputFoldersListGroupBox.Name = "InputFoldersListGroupBox";
            this.InputFoldersListGroupBox.Size = new System.Drawing.Size(275, 498);
            this.InputFoldersListGroupBox.TabIndex = 4;
            this.InputFoldersListGroupBox.TabStop = false;
            this.InputFoldersListGroupBox.Text = "Список папок-источников";
            // 
            // FileTypeOpenFileDialog
            // 
            this.FileTypeOpenFileDialog.Multiselect = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 522);
            this.Controls.Add(this.SelectedFolderRulesGroupBox);
            this.Controls.Add(this.InputFoldersListGroupBox);
            this.Controls.Add(this.VisualizeRuleFolderGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folders manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.FoldersListViewContextMenuStrip.ResumeLayout(false);
            this.SelectedFolderRulesGroupBox.ResumeLayout(false);
            this.SelectedFolderRulesGroupBox.PerformLayout();
            this.FolderRulesContextMenuStrip.ResumeLayout(false);
            this.VisualizeRuleFolderGroupBox.ResumeLayout(false);
            this.VisualizeRuleFolderGroupBox.PerformLayout();
            this.ManageRuleValuesListTabControl.ResumeLayout(false);
            this.ManageRuleExpansionsTabPage.ResumeLayout(false);
            this.ManageRuleExpansionsTabPage.PerformLayout();
            this.ManageRuleNamesTabPage.ResumeLayout(false);
            this.ManageRuleNamesTabPage.PerformLayout();
            this.InputFoldersListGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FoldersListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ListView InputFoldersListView;
        private System.Windows.Forms.ColumnHeader FolderNameColumnHeader;
        private System.Windows.Forms.GroupBox SelectedFolderRulesGroupBox;
        private System.Windows.Forms.ListView SelectedFolderRulesListView;
        private System.Windows.Forms.ColumnHeader OutputFolderColumnHeader;
        private System.Windows.Forms.ColumnHeader FilesTypesColumnHeader;
        private System.Windows.Forms.ContextMenuStrip FolderRulesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddRuleToolStripMenuItem;
        private System.Windows.Forms.GroupBox VisualizeRuleFolderGroupBox;
        private System.Windows.Forms.Button CloseVisualizeRuleFolderBtn;
        private System.Windows.Forms.Label OutputRuleFolderLabel;
        private System.Windows.Forms.TabControl ManageRuleValuesListTabControl;
        private System.Windows.Forms.TabPage ManageRuleExpansionsTabPage;
        private System.Windows.Forms.TextBox RuleExpansionBox;
        private System.Windows.Forms.Button SaveRuleExpansionFromBoxBtn;
        private System.Windows.Forms.ListView VisualizeRuleExpansionsListView;
        private System.Windows.Forms.ColumnHeader VisualizeExpansionColumnHeader;
        private System.Windows.Forms.TabPage ManageRuleNamesTabPage;
        private System.Windows.Forms.TextBox RuleNameBox;
        private System.Windows.Forms.Button SaveRuleNameFromBoxBtn;
        private System.Windows.Forms.ListView VisualizeRuleNamesListView;
        private System.Windows.Forms.ColumnHeader VisualizeNamesColumnHeader;
        private System.Windows.Forms.TextBox OutputRuleFolderBox;
        private System.Windows.Forms.GroupBox InputFoldersListGroupBox;
        private System.Windows.Forms.Label SelectedFolderRulesLabel;
        private System.Windows.Forms.Label RulesForFolderLabel;
        private System.Windows.Forms.Button CloseSelectedFolderRulesBtn;
        private System.Windows.Forms.Label InputRulesFolderLabel;
        private System.Windows.Forms.TextBox InputRulesFolderBox;
        private System.Windows.Forms.OpenFileDialog FileTypeOpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem SortToolStripMenuItem;
    }
}

