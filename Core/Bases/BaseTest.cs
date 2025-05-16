using AventStack.ExtentReports;
using OpenQA.Selenium;

public abstract class BaseTest : IAsyncLifetime
{
    protected IWebDriver driver;

    protected readonly ExtentReports extent;

    protected ExtentTest test;

    public BaseTest(ExtentReportFixture fixture)
    {
        extent = fixture.Extent;
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


    protected void PerformTest(string testName, Action<UnifiedLog> action)
    {
        lock (extent)
        {
            test = extent.CreateTest(testName);
        }

        var unifiedLog = new UnifiedLog(test);

        try
        {
            test.Info($"Started test {testName}");

            action(unifiedLog);

            test.Pass($"Passed Test {testName}");
        }
        catch (Exception ex)
        {

            var screenshotPath = ScreenshotHelper.Capture(driver, testName);
            Serilog.Log.Error(ex, "Test failed: {Message}", ex.Message);

            test.Fail(ex);
            test.AddScreenCaptureFromPath(screenshotPath);

            throw;
        }
    }
}
