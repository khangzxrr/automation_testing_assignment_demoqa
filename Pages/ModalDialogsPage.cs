using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class ModalDialogsPage : BasePage
{
    public ModalDialogsPage(IWebDriver driver) : base(driver)
    {
    }

    private readonly string url = "https://demoqa.com/modal-dialogs";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);


    public WebElement SmallModalButton => Find(ModalDialogsPageLocators.SmallModalButton_Id);
    public WebElement SmallModalCloseX => Find(ModalDialogsPageLocators.SmallModal_Close_XPath1);
    public WebElement SmallModalCloseButton => Find(ModalDialogsPageLocators.SmallModal_CloseButton_Id);
    public WebElement LargeModalButton => Find(ModalDialogsPageLocators.LargeModalButton_Id);
    public WebElement LargeModalContent => Find(ModalDialogsPageLocators.LargeModal_Content_Id);
    public WebElement ModalOverlay => Find(ModalDialogsPageLocators.ModalOverlay_CSS);

    public void OpenSmallModal() => SmallModalButton.Click();
    public void CloseSmallModalX() => SmallModalCloseX.Click();
    public void CloseSmallModalButton() => SmallModalCloseButton.Click();
    public void OpenLargeModal() => LargeModalButton.Click();

    public void WaitForSmallModalDisplay() => wait.Until(ExpectedConditions.ElementIsVisible(ModalDialogsPageLocators.SmallModal_CloseButton_Id));
    public void WaitForLargeModalDisplay() => wait.Until(ExpectedConditions.ElementIsVisible(ModalDialogsPageLocators.LargeModal_Content_Id));

    public bool IsLargeModalVisible()
    {
        try
        {
            return LargeModalContent.Displayed;
        }
        catch
        {
            return false;
        }
    }

    public void ClickModalOverlay()
    {
        try
        {
            ModalOverlay.Click();
        }
        catch
        {
            // Might not be clickable or intentionally blocked
        }
    }
}
