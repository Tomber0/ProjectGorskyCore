using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Elements
{
    public class Textbox : Element
    {
        public Textbox(By locator, string name) : base(locator, name)
        {
            LoggerManager.Logger.Info($"Adding new textbox:{name}");
        }

        public void SendKeys(string value) 
        {
            LoggerManager.Logger.Info($"Sending text '{value}' to webelement {Name}");
            WebElement.SendKeys(value);
        }

        public void Clear() 
        {
            LoggerManager.Logger.Info($"Clearing imput field of {Name}");
            WebElement.Clear();
        }
    }
}
