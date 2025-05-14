
using System.Globalization;
using CsvHelper;

public class CsvDataLoader : IDataLoaderStrategy
{

    public IEnumerable<object[]> LoadData(string filepath)
    {
        using var reader = new StreamReader(filepath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read(); // move to first row
        csv.ReadHeader(); // load headers

        var headers = csv.HeaderRecord;

        while (csv.Read())
        {
            var values = new object[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                values[i] = csv.GetField(headers[i]);
            }
            yield return values;
        }
    }
}
