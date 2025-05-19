using System.Text;
using AccountModel;
using RestSharp;

public class AccountService : ApiClient
{
    public void AddBasicHeader(string username, string password)
    {
        var credential = $"{username}:{password}";
        var encodeCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));

        client.AddDefaultHeader("Authorization", $"Basic {encodeCredential}");
    }

    public async Task<RestResponse<TokenModel>> GenerateToken(LoginModel login)
    {
        return await SendRequest<TokenModel>("/Account/v1/GenerateToken", Method.Post, login);
    }

    public async Task<RestResponse<RegisterResponseModel>> CreateUser(RegisterModel register)
    {
        return await SendRequest<RegisterResponseModel>("/Account/v1/User", Method.Post, register);
    }

    public async Task<RestResponse<DeleteResponseModel>> DeleteUser(string uuid)
    {
        return await SendRequest<DeleteResponseModel>($"/Account/v1/User/{uuid}", Method.Delete);
    }

    public async Task<RestResponse<bool>> Authorized(AuthorizedModel authorized)
    {
        return await SendRequest<bool>("/Account/v1/Authorized", Method.Post, authorized);
    }


}
