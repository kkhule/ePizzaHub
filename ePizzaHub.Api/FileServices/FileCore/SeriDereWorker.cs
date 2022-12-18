using System;
using System.Collections.Generic;
using System.Text;

namespace FileServices.FileCore
{
    public class SeriDereWorker
    {

        private SerializationDeserialization serializationDeserialization;

        public SeriDereWorker(string db)
        {
            serializationDeserialization = SeriDereKeeper.GetSerDer("");
        }

        public void SerializeData<T>(T data,string filePath)
        {
            serializationDeserialization.SerializeData(data, filePath);
        }

        public T DeserializeData<T>(string filePath)
        {
            return serializationDeserialization.DeserializeData<T>(filePath);
        }
    }
}
