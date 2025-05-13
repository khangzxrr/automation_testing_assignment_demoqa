using OpenQA.Selenium;

public static class AutoCompletePageLocators
{
    public static By MultipleColorInput_Id = By.Id("autoCompleteMultipleInput");
    public static By SingleColorInput_Id = By.Id("autoCompleteSingleInput");
    public static By MultiColorInput_Id = By.Id("autoCompleteMultipleInput");

    public static By ClearAllButton_CSS => By.CssSelector(".auto-complete__clear-indicator");
    public static By MultiColorValue_XPath => By.XPath("//div[contains(@class,'auto-complete__multi-value')]");

    public static By AutoCompleteOption(string color) => By.XPath($"//div[contains(@id, 'react-select') and text()='{color}']");
}
