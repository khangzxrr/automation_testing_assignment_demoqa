using OpenQA.Selenium;

public partial class TestCase
{
    // [Trait("Category", "DemoQA")]
    // [Trait("Component", "PracticeForm")]
    // [Trait("TestCase", "TC02")]
    // [Trait("Type", "Validation")]
    // [Trait("Level", "FieldValidation")]
    // [Fact]
    public void TC02_VerifyValidationMessagesForEmptyRequiredFields()
    {
        driver.Url = "https://demoqa.com/automation-practice-form";

        // Step 1: Leave all required fields blank
        // Step 2: Click Submit
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);

        // Step 3: Verify form-control:invalid by using checkValidity on each required input

        // Collect required form-control inputs
        var requiredFields = new List<By>
        {
            ElementLocators.TC02_VerifyValidationMessages.FirstName_Id,
            ElementLocators.TC02_VerifyValidationMessages.LastName_Id,
            ElementLocators.TC02_VerifyValidationMessages.Mobile_Id,

        };

        foreach (var locator in requiredFields)
        {
            var element = driver.FindElement(locator);
            bool isInvalid = !(bool)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].checkValidity();", element);
            string classAttr = element.GetAttribute("class");

            // Ensure element is marked as invalid AND has class "form-control"
            Assert.Contains("form-control", classAttr);
            Assert.True(isInvalid, $"Expected invalid for: {locator}");
        }

        // Gender is required but not form-control class — validate manually
        var selectedGender = driver.FindElements(By.CssSelector("input[name='gender']:checked"));
        Assert.Empty(selectedGender);
    }

    // [Trait("Category", "DemoQA")]
    // [Trait("Component", "PracticeForm")]
    // [Trait("TestCase", "TC02")]
    // [Trait("Type", "Validation")]
    // [Trait("Level", "ProgressiveValidation")]
    // [Fact]
    public void TC02_ProgressivelyFillRequiredFieldsAndValidateRemainingInvalid()
    {
        driver.Url = "https://demoqa.com/automation-practice-form";

        var js = (IJavaScriptExecutor)driver;

        // Step 1: Leave all blank → Click Submit
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.FirstName_Id);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.LastName_Id);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id);
        AssertGenderNotSelected();

        // Step 2: Fill First Name
        driver.FindElement(ElementLocators.TC02_VerifyValidationMessages.FirstName_Id).SendKeys("John");
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);
        AssertValid(ElementLocators.TC02_VerifyValidationMessages.FirstName_Id);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.LastName_Id);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id);
        AssertGenderNotSelected();

        // Step 3: Fill Last Name
        driver.FindElement(ElementLocators.TC02_VerifyValidationMessages.LastName_Id).SendKeys("Doe");
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);
        AssertValid(ElementLocators.TC02_VerifyValidationMessages.LastName_Id);
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id);
        AssertGenderNotSelected();

        // Step 4: Select Gender (click label to trigger check)
        driver.FindElement(ElementLocators.TC02_VerifyValidationMessages.GenderMale_XPath2).Click();
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);
        AssertGenderSelected();
        AssertInvalid(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id);

        // Step 5: Fill Mobile Number
        driver.FindElement(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id).SendKeys("0911223344");
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC02_VerifyValidationMessages.Submit_XPath1);
        AssertValid(ElementLocators.TC02_VerifyValidationMessages.Mobile_Id);

        // Final assertion: all required fields now valid
        AssertGenderSelected();
    }

    private void AssertInvalid(By locator)
    {
        var element = driver.FindElement(locator);
        bool isInvalid = !(bool)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].checkValidity();", element);
        string classAttr = element.GetAttribute("class");
        Assert.Contains("form-control", classAttr);
        Assert.True(isInvalid, $"Expected invalid for: {locator}");
    }

    private void AssertValid(By locator)
    {
        var element = driver.FindElement(locator);
        bool isValid = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].checkValidity();", element);
        Assert.True(isValid, $"Expected valid for: {locator}");
    }

    private void AssertGenderNotSelected()
    {
        var selected = driver.FindElements(By.CssSelector("input[name='gender']:checked"));
        Assert.Empty(selected);
    }

    private void AssertGenderSelected()
    {
        var selected = driver.FindElements(By.CssSelector("input[name='gender']:checked"));
        Assert.Single(selected);
    }
}
