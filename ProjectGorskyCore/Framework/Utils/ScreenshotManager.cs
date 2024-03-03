using OpenQA.Selenium;

namespace Framework.Utils
{
    public static class ScreenshotManager
    {
        public static void SaveScreenshot(Screenshot screenshot, string fileName, ScreenshotImageFormat format) 
        {
            LoggerManager.Logger.Info($"Saving screenshot {fileName}");
            screenshot.SaveAsFile(fileName, format);
        }
    }
}
