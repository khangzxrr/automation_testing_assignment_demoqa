using System.Text;
using AccountModel;
using RestSharp;

public class ApiTestBuilder
{
    private RestClient client;

    public AccountService accountService;
    public BookService bookService;

    public TokenModel TokenModel { get; private set; }

    public UserModel UserModel { get; set; }

    public ApiTestBuilder()
    {
        client = new RestClient(ConfigurationManager.Config.Api.BaseUrl);

        accountService = new AccountService(client);
        bookService = new BookService(client);
    }

    public ApiTestBuilder AddAuthorization(string username, string password)
    {
        var credential = $"{username}:{password}";
        var encodeCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));

        client.AddDefaultHeader("Authorization", $"Basic {encodeCredential}");

        return this;
    }

    public ApiTestBuilder AddBearerAuthorization(string? bearer = null)
    {
        client.AddDefaultHeader("Authorization", $"Bearer {bearer ?? TokenModel.Token}");

        return this;
    }

    public async Task<(ApiTestBuilder builder, RestResponse<TokenModel> generateTokenResponse)> GenerateToken(LoginModel? loginModel = null)
    {
        if (loginModel == null)
        {
            loginModel = new LoginModel
            {
                UserName = UserModel.UserName,
                Password = UserModel.Password,
            };
        }

        var response = await accountService.GenerateToken(loginModel);

        if (response.Data != null)
        {
            TokenModel = response.Data;
        }


        return (this, response);
    }

    public void EnsureAuthorization()
    {
        if (client.DefaultParameters.FirstOrDefault(p => p.Name == "Authorization") == null)
        {
            throw new InvalidOperationException("Call AddAuthorization first");
        }
    }
}
