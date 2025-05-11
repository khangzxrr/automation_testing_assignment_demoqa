using OpenQA.Selenium;

public partial class TestCase
{

    [Theory]
    [InlineData("MissingAt", "userexample.com")]
    [InlineData("MissingDomain", "user@")]
    [InlineData("ContainsSpace", "user @example.com")]
    [InlineData("SpecialChars", "user@@example..com")]
    public void TC03_VerifyEmailValidationWithVariousInvalidFormats(string caseName, string invalidEmail)
    {
        driver.Url = "https://demoqa.com/automation-practice-form";

        var emailField = driver.FindElement(ElementLocators.TC02_VerifyValidationMessages.Email_Id);

        emailField.Clear();
        emailField.SendKeys(invalidEmail);

        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);

        bool isValid = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].checkValidity();", emailField);
        Assert.False(isValid, $"Expected invalid email format for case: {caseName} => {invalidEmail}");
    }
}
