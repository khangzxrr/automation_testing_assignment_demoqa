using OpenQA.Selenium;

public class DynamicPropertyPage : BasePage
{
    public DynamicPropertyPage(IWebDriver driver, UnifiedLog log) : base(driver, log)
    {
    }

    private readonly string url = "https://demoqa.com/dynamic-properties";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement enableAfter => Find(DynamicPropertiesPageLocators.EnableAfter_Id);
    public WebElement colorChange => Find(DynamicPropertiesPageLocators.ColorChange_Id);

    public WebElement visibleAfter => Find(DynamicPropertiesPageLocators.VisibleAfter_Id);
    public WebElement visibleAfterWithoutWaiting => FindWithoutWaiting(DynamicPropertiesPageLocators.VisibleAfter_Id);

    public string getColorChangeButtonColor => colorChange.GetCssValue("color");


    public void waitUntilButtonEnabled()
    {
        wait.Until(d => enableAfter.Enabled);
    }

    public void waitUntilColorChanged(string previousColor)
    {
        wait.Until(d => colorChange.GetCssValue("color") != previousColor);
    }

    public void waitUntilVisibleAfterButtonVisibled()
    {
        WaitHelper.WaitUntilVisible(driver, DynamicPropertiesPageLocators.VisibleAfter_Id);
    }
}
