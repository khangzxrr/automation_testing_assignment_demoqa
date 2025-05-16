
[Collection("TestCollection")]
public class BookStoreTest : BaseTest
{
    public BookStoreTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "BookStore")]
    [Trait("TestCase", "TC09")]
    [Trait("Type", "LoginSearchAdd")]
    [Trait("Element", "BooksTable")]
    [Trait("Level", "EndToEnd")]
    public void TC09_VerifyBookStoreLoginSearchAndAddToCollection()
    {
        var testname = nameof(TC09_VerifyBookStoreLoginSearchAndAddToCollection);
        PerformTest(
            testname,
            (UnifiedLog log) =>
            {
                var page = new BookStorePage(driver, log);

                page.NavigateTo();

                page.WaitForPageReady();

                // Step 1: Login
                page.Login("khangzxrr", "@DucatiV4S@");

                // Step 2: Search book
                page.SearchBook("Git Pocket Guide");

                // Step 3: Click book and add to collection
                page.ClickFirstBook();
                page.AddBookToCollection();

                // Step 4: Accept alert (if shown)
                page.AcceptAlertIfPresent();
            }
        );
    }
}
