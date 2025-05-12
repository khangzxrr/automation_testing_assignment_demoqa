using OpenQA.Selenium;

public static class FramesPageLocators
{
    // Frame 1
    public static By Frame1_Id = By.Id("frame1");
    public static By Frame1_CSS1 = By.CssSelector("#frame1");
    public static By Frame1_CSS2 = By.CssSelector("iframe#frame1");
    public static By Frame1_XPath1 = By.XPath("//iframe[@id='frame1']");
    public static By Frame1_XPath2 = By.XPath(
        "//iframe[contains(@src, 'sample') and @id='frame1']"
    );

    // Frame 2
    public static By Frame2_Id = By.Id("frame2");
    public static By Frame2_CSS1 = By.CssSelector("#frame2");
    public static By Frame2_CSS2 = By.CssSelector("iframe#frame2");
    public static By Frame2_XPath1 = By.XPath("//iframe[@id='frame2']");
    public static By Frame2_XPath2 = By.XPath(
        "//iframe[contains(@src, 'sample') and @id='frame2']"
    );

    // Content inside frames: Heading
    public static By FrameHeading_Id = By.Id("sampleHeading");
    public static By FrameHeading_CSS1 = By.CssSelector("#sampleHeading");
    public static By FrameHeading_CSS2 = By.CssSelector("h1#sampleHeading");
    public static By FrameHeading_XPath1 = By.XPath("//h1[@id='sampleHeading']");
    public static By FrameHeading_XPath2 = By.XPath("//body/h1[@id='sampleHeading']");

    // Comments:
    // - Each frame is identified by a unique ID.
    // - The heading inside each frame also has a unique ID.
    // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
}
