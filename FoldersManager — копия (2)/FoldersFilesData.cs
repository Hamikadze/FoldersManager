using System;

namespace FoldersManager
{
    internal class FoldersFilesData
    {
        public static string PathCoreFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "FoldersManager";
        public static string PathFoldersRules = PathCoreFolder + @"\" + "FoldersRulesCollection.json";
    }
}