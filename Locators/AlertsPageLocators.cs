using OpenQA.Selenium;

public static class AlertsPageLocators
{
    public static By SimpleAlert_Id = By.Id("alertButton");
    public static By SimpleAlert_CSS1 = By.CssSelector("#alertButton");
    public static By SimpleAlert_CSS2 = By.CssSelector("button#alertButton");
    public static By SimpleAlert_XPath1 = By.XPath("//button[@id='alertButton']");
    public static By SimpleAlert_XPath2 = By.XPath("//button[text()='Click me']");
    public static By TimedAlert_Id = By.Id("timerAlertButton");
    public static By TimedAlert_CSS1 = By.CssSelector("#timerAlertButton");
    public static By TimedAlert_CSS2 = By.CssSelector("button#timerAlertButton");
    public static By TimedAlert_XPath1 = By.XPath("//button[@id='timerAlertButton']");
    public static By TimedAlert_XPath2 = By.XPath("//button[text()='Click me']");
    public static By ConfirmButton_Id = By.Id("confirmButton");
    public static By ConfirmButton_CSS1 = By.CssSelector("#confirmButton");
    public static By ConfirmButton_CSS2 = By.CssSelector("button#confirmButton");
    public static By ConfirmButton_XPath1 = By.XPath("//button[@id='confirmButton']");
    public static By ConfirmButton_XPath2 = By.XPath("//button[text()='Click me']");
    public static By PromptButton_Id = By.Id("promtButton");
    public static By PromptButton_CSS1 = By.CssSelector("#promtButton");
    public static By PromptButton_CSS2 = By.CssSelector("button#promtButton");
    public static By PromptButton_XPath1 = By.XPath("//button[@id='promtButton']");
    public static By PromptButton_XPath2 = By.XPath("//button[text()='Click me']");
    public static By ConfirmResult_Id = By.Id("confirmResult");
    public static By ConfirmResult_CSS1 = By.CssSelector("#confirmResult");
    public static By ConfirmResult_CSS2 = By.CssSelector("span#confirmResult");
    public static By ConfirmResult_XPath1 = By.XPath("//span[@id='confirmResult']");
    public static By ConfirmResult_XPath2 = By.XPath("//span[contains(text(),'You selected')]");
    public static By PromptResult_Id = By.Id("promptResult");
    public static By PromptResult_CSS1 = By.CssSelector("#promptResult");
    public static By PromptResult_CSS2 = By.CssSelector("span#promptResult");
    public static By PromptResult_XPath1 = By.XPath("//span[@id='promptResult']");
    public static By PromptResult_XPath2 = By.XPath("//span[contains(text(),'You entered')]");
}
