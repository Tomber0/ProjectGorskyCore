using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Elements
{
    public class Label : Element
    {
        public Label(By locator, string name) : base(locator, name)
        {
            LoggerManager.Logger.Info($"Adding new label:{name}");
        }
    }
}
