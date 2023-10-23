using Lab4.Models;
using Newtonsoft.Json;
using System.IO;

namespace Lab4
{
    public class JsonHelper
    {
        private const string PATH = @"../../Resources/4.json";

        public void Serealire(MainModelJson mainModelJson)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(PATH))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, mainModelJson);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
        }

        public MainModelJson Deserealire()
        {
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(PATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                MainModelJson mainModelJson = (MainModelJson)serializer.Deserialize(file, typeof(MainModelJson));
                return mainModelJson;
            }
        }
    }
}