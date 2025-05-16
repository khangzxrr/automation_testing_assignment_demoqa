using OpenQA.Selenium;

public class SliderPage : BasePage
{
    public SliderPage(IWebDriver driver, UnifiedLog log) : base(driver, log)
    {
    }

    private readonly string url = "https://demoqa.com/slider";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement Slider => Find(SliderPageLocators.SliderInput_CSS1);
    public WebElement SliderValue => Find(SliderPageLocators.SliderValue_Id);

    public void MoveSliderByOffset(int offsetX)
    {
        actions.ClickAndHold(Slider.source).MoveByOffset(offsetX, 0).Release().Perform();
    }

    public void PressArrowRight(int times)
    {
        for (int i = 0; i < times; i++)
            Slider.Type(Keys.ArrowRight);
    }

    public void PressArrowLeft(int times)
    {
        for (int i = 0; i < times; i++)
            Slider.Type(Keys.ArrowLeft);
    }

    public string GetSliderValue() => SliderValue.GetAttribute("value");

    public void SetSliderToMin()
    {
        Slider.Click();
        for (int i = 0; i < 110; i++)
            Slider.Type(Keys.ArrowLeft);
    }

    public void SetSliderToMax()
    {
        Slider.Click();
        for (int i = 0; i < 110; i++)
            Slider.Type(Keys.ArrowRight);
    }

}
