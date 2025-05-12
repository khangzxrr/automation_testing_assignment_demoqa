using OpenQA.Selenium;

public static class AutoCompletePageLocators
{
    public static By MultipleColorInput_Id = By.Id("autoCompleteMultipleInput");
    public static By MultipleColorInput_CSS1 = By.CssSelector("#autoCompleteMultipleInput");
    public static By MultipleColorInput_CSS2 = By.CssSelector("input#autoCompleteMultipleInput");
    public static By MultipleColorInput_XPath1 = By.XPath("//input[@id='autoCompleteMultipleInput']");
    public static By MultipleColorInput_XPath2 = By.XPath("//div[@id='autoCompleteMultipleContainer']//input");
    public static By MultipleColorSelected_CSS1 = By.CssSelector(".auto-complete__multi-value__label");
    public static By MultipleColorSelected_CSS2 = By.CssSelector("div.auto-complete__multi-value__label");
    public static By MultipleColorSelected_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__multi-value__label')]");
    public static By MultipleColorSelected_XPath2 = By.XPath("//div[@id='autoCompleteMultipleContainer']//div[contains(@class, 'auto-complete__multi-value__label')]");
    public static By SingleColorInput_Id = By.Id("autoCompleteSingleInput");
    public static By SingleColorInput_CSS1 = By.CssSelector("#autoCompleteSingleInput");
    public static By SingleColorInput_CSS2 = By.CssSelector("input#autoCompleteSingleInput");
    public static By SingleColorInput_XPath1 = By.XPath("//input[@id='autoCompleteSingleInput']");
    public static By SingleColorInput_XPath2 = By.XPath("//div[@id='autoCompleteSingleContainer']//input");
    public static By SingleColorValue_XPath1 = By.XPath("//div[contains(@class,'auto-complete__single-value')]");
    public static By SingleColorSelected_CSS1 = By.CssSelector(".auto-complete__single-value");
    public static By SingleColorSelected_CSS2 = By.CssSelector("div.auto-complete__single-value");
    public static By SingleColorSelected_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__single-value')]");
    public static By SingleColorSelected_XPath2 = By.XPath("//div[@id='autoCompleteSingleContainer']//div[contains(@class, 'auto-complete__single-value')]");
    public static By AutoCompleteOptions_CSS1 = By.CssSelector(".auto-complete__option");
    public static By AutoCompleteOptions_CSS2 = By.CssSelector("div.auto-complete__option");
    public static By AutoCompleteOptions_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__option')]");
    public static By AutoCompleteOptions_XPath2 = By.XPath("//div[@class='auto-complete__menu']//div[contains(@class, 'auto-complete__option')]");
    public static By MultiColorInput_Id = By.Id("autoCompleteMultipleInput");
    public static By AutoCompleteOption_CSS = By.CssSelector(".auto-complete__option");
    public static By MultiColorTags_CSS = By.CssSelector(".auto-complete__multi-value__label");
    public static By RemoveButton_CSS = By.CssSelector(".auto-complete__multi-value__remove");

    public static By ClearAllButton_CSS => By.CssSelector(".auto-complete__clear-indicator");
    public static By MultiColorValue_XPath => By.XPath("//div[contains(@class,'auto-complete__multi-value')]");
}
