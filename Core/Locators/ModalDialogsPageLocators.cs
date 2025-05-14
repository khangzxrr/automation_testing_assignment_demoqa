using OpenQA.Selenium;

public static class ModalDialogsPageLocators
{
    public static By SmallModalButton_Id = By.Id("showSmallModal");

    public static By LargeModalButton_Id = By.Id("showLargeModal");

    public static By SmallModal_Close_XPath1 = By.XPath("//div[@id='example-modal-sizes-title-sm']/following-sibling::button[contains(@class,'close')]");
    public static By SmallModal_CloseButton_Id = By.Id("closeSmallModal");
    public static By LargeModal_Content_Id = By.Id("example-modal-sizes-title-lg");
    public static By ModalOverlay_CSS = By.CssSelector(".modal-backdrop");
}
