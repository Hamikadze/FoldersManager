﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    }
}