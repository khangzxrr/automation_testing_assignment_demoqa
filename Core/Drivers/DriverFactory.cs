using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

public static class DriverFactory
{
    public static IWebDriver MakeDriverFromConfig()
    {
        IWebDriver driver = null;
        if (ConfigurationManager.Config.Driver.Type == "Chrome")
        {
            driver = MakeDriver(DriverType.Chrome, GetChromeOptions());
        }
        if (ConfigurationManager.Config.Driver.Type == "Firefox")
        {
            driver = MakeDriver(DriverType.Firefox, GetFirefoxOptions());
        }
        if (ConfigurationManager.Config.Driver.Type == "Edge")
        {
            driver = MakeDriver(DriverType.Edge, GetEdgeOptions());
        }

        if (driver == null)
        {

            throw new ArgumentException("Unsupported browser");
        }

        driver.Manage().Window.Size = new System.Drawing.Size(ConfigurationManager.Config.Driver.Width, ConfigurationManager.Config.Driver.Height);

        return driver;
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

        if (ConfigurationManager.Config.Driver.Headless)
        {

            options.AddArgument("--headless=new");

        }
        if (ConfigurationManager.Config.Driver.Width != 0 && ConfigurationManager.Config.Driver.Height != 0)
        {
            options.AddArgument($"--window-size={ConfigurationManager.Config.Driver.Width},{ConfigurationManager.Config.Driver.Height}");
        }

        options.AddArgument("--disable-gpu");

        return options;
    }

    public static FirefoxOptions GetFirefoxOptions()
    {
        var options = new FirefoxOptions
        {
            PageLoadStrategy = PageLoadStrategy.Eager,
            PageLoadTimeout = TimeSpan.FromSeconds(60),
        };


        if (ConfigurationManager.Config.Driver.Headless)
        {

            options.AddArgument("--headless");

        }

        if (ConfigurationManager.Config.Driver.Width != 0 && ConfigurationManager.Config.Driver.Height != 0)
        {

            options.AddArgument($"--width={ConfigurationManager.Config.Driver.Width}");

            options.AddArgument($"--height={ConfigurationManager.Config.Driver.Height}");

        }


        options.SetPreference("permissions.default.image", 2);

        return options;
    }

    public static EdgeOptions GetEdgeOptions()
    {
        return new EdgeOptions();
    }
}
