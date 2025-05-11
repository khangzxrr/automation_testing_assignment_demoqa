using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "PracticeForm")]
    [Trait("TestCase", "TC04")]
    [Trait("Type", "UIBehavior")]
    [Trait("Element", "Button")]
    [Trait("Level", "StateTransition")]
    public void TC04_VerifyDynamicButtonStateChanges()
    {
        driver.Url = "https://demoqa.com/dynamic-properties";

        // Step 1: Observe initial states
        var enableAfter = driver.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.EnableAfter_Id);
        var colorChange = driver.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.ColorChange_Id);
        var visibleAfterLocator = ElementLocators.TC04_VerifyDynamicButtonStates.VisibleAfter_Id;

        string originalColor = colorChange.GetCssValue("color");

        Assert.False(enableAfter.Enabled, "Enable After button should initially be disabled");


        Assert.True(colorChange.Displayed, "Color Change button should be visible");
        Assert.Throws<NoSuchElementException>(() => driver.FindElement(visibleAfterLocator));

        // Step 2: Wait for 'Enable After' button to be enabled

        wait.Until(d => d.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.EnableAfter_Id).Enabled);

        Assert.True(driver.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.EnableAfter_Id).Enabled);

        // Step 3: Monitor color change
        wait.Until(d =>
        {
            var newColor = d.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.ColorChange_Id).GetCssValue("color");
            return newColor != originalColor;
        });

        string changedColor = driver.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.ColorChange_Id).GetCssValue("color");
        Assert.NotEqual(originalColor, changedColor);

        // Step 4: Wait for button appearance
        wait.Until(ExpectedConditions.ElementIsVisible(visibleAfterLocator));
        var visibleAfter = driver.FindElement(visibleAfterLocator);
        Assert.True(visibleAfter.Displayed, "Visible After button should appear");

        // Step 5: Final assertions for each button
        Assert.True(enableAfter.Enabled, "Enable After is now enabled");
        Assert.True(colorChange.Displayed, "Color Change is visible");
        Assert.True(visibleAfter.Displayed, "Visible After button is visible");
    }


}
