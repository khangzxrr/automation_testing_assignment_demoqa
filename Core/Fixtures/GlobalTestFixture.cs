public class GlobalTestFixture : IDisposable, IClassFixture<ExtentReportFixture>
{
    public LogFixture LogFixture { get; }
    public ExtentReportFixture ExtentReportFixture { get; }

    public GlobalTestFixture()
    {
        DriverPool.Initialize(3);

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
