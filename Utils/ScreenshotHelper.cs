using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static void Capture(IWebDriver driver, string testname)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        var dir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
        Directory.CreateDirectory(dir);
        var file = Path.Combine(dir, $"{testname.Trim()}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
        screenshot.SaveAsFile(file);
    }
}
