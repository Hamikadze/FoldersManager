using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FoldersManager
{
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    public partial class MainForm : Form
    {
        private int _oldWidth;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _oldWidth = this.Width;
            this.MinimumSize = this.Size;
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
                    Text = string.IsNullOrWhiteSpace(folder.OutputFolderPath) ? string.Empty : new DirectoryInfo(folder.OutputFolderPath).Name,
                    SubItems = { filesTypes }
                });
            }
            SelectedFolderRulesListView.Items.AddRange(itemsList.ToArray());
            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void ReloadVisualizeRuleListView()
        {
            VisualizeRuleExpansionsListView.Items.Clear();
            VisualizeRuleNamesListView.Items.Clear();
            if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Any() || !FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                   .ValuesList.Any()) return;
            if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Any(x => x.Type == EnumData.EnumRuleValuesTypes.Extension))
            {
                var itemsList = new List<ListViewItem>();
                foreach (var type in FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.FindAll(x => x.Type == EnumData.EnumRuleValuesTypes.Extension))
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
               .ValuesList.Any(x => x.Type == EnumData.EnumRuleValuesTypes.Name))
            {
                var itemsList = new List<ListViewItem>();
                foreach (var name in FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.FindAll(x => x.Type == EnumData.EnumRuleValuesTypes.Name))
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
            GroupBoxVisibleChange(VisualizeRuleFolderGroupBox);
            FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(string.Empty, false, new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
            ReloadSelectedFolderRulesListView();
            SelectedFolderRulesListView.Items[SelectedFolderRulesListView.Items.Count - 1].Selected = true;
            if (FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.Count > SelectedFolderRulesListView.SelectedIndices[0])
            {
                OutputRuleFolderBox.Text =
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                        .OutputFolderPath;
                ReloadVisualizeRuleListView();
            }
            if (string.IsNullOrWhiteSpace(
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[
                    SelectedFolderRulesListView.SelectedIndices[0]].OutputFolderPath))
            {
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary.RemoveAt(SelectedFolderRulesListView.Items.Count - 1);
            }
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
                    GroupBoxVisibleChange(SelectedFolderRulesGroupBox);
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
                    GroupBoxVisibleChange(VisualizeRuleFolderGroupBox);
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
#if !DEBUG
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
#endif

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
            GroupBoxVisibleChange(InputFoldersListGroupBox);
            ReloadInputFoldersListView();
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

        private void CloseVisualizeRuleFolderBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(CloseVisualizeRuleFolderBtn, "Изменения сохраняются автоматически");
        }

        private void FoldersListViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = InputFoldersListView.SelectedItems.Count > 0;
        }

        private void OutputRuleFolderBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OutputRuleFolderBox.Text))
            {
                ManageRuleValuesListTabControl.Enabled = false;
                return;
            }
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
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(x => x.Value == VisualizeRuleExpansionsListView.SelectedItems[0].Text && x.Type == EnumData.EnumRuleValuesTypes.Extension).Enabled ^= true;
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void VisualizeRuleNamesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (VisualizeRuleNamesListView.SelectedIndices.Count == 0) return;
            FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Find(x => x.Value == VisualizeRuleNamesListView.SelectedItems[0].Text && x.Type == EnumData.EnumRuleValuesTypes.Name).Enabled ^= true;
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
                                    x.Type == EnumData.EnumRuleValuesTypes.Name);
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
                                    x.Type == EnumData.EnumRuleValuesTypes.Extension);
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].ValuesList.Remove(valueItem);
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void SaveRuleNameFromBoxBtn_Click(object sender, EventArgs e)
        {
            if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Exists(x => x.Value == RuleNameBox.Text && x.Type == EnumData.EnumRuleValuesTypes.Name))
            {
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumData.EnumRuleValuesTypes.Name, RuleNameBox.Text, false));
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
                     .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumData.EnumRuleValuesTypes.Extension, fileExtension, false));
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
                    .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumData.EnumRuleValuesTypes.Extension, fileExtension, false));
                }
            }
            ReloadVisualizeRuleListView();
        }

        private void SaveRuleExpansionFromBoxBtn_Click(object sender, EventArgs e)
        {
            List<string> extensionsList = new List<string>();
            if (Regex.IsMatch(RuleExpansionBox.Text.Trim(), "[;|, ]"))
            {
                foreach (var rawExtension in Regex.Split(RuleExpansionBox.Text, "[;|, ]"))
                {
                    if (string.IsNullOrWhiteSpace(rawExtension)) continue;
                    string rawExtensionTemp = rawExtension;
                    if (rawExtensionTemp[0] != '.')
                    {
                        rawExtensionTemp = "." + rawExtensionTemp;
                    }
                    if (rawExtensionTemp[rawExtensionTemp.Length - 1] == '.')
                    {
                        rawExtensionTemp = rawExtensionTemp.Substring(0, rawExtensionTemp.Length - 1);
                    }
                    extensionsList.Add(rawExtensionTemp.Trim());
                }
            }
            else
            {
                string rawExtensionTemp = RuleExpansionBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(rawExtensionTemp)) return;
                if (rawExtensionTemp[0] != '.')
                {
                    rawExtensionTemp = "." + rawExtensionTemp;
                }
                if (rawExtensionTemp[rawExtensionTemp.Length - 1] == '.')
                {
                    rawExtensionTemp = rawExtensionTemp.Substring(0, rawExtensionTemp.Length - 1);
                }
                extensionsList.Add(rawExtensionTemp.Trim());
            }
            foreach (var extension in extensionsList)
            {
                var fileExtension = Path.GetExtension(extension);
                RuleExpansionBox.Text = fileExtension;
                if (!FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                    .ValuesList.Exists(x => x.Value == fileExtension))
                {
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]]
                    .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumData.EnumRuleValuesTypes.Extension, fileExtension, false));
                }
            }
            ReloadVisualizeRuleListView();
        }

        private void CloseVisualizeRuleFolderBtn_Click(object sender, EventArgs e)
        {
            GroupBoxVisibleChange(SelectedFolderRulesGroupBox);
            if (SelectedFolderRulesListView.SelectedItems.Count > 0)
                SelectedFolderRulesListView.SelectedItems[0].Selected = false;
            SelectedFolderRulesListView.Focus();
            ReloadSelectedFolderRulesListView();
        }

        private void CloseSelectedFolderRulesBtn_Click(object sender, EventArgs e)
        {
            GroupBoxVisibleChange(InputFoldersListGroupBox);
            if (InputFoldersListView.SelectedItems.Count > 0)
                InputFoldersListView.SelectedItems[0].Selected = false;
            InputFoldersListView.Focus();
            ReloadInputFoldersListView();
        }

        private void CloseSelectedFolderRulesBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(CloseSelectedFolderRulesBtn, "Изменения сохраняются автоматически");
        }

        private void GroupBoxVisibleChange(Control control)
        {
            control.Visible = true;
            if (InputFoldersListGroupBox == control)
            {
                CancelButton = null;
                AcceptButton = null;
            }
            if (SelectedFolderRulesGroupBox == control)
            {
                CancelButton = CloseSelectedFolderRulesBtn;
                AcceptButton = null;
            }
            if (VisualizeRuleFolderGroupBox == control)
            {
                CancelButton = CloseVisualizeRuleFolderBtn;
                AcceptButton = null;
            }

            if (InputFoldersListGroupBox != control)
                InputFoldersListGroupBox.Visible = !control.Visible;
            if (SelectedFolderRulesGroupBox != control)
                SelectedFolderRulesGroupBox.Visible = !control.Visible;
            if (VisualizeRuleFolderGroupBox != control)
                VisualizeRuleFolderGroupBox.Visible = !control.Visible;
        }

        private void SortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThreadsUtils.SortThread.IsAlive) return;
            ThreadsUtils.SortThread = new Thread(() =>
            {
                AppUtils.MoveFilesTask();
                ThreadsUtils.SortThread.Abort();
            })
            { IsBackground = true };
            ThreadsUtils.SortThread.Start();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            OutputFolderColumnHeader.Width = OutputFolderColumnHeader.Width + this.Width - _oldWidth;
            FolderNameColumnHeader.Width = FolderNameColumnHeader.Width + this.Width - _oldWidth;
            VisualizeExpansionColumnHeader.Width = VisualizeExpansionColumnHeader.Width + this.Width - _oldWidth;
            _oldWidth = this.Width;
        }
    }
}