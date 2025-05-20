using AccountModel;
using RestSharp;

public class AccountService : ApiClient
{
    public AccountService(RestClient client)
        : base(client) { }

    public async Task<RestResponse<RegisterResponseModel>> GetUser(string uuid)
    {
        return await SendRequest<RegisterResponseModel>($"/Account/v1/User/{uuid}", Method.Get);
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
