using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Elements
{
    public class Button : Element
    {
        public Button(By locator, string name) : base(locator, name)
        {
            LoggerManager.Logger.Info($"Adding new button:{name}");
        }
    }
}
