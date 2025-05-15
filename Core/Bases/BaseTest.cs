using OpenQA.Selenium;

public abstract class BaseTest : IDisposable
{
    protected IWebDriver driver;

    public BaseTest()
    {
        driver = DriverFactory.MakeDriver(DriverType.Firefox);
        driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

        Logger.Initialize();
    }

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();

        Logger.Shutdown();
    }

    protected void PerformTest(string testName, Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            ScreenshotHelper.Capture(driver, testName);
            Serilog.Log.Error(ex, "Test failed: {Message}", ex.Message);
            throw;
        }
    }
}
