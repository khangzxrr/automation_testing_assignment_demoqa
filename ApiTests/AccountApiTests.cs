using System.Net;
using AccountModel;

[Trait("Category", "API")]
public class AccountApiTests
{
    [Fact]
    public async Task VerifyGenerateToken_ShouldReturnToken()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, var generateTokenResponse) = await apiTestBuilder.GenerateToken();

        Assert.NotNull(generateTokenResponse.Data);
        Assert.False(string.IsNullOrWhiteSpace(generateTokenResponse.Data.Token));
    }

    [Fact]
    public async Task VerifyGenerateToken_ShouldThrowWhenUserNotFound()
    {
        var loginModel = new LoginModel
        {
            UserName = Guid.NewGuid() + "notfound",
            Password = ConfigurationManager.Config.Api.DefaultPassword
        };

        var apiTestBuilder = new ApiTestBuilder();
        (apiTestBuilder, var generateTokenResponse) = await apiTestBuilder.GenerateToken(loginModel);

        Assert.Contains("User authorization failed.", generateTokenResponse.Content);
    }


    [Fact]
    public async Task VerifyCreateUser_ShouldCreateUserWhichValidUsernameAndPassword()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();

        Assert.False(string.IsNullOrWhiteSpace(apiTestBuilder.UserModel.UserId));
    }

    [Fact]
    public async Task VerifyCreateUser_ShouldThrowWhenAlreadyExistUsernameAndPassword()
    {

        var firstApiTestBuilder = new ApiTestBuilder();
        firstApiTestBuilder = await firstApiTestBuilder.CreateRandomUser();

        var registerModel = new RegisterModel
        {
            UserName = firstApiTestBuilder.UserModel.UserName,
            Password = firstApiTestBuilder.UserModel.Password,
        };

        var secondApiTestBuilder = new ApiTestBuilder();
        (secondApiTestBuilder, var secondApiRegisterResponse) = await secondApiTestBuilder.CreateUser(registerModel);

        Assert.Equal(HttpStatusCode.NotAcceptable, secondApiRegisterResponse.StatusCode);
        Assert.NotNull(secondApiRegisterResponse.Content);
        Assert.Contains("User exists!", secondApiRegisterResponse.Content);

    }

    [Fact]
    public async Task VerifyGetUser_ShouldReturnExistUser()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        var getUserResponse = await apiTestBuilder.GetUser();

        Assert.NotNull(getUserResponse.Data);

        Assert.Equal(apiTestBuilder.UserModel.UserId, getUserResponse.Data.UserId);
    }

    [Fact]
    public async Task VerifyAuthorize_ShouldReturnTrueWhichExistUser()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        var authorizedResponse = await apiTestBuilder.Authorized();

        Assert.True(authorizedResponse.Data);
    }

    [Fact]
    public async Task VerifyAuthorize_ShouldReturnFalseWhenUserIsNotGenerateToken()
    {

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();

        var authorizedResponse = await apiTestBuilder.Authorized();

        Assert.False(authorizedResponse.Data);
    }

    [Fact]
    public async Task VerifyDeleteUser_ShouldDeleteUserWithExistUser()
    {
        var registerModel = RegisterModel.Generate();

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        (apiTestBuilder, _) = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        await apiTestBuilder.DeleteUser();

        var authorizedResponse = await apiTestBuilder.Authorized();

        Assert.True(authorizedResponse.StatusCode == System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task VerifyDeleteUser_ShouldThrowWhenUserNotAuthorized()
    {

        var registerModel = RegisterModel.Generate();

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();

        var deleteResponse = await apiTestBuilder.DeleteUser();

        Assert.Equal(HttpStatusCode.Unauthorized, deleteResponse.StatusCode);
        Assert.Contains("User not authorized!", deleteResponse.Content);


    }
}
