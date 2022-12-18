using System;
using System.Collections.Generic;
using System.Text;

namespace FileServices.FileCore
{
    public static class SeriDereKeeper
    {
        static Dictionary<string, SerializationDeserialization> _SerDerCollection;
        static object syncLock = new object();

        static SeriDereKeeper()
        {
            _SerDerCollection = new Dictionary<string, SerializationDeserialization>();
        }

        public static SerializationDeserialization GetSerDer(string key)
        {
            lock(syncLock)
            {
                if(!_SerDerCollection.ContainsKey(key))
                {
                    _SerDerCollection.Add(key, CreateSerializationDeserialization(key));
                }

                return _SerDerCollection[key];
            }
        }

        private static SerializationDeserialization CreateSerializationDeserialization (string key)
        {
           return SeriDeseFactory.CreateSeriDese(key);
        }

    }
}
