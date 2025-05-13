using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static void Capture(IWebDriver driver)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        var dir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
        Directory.CreateDirectory(dir);
        var file = Path.Combine(dir, $"{DateTime.Now:yyyyMMdd_HHmmss}.png");
        screenshot.SaveAsFile(file);
    }
}
