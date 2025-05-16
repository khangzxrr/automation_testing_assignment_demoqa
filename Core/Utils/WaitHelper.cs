using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class WaitHelper
{
    public static WebDriverWait MakeDriverWait(IWebDriver driver, int timeoutInSeconds = 10)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
    }

    public static IWebElement WaitUntilVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return localWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)
        );
    }

    public static IWebElement WaitUntilExist(IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var localWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return localWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator)
        );
    }

    public static void WaitForPageReady(IWebDriver driver, int timeoutInSeconds = 30)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d =>
        {
            var js = (IJavaScriptExecutor)d;
            return js.ExecuteScript("return document.readyState").ToString() == "complete"
                && (bool)(js.ExecuteScript("return window.jQuery ? jQuery.active === 0 : true"));
        });
    }
}
