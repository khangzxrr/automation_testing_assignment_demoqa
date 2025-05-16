using System.Threading.Channels;
using OpenQA.Selenium;

public class DriverPool
{
    private static Channel<IWebDriver> channel;
    private static int poolSize;

    public static void Initialize()
    {
        poolSize = ConfigurationManager.Config.Driver.Pool;

        channel = Channel.CreateBounded<IWebDriver>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            var driver = DriverFactory.MakeDriverFromConfig();
            channel.Writer.TryWrite(driver);
        }
    }

    public static async Task<IWebDriver> AcquireAsync()
    {
        var driver = await channel.Reader.ReadAsync();

        return driver;
    }

    public static void Release(IWebDriver driver)
    {
        channel.Writer.TryWrite(driver);
    }

    public static void Cleanup()
    {
        while (channel.Reader.TryRead(out var driver))
        {
            driver.Quit();
        }
    }
}
