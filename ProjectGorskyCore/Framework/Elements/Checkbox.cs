using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Elements
{
    public  class Checkbox : Element
    {
        public Checkbox(By locator, string name) : base(locator, name)
        {
            LoggerManager.Logger.Info($"Adding new checkbox:{name}");
        }

        public bool IsChecked { 
            get 
            {
                LoggerManager.Logger.Info($"Checking if {Name} is checked");
                return WebElement.Selected;
            } 
        }

        public void Check() 
        {
            if (!IsChecked) 
            {
                LoggerManager.Logger.Info($"Checking {Name}");
                WebElement.Click();
            }
        }

        public void Uncheck()
        {
            if (IsChecked)
            {
                LoggerManager.Logger.Info($"Unchecking {Name}");
                WebElement.Click();
            }
        }
    }
}
