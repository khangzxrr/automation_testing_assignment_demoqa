using OpenQA.Selenium;

public abstract class BaseTest : IDisposable
{
    protected IWebDriver driver;

    public BaseTest()
    {
        driver = DriverFactory.MakeDriver(DriverType.Firefox);
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
    }

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    protected void PerformTest(string testName, Action action)
    {
        try
        {
            action();
        }
        catch (Exception)
        {
            ScreenshotHelper.Capture(driver, testName);
            throw;
        }
    }
}
