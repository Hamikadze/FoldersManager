namespace FoldersManager
{
    partial class ManageFolderRuleForm
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
            this.InputRuleFolderNameGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveChargesCloseFormBtn = new System.Windows.Forms.Button();
            this.OutputRuleFolderLabel = new System.Windows.Forms.Label();
            this.ManageRuleValuesListTabControl = new System.Windows.Forms.TabControl();
            this.ManageRuleTypesTabPage = new System.Windows.Forms.TabPage();
            this.RuleTypeBox = new System.Windows.Forms.TextBox();
            this.SaveRuleTypeFromBoxBtn = new System.Windows.Forms.Button();
            this.VisualizeRuleTypesListView = new System.Windows.Forms.ListView();
            this.VisualizeTypesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManageRuleNamesTabPage = new System.Windows.Forms.TabPage();
            this.RuleNameBox = new System.Windows.Forms.TextBox();
            this.SaveRuleNameFromBoxBtn = new System.Windows.Forms.Button();
            this.VisualizeRuleNamesListView = new System.Windows.Forms.ListView();
            this.VisualizeNamesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OutputRuleFolderBox = new System.Windows.Forms.TextBox();
            this.OutputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FileTypeOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InputRuleFolderNameGroupBox.SuspendLayout();
            this.ManageRuleValuesListTabControl.SuspendLayout();
            this.ManageRuleTypesTabPage.SuspendLayout();
            this.ManageRuleNamesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputRuleFolderNameGroupBox
            // 
            this.InputRuleFolderNameGroupBox.Controls.Add(this.SaveChargesCloseFormBtn);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.OutputRuleFolderLabel);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.ManageRuleValuesListTabControl);
            this.InputRuleFolderNameGroupBox.Controls.Add(this.OutputRuleFolderBox);
            this.InputRuleFolderNameGroupBox.Location = new System.Drawing.Point(13, 13);
            this.InputRuleFolderNameGroupBox.Name = "InputRuleFolderNameGroupBox";
            this.InputRuleFolderNameGroupBox.Size = new System.Drawing.Size(307, 430);
            this.InputRuleFolderNameGroupBox.TabIndex = 1;
            this.InputRuleFolderNameGroupBox.TabStop = false;
            // 
            // SaveChargesCloseFormBtn
            // 
            this.SaveChargesCloseFormBtn.Location = new System.Drawing.Point(172, 401);
            this.SaveChargesCloseFormBtn.Name = "SaveChargesCloseFormBtn";
            this.SaveChargesCloseFormBtn.Size = new System.Drawing.Size(129, 23);
            this.SaveChargesCloseFormBtn.TabIndex = 2;
            this.SaveChargesCloseFormBtn.Text = "Сохранить и закрыть";
            this.SaveChargesCloseFormBtn.UseVisualStyleBackColor = true;
            this.SaveChargesCloseFormBtn.Click += new System.EventHandler(this.SaveChargesCloseForm_Click);
            // 
            // OutputRuleFolderLabel
            // 
            this.OutputRuleFolderLabel.AutoSize = true;
            this.OutputRuleFolderLabel.Location = new System.Drawing.Point(3, 16);
            this.OutputRuleFolderLabel.Name = "OutputRuleFolderLabel";
            this.OutputRuleFolderLabel.Size = new System.Drawing.Size(88, 13);
            this.OutputRuleFolderLabel.TabIndex = 3;
            this.OutputRuleFolderLabel.Text = "Конечная папка";
            // 
            // ManageRuleValuesListTabControl
            // 
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleTypesTabPage);
            this.ManageRuleValuesListTabControl.Controls.Add(this.ManageRuleNamesTabPage);
            this.ManageRuleValuesListTabControl.Location = new System.Drawing.Point(6, 58);
            this.ManageRuleValuesListTabControl.Name = "ManageRuleValuesListTabControl";
            this.ManageRuleValuesListTabControl.SelectedIndex = 0;
            this.ManageRuleValuesListTabControl.Size = new System.Drawing.Size(295, 337);
            this.ManageRuleValuesListTabControl.TabIndex = 2;
            // 
            // ManageRuleTypesTabPage
            // 
            this.ManageRuleTypesTabPage.Controls.Add(this.RuleTypeBox);
            this.ManageRuleTypesTabPage.Controls.Add(this.SaveRuleTypeFromBoxBtn);
            this.ManageRuleTypesTabPage.Controls.Add(this.VisualizeRuleTypesListView);
            this.ManageRuleTypesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ManageRuleTypesTabPage.Name = "ManageRuleTypesTabPage";
            this.ManageRuleTypesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManageRuleTypesTabPage.Size = new System.Drawing.Size(287, 311);
            this.ManageRuleTypesTabPage.TabIndex = 0;
            this.ManageRuleTypesTabPage.Text = "Управление типами";
            this.ManageRuleTypesTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleTypeBox
            // 
            this.RuleTypeBox.Location = new System.Drawing.Point(6, 8);
            this.RuleTypeBox.Name = "RuleTypeBox";
            this.RuleTypeBox.Size = new System.Drawing.Size(194, 20);
            this.RuleTypeBox.TabIndex = 3;
            this.RuleTypeBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RuleTypeBox_MouseDoubleClick);
            // 
            // SaveRuleTypeFromBoxBtn
            // 
            this.SaveRuleTypeFromBoxBtn.Location = new System.Drawing.Point(206, 6);
            this.SaveRuleTypeFromBoxBtn.Name = "SaveRuleTypeFromBoxBtn";
            this.SaveRuleTypeFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleTypeFromBoxBtn.TabIndex = 2;
            this.SaveRuleTypeFromBoxBtn.Text = "Сохранить";
            this.SaveRuleTypeFromBoxBtn.UseVisualStyleBackColor = true;
            this.SaveRuleTypeFromBoxBtn.Click += new System.EventHandler(this.SaveRuleTypeFromBoxBtn_Click);
            // 
            // VisualizeRuleTypesListView
            // 
            this.VisualizeRuleTypesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VisualizeTypesColumnHeader});
            this.VisualizeRuleTypesListView.FullRowSelect = true;
            this.VisualizeRuleTypesListView.HoverSelection = true;
            this.VisualizeRuleTypesListView.Location = new System.Drawing.Point(6, 35);
            this.VisualizeRuleTypesListView.MultiSelect = false;
            this.VisualizeRuleTypesListView.Name = "VisualizeRuleTypesListView";
            this.VisualizeRuleTypesListView.Size = new System.Drawing.Size(275, 270);
            this.VisualizeRuleTypesListView.TabIndex = 0;
            this.VisualizeRuleTypesListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleTypesListView.View = System.Windows.Forms.View.Details;
            this.VisualizeRuleTypesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizeRuleTypesListView_KeyUp);
            this.VisualizeRuleTypesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VisualizeRuleTypesListView_MouseDoubleClick);
            // 
            // VisualizeTypesColumnHeader
            // 
            this.VisualizeTypesColumnHeader.Text = "Типы файлов";
            this.VisualizeTypesColumnHeader.Width = 150;
            // 
            // ManageRuleNamesTabPage
            // 
            this.ManageRuleNamesTabPage.Controls.Add(this.RuleNameBox);
            this.ManageRuleNamesTabPage.Controls.Add(this.SaveRuleNameFromBoxBtn);
            this.ManageRuleNamesTabPage.Controls.Add(this.VisualizeRuleNamesListView);
            this.ManageRuleNamesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ManageRuleNamesTabPage.Name = "ManageRuleNamesTabPage";
            this.ManageRuleNamesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManageRuleNamesTabPage.Size = new System.Drawing.Size(287, 311);
            this.ManageRuleNamesTabPage.TabIndex = 1;
            this.ManageRuleNamesTabPage.Text = "Управление именами";
            this.ManageRuleNamesTabPage.UseVisualStyleBackColor = true;
            // 
            // RuleNameBox
            // 
            this.RuleNameBox.Location = new System.Drawing.Point(6, 8);
            this.RuleNameBox.Name = "RuleNameBox";
            this.RuleNameBox.Size = new System.Drawing.Size(194, 20);
            this.RuleNameBox.TabIndex = 5;
            // 
            // SaveRuleNameFromBoxBtn
            // 
            this.SaveRuleNameFromBoxBtn.Location = new System.Drawing.Point(206, 6);
            this.SaveRuleNameFromBoxBtn.Name = "SaveRuleNameFromBoxBtn";
            this.SaveRuleNameFromBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRuleNameFromBoxBtn.TabIndex = 4;
            this.SaveRuleNameFromBoxBtn.Text = "Сохранить";
            this.SaveRuleNameFromBoxBtn.UseVisualStyleBackColor = true;
            this.SaveRuleNameFromBoxBtn.Click += new System.EventHandler(this.SaveRuleNameFromBoxBtn_Click);
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
            this.VisualizeRuleNamesListView.Size = new System.Drawing.Size(275, 270);
            this.VisualizeRuleNamesListView.TabIndex = 3;
            this.VisualizeRuleNamesListView.UseCompatibleStateImageBehavior = false;
            this.VisualizeRuleNamesListView.View = System.Windows.Forms.View.Details;
            this.VisualizeRuleNamesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisualizeRuleNamesListView_KeyUp);
            this.VisualizeRuleNamesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VisualizeRuleNamesListView_MouseDoubleClick);
            // 
            // VisualizeNamesColumnHeader
            // 
            this.VisualizeNamesColumnHeader.Text = "Названия файлов";
            this.VisualizeNamesColumnHeader.Width = 150;
            // 
            // OutputRuleFolderBox
            // 
            this.OutputRuleFolderBox.Location = new System.Drawing.Point(6, 32);
            this.OutputRuleFolderBox.Name = "OutputRuleFolderBox";
            this.OutputRuleFolderBox.Size = new System.Drawing.Size(291, 20);
            this.OutputRuleFolderBox.TabIndex = 1;
            this.OutputRuleFolderBox.TextChanged += new System.EventHandler(this.OutputRuleFolderBox_TextChanged);
            this.OutputRuleFolderBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OutputRuleFolderBox_MouseDoubleClick);
            // 
            // OutputFolderBrowserDialog
            // 
            this.OutputFolderBrowserDialog.Description = "Выберите папку для её дальнейшего обслуживания.";
            this.OutputFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FileTypeOpenFileDialog
            // 
            this.FileTypeOpenFileDialog.Multiselect = true;
            // 
            // ManageFolderRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 455);
            this.Controls.Add(this.InputRuleFolderNameGroupBox);
            this.MaximizeBox = false;
            this.Name = "ManageFolderRuleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManageFolderRuleForm";
            this.Load += new System.EventHandler(this.ManageFolderRuleForm_Load);
            this.InputRuleFolderNameGroupBox.ResumeLayout(false);
            this.InputRuleFolderNameGroupBox.PerformLayout();
            this.ManageRuleValuesListTabControl.ResumeLayout(false);
            this.ManageRuleTypesTabPage.ResumeLayout(false);
            this.ManageRuleTypesTabPage.PerformLayout();
            this.ManageRuleNamesTabPage.ResumeLayout(false);
            this.ManageRuleNamesTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox InputRuleFolderNameGroupBox;
        private System.Windows.Forms.ListView VisualizeRuleTypesListView;
        private System.Windows.Forms.TabControl ManageRuleValuesListTabControl;
        private System.Windows.Forms.TabPage ManageRuleTypesTabPage;
        private System.Windows.Forms.TabPage ManageRuleNamesTabPage;
        private System.Windows.Forms.TextBox OutputRuleFolderBox;
        private System.Windows.Forms.Button SaveChargesCloseFormBtn;
        private System.Windows.Forms.Label OutputRuleFolderLabel;
        private System.Windows.Forms.FolderBrowserDialog OutputFolderBrowserDialog;
        private System.Windows.Forms.ColumnHeader VisualizeTypesColumnHeader;
        private System.Windows.Forms.ListView VisualizeRuleNamesListView;
        private System.Windows.Forms.ColumnHeader VisualizeNamesColumnHeader;
        private System.Windows.Forms.TextBox RuleTypeBox;
        private System.Windows.Forms.Button SaveRuleTypeFromBoxBtn;
        private System.Windows.Forms.TextBox RuleNameBox;
        private System.Windows.Forms.Button SaveRuleNameFromBoxBtn;
        private System.Windows.Forms.OpenFileDialog FileTypeOpenFileDialog;
    }
}