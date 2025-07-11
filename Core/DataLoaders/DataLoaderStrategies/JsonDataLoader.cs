using Newtonsoft.Json.Linq;

public class JsonDataLoader : IDataLoaderStrategy
{

    public IEnumerable<object[]> LoadData(string filepath)
    {
        var json = File.ReadAllText(filepath);
        var array = JArray.Parse(json);

        foreach (JObject obj in array)
        {
            var values = new List<object>();
            foreach (var prop in obj.Properties())
            {
                values.Add(prop.Value.ToString()); // or .ToObject<object>() for raw values
            }

            yield return values.ToArray();
        }
    }
}
