public static class DataLoaderStrategyFactory
{
    public static IDataLoaderStrategy GetLoader(string filePath)
    {
        return Path.GetExtension(filePath) switch
        {
            ".csv" => new CsvDataLoader(),
            ".json" => new JsonDataLoader(),
            _ => throw new NotSupportedException("Unsupported file type")
        };
    }

}
