using OpenQA.Selenium;

public static class AlertsPageLocators
{
    public static By SimpleAlert_Id = By.Id("alertButton");
    public static By TimedAlert_Id = By.Id("timerAlertButton");
    public static By ConfirmButton_Id = By.Id("confirmButton");
    public static By PromptButton_Id = By.Id("promtButton");
    public static By ConfirmResult_Id = By.Id("confirmResult");
    public static By PromptResult_Id = By.Id("promptResult");
}
