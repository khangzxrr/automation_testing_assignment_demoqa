
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public partial class TestCase : IClassFixture<TestFixture>
{
    private IWebDriver driver;
    private WebDriverWait wait;


    public TestCase(TestFixture testFixture)
    {
        driver = testFixture.driver;
        wait = testFixture.wait;
    }

}
