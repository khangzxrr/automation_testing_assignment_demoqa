using SeleniumExtras.WaitHelpers;

public partial class TestCase
{
    //this test will fail because the motherfucking web is fucked up
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "BookStore")]
    [Trait("TestCase", "TC09")]
    [Trait("Type", "Authentication")]
    [Trait("Element", "LoginForm")]
    [Trait("Level", "Entry")]
    public void TC09_VerifyBookStoreLoginStart()
    {
        driver.Url = "https://demoqa.com/books";

        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.LoginButton_XPath1);
        driver.FindElement(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.Username_Id).SendKeys("khangzxrr");
        driver.FindElement(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.Password_Id).SendKeys("@DucatiV4S@");
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.SubmitLogin_XPath1);

        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.SearchBox_Id));
        var searchBox = driver.FindElement(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.SearchBox_Id);
        searchBox.SendKeys("Git Pocket Guide");

        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookTitles_XPath1));
        var bookTitleElement = driver.FindElement(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookTitles_XPath1);
        string selectedBook = bookTitleElement.Text;
        bookTitleElement.Click();

        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.AddToCollectionButton_XPath1));
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.AddToCollectionButton_XPath1);

        try { driver.SwitchTo().Alert().Accept(); } catch { }

        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.GoToProfileButton_XPath1);

        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookLinkInProfile(selectedBook)));
        var bookInProfile = driver.FindElement(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookLinkInProfile(selectedBook));
        Assert.Equal(selectedBook, bookInProfile.Text);

        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.DeleteAllBooksButton_XPath1);
        SeleniumHelpers.ScrollIntoViewAndClick(driver, wait, ElementLocators.TC09_VerifyBookStoreSearchAndCollection.OKConfirmButton_XPath1);

        wait.Until(d => d.FindElements(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookLinkInProfile(selectedBook)).Count == 0);
        Assert.Empty(driver.FindElements(ElementLocators.TC09_VerifyBookStoreSearchAndCollection.BookLinkInProfile(selectedBook)));

    }
}
