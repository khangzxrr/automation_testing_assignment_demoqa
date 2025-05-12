using OpenQA.Selenium;

public static class ProgressBarPageLocators
{
    public static By StartButton_Id = By.Id("startStopButton");
    public static By StartButton_CSS1 = By.CssSelector("#startStopButton");
    public static By StartButton_CSS2 = By.CssSelector("button#startStopButton");
    public static By StartButton_XPath1 = By.XPath("//button[@id='startStopButton']");
    public static By StartButton_XPath2 = By.XPath("//button[text()='Start']");
    public static By StopButton_Id = By.Id("startStopButton");
    public static By StopButton_CSS1 = By.CssSelector("#startStopButton");
    public static By StopButton_CSS2 = By.CssSelector("button#startStopButton");
    public static By StopButton_XPath1 = By.XPath("//button[@id='startStopButton']");
    public static By StopButton_XPath2 = By.XPath("//button[text()='Stop']");
    public static By ProgressBar_Id = By.Id("progressBar");
    public static By ProgressBar_CSS1 = By.CssSelector("#progressBar");
    public static By ProgressBar_CSS2 = By.CssSelector("div#progressBar");
    public static By ProgressBar_XPath1 = By.XPath("//div[@id='progressBar']");
    public static By ProgressBar_XPath2 = By.XPath("//div[contains(@class, 'progress-bar')]");
    public static By ProgressValue_CSS1 = By.CssSelector("#progressBar .progress-bar");
    public static By ProgressValue_CSS2 = By.CssSelector("div#progressBar > div.progress-bar");
    public static By ProgressValue_XPath1 = By.XPath("//div[@id='progressBar']/div");
    public static By ProgressValue_XPath2 = By.XPath("//div[contains(@class, 'progress-bar') and contains(text(), '%')]");
    public static By ResetButton_XPath1 = By.XPath("//button[text()='Reset']");
}
