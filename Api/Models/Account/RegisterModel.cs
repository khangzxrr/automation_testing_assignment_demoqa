namespace AccountModel;

public class RegisterModel : LoginModel
{
    public static RegisterModel Generate()
    {
        return new RegisterModel
        {
            UserName = ConfigurationManager.Config.Api.DefaultUsername + Guid.NewGuid(),
            Password = ConfigurationManager.Config.Api.DefaultPassword
        };
    }

}
