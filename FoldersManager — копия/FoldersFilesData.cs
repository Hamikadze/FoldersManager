using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersManager
{
    internal class FoldersFilesData
    {
        public static string PathCoreFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "FoldersManager";
        public static string PathFoldersRules = PathCoreFolder + @"\" + "FoldersRulesCollection.json";
    }
}