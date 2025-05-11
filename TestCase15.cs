using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "AutoComplete")]
    [Trait("TestCase", "TC15")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "AutoCompleteInput")]
    [Trait("Level", "MultiStateSelection")]
    public void TC15_VerifyAutoCompleteFunctionality()
    {
        driver.Url = "https://demoqa.com/auto-complete";

        // Step 1: Type in single color input
        var singleInput = driver.FindElement(ElementLocators.TC15_VerifyAutoCompleteFunctionality.SingleColorInput_Id);
        singleInput.SendKeys("Re");

        // Step 2: Select from suggestion
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS));
        var redOption = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS)
                              .First(el => el.Text == "Red");
        redOption.Click();

        // Verify selected value
        string selectedSingleValue = driver.FindElement(ElementLocators.TC15_VerifyAutoCompleteFunctionality.SingleColorValue_XPath1).Text;
        Assert.Equal("Red", selectedSingleValue);

        // Step 3: Type in multiple color input
        var multiInput = driver.FindElement(ElementLocators.TC15_VerifyAutoCompleteFunctionality.MultiColorInput_Id);
        multiInput.SendKeys("Blu");
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS));
        var blueOption = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS)
                               .First(el => el.Text == "Blue");
        blueOption.Click();

        // Step 4: Select another color
        multiInput.SendKeys("Gre");
        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS));
        var greenOption = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.AutoCompleteOption_CSS)
                                .First(el => el.Text == "Green");
        greenOption.Click();

        // Verify both selected
        var selectedTags = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.MultiColorTags_CSS);
        Assert.Contains("Blue", selectedTags.Select(e => e.Text));
        Assert.Contains("Green", selectedTags.Select(e => e.Text));
        Assert.Equal(2, selectedTags.Count);

        // Step 5: Delete one color
        var removeButtons = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.RemoveButton_CSS);
        removeButtons.First().Click(); // Remove first (e.g., Blue)

        var updatedTags = driver.FindElements(ElementLocators.TC15_VerifyAutoCompleteFunctionality.MultiColorTags_CSS);
        Assert.Single(updatedTags); // Only one remains


    }
}

