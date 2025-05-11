using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Slider")]
    [Trait("TestCase", "TC10")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "Slider")]
    [Trait("Level", "ValueChange")]
    public void TC10_VerifySliderInteractions()
    {
        driver.Url = "https://demoqa.com/slider";

        var slider = wait.Until(ExpectedConditions.ElementToBeClickable(ElementLocators.TC10_VerifySliderFunctionality.SliderInput_CSS1));

        var sliderValue = driver.FindElement(ElementLocators.TC10_VerifySliderFunctionality.SliderValue_Id);
        var actions = new Actions(driver);

        // Step 1: Click the slider to move
        actions.MoveToElement(slider, 30, 0).Click().Perform();
        string clickedValue = sliderValue.GetAttribute("value");
        int numbericAfterDragValue = int.Parse(clickedValue);


        Assert.True(25 < numbericAfterDragValue); // default is 25, we drag to the right => it will increase

        // Step 3: Use keyboard arrows to increase value
        slider.SendKeys(Keys.ArrowRight);
        slider.SendKeys(Keys.ArrowRight);
        slider.SendKeys(Keys.ArrowRight);
        slider.SendKeys(Keys.ArrowRight);

        Thread.Sleep(200);
        int numericValue = int.Parse(sliderValue.GetAttribute("value"));
        Assert.True(numericValue > numbericAfterDragValue);

        // Step 4: Use keyboard arrows to decrease value
        slider.SendKeys(Keys.ArrowLeft);
        slider.SendKeys(Keys.ArrowLeft);
        slider.SendKeys(Keys.ArrowLeft);
        slider.SendKeys(Keys.ArrowLeft);

        Thread.Sleep(200);
        int adjustedValue = int.Parse(sliderValue.GetAttribute("value"));
        Assert.True(adjustedValue < numericValue);

        // Step 5: Test min (0) and max (100)
        actions.ClickAndHold(slider).MoveByOffset(-slider.Size.Width / 2, 0).Release().Perform(); // move far left
        Assert.Equal("0", sliderValue.GetAttribute("value"));

        actions.ClickAndHold(slider).MoveByOffset(slider.Size.Width / 2, 0).Release().Perform(); // move far right
        Assert.Equal("100", sliderValue.GetAttribute("value"));
    }

}
