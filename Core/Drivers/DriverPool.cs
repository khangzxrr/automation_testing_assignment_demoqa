using System.Threading.Channels;
using OpenQA.Selenium;

public class DriverPool
{
    private static Channel<IWebDriver> _channel;
    private static int _poolSize;

    public static void Initialize(int maxDrivers)
    {
        _poolSize = maxDrivers;

        _channel = Channel.CreateBounded<IWebDriver>(maxDrivers);

        for (int i = 0; i < maxDrivers; i++)
        {
            var driver = DriverFactory.MakeDriverFromConfig();
            _channel.Writer.TryWrite(driver);
        }
    }

    public static async Task<IWebDriver> AcquireAsync()
    {
        var driver = await _channel.Reader.ReadAsync();

        return driver;
    }

    public static void Release(IWebDriver driver)
    {
        _channel.Writer.TryWrite(driver);
    }

    public static void Cleanup()
    {
        while (_channel.Reader.TryRead(out var driver))
        {
            driver.Quit();
        }
    }
}
