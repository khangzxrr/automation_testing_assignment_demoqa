
[Collection("TestCollection")]
public class FramesTest : BaseTest
{
    public FramesTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Frames")]
    [Trait("TestCase", "TC08")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "iFrame")]
    [Trait("Level", "ContextSwitching")]
    public void TC08_VerifyFrameNavigationAndContent()
    {
        var testname = nameof(TC08_VerifyFrameNavigationAndContent);

        PerformTest(
            testname,
            (UnifiedLog log) =>
            {
                var page = new FramesPage(driver, log);

                page.NavigateTo();

                page.WaitForPageReady();

                page.SwitchToFrame1();
                var heading1 = page.GetFrameHeadingText();
                Assert.Contains("This is a sample page", heading1);

                page.SwitchToDefaultContent();

                page.SwitchToFrame2();
                var heading2 = page.GetFrameHeadingText();
                Assert.Contains("This is a sample page", heading2);

                Assert.Equal(heading1, heading2);
            }
        );
    }
}
