using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoldersManager
{
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
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
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
                    Selected = false,
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
                    Selected = false,
                    BackColor = backColor,
                    ToolTipText = folder.OutputFolderPath,
                    Text = new DirectoryInfo(folder.OutputFolderPath).Name,
                    SubItems = { filesTypes }
                });
            }
            SelectedFolderRulesListView.Items.AddRange(itemsList.ToArray());
            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void FolderRulesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = SelectedFolderRulesListView.SelectedItems.Count > 0;
        }

        private void AddFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputFolderBrowserDialog.Reset();
            InputFolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = InputFolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(InputFolderBrowserDialog.SelectedPath)) return;
            FoldersRulesCollection.FoldersRulesList.Add(new FoldersRulesCollection.FoldersRulesItem(InputFolderBrowserDialog.SelectedPath, false, new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem>()));
            ReloadInputFoldersListView();
        }

        private void AddRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageFolderRuleForm.ShowManageFolderRuleFolrm(SelectedFolderRulesListView.Items.Count, InputFoldersListView.SelectedIndices[0]);
            ReloadSelectedFolderRulesListView();
        }

        private void ChangeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputFoldersListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show(@"Выберите папку перед её изменением.", @"Папка не выбрана!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InputFolderBrowserDialog.Reset();
            InputFolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = InputFolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(InputFolderBrowserDialog.SelectedPath)) return;
            FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath = InputFolderBrowserDialog.SelectedPath;
            ReloadInputFoldersListView();
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
                    SelectedFolderRulesGroupBox.Visible = true;
                    SelectedFolderNameLabel.Text = $"Выбранная папка : {InputFoldersListView.SelectedItems[0].Text}";
                    ReloadSelectedFolderRulesListView();
                    break;
            }
        }

        private void SelectedFolderRulesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Clicks.ToString());
            switch (e.Clicks)
            {
                case 1:
                    MessageBox.Show("dsda");
                    break;

                default:
                    if (SelectedFolderRulesListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].RulesDictionary[SelectedFolderRulesListView.SelectedIndices[0]].Enabled ^= true;
                    ReloadSelectedFolderRulesListView();
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
            ReloadInputFoldersListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var inputFolder in FoldersRulesCollection.FoldersRulesList)
            {
                foreach (var rule in inputFolder.RulesDictionary)
                {
                    foreach (var value in rule.ValuesList.FindAll(x => x.Type == EnumRuleValuesTypes.Extension).Select(x => x.Value))
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

        private void SelectedFolderRulesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //if (e.Item.Checked) return;
            //e.Item.Checked = true;
            //ManageFolderRuleForm.ShowManageFolderRuleFolrm(e.ItemIndex, InputFoldersListView.SelectedIndices[0]);
            //ReloadSelectedFolderRulesListView();
        }

        private void CloseOutputRulesSettingsBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(CloseOutputRulesSettingsBtn, "Изменения сохраняются автоматически");
        }

        private void InputFoldersListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
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
            if (string.IsNullOrWhiteSpace(InputRulesFolderBox.Text)) ManageRuleValuesListTabControl.Enabled = false;
            if (!Directory.Exists(InputRulesFolderBox.Text))
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
                FoldersRulesCollection.FoldersRulesList.Exists(x => x.InputFolderPath == OutputRuleFolderBox.Text) &&
                FoldersRulesCollection.FoldersRulesList[InputFoldersListView.SelectedIndices[0]].InputFolderPath != OutputRuleFolderBox.Text)
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
    }
}