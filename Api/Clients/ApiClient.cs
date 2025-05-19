using RestSharp;

public class ApiClient
{
    protected RestClient client;

    public ApiClient()
    {
        client = new RestClient(ConfigurationManager.Config.Api.BaseUrl);
    }

    public async Task<RestResponse<T>> SendRequest<T>(string resource, Method method, object? body = null)
    {
        var request = new RestRequest(resource, method);

        if (body != null)
        {
            request.AddJsonBody(body);
        }

        return await client.ExecuteAsync<T>(request);
    }

}
