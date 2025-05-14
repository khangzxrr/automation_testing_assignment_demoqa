public interface IDataLoaderStrategy
{
    IEnumerable<object[]> LoadData(string filepath);
}
