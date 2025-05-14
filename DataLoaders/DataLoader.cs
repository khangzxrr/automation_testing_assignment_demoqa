public static class DataLoader
{
    public static IEnumerable<object[]> ValidUser
    {
        get
        {
            string filePath = "TestData/Registration/ValidUser.json";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }

    }


    public static IEnumerable<object[]> InvalidUser
    {
        get
        {
            string filePath = "TestData/Registration/InvalidUser.csv";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }

    }

}
