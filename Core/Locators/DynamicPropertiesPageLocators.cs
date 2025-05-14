using OpenQA.Selenium;

public static class DynamicPropertiesPageLocators
{

    // Element: Enable After Button
    // ID: Preferred for stability
    public static By EnableAfter_Id = By.Id("enableAfter");

    // Element: Color Change Button
    public static By ColorChange_Id = By.Id("colorChange");

    // Element: Visible After Button
    public static By VisibleAfter_Id = By.Id("visibleAfter");

    // Comments:
    // - These elements are dynamic and change state after a delay.
    // - Use explicit waits (WebDriverWait) to handle synchronization.
    // - ID selectors are preferred for their uniqueness and stability.
    // - CSS and XPath selectors provide alternative strategies.
}
