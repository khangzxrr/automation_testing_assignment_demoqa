using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class BookStorePage : BasePage
{
    public BookStorePage(IWebDriver driver) : base(driver)
    {
    }

    private readonly string url = "https://demoqa.com/books";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement LoginButton => Find(BookStorePageLocators.LoginButton_XPath1);
    public WebElement UsernameInput => Find(BookStorePageLocators.Username_Id);
    public WebElement PasswordInput => Find(BookStorePageLocators.Password_Id);
    public WebElement SubmitLogin => Find(BookStorePageLocators.SubmitLogin_XPath1);
    public WebElement SearchBox => Find(BookStorePageLocators.SearchBox_Id);
    public WebElement FirstBookTitle => Find(BookStorePageLocators.BookTitles_CSS1);
    public WebElement AddToCollectionButton => Find(BookStorePageLocators.AddToCollectionButton_Id);
    public WebElement OKConfirmButton => Find(BookStorePageLocators.OKConfirmButton_XPath1);

    public void Login(string username, string password)
    {
        LoginButton.Click();
        UsernameInput.Type(username);
        PasswordInput.Type(password);
        SubmitLogin.Click();
    }

    public void SearchBook(string title)
    {
        SearchBox.Clear();
        SearchBox.Type(title);
    }

    public void ClickFirstBook()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(BookStorePageLocators.BookTitles_CSS1)).Click();
    }

    public void AddBookToCollection()
    {
        AddToCollectionButton.ScrollIntoView();
        AddToCollectionButton.Click();
    }

    public void AcceptAlertIfPresent()
    {
        try
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
        }
        catch (WebDriverTimeoutException)
        {
            // No alert shown
        }
    }
}
