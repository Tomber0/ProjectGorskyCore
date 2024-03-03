using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Core
{
    public static class Browser
    {
        private static IWebDriver? _driver;
        public static IWebDriver? Driver
        {
            get
            {
                if (_driver == null)
                {
                    LoggerManager.Logger.Info($"Getting driver");
                    _driver = BrowserFactory.Driver;
                }
                return _driver;
            }
        }

        public static void Clear()
        {
            if (_driver != null)
            {
                LoggerManager.Logger.Info($"Quitting driver");
                _driver.Quit();
            }
            _driver = null;
        }

        public static void GoToUrl(string url)
        {
            if (Driver == null)
            {
                LoggerManager.Logger.Warn($"Cannot go to {url}, driver is null");
                return;
            }
            LoggerManager.Logger.Info($"Driver going to url:{url}");
            Driver.Navigate().GoToUrl(url);
        }

        public static IJavaScriptExecutor? JsExecutor {
            get
            {
                if (Driver != null)
                {
                    LoggerManager.Logger.Info($"Getting javascript executor from driver");
                    return (IJavaScriptExecutor)Driver;
                }
                LoggerManager.Logger.Warn($"Javascript executor returned null");
                return null;
            }
        }

        public static string WindowHandler
        {
            get
            {
                LoggerManager.Logger.Info($"Getting current window handler");
                return Driver.CurrentWindowHandle;
            }
        }

        public static List<string> WindowHandlers
        {
            get
            {
                LoggerManager.Logger.Info($"Getting window handlers");
                return Driver.WindowHandles.ToList();
            }
        }

        public static void Switch(string window) 
        {
            LoggerManager.Logger.Info($"Switching to {window}");
            Driver.SwitchTo().Window(window);
        }

        public static void OpenNewTab() 
        {
            LoggerManager.Logger.Info($"Opening a new tab");
            Driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public static void OpenNewWindow() 
        {
            LoggerManager.Logger.Info($"Opening a new window");
            Driver.SwitchTo().NewWindow(WindowType.Window);
        }

        public static void CloseCurrentTab() 
        {
            LoggerManager.Logger.Info($"Closing current tab");
            Driver.Close();
        }

        public static void SwitchToFrame(IWebElement iframe)
        {
            LoggerManager.Logger.Info($"Switching to frame");
            Driver.SwitchTo().Frame(iframe);
        }

        public static void LeaveFrame() 
        {
            LoggerManager.Logger.Info($"Leaving frame");
            Driver.SwitchTo().DefaultContent();
        }

        public static string AlertText 
        {
            get 
            {
                LoggerManager.Logger.Info($"Switching to alert");
                IAlert alert = Waits.WaitUntilAlertIsPresent();
                LoggerManager.Logger.Info($"Getting alert text");
                return alert.Text;
            }
        }

        public static void SendTextToAlert(string text) 
        {
            LoggerManager.Logger.Info($"Switching to alert");
            IAlert alert = Waits.WaitUntilAlertIsPresent();
            LoggerManager.Logger.Info($"Sendind text:{text} to alert");
            alert.SendKeys(text);
        }

        public static void ConfirmAlert() 
        {
            LoggerManager.Logger.Info($"Switching to alert");
            IAlert alert = Waits.WaitUntilAlertIsPresent();
            LoggerManager.Logger.Info($"Confirming an alert");
            alert.Accept();
        }

        public static void CanellingAlert() 
        {
            LoggerManager.Logger.Info($"Switching to alert");
            IAlert alert = Waits.WaitUntilAlertIsPresent();
            LoggerManager.Logger.Info($"Canceling an alert");
            alert.Dismiss();
        }

        public static bool IsAlertOnPage
        {
            get
            {
                LoggerManager.Logger.Info($"Switching to alert");
                IAlert alert;
                try
                {
                 alert = Driver.SwitchTo().Alert();
                }
                catch (Exception)
                {
                    alert = null;   
                }
                return (alert != null);
            }
        }

        public static string CurrentUrl 
        {
            get 
            {
                return Driver.Url;
            }
        }

        public static Screenshot TakeScreenshot() 
        {
            LoggerManager.Logger.Info($"Driver taking a screenshot");
            return (Driver as ITakesScreenshot).GetScreenshot();
        }
    }
}
