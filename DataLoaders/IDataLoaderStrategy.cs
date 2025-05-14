public interface IDataLoaderStrategy
{
    IEnumerable<T> LoadData<T>(string filepath);
}
