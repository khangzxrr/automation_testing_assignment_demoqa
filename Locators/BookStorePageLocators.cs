
using OpenQA.Selenium;

public static class BookStorePageLocators
{
    public static By SearchBox_Id = By.Id("searchBox");
    public static By SearchBox_CSS1 = By.CssSelector("#searchBox");
    public static By SearchBox_CSS2 = By.CssSelector("input#searchBox");
    public static By SearchBox_XPath1 = By.XPath("//input[@id='searchBox']");
    public static By SearchBox_XPath2 = By.XPath("//input[@placeholder='Type to search']");
    public static By BookTitles_CSS1 = By.CssSelector(".rt-tbody .rt-tr-group .rt-td:nth-child(2) a");
    public static By BookTitles_CSS2 = By.CssSelector("div.rt-tbody div.rt-tr-group div.rt-td:nth-child(2) a");
    public static By BookTitles_XPath1 = By.XPath("//div[@class='rt-tbody']//div[@class='rt-tr-group']//a");
    public static By BookTitles_XPath2 = By.XPath("//a[contains(@href, 'books?book=')]");
    public static By AddToCollectionButton_Id = By.Id("addNewRecordButton");
    public static By AddToCollectionButton_CSS1 = By.CssSelector("#addNewRecordButton");
    public static By AddToCollectionButton_CSS2 = By.CssSelector("button#addNewRecordButton");
    public static By AddToCollectionButton_XPath1 = By.XPath("//button[@id='addNewRecordButton']");
    public static By AddToCollectionButton_XPath2 = By.XPath("//button[text()='Add To Your Collection']");
    public static By GoToProfileButton_CSS1 = By.CssSelector("button#gotoStore");
    public static By GoToProfileButton_CSS2 = By.CssSelector("button[onclick='goToProfile()']");
    public static By GoToProfileButton_XPath1 = By.XPath("//button[@id='gotoStore']");
    public static By GoToProfileButton_XPath2 = By.XPath("//button[text()='Go To Book Store']");
    public static By DeleteAllBooksButton_Id = By.Id("submit");
    public static By DeleteAllBooksButton_CSS1 = By.CssSelector("#submit");
    public static By DeleteAllBooksButton_CSS2 = By.CssSelector("button#submit");
    public static By DeleteAllBooksButton_XPath1 = By.XPath("//button[@id='submit']");
    public static By DeleteAllBooksButton_XPath2 = By.XPath("//button[text()='Delete All Books']");
    public static By LoginButton_XPath1 = By.XPath("//button[text()='Login']");
    public static By Username_Id = By.Id("userName");
    public static By Password_Id = By.Id("password");
    public static By SubmitLogin_XPath1 = By.XPath("//button[@id='login']");
    public static By OKConfirmButton_XPath1 = By.Id("closeSmallModal-ok");
    public static By BookLinkInProfile(string bookTitle) => By.XPath($"//a[text()='{bookTitle}']");
}
