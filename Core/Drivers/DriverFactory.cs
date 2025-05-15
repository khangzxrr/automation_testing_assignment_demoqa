using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

public static class DriverFactory
{
    public static IWebDriver MakeDriverFromConfig()
    {
        if (ConfigurationManager.Config.Driver.Type == "Chrome")
        {
            return MakeDriver(DriverType.Chrome, GetChromeOptions());
        }
        if (ConfigurationManager.Config.Driver.Type == "Firefox")
        {
            return MakeDriver(DriverType.Firefox, GetFirefoxOptions());
        }
        if (ConfigurationManager.Config.Driver.Type == "Edge")
        {
            return MakeDriver(DriverType.Edge, GetEdgeOptions());
        }

        throw new ArgumentException("Unsupported browser");
    }

    public static IWebDriver MakeDriver(DriverType type, dynamic? options = null)
    {
        if (type == DriverType.Chrome)
        {
            return new ChromeDriver((ChromeOptions?)options ?? GetChromeOptions());
        }

        if (type == DriverType.Firefox)
        {
            return new FirefoxDriver((FirefoxOptions?)options ?? GetFirefoxOptions());
        }

        if (type == DriverType.Edge)
        {
            return new EdgeDriver((EdgeOptions?)options ?? GetEdgeOptions());
        }

        throw new ArgumentException("Unsupported browser");
    }

    public static ChromeOptions GetChromeOptions()
    {
        var options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager,
            PageLoadTimeout = TimeSpan.FromSeconds(60),
        };

        options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
        options.AddArgument("--headless");

        return options;
    }

    public static FirefoxOptions GetFirefoxOptions()
    {
        var options = new FirefoxOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager,
            PageLoadTimeout = TimeSpan.FromSeconds(60),
        };

        options.AddArgument("--headless");
        options.SetPreference("permissions.default.image", 2);

        return options;
    }

    public static EdgeOptions GetEdgeOptions()
    {
        return new EdgeOptions();
    }
}
