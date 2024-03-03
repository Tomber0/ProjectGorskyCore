using NLog;
using NLog.Config;
using NUnit.Framework;
using Framework.Core;
using Framework.Utils;

namespace Framework.Tests
{
    public class Test
    {
        [OneTimeSetUp]
        public void BeforeTestRun() 
        {
            LoggerManager.Logger.Info("Tests are setting up");
            LogManager.Configuration = new XmlLoggingConfiguration(AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + $@"Config{System.IO.Path.DirectorySeparatorChar}NLOG.config");
            ConfigManager.AddFileToCollection(AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + $@"Config{System.IO.Path.DirectorySeparatorChar}config.json", "config");
            ConfigManager.AddFileToCollection(AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + $@"Config{System.IO.Path.DirectorySeparatorChar}timeout.json", "timeout");
            LoggerManager.Logger.Info("Test configurated");
        }

        [SetUp]
        public void BeforeTestMetod() 
        {
            LoggerManager.Logger.Info("Test run configurating");
        }

        [TearDown]
        public void AfterTestMethod()
        {
            LoggerManager.Logger.Info("Test run closing");
            Browser.Clear();
            LoggerManager.Logger.Info("Test run closed");
        }

        [OneTimeTearDown]
        public void AfterTestRun() 
        {
            LoggerManager.Logger.Info("Tests start tearing down");
            Browser.Clear();
            LoggerManager.Logger.Info("Tests are over");
        }
    }
}
