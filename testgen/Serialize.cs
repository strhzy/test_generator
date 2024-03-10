using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testgen
{
    internal class Json
    {
        public static T Deserialize<T>()
        {
            string json = File.ReadAllText("test.json");
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
        public static void Serialize<T>(T test)
        {
            string json = JsonConvert.SerializeObject(test);
            File.WriteAllText("test.json", json);
        }
    }
}
