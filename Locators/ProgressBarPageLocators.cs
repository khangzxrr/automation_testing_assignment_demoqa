using OpenQA.Selenium;

public static class ProgressBarPageLocators
{
    public static By StartButton_Id = By.Id("startStopButton");
    public static By ProgressValue_CSS1 = By.CssSelector("#progressBar .progress-bar");
    public static By ResetButton_XPath1 = By.XPath("//button[text()='Reset']");
}
