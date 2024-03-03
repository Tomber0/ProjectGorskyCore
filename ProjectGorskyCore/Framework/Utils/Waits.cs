using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Framework.Core;
using System.Collections.ObjectModel;

namespace Framework.Utils
{
    public static class Waits
    {
        public static IWebElement? WebWaitForElementToBeClickable(IWebElement webElement, Type?[] ignoreExeptions = null)
        {
            LoggerManager.Logger.Info($"Waiting until element to be clickable");

            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(ConfigManager.GetValueFromCollection("wait_time", "timeout").ToDouble()));
            if (ignoreExeptions != null)
            {
                wait.IgnoreExceptionTypes(ignoreExeptions);
            }
            var wElem = wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            return wElem;
        }

        public static IWebElement? WebWaitForElementToBeClickable(By by, Type?[] ignoreExeptions = null)
        {
            LoggerManager.Logger.Info($"Waiting until element to be clickable");

            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(ConfigManager.GetValueFromCollection("wait_time", "timeout").ToDouble()));

            if (ignoreExeptions != null)
            {
                wait.IgnoreExceptionTypes(ignoreExeptions);
            }
            var wElem = wait.Until(ExpectedConditions.ElementToBeClickable(by));
            return wElem;
        }

        public static IWebElement? WebWaitForElementToBeDisplayed(By by, Type?[] ignoreExeptions = null)
        {
            LoggerManager.Logger.Info($"Waiting until element to be displayed");

            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(ConfigManager.GetValueFromCollection("wait_time", "timeout").ToDouble()));

            if (ignoreExeptions != null)
            {
                wait.IgnoreExceptionTypes(ignoreExeptions);
            }
            var wElem = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return wElem;
        }

        public static ReadOnlyCollection<IWebElement>? WebWaitForPresenceOfAllElements(By by, Type?[] ignoreExeptions = null)
        {
            LoggerManager.Logger.Info($"Waiting until all elements are present");
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(ConfigManager.GetValueFromCollection("wait_time", "timeout").ToDouble()));
            if (ignoreExeptions != null)
            {
                wait.IgnoreExceptionTypes(ignoreExeptions);
            }
            var wElems = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return wElems;
        }

        public static IAlert WaitUntilAlertIsPresent()
        {
            LoggerManager.Logger.Info($"Waiting until alert on page is present");
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(ConfigManager.GetValueFromCollection("wait_time", "timeout").ToDouble()));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            return alert;
        }
    }
}
