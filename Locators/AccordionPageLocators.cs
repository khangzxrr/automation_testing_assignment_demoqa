using OpenQA.Selenium;

public static class AccordionPageLocators
{
    public static By Section1Heading_Id = By.Id("section1Heading");
    public static By Section1Heading_CSS1 = By.CssSelector("#section1Heading");
    public static By Section1Heading_CSS2 = By.CssSelector("div#section1Heading");
    public static By Section1Heading_XPath1 = By.XPath("//div[@id='section1Heading']");
    public static By Section1Heading_XPath2 = By.XPath("//div[text()='What is Lorem Ipsum?']");
    public static By Section1Content_Id = By.Id("section1Content");
    public static By Section1Content_CSS1 = By.CssSelector("#section1Content");
    public static By Section1Content_CSS2 = By.CssSelector("div#section1Content");
    public static By Section1Content_XPath1 = By.XPath("//div[@id='section1Content']");
    public static By Section1Content_XPath2 = By.XPath("//div[@id='section1Content']/p");
    public static By Section2Heading_Id = By.Id("section2Heading");
    public static By Section2Heading_CSS1 = By.CssSelector("#section2Heading");
    public static By Section2Heading_CSS2 = By.CssSelector("div#section2Heading");
    public static By Section2Heading_XPath1 = By.XPath("//div[@id='section2Heading']");
    public static By Section2Heading_XPath2 = By.XPath("//div[text()='Where does it come from?']");
    public static By Section2Content_Id = By.Id("section2Content");
    public static By Section2Content_CSS1 = By.CssSelector("#section2Content");
    public static By Section2Content_CSS2 = By.CssSelector("div#section2Content");
    public static By Section2Content_XPath1 = By.XPath("//div[@id='section2Content']");
    public static By Section2Content_XPath2 = By.XPath("//div[@id='section2Content']/p");
    public static By Section3Heading_Id = By.Id("section3Heading");
    public static By Section3Heading_CSS1 = By.CssSelector("#section3Heading");
    public static By Section3Heading_CSS2 = By.CssSelector("div#section3Heading");
    public static By Section3Heading_XPath1 = By.XPath("//div[@id='section3Heading']");
    public static By Section3Heading_XPath2 = By.XPath("//div[text()='Why do we use it?']");
    public static By Section3Content_Id = By.Id("section3Content");
    public static By Section3Content_CSS1 = By.CssSelector("#section3Content");
    public static By Section3Content_CSS2 = By.CssSelector("div#section3Content");
    public static By Section3Content_XPath1 = By.XPath("//div[@id='section3Content']");
    public static By Section3Content_XPath2 = By.XPath("//div[@id='section3Content']/p");
    public static By Section3Collapse_XPath1 = By.XPath("//div[@id='section3Content']/parent::div");
}
