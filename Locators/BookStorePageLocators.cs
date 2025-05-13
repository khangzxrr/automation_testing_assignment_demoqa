
using OpenQA.Selenium;

public static class BookStorePageLocators
{
    public static By SearchBox_Id = By.Id("searchBox");

    public static By BookTitles_CSS1 = By.CssSelector(".rt-tbody .rt-tr-group .rt-td:nth-child(2) a");
    public static By AddToCollectionButton_Id = By.Id("addNewRecordButton");

    public static By LoginButton_XPath1 = By.XPath("//button[text()='Login']");

    public static By Username_Id = By.Id("userName");
    public static By Password_Id = By.Id("password");

    public static By SubmitLogin_XPath1 = By.XPath("//button[@id='login']");


    public static By OKConfirmButton_XPath1 = By.Id("closeSmallModal-ok");
    public static By BookLinkInProfile(string bookTitle) => By.XPath($"//a[text()='{bookTitle}']");
}
