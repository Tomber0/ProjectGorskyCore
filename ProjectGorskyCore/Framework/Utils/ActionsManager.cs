using OpenQA.Selenium.Interactions;
using Framework.Core;
using Framework.Elements;

namespace Framework.Utils
{
    public static class ActionsManager
    {
        public static Actions Action { get; private set; } = new Actions(Browser.Driver);

        public static void DoubleClick(Element element) 
        {
            LoggerManager.Logger.Info($"Adding double click on {element.Name} to sequence");
            Action.DoubleClick(element.WebElement);
        }

        public static void Click(Element element) 
        {
            LoggerManager.Logger.Info($"Adding click on {element.Name} to sequence");
            Action.Click(element.WebElement);
        }

        public static void DragAndHold(Element element,int offsetX,int offsetY) 
        {
            LoggerManager.Logger.Info($"Adding drag&drop x = {offsetX}, y = {offsetY} on {element.Name} to sequence");
            Action.DragAndDropToOffset(element.WebElement,offsetX,offsetY);
        }

        public static void ClickAndHold(Element element) 
        {
            LoggerManager.Logger.Info($"Adding click&hold on {element.Name} to sequence");
            Action.ClickAndHold(element.WebElement);
        }

        public static void MoveByOffset(int offsetX,int offsetY) 
        {
            LoggerManager.Logger.Info($"Adding move by offset x = {offsetX}, y = {offsetY}  to sequence");
            Action.MoveByOffset(offsetX, offsetY);
        }

        public static void MoveToElement(Element element,int offsetX, int offsetY) 
        {
            LoggerManager.Logger.Info($"Adding move to element {element.Name} x = {offsetX}, y = {offsetY}  to sequence");
            Action.MoveToElement(element.WebElement,offsetX, offsetY);
        }

        public static void Release() 
        {
            LoggerManager.Logger.Info($"Adding to sequence");
            Action.Release();
        }

        public static void MoveToElement(Element element) 
        {
            LoggerManager.Logger.Info($"Adding move to element: {element.Name} to sequence");
            Action.MoveToElement(element.WebElement);
        }

        public static void KeyUp(string keys)
        { 
            LoggerManager.Logger.Info($"Adding key up: {keys} to sequence");
            Action.KeyUp(keys);
        }

        public static void KeyDown(string keys)
        {
            LoggerManager.Logger.Info($"Adding key dowm: {keys} to sequence");
            Action.KeyDown(keys);
        }

        public static void SendKeys(string keys) 
        {
            LoggerManager.Logger.Info($"Adding send keys : {keys} to sequence");
            Action.SendKeys(keys);
        }

        public static void Build() 
        {
            LoggerManager.Logger.Info($"Building sequence");
            Action.Build();
        }

        public static void Perform() 
        {
            LoggerManager.Logger.Info($"Performing sequence");
            Action.Perform();
        }

        public static void Clear()
        {
            LoggerManager.Logger.Info($"Resetting sequence");
            Action.Reset();
        }
    }
}
