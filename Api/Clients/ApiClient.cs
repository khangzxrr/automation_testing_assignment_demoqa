using System.Text;
using RestSharp;

public class ApiClient
{
    protected RestClient client;

    public ApiClient()
    {
        client = new RestClient(ConfigurationManager.Config.Api.BaseUrl);
    }

    public async Task<RestResponse<T>> SendRequest<T>(
        string resource,
        Method method,
        object? body = null
    )
    {
        var request = new RestRequest(resource, method);

        if (body != null)
        {
            request.AddJsonBody(body);
        }

        return await client.ExecuteAsync<T>(request);
    }

    public void AddBasicHeader(string username, string password)
    {
        var credential = $"{username}:{password}";
        var encodeCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));

        client.AddDefaultHeader("Authorization", $"Basic {encodeCredential}");
    }
}
