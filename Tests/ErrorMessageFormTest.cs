
[Collection("TestCollection")]
public class ErrorMessageFormTest : BaseTest
{
    [Trait("Category", "DemoQA")]
    [Trait("Component", "PracticeForm")]
    [Trait("TestCase", "TC02")]
    [Trait("Type", "Validation")]
    [Trait("Level", "FieldValidation")]
    [Fact]
    public void TC02_VerifyValidationMessagesForEmptyRequiredFields()
    {
        var testname = nameof(TC02_VerifyValidationMessagesForEmptyRequiredFields);

        PerformTest(
            testname,
            () =>
            {
                var page = new RegistrationFormPage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                page.ClickSubmit();

                Assert.Contains("form-control", page.FirstName.GetClass());
                Assert.False(page.FirstName.IsValid());

                Assert.Contains("form-control", page.LastName.GetClass());
                Assert.False(page.LastName.IsValid());

                Assert.Contains("form-control", page.Mobile.GetClass());
                Assert.False(page.Mobile.IsValid());
            }
        );
    }

    [Trait("Category", "DemoQA")]
    [Trait("Component", "PracticeForm")]
    [Trait("TestCase", "TC02")]
    [Trait("Type", "Validation")]
    [Trait("Level", "ProgressiveValidation")]
    [Fact]
    public void TC02_ProgressivelyFillRequiredFieldsAndValidateRemainingInvalid()
    {
        var testname = nameof(TC02_ProgressivelyFillRequiredFieldsAndValidateRemainingInvalid);
        PerformTest(
            testname,
            () =>
            {
                driver.Url = "https://demoqa.com/automation-practice-form";

                var page = new RegistrationFormPage(driver);

                page.NavigateTo();

                page.ClickSubmit();

                Assert.Contains("form-control", page.FirstName.GetClass());
                Assert.False(page.FirstName.IsValid());

                Assert.Contains("form-control", page.LastName.GetClass());
                Assert.False(page.LastName.IsValid());

                Assert.Contains("form-control", page.Mobile.GetClass());
                Assert.False(page.Mobile.IsValid());

                page.EnterFirstName("John");
                page.ClickSubmit();

                Assert.Contains("form-control", page.FirstName.GetClass());
                Assert.True(page.FirstName.IsValid());

                Assert.Contains("form-control", page.LastName.GetClass());
                Assert.False(page.LastName.IsValid());

                Assert.Contains("form-control", page.Mobile.GetClass());
                Assert.False(page.Mobile.IsValid());

                page.EnterLastName("Joe");
                page.ClickSubmit();

                Assert.Contains("form-control", page.FirstName.GetClass());
                Assert.True(page.FirstName.IsValid());

                Assert.Contains("form-control", page.LastName.GetClass());
                Assert.True(page.LastName.IsValid());

                Assert.Contains("form-control", page.Mobile.GetClass());
                Assert.False(page.Mobile.IsValid());

                page.EnterMobile("0919092211");
                page.ClickSubmit();

                Assert.Contains("form-control", page.FirstName.GetClass());
                Assert.True(page.FirstName.IsValid());

                Assert.Contains("form-control", page.LastName.GetClass());
                Assert.True(page.LastName.IsValid());

                Assert.Contains("form-control", page.Mobile.GetClass());
                Assert.True(page.Mobile.IsValid());
            }
        );
    }
}
