

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "ProgressBar")]
    [Trait("TestCase", "TC11")]
    [Trait("Type", "UIBehavior")]
    [Trait("Element", "ProgressBar")]
    [Trait("Level", "StateTransition")]
    public void TC11_VerifyProgressBarFunctionality()
    {
        driver.Url = "https://demoqa.com/progress-bar";

        var startStopBtn = driver.FindElement(ElementLocators.TC11_VerifyProgressBarOperations.StartButton_Id);
        var progressBar = driver.FindElement(ElementLocators.TC11_VerifyProgressBarOperations.ProgressValue_CSS1);

        // Step 1: Click Start button
        startStopBtn.Click();

        // Step 2: Wait for progress to exceed 20%

        wait.Until(driver =>
        {
            string value = progressBar.Text.Replace("%", "");
            return int.TryParse(value, out int percent) && percent > 20;
        });

        // Step 3: Click Stop
        startStopBtn.Click();

        // Step 4: Verify current percentage
        string percentText = progressBar.Text.Replace("%", "");
        Assert.True(int.TryParse(percentText, out int partialPercent));
        Assert.InRange(partialPercent, 21, 30); //assumtion sometime delay will cause 1 or 2 percent missmatch

        // Step 5: Click Start again and wait until 100%
        startStopBtn.Click();
        wait.Until(driver =>
        {
            string value = progressBar.Text.Replace("%", "");
            return value == "100";
        });
        Assert.Equal("100", progressBar.Text.Replace("%", ""));

        // Step 6: Click Reset button
        var resetBtn = driver.FindElement(ElementLocators.TC11_VerifyProgressBarOperations.ResetButton_XPath1);
        resetBtn.Click();

        // Confirm reset
        wait.Until(driver => progressBar.Text.Replace("%", "") == "");
        Assert.Equal("", progressBar.Text.Replace("%", ""));
    }
}
