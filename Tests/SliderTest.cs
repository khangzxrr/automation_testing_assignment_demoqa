
[Collection("TestCollection")]
public class SliderTest : BaseTest
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Slider")]
    [Trait("TestCase", "TC10")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "RangeSlider")]
    [Trait("Level", "Boundary")]
    public void TC10_VerifySliderInteractions()
    {
        var testname = nameof(TC10_VerifySliderInteractions);

        PerformTest(
            testname,
            () =>
            {
                var page = new SliderPage(driver);

                page.NavigateTo();

                page.WaitForPageReady();

                // Step 1: Drag slider by offset
                page.MoveSliderByOffset(30);
                var valueAfterDrag = int.Parse(page.GetSliderValue());
                Assert.True(valueAfterDrag > 0);

                // Step 2: Increase slider via arrow keys
                page.PressArrowRight(10);
                var increasedValue = int.Parse(page.GetSliderValue());
                Assert.True(increasedValue > valueAfterDrag);

                // Step 3: Decrease slider via arrow keys
                page.PressArrowLeft(5);
                var decreasedValue = int.Parse(page.GetSliderValue());
                Assert.True(decreasedValue < increasedValue);

                // Step 4: Set to min and verify
                page.SetSliderToMin();
                var minValue = int.Parse(page.GetSliderValue());
                Assert.Equal(0, minValue);

                // Step 5: Set to max and verify
                page.SetSliderToMax();
                var maxValue = int.Parse(page.GetSliderValue());
                Assert.Equal(100, maxValue);
            }
        );
    }
}
