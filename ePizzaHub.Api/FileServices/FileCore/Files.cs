using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileServices.FileCore
{
    public abstract class Files
    {
        public bool FileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        public abstract object ReadFile(string filePath);

        public abstract  void WriteFile(object data,string filePath);
    }
}
