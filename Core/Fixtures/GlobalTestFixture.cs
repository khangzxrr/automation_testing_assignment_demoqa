public class GlobalTestFixture : IDisposable
{
    public GlobalTestFixture()
    {
        DriverPool.Initialize(3);
    }

    public void Dispose()
    {
        DriverPool.Cleanup();
    }
}

[CollectionDefinition("TestCollection")]
public class TestCollection : ICollectionFixture<GlobalTestFixture> { }
