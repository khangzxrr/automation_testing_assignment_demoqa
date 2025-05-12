using OpenQA.Selenium;

public static class SliderPageLocators
{
    public static By SliderInput_CSS1 = By.CssSelector(".range-slider");
    public static By SliderInput_CSS2 = By.CssSelector("input[type='range']");
    public static By SliderInput_XPath1 = By.XPath("//input[@class='range-slider range-slider--primary']");
    public static By SliderInput_XPath2 = By.XPath("//input[@type='range']");
    public static By SliderValue_Id = By.Id("sliderValue");
    public static By SliderValue_CSS1 = By.CssSelector("#sliderValue");
    public static By SliderValue_CSS2 = By.CssSelector("input#sliderValue");
    public static By SliderValue_XPath1 = By.XPath("//input[@id='sliderValue']");
    public static By SliderValue_XPath2 = By.XPath("//div[@id='sliderContainer']//div[@class='col-3']/input");
}
