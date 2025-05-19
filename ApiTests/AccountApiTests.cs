using AccountModel;

public class AccountApiTests
{
    private readonly AccountService accountService = new();

    [Fact]
    public async Task VerifyGenerateToken_ShouldReturnToken()
    {
        var loginModel = new LoginModel
        {
            UserName = ConfigurationManager.Config.Api.DefaultUsername,
            Password = ConfigurationManager.Config.Api.DefaultUsername
        };

        var response = await accountService.GenerateToken(loginModel);

        Assert.True(response.IsSuccessful);
        Assert.False(string.IsNullOrWhiteSpace(response.Data?.Token));
    }

    [Fact]
    public async Task VerifyCreateUser_ShouldCreateUserWhichValidUsernameAndPassword()
    {
        var registerModel = new RegisterModel
        {
            UserName = ConfigurationManager.Config.Api.DefaultUsername + Guid.NewGuid(),
            Password = ConfigurationManager.Config.Api.DefaultPassword
        };

        var createUserResponse = await accountService.CreateUser(registerModel);

        var uuid = createUserResponse.Data.UserId;

        Assert.False(string.IsNullOrWhiteSpace(uuid));
    }

    [Fact]
    public async Task VerifyGetUser_ShouldReturnExistUser()
    {
        var registerModel = RegisterModel.Generate();

        var createUserResponse = await accountService.CreateUser(registerModel);

        var uuid = createUserResponse.Data.UserId;

        Assert.False(string.IsNullOrWhiteSpace(uuid));

        accountService.AddBasicHeader(registerModel.UserName, registerModel.Password);

        var getUserResponse = await accountService.GetUser(uuid);

        Assert.Equal(createUserResponse.Data.UserId, getUserResponse.Data.UserId);
    }

    [Fact]
    public async Task VerifyAuthorize_ShouldReturnTrueWhichExistUser()
    {

        var registerModel = RegisterModel.Generate();

        Console.WriteLine(registerModel.UserName);

        var createUserResponse = await accountService.CreateUser(registerModel);

        var uuid = createUserResponse.Data.UserId;

        Console.WriteLine(uuid);

        Assert.False(string.IsNullOrWhiteSpace(uuid));

        accountService.AddBasicHeader(registerModel.UserName, registerModel.Password);

        var authorizedModel = new AuthorizedModel
        {
            UserName = registerModel.UserName,
            Password = registerModel.Password
        };
        var authorized = await accountService.Authorized(authorizedModel);

        Console.WriteLine(authorized.Content);

        Assert.True(authorized.Data);
    }

    [Fact]
    public async Task VerifyDeleteUser_ShouldDeleteUserWithExistUser()
    {
        var registerModel = RegisterModel.Generate();

        var createUserResponse = await accountService.CreateUser(registerModel);

        var uuid = createUserResponse.Data.UserId;

        Assert.False(string.IsNullOrWhiteSpace(uuid));

        //authorize
        accountService.AddBasicHeader(registerModel.UserName, registerModel.Password);

        var deleteUserResponse = await accountService.DeleteUser(uuid);

        var authorizedModel = new AuthorizedModel
        {
            UserName = registerModel.UserName,
            Password = registerModel.Password,
        };
        //authorized should return 404 not found user because we deleted it
        var result = await accountService.Authorized(authorizedModel);

        Assert.True(result.StatusCode == System.Net.HttpStatusCode.NotFound);
    }
}
