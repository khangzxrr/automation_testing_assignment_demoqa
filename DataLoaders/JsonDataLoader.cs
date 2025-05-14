
using Newtonsoft.Json;

public class JsonDataLoader : IDataLoaderStrategy
{

    public IEnumerable<T> LoadData<T>(string filepath)
    {
        var json = File.ReadAllText(filepath);

        return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
    }
}
