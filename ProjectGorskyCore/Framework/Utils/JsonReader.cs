using Newtonsoft.Json;

namespace Framework.Utils
{
    public static class JsonReader
    {
        public static string? Path { get; private set; }

        public static Dictionary<string, string> FilePaths { get; private set; } = new Dictionary<string, string>();

        public static string GetValueFromFile(string key,string path) 
        {
            LoggerManager.Logger.Info($"Getting {key} from file:{path}");

            using (var reader = new StreamReader(path)) 
            {
                var json = reader.ReadToEndAsync().Result;
                Dictionary<string, string> configValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                return configValue[key];
            }
        }

        public static dynamic GetObjectFromJson(string key, string path)
        { 
            LoggerManager.Logger.Info($"Getting {key} from file:{path}");

            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEndAsync().Result;
                Dictionary<string, dynamic> configValue = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
                return configValue[key];
            }
        }

        public static string GetValuesFromJson(string key, string json) 
        {
            LoggerManager.Logger.Info($"Getting {key} from json");
            Dictionary<string, string> configValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return configValue[key];
        }
    }
}
