using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoldersManager
{
    internal class FoldersFilesUtils
    {
        public static void CreateFolder()
        {
            Directory.CreateDirectory(FoldersFilesData.PathCoreFolder);
        }

        public static string ReadFromFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append(s);
                        //we're just testing read speeds
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Error();
                return string.Empty;
            }
        }

        public static bool CompareFiles(string path1, string path2)
        {
            FileInfo fileInfo1 = new FileInfo(path1);
            FileInfo fileInfo2 = new FileInfo(path2);
            return fileInfo1.Length == fileInfo2.Length;
        }
    }
}