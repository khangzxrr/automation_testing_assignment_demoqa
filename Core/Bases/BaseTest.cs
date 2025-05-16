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

    protected void LogInfo(string info)
    {
        Serilog.Log.Information(info);

        test.Info(info);
    }

    protected void LogPass(string pass)
    {
        Serilog.Log.Information(pass);

        test.Pass(pass);
    }

    protected void LogFail(Exception exception, string testName)
    {

        var screenshotPath = ScreenshotHelper.Capture(driver, testName);
        Serilog.Log.Error(exception, "Test failed: {Message}", exception.Message);

        test.Fail(exception);
        test.AddScreenCaptureFromPath(screenshotPath);
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
            LogInfo($"Started test {testName}");

            action(unifiedLog);

            test.Pass($"Passed Test {testName}");
        }
        catch (Exception ex)
        {
            LogFail(ex, testName);

            throw;
        }
    }
}
