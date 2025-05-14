
using System.Globalization;
using CsvHelper;

public class CsvDataLoader : IDataLoaderStrategy
{
    public IEnumerable<T> LoadData<T>(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>();
            }
        }
    }
}
