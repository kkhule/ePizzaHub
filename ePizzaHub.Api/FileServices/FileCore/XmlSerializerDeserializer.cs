using System;
using System.Collections.Generic;
using System.Text;

namespace FileServices.FileCore
{
    public class XmlSerializerDeserializer : SerializationDeserialization
    {
        public override T DeserializeData<T>(string filePath)
        {
            throw new NotImplementedException();
        }

        public override void SerializeData<T>(T data, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
