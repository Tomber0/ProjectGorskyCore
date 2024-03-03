namespace Framework.Utils
{
    public static class ConfigManager
    {
        public static Dictionary<string, string> FilePaths { get; private set; } = new Dictionary<string, string>();

        public static void AddFileToCollection(string filePath, string alias)
        {
            if (!File.Exists(filePath))
            {
                LoggerManager.Logger.Error($"{filePath} was not found");
                throw new FileNotFoundException($"{filePath} was not found");
            }
            LoggerManager.Logger.Info($"Adding file {filePath} as {alias}");
            FilePaths.Add(alias, filePath);
        }

        public static string GetValueFromCollection(string key, string alias)
        {
            LoggerManager.Logger.Info($"Getting {key} from {alias}");
            return JsonReader.GetValueFromFile(key, FilePaths[alias]);
        }

        public static dynamic GetObjectFromCollection(string key,string alias) 
        {
            LoggerManager.Logger.Info($"Getting {key} from {alias}");
            return JsonReader.GetObjectFromJson(key, FilePaths[alias]);
        }

        public static dynamic GetObjectFromFile(string key,string path) 
        {
            LoggerManager.Logger.Info($"Getting {key} from {path}");
            return JsonReader.GetObjectFromJson(key, path);
        }
    }
}
