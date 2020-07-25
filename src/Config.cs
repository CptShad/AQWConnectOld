using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AQWConnect
{
   /// <summary>
   /// Json Config file class to write and read Json Files.
   /// </summary>
    public class Config
    {
        public static JObject configFile = new JObject();
        /// <summary>
        /// Initializes the Config.json file
        /// </summary>
        public static void Initialize()
        {
            if (File.Exists("./Config/Config.json"))
            {
                using (StreamReader reader = File.OpenText("./Config/Config.json"))
                {
                    configFile = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                }
            }
            else
            {
                if (!Directory.Exists("./Config/"))
                    Directory.CreateDirectory("./Config/");
                configFile.Add("token", "");
                File.WriteAllText("./Config/Config.json", configFile.ToString());
            }
        }

        /// <summary>
        /// Refreshes the config file
        /// </summary>
        private static void Refresh()
        {
            if (File.Exists("./Config/Config.json"))
            {
                using (StreamReader reader = File.OpenText("./Config/Config.json"))
                {
                    configFile = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                }
            }
        }

        /// <summary>
        /// Gets the Discord Bot Token from the json file
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            Refresh();
            return configFile.Property("token").Value.ToString();
        }

        /// <summary>
        /// Sets the Discord Bot Token for the json file
        /// </summary>
        /// <param name="token"></param>
        public static void SetToken(string token)
        {
            configFile["token"] = token;
            string output = JsonConvert.SerializeObject(configFile, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("./Config/Config.json", output);
        }
    }
}
