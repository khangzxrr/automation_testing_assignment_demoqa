using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public abstract class BasePage
{
    protected IWebDriver driver;

    protected WebDriverWait wait;

    protected Actions actions => new Actions(driver); //should use fresh actions

    protected UnifiedLog log;

    protected BasePage(IWebDriver driver, UnifiedLog log, int timeoutInSeconds = 15)
    {
        this.driver = driver;

        wait = WaitHelper.MakeDriverWait(driver, timeoutInSeconds);

        this.log = log;
    }

    public WebElement Find(By locator)
    {
        log.Info($"Find element {locator}");

        var element = WaitHelper.WaitUntilExist(driver, locator);

        return new WebElement(driver, element, wait, locator, log);
    }

    public List<WebElement> Finds(By locator)
    {
        var elements = driver.FindElements(locator);

        log.Info($"Find elements {locator}");

        return elements.Select(e => new WebElement(driver, e, wait, locator, log)).ToList();
    }

    public WebElement FindWithoutWaiting(By locator)
    {
        var element = driver.FindElement(locator);

        log.Info($"Find without waiting element {locator}");

        return new WebElement(driver, element, wait, locator, log);
    }

    public void DragAndDrop(WebElement source, WebElement target)
    {
        log.Info($"Perform drag and drop");

        actions
            .ClickAndHold(source.source)
            .Pause(TimeSpan.FromMilliseconds(500))
            .MoveToElement(target.source)
            .Release()
            .Pause(TimeSpan.FromMilliseconds(500))
            .Perform();
    }

    public void WaitForPageReady(int extraWait = 0)
    {
        log.Info("Wait for page ready");

        WaitHelper.WaitForPageReady(driver);

        Thread.Sleep(extraWait);
    }
}
