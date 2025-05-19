using RestSharp;

public class AccountService : ApiClient
{
    public async Task<RestResponse<TokenModel>> GenerateToken(LoginModel login)
    {
        var request = new RestRequest("/Account/v1/GenerateToken", Method.Post)
                          .AddJsonBody(login);

        return await client.ExecuteAsync<TokenModel>(request);
    }

}
