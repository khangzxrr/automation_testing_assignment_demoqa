using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected Actions actions => new Actions(driver); //should use fresh actions

    protected BasePage(IWebDriver driver, int timeoutInSeconds = 15)
    {
        this.driver = driver;

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
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

    public List<WebElement> Finds(By locator)
    {
        var elements = driver.FindElements(locator);

        return elements.Select(e => new WebElement(driver, e, wait, locator)).ToList();
    }

    public WebElement FindWithoutWaiting(By locator)
    {
        var element = driver.FindElement(locator);

        return new WebElement(driver, element, wait, locator);
    }

    public void DragAndDrop(WebElement source, WebElement target)
    {
        actions
            .ClickAndHold(source.source)
            .Pause(TimeSpan.FromMilliseconds(500))
            .MoveToElement(target.source)
            .Release()
            .Pause(TimeSpan.FromMilliseconds(500))
            .Perform();
    }

    public void WaitForPageReady(int timeoutInSeconds = 60)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d =>
        {
            var js = (IJavaScriptExecutor)d;
            return js.ExecuteScript("return document.readyState").ToString() == "complete"
                && (bool)(js.ExecuteScript("return window.jQuery ? jQuery.active === 0 : true"));
        });
    }
}
