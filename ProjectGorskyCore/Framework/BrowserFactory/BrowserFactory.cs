using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Framework.Utils;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Framework.Core
{
    public class BrowserFactory
    {
        private static IWebDriver? _driver;
        private static ICapabilities? _capabilities;
        public static IWebDriver? Driver 
        { 
            get 
            {
                switch (Utils.ConfigManager.GetValueFromCollection("browser","config")) 
                {
                    case "chrome":
                        {
                            LoggerManager.Logger.Info($"Creating new chrome driver");
                            ChromeOptions options = new ChromeOptions();
                            options.AddArgument("--lang=" + Utils.ConfigManager.GetValueFromCollection("lang", "config"));
                            options.AddArgument(Utils.ConfigManager.GetValueFromCollection("incognito", "config"));
                            options.AddUserProfilePreference("download.default_directory", AppContext.BaseDirectory + Utils.ConfigManager.GetValueFromCollection("default-path", "config"));
                            options.AddUserProfilePreference("disable-popup-blocking", Utils.ConfigManager.GetValueFromCollection("disable-popup-blocking", "config"));
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _driver = new ChromeDriver(options);
                            return _driver;
                        }
                        break;
                    case "firefox":
                        {
                            LoggerManager.Logger.Info($"Creating new firefox driver");
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArgument("--lang=" + Utils.ConfigManager.GetValueFromCollection("lang", "config"));
                            options.AddArgument(Utils.ConfigManager.GetValueFromCollection("incognito", "config"));
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _driver = new FirefoxDriver(options);
                            return _driver;
                        }
                    default:
                        LoggerManager.Logger.Error($"No webdriver was provided");
                        throw new Exception("No web-browser given in config.json file!");
                        break;
                }
            }
            private set { _driver = value; } 
        }

        public static ICapabilities? Capabilities 
        {
            get
            {
                LoggerManager.Logger.Info($"Getting browser capabilities");
                _capabilities = ((WebDriver)_driver).Capabilities;
                return _capabilities;
            }
            private set 
            {
                _capabilities = value;
            } 
        }

    }
}
