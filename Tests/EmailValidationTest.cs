public class EmailValidationTest : BaseTest
{

    [Theory]
    [InlineData("MissingAt", "userexample.com")]
    [InlineData("MissingDomain", "user@")]
    [InlineData("ContainsSpace", "user @example.com")]
    [InlineData("SpecialChars", "user@@example..com")]
    public void TC03_VerifyEmailValidationWithVariousInvalidFormats(string caseName, string invalidEmail)
    {
        PerformTest(() =>
        {
            var page = new RegistrationFormPage(driver);

            page.NavigateTo();

            page.EnterEmail(invalidEmail);
            page.ClickSubmit();

            Assert.False(page.Email.IsValid(), $"Expected invalid email format for case: {caseName} => {invalidEmail}");

        });
    }
}
