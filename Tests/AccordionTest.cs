
[Collection("TestCollection")]
public class AccordionTest : BaseTest
{
    public AccordionTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Accordion")]
    [Trait("TestCase", "TC14")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "ExpandableSection")]
    [Trait("Level", "Visibility")]
    public void TC14_VerifyAccordionFunctionality()
    {
        var name = nameof(TC14_VerifyAccordionFunctionality);

        PerformTest(
            name,
            () =>
            {
                var page = new AccordionPage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                Assert.True(page.IsSectionContentVisible(page.Section1Content));

                page.ExpandSection2();
                page.waitUntilExpaned(page.Section2Content);

                Assert.True(page.IsCollapsed(page.Section1Content));
                Assert.True(page.IsSectionContentVisible(page.Section2Content));
                Assert.True(page.IsCollapsed(page.Section3Content));

                page.ExpandSection3();
                page.waitUntilExpaned(page.Section3Content);

                Assert.True(page.IsSectionContentVisible(page.Section3Content));
                Assert.True(page.IsCollapsed(page.Section1Content));
                Assert.True(page.IsCollapsed(page.Section2Content));
            }
        );
    }
}
