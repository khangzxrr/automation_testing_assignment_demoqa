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

        wait = WaitHelper.MakeDriverWait(driver, timeoutInSeconds);
    }

    public WebElement Find(By locator)
    {
        var element = WaitHelper.WaitUntilExist(driver, locator);

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

    public void WaitForPageReady() => WaitHelper.WaitForPageReady(driver);
}
