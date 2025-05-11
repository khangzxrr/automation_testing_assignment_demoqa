using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Frames")]
    [Trait("TestCase", "TC08")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "iFrame")]
    [Trait("Level", "ContextSwitching")]
    public void TC08_VerifyFrameNavigationAndContent()
    {
        driver.Url = "https://demoqa.com/frames";

        // Step 1: Switch to first frame
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(ElementLocators.TC08_VerifyFrameNavigation.Frame1_Id));

        // Step 2: Verify content in frame1
        var heading1 = wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC08_VerifyFrameNavigation.FrameHeading_Id)).Text;
        Assert.Contains("This is a sample page", heading1);

        // Step 3: Switch back to main page
        driver.SwitchTo().DefaultContent();

        // Step 4: Switch to second frame
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(ElementLocators.TC08_VerifyFrameNavigation.Frame2_Id));

        // Step 5: Verify content in frame2
        var heading2 = wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC08_VerifyFrameNavigation.FrameHeading_Id)).Text;
        Assert.Contains("This is a sample page", heading2);

        // Confirm both frame contents are same
        Assert.Equal(heading1, heading2);
    }
}
