using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected Actions actions;

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        actions = new Actions(driver);
    }

    protected IWebElement WaitUntilClickable(By locator, int timeoutInSeconds = 15)
    {
        var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return localWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)
        );
    }

    protected IWebElement WaitUntilVisible(By locator, int timeoutInSeconds = 15)
    {
        var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return localWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)
        );
    }

    protected IWebElement WaitUntilExist(By locator, int timeoutInSeconds = 15)
    {
        var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return localWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator)
        );
    }



    public WebElement Find(By locator)
    {
        var element = WaitUntilExist(locator);

        return new WebElement(driver, element, wait, locator);
    }

    public WebElement FindWithoutWaiting(By locator)
    {
        var element = driver.FindElement(locator);

        return new WebElement(driver, element, wait, locator);
    }


    public void Click(By locator) => WaitUntilClickable(locator).Click();

    public void Type(By locator, string text)
    {
        var element = WaitUntilVisible(locator);
        element.SendKeys(text);
    }

    public void Clear(By locator)
    {
        var element = WaitUntilVisible(locator);
        element.Clear();
    }

    public void SelectByValue(By locator, string value)
    {
        var element = WaitUntilVisible(locator);

        SelectElement selectElement = new SelectElement(element);
        selectElement.SelectByValue(value);
    }

    public string GetText(By locator) => WaitUntilVisible(locator).Text;
}
