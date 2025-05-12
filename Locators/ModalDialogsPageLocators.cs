using OpenQA.Selenium;

public static class ModalDialogsPageLocators
{
    public static By SmallModalButton_Id = By.Id("showSmallModal");
    public static By SmallModalButton_CSS1 = By.CssSelector("#showSmallModal");
    public static By SmallModalButton_CSS2 = By.CssSelector("button#showSmallModal");
    public static By SmallModalButton_XPath1 = By.XPath("//button[@id='showSmallModal']");
    public static By SmallModalButton_XPath2 = By.XPath("//button[text()='Small modal']");
    public static By LargeModalButton_Id = By.Id("showLargeModal");
    public static By LargeModalButton_CSS1 = By.CssSelector("#showLargeModal");
    public static By LargeModalButton_CSS2 = By.CssSelector("button#showLargeModal");
    public static By LargeModalButton_XPath1 = By.XPath("//button[@id='showLargeModal']");
    public static By LargeModalButton_XPath2 = By.XPath("//button[text()='Large modal']");
    public static By ModalTitle_Class = By.ClassName("modal-title");
    public static By ModalTitle_CSS1 = By.CssSelector(".modal-title");
    public static By ModalTitle_CSS2 = By.CssSelector(".modal-header > .modal-title");
    public static By ModalTitle_XPath1 = By.XPath("//div[@class='modal-header']//div[@class='modal-title h4']");
    public static By ModalTitle_XPath2 = By.XPath("//div[contains(@class, 'modal-title')]");
    public static By ModalBody_Class = By.ClassName("modal-body");
    public static By ModalBody_CSS1 = By.CssSelector(".modal-body");
    public static By ModalBody_CSS2 = By.CssSelector("div.modal-body");
    public static By ModalBody_XPath1 = By.XPath("//div[@class='modal-body']");
    public static By ModalBody_XPath2 = By.XPath("//div[contains(@class, 'modal-body')]");
    public static By CloseButton_Id = By.Id("closeSmallModal");
    public static By CloseButton_CSS1 = By.CssSelector("#closeSmallModal");
    public static By CloseButton_CSS2 = By.CssSelector("button#closeSmallModal");
    public static By CloseButton_XPath1 = By.XPath("//button[@id='closeSmallModal']");
    public static By CloseButton_XPath2 = By.XPath("//button[text()='Close']");
    public static By SmallModal_Close_XPath1 = By.XPath("//div[@id='example-modal-sizes-title-sm']/following-sibling::button[contains(@class,'close')]");
    public static By SmallModal_CloseButton_Id = By.Id("closeSmallModal");
    public static By LargeModal_Content_Id = By.Id("example-modal-sizes-title-lg");
    public static By LargeModal_CloseButton_Id = By.Id("closeLargeModal");
    public static By ModalOverlay_CSS = By.CssSelector(".modal-backdrop");
}
