public class GlobalTestFixture : IDisposable
{
    public GlobalTestFixture()
    {
        DriverPool.Initialize(4);
    }
    public void Dispose()
    {
        DriverPool.Cleanup();
    }
}

[CollectionDefinition("TestCollection")]
public class TestCollection : ICollectionFixture<GlobalTestFixture> { }
