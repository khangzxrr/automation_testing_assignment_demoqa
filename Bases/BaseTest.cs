using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public abstract class BaseTest : IDisposable
{
    protected IWebDriver driver;

    public BaseTest()
    {
        var options = new FirefoxOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager,
            PageLoadTimeout = TimeSpan.FromSeconds(60),
        };
        // options.AddArgument("--headless");

        var profile = new FirefoxProfile();

        var fullPathUblock = Directory.GetCurrentDirectory() + "/ublock_origin-1.63.2.xpi";
        profile.AddExtension(fullPathUblock);

        options.SetPreference("permissions.default.image", 2);

        var service = FirefoxDriverService.CreateDefaultService("/usr/bin/geckodriver");

        driver = new FirefoxDriver(service, options);
        driver.Manage().Window.Maximize();
    }

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    protected void PerformTest(Action action)
    {
        try
        {
            action();
        }
        catch (Exception)
        {
            ScreenshotHelper.Capture(driver);
            throw;
        }

    }
}
