using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoldersManager
{
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ReloadInputFoldersListView()
        {
            InputFoldersListView.Items.Clear();
            var itemsList = new List<ListViewItem>();
            foreach (var folder in FoldersRulesCollection.FoldersRulesList)
            {
                Color backColor = folder.Enabled ? Color.LightGreen : Color.LightCoral;
                itemsList.Add(new ListViewItem()
                {
                    BackColor = backColor,
                    ToolTipText = folder.InputFolderPath,
                    Text = new DirectoryInfo(folder.InputFolderPath).Name
                });
            }
            InputFoldersListView.Items.AddRange(itemsList.ToArray());
            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void ReloadSelectedFolderRulesListView()
        {
            SelectedFolderRulesListView.Items.Clear();
            var itemsList = new List<ListViewItem>();
            foreach (var folder in FoldersRulesCollection.FoldersRulesList[int.Parse(SelectedFolderRulesListView.Text)].RulesDictionary)
            {
                var filesTypes = new ListViewItem.ListViewSubItem().Text = string.Join(" ", folder.ValuesList.Select(x => x.Value).ToArray());

                Color backColor = folder.Enabled ? Color.LightGreen : Color.LightCoral;
                itemsList.Add(new ListViewItem()
                {
                    BackColor = backColor,
                    ToolTipText = folder.OutputFolderPath,
                    Text = new DirectoryInfo(folder.OutputFolderPath).Name,
                    SubItems = { filesTypes }
                });
            }
            SelectedFolderRulesListView.Items.AddRange(itemsList.ToArray());
            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void ReloadVisualizeRuleListView()
        {
            if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Any() || !FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                   .ValuesList.Any()) return;

            if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Any(x => x.Type == EnumRuleValuesTypes.Extension))
            {
                var itemsList = new List<ListViewItem>();
                VisualizeRuleExpansionsListView.Items.Clear();
                foreach (var type in FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.FindAll(x => x.Type == EnumRuleValuesTypes.Extension))
                {
                    Color backColor = type.Enabled ? Color.LightGreen : Color.LightCoral;
                    itemsList.Add(new ListViewItem()
                    {
                        BackColor = backColor,
                        Text = type.Value
                    });
                }
                VisualizeRuleExpansionsListView.Items.AddRange(itemsList.ToArray());
            }
            if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
               .ValuesList.Any(x => x.Type == EnumRuleValuesTypes.Name))
            {
                var itemsList = new List<ListViewItem>();
                VisualizeRuleNamesListView.Items.Clear();
                foreach (var name in FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.FindAll(x => x.Type == EnumRuleValuesTypes.Name))
                {
                    Color backColor = name.Enabled ? Color.LightGreen : Color.LightCoral;
                    itemsList.Add(new ListViewItem()
                    {
                        BackColor = backColor,
                        Text = name.Value
                    });
                }
                VisualizeRuleNamesListView.Items.AddRange(itemsList.ToArray());
            }

            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void FolderRulesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = SelectedFolderRulesListView.SelectedItems.Count > 0;
        }

        private void AddFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.Reset();
            FolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = FolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath)) return;
            FoldersRulesCollection.FoldersRulesList.Add(new FoldersRulesCollection.FoldersRulesItem(FolderBrowserDialog.SelectedPath, false, new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem>()));
            ReloadInputFoldersListView();
        }

        private void AddRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageFolderRuleForm.ShowManageFolderRuleFolrm(SelectedFolderRulesListView.Items.Count, InputFoldersListView.SelectedIndices[0]);
            ReloadSelectedFolderRulesListView();
        }

        private void InputFoldersListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (InputFoldersListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].Enabled ^= true;
                    ReloadInputFoldersListView();
                    break;

                case MouseButtons.Left:
                    if (InputFoldersListView.SelectedIndices.Count == 0) return;
                    SelectedFolderRulesListView.Text = InputFoldersListView.SelectedIndices[0].ToString();
                    InputFoldersListGroupBox.Visible = false;
                    SelectedFolderRulesGroupBox.Visible = true;
                    VisualizeRuleFolderGroupBox.Visible = false;
                    InputRulesFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath;
                    ReloadSelectedFolderRulesListView();
                    break;
            }
        }

        private void SelectedFolderRulesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (SelectedFolderRulesListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].Enabled ^= true;
                    ReloadSelectedFolderRulesListView();
                    break;

                case MouseButtons.Left:
                    if (SelectedFolderRulesListView.SelectedIndices.Count == 0) return;
                    InputFoldersListGroupBox.Visible = false;
                    SelectedFolderRulesGroupBox.Visible = false;
                    VisualizeRuleFolderGroupBox.Visible = true;
                    if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Count > SelectedFolderRulesListView.SelectedIndices[0])
                    {
                        OutputRuleFolderBox.Text =
                            FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                                .OutputFolderPath;
                        ReloadVisualizeRuleListView();
                    }
                    break;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!File.Exists(FoldersFilesData.PathFoldersRules))
            {
                File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList));
            }
            var jsonString = File.ReadAllText(FoldersFilesData.PathFoldersRules);
            if (string.IsNullOrWhiteSpace(jsonString)) return;
            var foldersRulesList = JsonConvert.DeserializeObject<FoldersRulesCollection.FoldersRulesItem[]>(jsonString);
            foreach (var foldersRulesItem in foldersRulesList)
            {
                FoldersRulesCollection.FoldersRulesList.Add(foldersRulesItem);
            }
            InputFoldersListGroupBox.Visible = true;
            SelectedFolderRulesGroupBox.Visible = false;
            VisualizeRuleFolderGroupBox.Visible = false;
            ReloadInputFoldersListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var inputFolder in FoldersRulesCollection.FoldersRulesList.FindAll(x => x.Enabled))
            {
                foreach (var rule in inputFolder.RulesDictionary.FindAll(x => x.Enabled))
                {
                    foreach (var value in rule.ValuesList.FindAll(x => x.Enabled && x.Type == EnumRuleValuesTypes.Extension).Select(x => x.Value))
                    {
                        var filesInInputFolder =
                            Directory.GetFiles(inputFolder.InputFolderPath)
                                .ToList()
                                .FindAll(x => Path.GetExtension(x) == value);
                        foreach (var fileInInputFolder in filesInInputFolder)
                        {
                            File.Move(fileInInputFolder, rule.OutputFolderPath + @"\" + Path.GetFileName(fileInInputFolder));
                        }
                    }
                }
            }
        }

        private void InputFoldersListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (InputFoldersListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList.RemoveAt(InputFoldersListView.SelectedIndices[0]);
                    ReloadInputFoldersListView();
                    break;
            }
        }

        private void SelectedFolderRulesListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (SelectedFolderRulesListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.RemoveAt
                        (SelectedFolderRulesListView.SelectedIndices[0]);
                    ReloadSelectedFolderRulesListView();
                    break;
            }
        }

        private void CloseOutputRulesSettingsBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(CloseOutputRulesSettingsBtn, "Изменения сохраняются автоматически");
        }

        private void FoldersListViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = InputFoldersListView.SelectedItems.Count > 0;
        }

        private void OutputRuleFolderBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OutputRuleFolderBox.Text)) ManageRuleValuesListTabControl.Enabled = false;
            if (!Directory.Exists(OutputRuleFolderBox.Text))
            {
                MessageBox.Show(@"Указан неверный путь к папке.", @"Папка не существует!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OutputRuleFolderBox.Text =
                    OutputRuleFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath;
            }
            else
            {
                if (
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Exists(x => x.OutputFolderPath == OutputRuleFolderBox.Text) &&
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath != OutputRuleFolderBox.Text)
                {
                    MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Count <= SelectedFolderRulesListView.SelectedIndices[0])
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(OutputRuleFolderBox.Text, false,
                            new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
                    else
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath = OutputRuleFolderBox.Text;
                    OutputRuleFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                            .OutputFolderPath;
                }
            }
        }

        private void InputRulesFolderBox_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(InputRulesFolderBox.Text)) ManageRuleValuesListTabControl.Enabled = false;
            if (!Directory.Exists(InputRulesFolderBox.Text))
            {
                MessageBox.Show(@"Указан неверный путь к папке.", @"Папка не существует!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputRulesFolderBox.Text =
                    InputRulesFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath;
            }
            else
            {
                if (
                FoldersRulesCollection.FoldersRulesList.Exists(x => x.InputFolderPath == OutputRuleFolderBox.Text) &&
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath != OutputRuleFolderBox.Text)
                {
                    MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Count <= SelectedFolderRulesListView.SelectedIndices[0])
                    //    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(OutputRuleFolderBox.Text, false,
                    //        new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
                    //else
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath = InputRulesFolderBox.Text;
                    InputRulesFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath;
                }
            }
        }

        private void OutputRuleFolderBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog.Reset();
            FolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = FolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath)) return;
            if (
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Exists(x => x.OutputFolderPath == FolderBrowserDialog.SelectedPath) &&
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath != FolderBrowserDialog.SelectedPath)
            {
                MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Count <= SelectedFolderRulesListView.SelectedIndices[0])
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(FolderBrowserDialog.SelectedPath, false,
                        new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
                else
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath = FolderBrowserDialog.SelectedPath;
                OutputRuleFolderBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void InputRulesFolderBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog.Reset();
            FolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = FolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath)) return;
            if (
                FoldersRulesCollection.FoldersRulesList.Exists(x => x.InputFolderPath == FolderBrowserDialog.SelectedPath) &&
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath != FolderBrowserDialog.SelectedPath)
            {
                MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath = FolderBrowserDialog.SelectedPath;
                InputRulesFolderBox.Text =
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath;
            }
        }

        private void VisualizeRuleExpansionsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (VisualizeRuleExpansionsListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(x => x.Value == VisualizeRuleExpansionsListView.SelectedItems[0].Text && x.Type == EnumRuleValuesTypes.Extension).Enabled ^= true;
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void VisualizeRuleNamesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (VisualizeRuleNamesListView.SelectedIndices.Count == 0) return;
            FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(x => x.Value == VisualizeRuleNamesListView.SelectedItems[0].Text && x.Type == EnumRuleValuesTypes.Name).Enabled ^= true;
            ReloadVisualizeRuleListView();
        }

        private void VisualizeRuleNamesListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (VisualizeRuleNamesListView.SelectedIndices.Count == 0) return;
                    var valueItem =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary
                            [SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(
                                x =>
                                    x.Value == VisualizeRuleNamesListView.SelectedItems[0].Text &&
                                    x.Type == EnumRuleValuesTypes.Name);
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Remove(valueItem);
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void VisualizeRuleExpansionsListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (VisualizeRuleExpansionsListView.SelectedIndices.Count == 0) return;
                    var valueItem =
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary
                            [SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(
                                x =>
                                    x.Value == VisualizeRuleExpansionsListView.SelectedItems[0].Text &&
                                    x.Type == EnumRuleValuesTypes.Extension);
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Remove(valueItem);
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void SaveRuleNameFromBoxBtn_Click(object sender, EventArgs e)
        {
            if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Exists(x => x.Value == RuleNameBox.Text && x.Type == EnumRuleValuesTypes.Name))
            {
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Name, RuleNameBox.Text, false));
            }
            ReloadVisualizeRuleListView();
        }

        private void RuleExpansionBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileTypeOpenFileDialog.Reset();
            FileTypeOpenFileDialog.InitialDirectory =
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath;
            DialogResult fileTypeDialogResult = FileTypeOpenFileDialog.ShowDialog();

            if (fileTypeDialogResult != DialogResult.OK || !FileTypeOpenFileDialog.SafeFileNames.Any()) return;

            if (FileTypeOpenFileDialog.SafeFileNames.Length > 1)
                foreach (var fullFileName in FileTypeOpenFileDialog.SafeFileNames)
                {
                    string fileExtension = Path.GetExtension(fullFileName);
                    if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                        .ValuesList.Exists(x => x.Value == fileExtension))
                    {
                        FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                     .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
                    }
                }
            else
            {
                string fileExtension = Path.GetExtension(FileTypeOpenFileDialog.SafeFileNames[0]);
                RuleExpansionBox.Text = fileExtension;
                if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                    .ValuesList.Exists(x => x.Value == fileExtension))
                {
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                    .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
                }
            }
            ReloadVisualizeRuleListView();
        }

        private void SaveRuleExpansionFromBoxBtn_Click(object sender, EventArgs e)
        {
            var fileExtension = Path.GetExtension(RuleExpansionBox.Text);
            RuleExpansionBox.Text = fileExtension;
            if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Exists(x => x.Value == fileExtension))
            {
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
            }
            ReloadVisualizeRuleListView();
        }

        private void CloseOutputRulesSettingsBtn_Click(object sender, EventArgs e)
        {
            InputFoldersListGroupBox.Visible = false;
            SelectedFolderRulesGroupBox.Visible = true;
            VisualizeRuleFolderGroupBox.Visible = false;
            SelectedFolderRulesListView.SelectedItems[0].Selected = false;
            SelectedFolderRulesListView.Focus();
        }

        private void CloseSelectedFolderRulesBtn_Click(object sender, EventArgs e)
        {
            InputFoldersListGroupBox.Visible = true;
            SelectedFolderRulesGroupBox.Visible = false;
            VisualizeRuleFolderGroupBox.Visible = false;
            InputFoldersListView.SelectedItems[0].Selected = false;
            InputFoldersListView.Focus();
        }

        private void CloseSelectedFolderRulesBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(CloseSelectedFolderRulesBtn, "Изменения сохраняются автоматически");
        }
    }
}