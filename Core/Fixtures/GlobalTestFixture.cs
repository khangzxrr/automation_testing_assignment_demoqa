public class GlobalTestFixture : IDisposable
{
    public LogFixture LogFixture { get; }
    public ExtentReportFixture ExtentReportFixture { get; }

    public GlobalTestFixture()
    {
        DriverPool.Initialize();

        LogFixture = new LogFixture();

        ExtentReportFixture = new ExtentReportFixture();
    }

    public void Dispose()
    {
        DriverPool.Cleanup();

        LogFixture.Dispose();

        ExtentReportFixture.Dispose();
    }
}

[CollectionDefinition("TestCollection")]
public class TestCollection : ICollectionFixture<GlobalTestFixture> { }
