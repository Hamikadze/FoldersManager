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
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoldersListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.InputFoldersListView = new System.Windows.Forms.ListView();
            this.FolderNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedFolderRulesGroupBox = new System.Windows.Forms.GroupBox();
            this.CloseSelectedFolderRulesBtn = new System.Windows.Forms.Button();
            this.SelectedFolderNameLabel = new System.Windows.Forms.Label();
            this.SelectedFolderRulesListView = new System.Windows.Forms.ListView();
            this.OutputFolderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilesTypesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FolderRulesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.InputRuleFolderNameGroupBox = new System.Windows.Forms.GroupBox();
            this.RulesForFolderLabel = new System.Windows.Forms.Label();
            this.CloseOutputRulesSettingsBtn = new System.Windows.Forms.Button();
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
            this.InputRulesFolderLabel = new System.Windows.Forms.Label();
            this.InputRulesFolderBox = new System.Windows.Forms.TextBox();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.FoldersListViewContextMenuStrip.SuspendLayout();
            this.SelectedFolderRulesGroupBox.SuspendLayout();
            this.FolderRulesContextMenuStrip.SuspendLayout();
            this.InputRuleFolderNameGroupBox.SuspendLayout();
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
            this.ExitToolStripMenuItem});
            this.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(109, 26);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = global::FoldersManager.Properties.Resources.close;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
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
            // InputFolderBrowserDialog
            // 
            this.InputFolderBrowserDialog.Description = "Выберите папку для её дальнейшего обслуживания.";
            this.InputFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // InputFoldersListView
            // 
            this.InputFoldersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FolderNameColumnHeader});
            this.InputFoldersListView.ContextMenuStrip = this.FoldersListViewContextMenuStrip;
            this.InputFoldersListView.FullRowSelect = true;
            this.InputFoldersListView.HideSelection = false;
            this.InputFoldersListView.Location = new System.Drawing.Point(6, 19);
            this.InputFoldersListView.MultiSelect = false;
            this.InputFoldersListView.Name = "InputFoldersListView";
            this.InputFoldersListView.ShowItemToolTips = true;
            this.InputFoldersListView.Size = new System.Drawing.Size(262, 415);
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
            this.SelectedFolderRulesGroupBox.Controls.Add(this.InputRulesFolderLabel);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.InputRulesFolderBox);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.CloseSelectedFolderRulesBtn);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.SelectedFolderNameLabel);
            this.SelectedFolderRulesGroupBox.Controls.Add(this.SelectedFolderRulesListView);
            this.SelectedFolderRulesGroupBox.Location = new System.Drawing.Point(365, 12);
            this.SelectedFolderRulesGroupBox.Name = "SelectedFolderRulesGroupBox";
            this.SelectedFolderRulesGroupBox.Size = new System.Drawing.Size(274, 440);
            this.SelectedFolderRulesGroupBox.TabIndex = 3;
            this.SelectedFolderRulesGroupBox.TabStop = false;
            this.SelectedFolderRulesGroupBox.Text = "Конечные папки и правила";
            this.SelectedFolderRulesGroupBox.Visible = false;
            // 
            // CloseSelectedFolderRulesBtn
            // 
            this.CloseSelectedFolderRulesBtn.Location = new System.Drawing.Point(183, 411);
            this.CloseSelectedFolderRulesBtn.Name = "CloseSelectedFolderRulesBtn";
            this.CloseSelectedFolderRulesBtn.Size = new System.Drawing.Size(85, 23);
            this.CloseSelectedFolderRulesBtn.TabIndex = 5;
            this.CloseSelectedFolderRulesBtn.Text = "Закрыть";
            this.CloseSelectedFolderRulesBtn.UseVisualStyleBackColor = true;
            // 
            // SelectedFolderNameLabel
            // 
            this.SelectedFolderNameLabel.AutoSize = true;
            this.SelectedFolderNameLabel.Location = new System.Drawing.Point(6, 55);
            this.SelectedFolderNameLabel.Name = "SelectedFolderNameLabel";
            this.SelectedFolderNameLabel.Size = new System.Drawing.Size(165, 13);
            this.SelectedFolderNameLabel.TabIndex = 4;
            this.SelectedFolderNameLabel.Text = "Выбранная исходная папка : ...";
            // 
            // SelectedFolderRulesListView
            // 
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
            this.SelectedFolderRulesListView.Size = new System.Drawing.Size(262, 334);
            this.SelectedFolderRulesListView.TabIndex = 0;
            this.SelectedFolderRulesListView.UseCompatibleStateImageBehavior = false;
            this.SelectedFolderRulesListView.View = System.Windows.Forms.View.Details;
            this.SelectedFolderRulesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SelectedFolderRulesListView_ItemSelectionChanged);
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
            this.FolderRulesContextMenuStrip.Size = new System.Drawing.Size(177, 26);
            this.FolderRulesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FolderRulesContextMenuStrip_Opening);
            // 
            // AddRuleToolStripMenuItem
            // 
            this.AddRuleToolStripMenuItem.Image = global::FoldersManager.Properties.Resources.add;
            this.AddRuleToolStripMenuItem.Name = "AddRuleToolStripMenuItem";
            this.AddRuleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.AddRuleToolStripMenuItem.Text = "Добавить правило";
            this.AddRuleToolStripMenuItem.Click += new System.EventHandler(this.AddRuleToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1033, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputRuleFolderNameGroupBox
            // 
            this.InputRuleFolderNameGroupBox.Controls.Add(this.RulesForFolderLabel);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.CloseOutputRulesSettingsBtn);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.OutputRuleFolderLabel);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.ManageRuleValuesListTabControl);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.OutputRuleFolderBox);
            this.InputRuleFolderNameGroupBox.Location = new System.Drawing.Point(696, 12);
            this.InputRuleFolderNameGroupBox.Name = "InputRuleFolderNameGroupBox";
            this.InputRuleFolderNameGroupBox.Size = new System.Drawing.Size(274, 440);
            this.InputRuleFolderNameGroupBox.TabIndex = 2;
            this.InputRuleFolderNameGroupBox.TabStop = false;
            this.InputRuleFolderNameGroupBox.Text = "Настройка правил для папки";
            this.InputRuleFolderNameGroupBox.Visible = false;
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
            // CloseOutputRulesSettingsBtn
            // 
            this.CloseOutputRulesSettingsBtn.Location = new System.Drawing.Point(183, 411);
            this.CloseOutputRulesSettingsBtn.Name = "CloseOutputRulesSettingsBtn";
            this.CloseOutputRulesSettingsBtn.Size = new System.Drawing.Size(85, 23);
            this.CloseOutputRulesSettingsBtn.TabIndex = 2;
            this.CloseOutputRulesSettingsBtn.Text = "Закрыть";
            this.CloseOutputRulesSettingsBtn.UseVisualStyleBackColor = true;
            this.CloseOutputRulesSettingsBtn.MouseHover += new System.EventHandler(this.CloseOutputRulesSettingsBtn_MouseHover);
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
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleExpansionsTabPage);
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleNamesTabPage);
            this.ManageRuleValuesListTabControl.Location = new System.Drawing.Point(6, 71);
            this.ManageRuleValuesListTabControl.Name = "ManageRuleValuesListTabControl";
            this.ManageRuleValuesListTabControl.SelectedIndex = 0;
            this.ManageRuleValuesListTabControl.Size = new System.Drawing.Size(262, 334);
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
            this.ManageRuleExpansionsTabPage.Size = new System.Drawing.Size(254, 308);
            this.ManageRuleExpansionsTabPage.TabIndex = 0;
            this.ManageRuleExpansionsTabPage.Text = "Расширения файлов";
            this.ManageRuleExpansionsTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleExpansionBox
            // 
            this.RuleExpansionBox.Location = new System.Drawing.Point(6, 8);
            this.RuleExpansionBox.Name = "RuleExpansionBox";
            this.RuleExpansionBox.Size = new System.Drawing.Size(161, 20);
            this.RuleExpansionBox.TabIndex = 3;
            // 
            // SaveRuleExpansionFromBoxBtn
            // 
            this.SaveRuleExpansionFromBoxBtn.Location = new System.Drawing.Point(173, 6);
            this.SaveRuleExpansionFromBoxBtn.Name = "SaveRuleExpansionFromBoxBtn";
            this.SaveRuleExpansionFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleExpansionFromBoxBtn.TabIndex = 2;
            this.SaveRuleExpansionFromBoxBtn.Text = "Сохранить";
            this.SaveRuleExpansionFromBoxBtn.UseVisualStyleBackColor = true;
            // 
            // VisualizeRuleExpansionsListView
            // 
            this.VisualizeRuleExpansionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VisualizeExpansionColumnHeader});
            this.VisualizeRuleExpansionsListView.FullRowSelect = true;
            this.VisualizeRuleExpansionsListView.HoverSelection = true;
            this.VisualizeRuleExpansionsListView.Location = new System.Drawing.Point(6, 35);
            this.VisualizeRuleExpansionsListView.MultiSelect = false;
            this.VisualizeRuleExpansionsListView.Name = "VisualizeRuleExpansionsListView";
            this.VisualizeRuleExpansionsListView.Size = new System.Drawing.Size(242, 267);
            this.VisualizeRuleExpansionsListView.TabIndex = 0;
            this.VisualizeRuleExpansionsListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleExpansionsListView.View = System.Windows.Forms.View.Details;
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
            this.ManageRuleNamesTabPage.Size = new System.Drawing.Size(254, 308);
            this.ManageRuleNamesTabPage.TabIndex = 1;
            this.ManageRuleNamesTabPage.Text = "Имена файлов";
            this.ManageRuleNamesTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleNameBox
            // 
            this.RuleNameBox.Location = new System.Drawing.Point(6, 8);
            this.RuleNameBox.Name = "RuleNameBox";
            this.RuleNameBox.Size = new System.Drawing.Size(161, 20);
            this.RuleNameBox.TabIndex = 5;
            // 
            // SaveRuleNameFromBoxBtn
            // 
            this.SaveRuleNameFromBoxBtn.Location = new System.Drawing.Point(173, 6);
            this.SaveRuleNameFromBoxBtn.Name = "SaveRuleNameFromBoxBtn";
            this.SaveRuleNameFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleNameFromBoxBtn.TabIndex = 4;
            this.SaveRuleNameFromBoxBtn.Text = "Сохранить";
            this.SaveRuleNameFromBoxBtn.UseVisualStyleBackColor = true;
            // 
            // VisualizeRuleNamesListView
            // 
            this.VisualizeRuleNamesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VisualizeNamesColumnHeader});
            this.VisualizeRuleNamesListView.FullRowSelect = true;
            this.VisualizeRuleNamesListView.HideSelection = false;
            this.VisualizeRuleNamesListView.Location = new System.Drawing.Point(6, 35);
            this.VisualizeRuleNamesListView.MultiSelect = false;
            this.VisualizeRuleNamesListView.Name = "VisualizeRuleNamesListView";
            this.VisualizeRuleNamesListView.Size = new System.Drawing.Size(242, 267);
            this.VisualizeRuleNamesListView.TabIndex = 3;
            this.VisualizeRuleNamesListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleNamesListView.View = System.Windows.Forms.View.Details;
            // 
            // VisualizeNamesColumnHeader
            // 
            this.VisualizeNamesColumnHeader.Text = "Названия файлов";
            this.VisualizeNamesColumnHeader.Width = 210;
            // 
            // OutputRuleFolderBox
            // 
            this.OutputRuleFolderBox.Location = new System.Drawing.Point(10, 32);
            this.OutputRuleFolderBox.Name = "OutputRuleFolderBox";
            this.OutputRuleFolderBox.Size = new System.Drawing.Size(258, 20);
            this.OutputRuleFolderBox.TabIndex = 1;
            this.OutputRuleFolderBox.TextChanged += new System.EventHandler(this.OutputRuleFolderBox_TextChanged);
            // 
            // InputFoldersListGroupBox
            // 
            this.InputFoldersListGroupBox.Controls.Add(this.InputFoldersListView);
            this.InputFoldersListGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputFoldersListGroupBox.Name = "InputFoldersListGroupBox";
            this.InputFoldersListGroupBox.Size = new System.Drawing.Size(274, 440);
            this.InputFoldersListGroupBox.TabIndex = 4;
            this.InputFoldersListGroupBox.TabStop = false;
            this.InputFoldersListGroupBox.Text = "Список папок-источников";
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
            // InputRulesFolderBox
            // 
            this.InputRulesFolderBox.Location = new System.Drawing.Point(9, 32);
            this.InputRulesFolderBox.Name = "InputRulesFolderBox";
            this.InputRulesFolderBox.Size = new System.Drawing.Size(258, 20);
            this.InputRulesFolderBox.TabIndex = 5;
            this.InputRulesFolderBox.TextChanged += new System.EventHandler(this.InputRulesFolderBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 464);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputRuleFolderNameGroupBox);
            this.Controls.Add(this.SelectedFolderRulesGroupBox);
            this.Controls.Add(this.InputFoldersListGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folders manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.FoldersListViewContextMenuStrip.ResumeLayout(false);
            this.SelectedFolderRulesGroupBox.ResumeLayout(false);
            this.SelectedFolderRulesGroupBox.PerformLayout();
            this.FolderRulesContextMenuStrip.ResumeLayout(false);
            this.InputRuleFolderNameGroupBox.ResumeLayout(false);
            this.InputRuleFolderNameGroupBox.PerformLayout();
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
        private System.Windows.Forms.FolderBrowserDialog InputFolderBrowserDialog;
        private System.Windows.Forms.ListView InputFoldersListView;
        private System.Windows.Forms.ColumnHeader FolderNameColumnHeader;
        private System.Windows.Forms.GroupBox SelectedFolderRulesGroupBox;
        private System.Windows.Forms.ListView SelectedFolderRulesListView;
        private System.Windows.Forms.ColumnHeader OutputFolderColumnHeader;
        private System.Windows.Forms.ColumnHeader FilesTypesColumnHeader;
        private System.Windows.Forms.ContextMenuStrip FolderRulesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddRuleToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox InputRuleFolderNameGroupBox;
        private System.Windows.Forms.Button CloseOutputRulesSettingsBtn;
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
        private System.Windows.Forms.Label SelectedFolderNameLabel;
        private System.Windows.Forms.Label RulesForFolderLabel;
        private System.Windows.Forms.Button CloseSelectedFolderRulesBtn;
        private System.Windows.Forms.Label InputRulesFolderLabel;
        private System.Windows.Forms.TextBox InputRulesFolderBox;
    }
}

