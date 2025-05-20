using AccountModel;

[Trait("Category", "API")]
public class AccountApiTests
{
    [Fact]
    public async Task VerifyGenerateToken_ShouldReturnToken()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();

        Assert.False(string.IsNullOrWhiteSpace(apiTestBuilder.TokenModel.Token));
    }

    [Fact]
    public async Task VerifyCreateUser_ShouldCreateUserWhichValidUsernameAndPassword()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();

        Assert.False(string.IsNullOrWhiteSpace(apiTestBuilder.UserModel.UserId));
    }

    [Fact]
    public async Task VerifyGetUser_ShouldReturnExistUser()
    {
        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
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
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        var authorizedResponse = await apiTestBuilder.Authorized();

        Assert.True(authorizedResponse.Data);
    }

    [Fact]
    public async Task VerifyDeleteUser_ShouldDeleteUserWithExistUser()
    {
        var registerModel = RegisterModel.Generate();

        var apiTestBuilder = new ApiTestBuilder();
        apiTestBuilder = await apiTestBuilder.CreateRandomUser();
        apiTestBuilder = await apiTestBuilder.GenerateToken();
        apiTestBuilder = apiTestBuilder.AddBearerAuthorization();

        await apiTestBuilder.DeleteUser();

        var authorizedResponse = await apiTestBuilder.Authorized();

        Assert.True(authorizedResponse.StatusCode == System.Net.HttpStatusCode.NotFound);
    }
}
