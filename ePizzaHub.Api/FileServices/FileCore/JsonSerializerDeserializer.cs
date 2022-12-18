using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileServices.FileCore
{
    public class JsonSerializerDeserializer : SerializationDeserialization
    {
        public override T DeserializeData<T>(string filePath)
        {
            var data = base.ReadFile(filePath);
            if( data.GetType() == typeof(bool) && Convert.ToBoolean(data) == false)
            {
                return default(T);
            }
           return JsonConvert.DeserializeObject<T>(data.ToString());
        }


        public override void SerializeData<T>(T data, string filePath)
        {
            var serJason= JsonConvert.SerializeObject(data, Formatting.Indented);
            base.WriteFile(serJason, filePath);
        }

    }
}
