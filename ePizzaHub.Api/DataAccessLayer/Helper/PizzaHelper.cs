using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class PizzaHelper
    {
        public static readonly string ExePath;

        static PizzaHelper()
        {
            ExePath = AppDomain.CurrentDomain.BaseDirectory;
            CreateResourcesDirectory();
        }

        private static void CreateResourcesDirectory()
        {
            string dirPath = CombinePath(ExePath, "JsonFiles");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        public static string JsonFilePath { get { return CombinePath(ExePath, "JsonFiles"); } }

        public static string CombinePath(string path, string fileName)
        {
            return System.IO.Path.Combine(path, fileName);
        }
    }
}
