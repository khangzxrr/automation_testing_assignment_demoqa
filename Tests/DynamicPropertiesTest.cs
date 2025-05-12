using OpenQA.Selenium;

public class DynamicPropertiesTest : BaseTest
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
        var page = new DynamicPropertyPage(driver);

        page.NavigateTo();

        // Step 1: Observe initial states
        string originalColor = page.getColorChangeButtonColor;

        Assert.False(page.enableAfter.Enabled, "Enable After button should initially be disabled");

        Assert.True(page.colorChange.Displayed, "Color Change button should be visible");
        Assert.Throws<NoSuchElementException>(() => page.visibleAfterWithoutWaiting);

        // Step 2: Wait for 'Enable After' button to be enabled
        //
        page.waitUntilButtonEnabled();

        Assert.True(page.enableAfter.Enabled, "Enable After button should become enabled");

        page.waitUntilColorChanged(originalColor);

        Assert.NotEqual(page.getColorChangeButtonColor, originalColor);

        page.waitUntilVisibleAfterButtonVisibled();

        Assert.True(page.visibleAfter.Displayed, "Visible After should appear");

        Assert.True(page.enableAfter.Enabled, "Enable After is now enabled");
        Assert.True(page.colorChange.Displayed, "Color Change is visible");
        Assert.True(page.visibleAfter.Displayed, "Visible After is visible");

    }


}
