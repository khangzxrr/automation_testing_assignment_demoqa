public class LogFixture : IDisposable
{

    public LogFixture()
    {
        Logger.Initialize();
    }

    public void Dispose()
    {
        Logger.Shutdown();
    }
}
