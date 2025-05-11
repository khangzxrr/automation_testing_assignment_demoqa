using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "ModalDialogs")]
    [Trait("TestCase", "TC13")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "Modal")]
    [Trait("Level", "OpenCloseBehavior")]
    public void TC13_VerifyModalDialogsDisplayAndClose()
    {
        driver.Url = "https://demoqa.com/modal-dialogs";

        // Step 1: Open small modal
        driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.SmallModalButton_Id).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC13_VerifyModalDialogs.SmallModal_Close_XPath1));

        // Step 2: Close using X button
        driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.SmallModal_Close_XPath1).Click();
        Thread.Sleep(300); // brief wait for fade-out

        // Step 3: Reopen small modal
        driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.SmallModalButton_Id).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC13_VerifyModalDialogs.SmallModal_CloseButton_Id));

        // Step 4: Close using Close button
        driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.SmallModal_CloseButton_Id).Click();
        Thread.Sleep(300);

        // Step 5: Open large modal
        driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.LargeModalButton_Id).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC13_VerifyModalDialogs.LargeModal_Content_Id));

        // Step 7: Test overlay click (should not close modal)
        var overlay = driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.ModalOverlay_CSS);
        Actions actions = new Actions(driver);
        actions.MoveToElement(overlay, 5, 5).Click().Perform();
        Thread.Sleep(300);

        Assert.Empty(driver.FindElements(ElementLocators.TC13_VerifyModalDialogs.LargeModal_Content_Id));
    }
}
