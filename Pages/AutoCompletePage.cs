using OpenQA.Selenium;

public class AutoCompletePage : BasePage
{
    public AutoCompletePage(IWebDriver driver) : base(driver)
    {
    }
    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    private readonly string url = "https://demoqa.com/auto-complete";
    public WebElement SingleColorInput => Find(AutoCompletePageLocators.SingleColorInput_Id);
    public WebElement MultiColorInput => Find(AutoCompletePageLocators.MultiColorInput_Id);
    public WebElement AutoCompleteOption(string color) =>
        Find(By.XPath($"//div[contains(@id, 'react-select') and text()='{color}']"));

    public List<WebElement> MultiColorTags =>
        Finds(AutoCompletePageLocators.MultiColorValue_XPath);

    public void TypeAndSelectSingleColor(string color)
    {
        SingleColorInput.Type(color);
        AutoCompleteOption(color).Click();
    }

    public void TypeAndSelectMultipleColors(params string[] colors)
    {
        foreach (var color in colors)
        {
            MultiColorInput.Type(color);
            AutoCompleteOption(color).Click();
        }
    }

    public List<string> GetSelectedColors() =>
        MultiColorTags.Select(tag => tag.Text.Trim()).ToList();

    public void RemoveColor(string color)
    {
        var tag = MultiColorTags.FirstOrDefault(e => e.Text.Contains(color));
        tag?.source.FindElement(By.XPath(".//following-sibling::div")).Click();
    }

    public void ClearAllColors()
    {
        var clearButton = driver.FindElements(AutoCompletePageLocators.ClearAllButton_CSS).FirstOrDefault();
        clearButton?.Click();
    }
}
