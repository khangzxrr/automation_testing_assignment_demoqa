
using OpenQA.Selenium;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Accordion")]
    [Trait("TestCase", "TC14")]
    [Trait("Type", "UIBehavior")]
    [Trait("Element", "AccordionSection")]
    [Trait("Level", "ToggleVisibility")]
    public void TC14_VerifyAccordionFunctionality()
    {
        driver.Url = "https://demoqa.com/accordian";

        // Step 1: Click first section header
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC14_VerifyAccordionSections.Section1Heading_Id);

        // Step 2: Verify content displays
        var section1Content = driver.FindElement(ElementLocators.TC14_VerifyAccordionSections.Section1Content_Id);
        wait.Until(d => section1Content.Displayed && section1Content.Text.Length > 0);
        Assert.True(section1Content.Displayed);
        Assert.False(string.IsNullOrWhiteSpace(section1Content.Text));

        // Step 3: Click second section
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC14_VerifyAccordionSections.Section2Heading_Id);

        // Step 4: Verify first section closes
        wait.Until(d => !section1Content.Displayed || section1Content.GetAttribute("class").Contains("collapse"));
        Assert.False(section1Content.Displayed || section1Content.GetAttribute("class").Contains("show"));

        var section3Collapse = driver.FindElement(ElementLocators.TC14_VerifyAccordionSections.Section3Collapse_XPath1);

        var section3Content = driver.FindElement(ElementLocators.TC14_VerifyAccordionSections.Section3Content_Id);

        var jsDriver = ((IJavaScriptExecutor)driver);
        Assert.Equal("collapse", section3Collapse.GetAttribute("class"));


        Int64 section3Height = (Int64)jsDriver.ExecuteScript("return arguments[0].clientHeight;", section3Content);
        Assert.Equal(0, section3Height);

        // Step 5: Click third section
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC14_VerifyAccordionSections.Section3Heading_Id);

        // step 6: wait for collaping animation
        wait.Until(d => d.FindElement(ElementLocators.TC14_VerifyAccordionSections.Section3Collapse_XPath1).GetAttribute("class") == "collapsing");

        wait.Until(d => d.FindElement(ElementLocators.TC14_VerifyAccordionSections.Section3Collapse_XPath1).GetAttribute("class") == "collapse show");

        section3Height = (Int64)jsDriver.ExecuteScript("return arguments[0].clientHeight;", section3Content);

        Assert.Equal("collapse show", section3Collapse.GetAttribute("class"));
        Assert.True(section3Height > 0);
    }
}
