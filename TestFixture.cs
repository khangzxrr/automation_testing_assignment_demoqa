using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

public class TestFixture : IDisposable
{

    public IWebDriver driver;
    public WebDriverWait wait;

    public TestFixture()
    {
        var service = FirefoxDriverService.CreateDefaultService("/usr/bin/geckodriver");

        var options = new FirefoxOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager,
            PageLoadTimeout = TimeSpan.FromSeconds(60)
        };

        var profile = new FirefoxProfile();

        var fullPathUblock = Directory.GetCurrentDirectory() + "/ublock_origin-1.63.2.xpi";
        profile.AddExtension(fullPathUblock);

        options.SetPreference("permissions.default.image", 2);
        options.Profile = profile;


        driver = new FirefoxDriver(service, options);

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    }

    public void Dispose()
    {

        driver?.Quit();
    }
}

