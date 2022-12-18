using System;
using System.Collections.Generic;
using System.Text;

namespace FileServices.FileCore
{
    public sealed class SeriDeseFactory
    {

        public SeriDeseFactory()
        {

        }

        public static SerializationDeserialization CreateSeriDese(string SeriDeseType)
        {
            switch (SeriDeseType.ToUpper())
            {
                case "JSON":
                    return new JsonSerializerDeserializer();

                case "XML":
                    return new XmlSerializerDeserializer();

                default:
                    return null;
            }
        }

    }
}
