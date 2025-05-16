
[Collection("TestCollection")]
public class ProgressBarTest : BaseTest
{
    public ProgressBarTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "ProgressBar")]
    [Trait("TestCase", "TC11")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "ProgressIndicator")]
    [Trait("Level", "Dynamic")]
    public void TC11_VerifyProgressBarFunctionality()
    {
        var testname = nameof(TC11_VerifyProgressBarFunctionality);
        PerformTest(
            testname,
            () =>
            {
                var page = new ProgressBarPage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                // Step 1: Start and stop at ~20–30%
                page.ClickStartStop();
                page.WaitForProgressToExceed(20);
                page.ClickStartStop();
                var midValue = page.GetProgressPercent();
                Assert.InRange(midValue, 20, 30);

                // Step 2: Continue to 100%
                page.ClickStartStop();
                page.WaitForProgressToEqual(100);
                var fullValue = page.GetProgressPercent();
                Assert.Equal(100, fullValue);

                // Step 3: Reset
                page.ClickReset();
                page.WaitForProgressToBeReset();
                Assert.Equal(0, page.GetProgressPercent());
            }
        );
    }
}
