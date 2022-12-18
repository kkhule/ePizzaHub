using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileServices.FileCore
{
    public static class FilesStream 
    {

        static object syncLock = new object();

        static bool FileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        public static object ReadFile(string filePath)
        {
            if (!FileExist(filePath))
            {
                return false;
            }

            string data=string.Empty;
            using (StreamReader sReader = new StreamReader(filePath))
            {
                data=sReader.ReadToEnd();
            }

            return data;
        }

        public static void WriteFile(object data, string filePath)
        {
            lock (syncLock)
            {
                using (StreamWriter sWriter = new StreamWriter(filePath, true))
                {
                    sWriter.Write(data.ToString());
                }
            }
        }
    }
}
