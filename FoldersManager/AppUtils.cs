using FoldersManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoldersManager
{
    internal class AppUtils
    {
        public static void MoveFilesTask()
        {
            try
            {
                foreach (var inputFolder in FoldersRulesCollection.FoldersRulesList.FindAll(x => x.Enabled))
                {
                    foreach (var rule in inputFolder.RulesDictionary.FindAll(x => x.Enabled))
                    {
                        foreach (
                            var value in
                                rule.ValuesList.FindAll(
                                    x => x.Enabled && x.Type == EnumData.EnumRuleValuesTypes.Extension)
                                    .Select(x => x.Value))
                        {
                            var filesInInputFolder =
                                Directory.GetFiles(inputFolder.InputFolderPath)
                                    .ToList()
                                    .FindAll(x => Path.GetExtension(x) == value);
                            foreach (var fileInInputFolder in filesInInputFolder)
                            {
                                string outputPath = rule.OutputFolderPath + @"\" + Path.GetFileName(fileInInputFolder);
                                if (File.Exists(outputPath))
                                {
                                    if (FoldersFilesUtils.CompareFiles(fileInInputFolder, outputPath))
                                    {
                                        File.Delete(fileInInputFolder);
                                    }
                                }
                                else
                                {
                                    File.Move(fileInInputFolder, outputPath);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Error();
            }

            //Parallel.ForEach(FoldersRulesCollection.FoldersRulesList.FindAll(x => x.Enabled), folderRuleItem =>
            //{
            //    Parallel.ForEach(folderRuleItem.RulesDictionary.FindAll(x => x.Enabled), rulesDictionaryItem =>
            //    {
            //        Parallel.ForEach(
            //            rulesDictionaryItem.ValuesList.FindAll(x => x.Enabled && x.Type == EnumData.EnumRuleValuesTypes.Extension)
            //                .Select(x => x.Value),
            //            value =>
            //            {
            //                var filesInInputFolder =
            //                    Directory.GetFiles(folderRuleItem.InputFolderPath)
            //                        .ToList();
            //                Parallel.ForEach(filesInInputFolder.FindAll(x => Path.GetExtension(x) == value),
            //                    fileInInputFolder =>
            //                    {
            //                        File.Move(fileInInputFolder,
            //                            rulesDictionaryItem.OutputFolderPath + @"\" +
            //                            Path.GetFileName(fileInInputFolder));
            //                    });
            //                Parallel.ForEach(filesInInputFolder.FindAll(x => Regex.IsMatch(Path.GetFileName(x), value)),
            //                    fileInInputFolder =>
            //                    {
            //                        File.Move(fileInInputFolder,
            //                            rulesDictionaryItem.OutputFolderPath + @"\" +
            //                            Path.GetFileName(fileInInputFolder));
            //                    });
            //            });
            //    });
            //});
        }
    }
}

public static class FoldersRulesCollection
{
    public static List<FoldersRulesItem> FoldersRulesList = new List<FoldersRulesItem>();

    public class FoldersRulesItem
    {
        public FoldersRulesItem(string inputFolderPath, bool enabled, List<RulesDictionaryItem> rulesDictionary)
        {
            InputFolderPath = inputFolderPath;
            Enabled = enabled;
            RulesDictionary = rulesDictionary;
        }

        public string InputFolderPath { get; set; }
        public bool Enabled { get; set; }

        public List<RulesDictionaryItem> RulesDictionary { get; set; }

        public class RulesDictionaryItem
        {
            public RulesDictionaryItem(string outputFolderPath, bool enabled, List<ValuesItem> valuesList)
            {
                OutputFolderPath = outputFolderPath;
                Enabled = enabled;
                ValuesList = valuesList;
            }

            public string OutputFolderPath { get; set; }
            public bool Enabled { get; set; }
            public List<ValuesItem> ValuesList { get; set; }

            public class ValuesItem
            {
                public ValuesItem(EnumData.EnumRuleValuesTypes type, string value, bool enabled)
                {
                    Type = type;
                    Value = value;
                    Enabled = enabled;
                }

                public EnumData.EnumRuleValuesTypes Type { get; set; }

                public string Value { get; set; }

                public bool Enabled { get; set; }
            }
        }
    }
}