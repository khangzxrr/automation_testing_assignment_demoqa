using OpenQA.Selenium;

public abstract class BaseTest : IAsyncLifetime
{
    protected IWebDriver driver;

    public BaseTest()
    {
        // driver = DriverFactory.MakeDriverFromConfig();

        Logger.Initialize();
    }

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();

        Logger.Shutdown();
    }

    public Task DisposeAsync()
    {
        DriverPool.Release(driver);

        return Task.CompletedTask;
    }

    public async Task InitializeAsync()
    {
        driver = await DriverPool.AcquireAsync();
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
