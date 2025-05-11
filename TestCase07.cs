using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Alerts")]
    [Trait("TestCase", "TC07")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "JavaScriptAlert")]
    [Trait("Level", "PopupHandling")]
    public void TC07_VerifyAlertHandlingFunctionality()
    {
        driver.Url = "https://demoqa.com/alerts";

        // Step 1: Simple Alert
        driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.SimpleAlert_Id).Click();
        wait.Until(ExpectedConditions.AlertIsPresent());
        IAlert simpleAlert = driver.SwitchTo().Alert();
        Assert.Equal("You clicked a button", simpleAlert.Text);
        simpleAlert.Accept();

        // Step 2: Timed Alert (5s)
        driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.TimedAlert_Id).Click();
        wait.Until(ExpectedConditions.AlertIsPresent());
        IAlert delayedAlert = driver.SwitchTo().Alert();
        Assert.Equal("This alert appeared after 5 seconds", delayedAlert.Text);
        delayedAlert.Accept();

        // Step 3: Confirm Alert (Accept)
        driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.ConfirmButton_Id).Click();
        wait.Until(ExpectedConditions.AlertIsPresent());
        IAlert confirmAlert = driver.SwitchTo().Alert();
        Assert.Equal("Do you confirm action?", confirmAlert.Text);
        confirmAlert.Accept();
        string confirmResult = driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.ConfirmResult_Id).Text;
        Assert.Contains("Ok", confirmResult);

        // Step 4: Confirm Alert (Dismiss)
        driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.ConfirmButton_Id).Click();
        wait.Until(ExpectedConditions.AlertIsPresent());
        driver.SwitchTo().Alert().Dismiss();
        string dismissResult = driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.ConfirmResult_Id).Text;
        Assert.Contains("Cancel", dismissResult);

        // Step 5: Prompt Alert
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC07_VerifyAlertHandling.PromptButton_Id);

        wait.Until(ExpectedConditions.AlertIsPresent());
        IAlert promptAlert = driver.SwitchTo().Alert();
        string inputText = "KhangTest";
        promptAlert.SendKeys(inputText);
        promptAlert.Accept();
        string promptResult = driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.PromptResult_Id).Text;
        Assert.Contains(inputText, promptResult);
    }
}
