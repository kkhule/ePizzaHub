using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileServices.FileCore
{
    public abstract class SerializationDeserialization
    {
        object syncLock = new object();

        public abstract void SerializeData<T>(T data, string filePath);

        public abstract T DeserializeData<T>(string filePath);

        bool FileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        public  object ReadFile(string filePath)
        {
            if (!FileExist(filePath))
            {
                return false;
            }

            string data = string.Empty;
            using (StreamReader sReader = new StreamReader(filePath))
            {
                data = sReader.ReadToEnd();
            }

            return data;
        }

        public  void WriteFile(object data, string filePath)
        {
            lock (syncLock)
            {
                using (StreamWriter sWriter = new StreamWriter(filePath, false))
                {
                    sWriter.Write(data.ToString());
                }
            }
        }
    }
}
