using OpenQA.Selenium;

public static class DynamicPropertiesPageLocators
{

    // Element: Enable After Button
    // ID: Preferred for stability
    public static By EnableAfter_Id = By.Id("enableAfter");

    // CSS Selectors
    public static By EnableAfter_CSS1 = By.CssSelector("#enableAfter");
    public static By EnableAfter_CSS2 = By.CssSelector("button#enableAfter");

    // XPath Expressions
    public static By EnableAfter_XPath1 = By.XPath("//button[@id='enableAfter']");
    public static By EnableAfter_XPath2 = By.XPath("//button[text()='Will enable 5 seconds']");

    // Element: Color Change Button
    public static By ColorChange_Id = By.Id("colorChange");

    public static By ColorChange_CSS1 = By.CssSelector("#colorChange");
    public static By ColorChange_CSS2 = By.CssSelector("button#colorChange");

    public static By ColorChange_XPath1 = By.XPath("//button[@id='colorChange']");
    public static By ColorChange_XPath2 = By.XPath("//button[text()='Color Change']");

    // Element: Visible After Button
    public static By VisibleAfter_Id = By.Id("visibleAfter");

    public static By VisibleAfter_CSS1 = By.CssSelector("#visibleAfter");
    public static By VisibleAfter_CSS2 = By.CssSelector("button#visibleAfter");

    public static By VisibleAfter_XPath1 = By.XPath("//button[@id='visibleAfter']");
    public static By VisibleAfter_XPath2 = By.XPath(
        "//button[text()='Visible After 5 Seconds']"
    );

    // Comments:
    // - These elements are dynamic and change state after a delay.
    // - Use explicit waits (WebDriverWait) to handle synchronization.
    // - ID selectors are preferred for their uniqueness and stability.
    // - CSS and XPath selectors provide alternative strategies.
}
