using OpenQA.Selenium;

public static class FramesPageLocators
{
    // Frame 1
    public static By Frame1_Id = By.Id("frame1");

    // Frame 2
    public static By Frame2_Id = By.Id("frame2");

    // Content inside frames: Heading
    public static By FrameHeading_Id = By.Id("sampleHeading");
    // Comments:
    // - Each frame is identified by a unique ID.
    // - The heading inside each frame also has a unique ID.
    // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
}
