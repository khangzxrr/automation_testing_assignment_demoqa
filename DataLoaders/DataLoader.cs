public static class DataLoader
{
    public static IEnumerable<object[]> ValidUsers
    {
        get
        {
            string filePath = "TestData/Registration/ValidUsers.json";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }

    }


    public static IEnumerable<object[]> InvalidEmails
    {
        get
        {
            string filePath = "TestData/Registration/InvalidEmails.csv";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }
    }

    public static IEnumerable<object[]> WebTableEmployees
    {
        get
        {
            string filePath = "TestData/WebTables/Employees.json";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }
    }

    public static IEnumerable<object[]> Books
    {
        get
        {
            string filePath = "TestData/WebTables/Books.csv";
            return DataLoaderStrategyFactory
              .GetLoader(filePath)
              .LoadData(filePath);
        }
    }



}
