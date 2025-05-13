using OpenQA.Selenium;

public class AccordionPage : BasePage
{
    public AccordionPage(IWebDriver driver)
        : base(driver) { }

    private readonly string url = "https://demoqa.com/accordian";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement Section1Heading => Find(AccordionPageLocators.Section1Heading_Id);
    public WebElement Section1Content => Find(AccordionPageLocators.Section1Content_Id);
    public WebElement Section2Heading => Find(AccordionPageLocators.Section2Heading_Id);
    public WebElement Section2Content => Find(AccordionPageLocators.Section2Content_Id);
    public WebElement Section3Heading => Find(AccordionPageLocators.Section3Heading_Id);
    public WebElement Section3Content => Find(AccordionPageLocators.Section3Content_Id);

    public void ExpandSection1() => Section1Heading.Click();

    public void ExpandSection2() => Section2Heading.Click();

    public void ExpandSection3() => Section3Heading.Click();

    public void waitUntilExpaned(WebElement sectionContent)
    {
        wait.Until(d => IsSectionContentVisible(sectionContent));
        Thread.Sleep(500);
    }

    public bool IsSectionContentVisible(WebElement sectionContent) =>
        sectionContent.Displayed && GetClientHeight(sectionContent) > 0;

    public int GetClientHeight(WebElement element)
    {
        return Convert.ToInt32(element.ExecuteScript<object>("return arguments[0].clientHeight;"));
    }

    public bool IsCollapsed(WebElement element) => GetClientHeight(element) == 0;
}
