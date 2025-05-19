using RestSharp;

public class ApiClient
{
    protected RestClient client;

    public ApiClient()
    {
        client = new RestClient(ConfigurationManager.Config.Api.BaseUrl);
    }
}
