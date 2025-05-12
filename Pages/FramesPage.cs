using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class FramesPage : BasePage
{
    public FramesPage(IWebDriver driver) : base(driver)
    {
    }

    private readonly string url = "https://demoqa.com/frames";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public void SwitchToFrame1() =>
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(FramesPageLocators.Frame1_Id));

    public void SwitchToFrame2() =>
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(FramesPageLocators.Frame2_Id));

    public string GetFrameHeadingText() =>
        wait.Until(ExpectedConditions.ElementIsVisible(FramesPageLocators.FrameHeading_Id)).Text;

    public void SwitchToDefaultContent() => driver.SwitchTo().DefaultContent();
}
