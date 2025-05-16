
[Collection("TestCollection")]
public class AutoCompleteTest : BaseTest
{
    public AutoCompleteTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "AutoComplete")]
    [Trait("TestCase", "TC15")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "TaggingInput")]
    [Trait("Level", "MultiSelect")]
    public void TC15_VerifyAutoCompleteFunctionality()
    {
        var testname = nameof(TC15_VerifyAutoCompleteFunctionality);
        PerformTest(
            testname,
            () =>
            {
                var page = new AutoCompletePage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                // Step 1: Type in single color input
                page.TypeAndSelectSingleColor("Red");

                // Step 2: Type in multiple color input
                page.TypeAndSelectMultipleColors("Blue", "Green");
                var selected = page.GetSelectedColors();
                Assert.Contains("Blue", selected);
                Assert.Contains("Green", selected);

                // Step 3: Remove one
                page.RemoveColor("Blue");
                selected = page.GetSelectedColors();
                Assert.DoesNotContain("Blue", selected);
                Assert.Contains("Green", selected);

                // Step 4: Clear all
                page.ClearAllColors();
                Assert.Empty(page.GetSelectedColors());
            }
        );
    }
}
