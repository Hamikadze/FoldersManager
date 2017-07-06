using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersManager
{
    internal class AppUtils
    {
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
                    public ValuesItem(EnumRuleValuesTypes type, string value, bool enabled)
                    {
                        Type = type;
                        Value = value;
                        Enabled = enabled;
                    }

                    public EnumRuleValuesTypes Type { get; set; }

                    public string Value { get; set; }

                    public bool Enabled { get; set; }
                }
            }
        }
    }

    public enum EnumRuleValuesTypes
    {
        Extension,
        Name
    }
}