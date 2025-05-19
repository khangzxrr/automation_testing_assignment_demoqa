public class AccountApiTests
{
    private readonly AccountService accountService = new();

    [Fact]
    public async Task GenerateToken_ShouldReturnToken()
    {
        var loginModel = new LoginModel
        {
            UserName = "khangzxrr",
            Password = "@VoNgocKhang@1122"
        };

        var response = await accountService.GenerateToken(loginModel);

        Assert.True(response.IsSuccessful);
        Assert.False(string.IsNullOrWhiteSpace(response.Data?.Token));
    }
}
