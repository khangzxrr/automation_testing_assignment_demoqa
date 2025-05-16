
[Collection("TestCollection")]
public class EmailValidationTest : BaseTest
{
    public EmailValidationTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "FormValidation")]
    [Trait("TestCase", "TC03")]
    [Trait("Type", "InputFormat")]
    [Trait("Element", "EmailField")]
    [Trait("Level", "Validation")]
    [MemberData(nameof(DataLoader.InvalidEmails), MemberType = typeof(DataLoader))]
    public void TC03_VerifyEmailValidationWithVariousInvalidFormats(
        string caseName,
        string invalidEmail
    )
    {
        var testname = nameof(TC03_VerifyEmailValidationWithVariousInvalidFormats);

        PerformTest(
            testname,
            () =>
            {
                var page = new RegistrationFormPage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                page.EnterEmail(invalidEmail);
                page.ClickSubmit();

                Assert.False(
                    page.Email.IsValid(),
                    $"Expected invalid email format for case: {caseName} => {invalidEmail}"
                );
            }
        );
    }
}
