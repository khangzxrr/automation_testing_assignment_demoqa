using OpenQA.Selenium;

public class ProgressBarPage : BasePage
{
    public ProgressBarPage(IWebDriver driver, UnifiedLog log) : base(driver, log)
    {
    }

    private readonly string url = "https://demoqa.com/progress-bar";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement StartStopButton => Find(ProgressBarPageLocators.StartButton_Id);
    public WebElement ProgressBar => Find(ProgressBarPageLocators.ProgressValue_CSS1);
    public WebElement ResetButton => Find(ProgressBarPageLocators.ResetButton_XPath1);

    public void ClickStartStop() => StartStopButton.Click();
    public void ClickReset() => ResetButton.Click();

    public int GetProgressPercent()
    {
        string text = ProgressBar.Text.Replace("%", "").Trim();
        return int.TryParse(text, out int percent) ? percent : 0;
    }

    public void WaitForProgressToExceed(int targetPercent)
    {
        wait.Until(driver =>
        {
            int current = GetProgressPercent();
            return current > targetPercent;
        });
    }

    public void WaitForProgressToEqual(int expectedPercent)
    {
        wait.Until(driver => GetProgressPercent() == expectedPercent);
    }

    public void WaitForProgressToBeReset()
    {
        wait.Until(driver => string.IsNullOrEmpty(ProgressBar.Text) || GetProgressPercent() == 0);
    }

}
