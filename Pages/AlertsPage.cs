using OpenQA.Selenium;

public class AlertsPage : BasePage
{
    private readonly string url = "https://demoqa.com/alerts";

    public AlertsPage(OpenQA.Selenium.IWebDriver driver) : base(driver)
    {
    }


    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement SimpleAlertButton => Find(AlertsPageLocators.SimpleAlert_Id);
    public WebElement TimedAlertButton => Find(AlertsPageLocators.TimedAlert_Id);
    public WebElement ConfirmButton => Find(AlertsPageLocators.ConfirmButton_Id);
    public WebElement ConfirmResult => Find(AlertsPageLocators.ConfirmResult_Id);

    public WebElement PromptButton => Find(AlertsPageLocators.PromptButton_Id);
    public WebElement PromptResult => Find(AlertsPageLocators.PromptResult_Id);

    public void ClickSimpleAlert() => SimpleAlertButton.Click();
    public void ClickTimedAlert() => TimedAlertButton.Click();
    public void ClickConfirmButton() => ConfirmButton.Click();
    public void ClickPromptButton() => PromptButton.Click();

    public string GetConfirmResultText() => ConfirmResult.Text;

    public IAlert SwitchToAlert() => driver.SwitchTo().Alert();

    public void TypeToAlert(IAlert alert, string text) => alert.SendKeys(text);

    public void WaitForAlert() => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

    public void AcceptAlert() => SwitchToAlert().Accept();
    public void DismissAlert() => SwitchToAlert().Dismiss();

    public string GetAlertText() => SwitchToAlert().Text;
    public string GetPromptResult() => PromptResult.Text;

}
