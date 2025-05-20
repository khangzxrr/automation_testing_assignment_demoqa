using AccountModel;
using RestSharp;

public static class AccountApiTestBuilder
{
    public static async Task<ApiTestBuilder> CreateRandomUser(this ApiTestBuilder apiTestBuilder)
    {
        var registerModel = RegisterModel.Generate();

        var response = await apiTestBuilder.accountService.CreateUser(registerModel);

        apiTestBuilder.UserModel = new UserModel
        {
            Password = registerModel.Password,
            UserId = response.Data.UserId,
            UserName = registerModel.UserName,
        };

        return apiTestBuilder;
    }

    public static async Task<ApiTestBuilder> CreateUser(
        this ApiTestBuilder apiTestBuilder,
        RegisterModel registerModel
    )
    {
        var response = await apiTestBuilder.accountService.CreateUser(registerModel);

        apiTestBuilder.UserModel = new UserModel
        {
            Password = registerModel.Password,
            UserId = response.Data.UserId,
            UserName = registerModel.UserName,
        };

        return apiTestBuilder;
    }

    public static async Task<RestResponse<RegisterResponseModel>> GetUser(
        this ApiTestBuilder apiTestBuilder,
        string? uuid = null
    )
    {
        apiTestBuilder.EnsureAuthorization();

        return await apiTestBuilder.accountService.GetUser(uuid ?? apiTestBuilder.UserModel.UserId);
    }

    public static async Task<RestResponse<bool>> Authorized(
        this ApiTestBuilder apiTestBuilder,
        AuthorizedModel? authorizedModel = null
    )
    {
        apiTestBuilder.EnsureAuthorization();

        if (authorizedModel == null)
        {
            authorizedModel = new AuthorizedModel
            {
                UserName = apiTestBuilder.UserModel.UserName,
                Password = apiTestBuilder.UserModel.Password,
            };
        }

        return await apiTestBuilder.accountService.Authorized(authorizedModel);
    }

    public static async Task<RestResponse<DeleteResponseModel>> DeleteUser(
        this ApiTestBuilder apiTestBuilder,
        string? uuid = null
    )
    {
        apiTestBuilder.EnsureAuthorization();

        if (uuid == null)
        {
            uuid = apiTestBuilder.UserModel.UserId;
        }

        return await apiTestBuilder.accountService.DeleteUser(uuid);
    }
}
