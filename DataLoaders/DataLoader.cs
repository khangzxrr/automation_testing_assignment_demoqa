public static class DataLoader
{
    public static IEnumerable<object[]> ValidUser
    {
        get
        {
            string filePath = "TestData/ValidUser.json";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData<object[]>(filePath);
        }

    }
}
