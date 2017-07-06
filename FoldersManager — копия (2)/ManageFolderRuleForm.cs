using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoldersManager
{
    public partial class ManageFolderRuleForm : Form
    {
        private readonly int _indexOutputFolder = 0;
        private readonly int _indexInputFolder = 0;

        public ManageFolderRuleForm(int indexOutputFolder, int indexInputFolder)
        {
            _indexOutputFolder = indexOutputFolder;
            _indexInputFolder = indexInputFolder;
            InitializeComponent();
        }

        private void ManageFolderRuleForm_Load(object sender, EventArgs e)
        {
            InputRuleFolderNameGroupBox.Text =
                new DirectoryInfo(FoldersRulesCollection.FoldersRulesList[_indexInputFolder].InputFolderPath).Name;
            if (FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Count > _indexOutputFolder)
            {
                OutputRuleFolderBox.Text =
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                        .OutputFolderPath;
                ReloadVisualizeRuleListView();
            }
        }

        public static void ShowManageFolderRuleFolrm(int outputIndex, int inputIndex)
        {
            ManageFolderRuleForm manageFolderRuleForm = new ManageFolderRuleForm(outputIndex, inputIndex);
            manageFolderRuleForm.ShowDialog();
            return;
        }

        private void OutputRuleFolderBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OutputFolderBrowserDialog.Reset();
            OutputFolderBrowserDialog.Description = @"Выберите папку для её дальнейшего обслуживания.";
            DialogResult folderDialogResult = OutputFolderBrowserDialog.ShowDialog();
            if (folderDialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(OutputFolderBrowserDialog.SelectedPath)) return;
            if (
                FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Exists(x => x.OutputFolderPath == OutputFolderBrowserDialog.SelectedPath) && FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].OutputFolderPath != OutputFolderBrowserDialog.SelectedPath)
            {
                MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Count <= _indexOutputFolder)
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(OutputFolderBrowserDialog.SelectedPath, false, new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
                else
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].OutputFolderPath = OutputFolderBrowserDialog.SelectedPath;
                OutputRuleFolderBox.Text = OutputFolderBrowserDialog.SelectedPath;
            }
        }

        private void SaveChargesCloseForm_Click(object sender, EventArgs e)
        {
            Close();
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
                        FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].OutputFolderPath;
            }
            else
            {
                if (
                FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Exists(x => x.OutputFolderPath == OutputRuleFolderBox.Text) && FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].OutputFolderPath != OutputRuleFolderBox.Text)
                {
                    MessageBox.Show(@"Данная папка уже содержится в списке.", @"Повторное добавление папки!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Count <= _indexOutputFolder)
                        FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem(OutputRuleFolderBox.Text, false, new List<FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem>()));
                    else
                        FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].OutputFolderPath = OutputRuleFolderBox.Text;
                    OutputRuleFolderBox.Text =
                        FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                            .OutputFolderPath;
                }
            }
        }

        private void RuleTypeBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileTypeOpenFileDialog.Reset();
            FileTypeOpenFileDialog.InitialDirectory =
                FoldersRulesCollection.FoldersRulesList[_indexInputFolder].InputFolderPath;
            DialogResult fileTypeDialogResult = FileTypeOpenFileDialog.ShowDialog();

            if (fileTypeDialogResult != DialogResult.OK || !FileTypeOpenFileDialog.SafeFileNames.Any()) return;

            if (FileTypeOpenFileDialog.SafeFileNames.Length > 1)
                foreach (var fullFileName in FileTypeOpenFileDialog.SafeFileNames)
                {
                    string fileExtension = Path.GetExtension(fullFileName);
                    if (!FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                        .ValuesList.Exists(x => x.Value == fileExtension))
                    {
                        FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                     .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
                    }
                }
            else
            {
                string fileExtension = Path.GetExtension(FileTypeOpenFileDialog.SafeFileNames[0]);
                RuleTypeBox.Text = fileExtension;
                if (!FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                    .ValuesList.Exists(x => x.Value == fileExtension))
                {
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                    .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
                }
            }
            ReloadVisualizeRuleListView();
        }

        private void ReloadVisualizeRuleListView()
        {
            if (!FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary.Any() || !FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                   .ValuesList.Any()) return;

            if (FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                .ValuesList.Any(x => x.Type == EnumRuleValuesTypes.Extension))
            {
                var itemsList = new List<ListViewItem>();
                VisualizeRuleTypesListView.Items.Clear();
                foreach (var type in FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.FindAll(x => x.Type == EnumRuleValuesTypes.Extension))
                {
                    Color backColor = type.Enabled ? Color.LightGreen : Color.LightCoral;
                    itemsList.Add(new ListViewItem()
                    {
                        Selected = false,
                        BackColor = backColor,
                        Text = type.Value
                    });
                }
                VisualizeRuleTypesListView.Items.AddRange(itemsList.ToArray());
            }
            if (FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
               .ValuesList.Any(x => x.Type == EnumRuleValuesTypes.Name))
            {
                var itemsList = new List<ListViewItem>();
                VisualizeRuleNamesListView.Items.Clear();
                foreach (var name in FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.FindAll(x => x.Type == EnumRuleValuesTypes.Name))
                {
                    Color backColor = name.Enabled ? Color.LightGreen : Color.LightCoral;
                    itemsList.Add(new ListViewItem()
                    {
                        Selected = false,
                        BackColor = backColor,
                        Text = name.Value
                    });
                }
                VisualizeRuleNamesListView.Items.AddRange(itemsList.ToArray());
            }

            File.WriteAllText(FoldersFilesData.PathFoldersRules, JsonConvert.SerializeObject(FoldersRulesCollection.FoldersRulesList, Formatting.Indented));
        }

        private void SaveRuleTypeFromBoxBtn_Click(object sender, EventArgs e)
        {
            var fileExtension = Path.GetExtension(RuleTypeBox.Text);
            RuleTypeBox.Text = fileExtension;
            if (!FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                .ValuesList.Exists(x => x.Value == fileExtension))
            {
                FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Extension, fileExtension, false));
            }
            ReloadVisualizeRuleListView();
        }

        private void SaveRuleNameFromBoxBtn_Click(object sender, EventArgs e)
        {
            if (!FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                .ValuesList.Exists(x => x.Value == RuleNameBox.Text))
            {
                FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder]
                .ValuesList.Add(new FoldersRulesCollection.FoldersRulesItem.RulesDictionaryItem.ValuesItem(EnumRuleValuesTypes.Name, RuleNameBox.Text, false));
            }
            ReloadVisualizeRuleListView();
        }

        private void VisualizeRuleTypesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (VisualizeRuleTypesListView.SelectedIndices.Count == 0) return;
            FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.Find(x => x.Value == VisualizeRuleTypesListView.SelectedItems[0].Text && x.Type == EnumRuleValuesTypes.Extension).Enabled ^= true;
            ReloadVisualizeRuleListView();
        }

        private void VisualizeRuleNamesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (VisualizeRuleNamesListView.SelectedIndices.Count == 0) return;
            FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.Find(x => x.Value == VisualizeRuleNamesListView.SelectedItems[0].Text && x.Type == EnumRuleValuesTypes.Name).Enabled ^= true;
            ReloadVisualizeRuleListView();
        }

        private void VisualizeRuleTypesListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (VisualizeRuleTypesListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.RemoveAt(VisualizeRuleTypesListView.SelectedIndices[0]);
                    VisualizeRuleTypesListView.Items.Clear();
                    ReloadVisualizeRuleListView();
                    break;
            }
        }

        private void VisualizeRuleNamesListView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (VisualizeRuleNamesListView.SelectedIndices.Count == 0) return;
                    FoldersRulesCollection.FoldersRulesList[_indexInputFolder].RulesDictionary[_indexOutputFolder].ValuesList.RemoveAt(VisualizeRuleNamesListView.SelectedIndices[0]);
                    VisualizeRuleNamesListView.Items.Clear();
                    ReloadVisualizeRuleListView();
                    break;
            }
        }
    }
}