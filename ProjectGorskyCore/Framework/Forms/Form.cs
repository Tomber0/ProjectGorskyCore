using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Elements
{
    public abstract class Form
    {
        public By Locator { get; private set; }
        public string Name { get; private set; }
        public Label Label { get; private set; }

        public Form(By locator, string name)
        {
            LoggerManager.Logger.Info($"Creating new form:{name}");
            Locator = locator;
            Name = name;
            Label = new Label(locator, name);
        }

        public bool IsPageOpen { 
            get 
            {
                LoggerManager.Logger.Info($"Checking if {Name} is opened");
                return Label.IsDisplayed;
            } 
        }

        public bool IsPageOpened() 
        {
            try
            {
                return IsPageOpen;
            }
            catch (Exception)
            {
                return false;
            }
            return IsPageOpen;
        }
    }
}
