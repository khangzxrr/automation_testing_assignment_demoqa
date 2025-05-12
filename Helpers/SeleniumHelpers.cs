

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class SeleniumHelpers
{


    public static void ScrollIntoView(IWebDriver driver, WebDriverWait wait, IWebElement element)
    {
        // Scroll into view
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public static void ScrollIntoView(IWebDriver driver, WebDriverWait wait, By locator)
    {

        // Wait until element is present
        IWebElement element = wait.Until(drv => drv.FindElement(locator));

        // Scroll into view
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }


    public static void ScrollIntoViewAndClick(IWebDriver driver, WebDriverWait wait, IWebElement element)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
    }

    public static void ScrollIntoViewAndClick(IWebDriver driver, WebDriverWait wait, By locator)
    {
        // Wait until element is present
        IWebElement element = wait.Until(drv => drv.FindElement(locator));

        // Scroll into view
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        // Wait until it's displayed and enabled
        wait.Until(drv =>
        {
            try
            {
                var el = drv.FindElement(locator);
                return el.Displayed && el.Enabled;
            }
            catch
            {
                return false;
            }
        });

        // Click using JavaScript to avoid layout issues
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
    }
}
