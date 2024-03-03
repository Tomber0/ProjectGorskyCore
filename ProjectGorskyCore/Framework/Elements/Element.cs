using OpenQA.Selenium;
using Framework.Core;
using Framework.Utils;

namespace Framework.Elements
{
    public abstract class Element
    {
        public string Name { get; }
        public By Locator { get; }
        public Element(By locator, string name) 
        {
            LoggerManager.Logger.Info($"Adding new web element:{name}");
            Locator = locator;
            Name = name;
        }

        public void Click() 
        {
            LoggerManager.Logger.Info($"Clicking {Name}");
            WebElement.Click();
        }

        public bool WaitForDisplayed()
        {
            Waits.WebWaitForElementToBeDisplayed(Locator);
            return WebElement.Displayed;
        }

        public bool IsDisplayed 
        { 
            get 
            {
                LoggerManager.Logger.Info($"Checking if {Name} is displayed");
                return WebElement.Displayed;
            }
        }

        public string this[string attributeName] 
        {
            get 
            {
                return GetAttributeValue(attributeName);
            }
        }

        public string GetAttributeValue(string attributeName) 
        {
            LoggerManager.Logger.Info($"Getting {attributeName} from {Name}");
            return WebElement.GetAttribute(attributeName);
        }

        public string Text 
        {
            get 
            {
                LoggerManager.Logger.Info($"Getting text from {Name}");
                return WebElement.Text;
            }
        }

        public IWebElement? WebElement 
        {
            get 
            {
                LoggerManager.Logger.Info($"Getting webelement from {Name}");
                return Browser.Driver.FindElement(Locator);
            }
        }

        public Screenshot TakeScreenshotOfElement()
        {
            LoggerManager.Logger.Info($"Driver taking a screenshot");
            return (WebElement as ITakesScreenshot).GetScreenshot();
        }
    }
}
