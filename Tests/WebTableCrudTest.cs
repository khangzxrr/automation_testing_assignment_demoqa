
[Collection("TestCollection")]
public class WebTableCrudTest : BaseTest
{
    public WebTableCrudTest(GlobalTestFixture fixture) : base(fixture.ExtentReportFixture)
    {
    }

    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "WebTables")]
    [Trait("TestCase", "TC06")]
    [Trait("Type", "CRUD")]
    [Trait("Element", "TableRow")]
    [Trait("Level", "Functional")]
    [MemberData(nameof(DataLoader.WebTableEmployees), MemberType = typeof(DataLoader))]
    public void TC06_VerifyWebTableCRUDOperations(
        string first,
        string last,
        string email,
        string age,
        string initialSalary,
        string department,
        string updatedSalary
    )
    {
        var testname = nameof(TC06_VerifyWebTableCRUDOperations);

        PerformTest(
            testname,
            (UnifiedLog log) =>
            {
                var page = new WebTableCrudPage(driver, log);

                page.NavigateTo();

                page.WaitForPageReady();

                page.AddRecord(first, last, email, age, initialSalary, department);

                page.SearchByFirstName(first);
                page.WaitUntilRowCountNotEmpty();

                Assert.Contains(first, page.TableCells[0].Text);
                Assert.Contains(last, page.TableCells[1].Text);
                Assert.Contains(email, page.TableCells[3].Text);

                page.updatedSalary(updatedSalary);

                page.SearchByFirstName(first);
                Assert.Contains(updatedSalary, page.TableCells[4].Text);

                page.DeleteButton.Click();
                Assert.Empty(page.TableBody.Text.Trim());

                page.setPaginationTo("5");
                Assert.Equal("5", page.PaginationSelect.source.GetAttribute("value"));

                page.SearchBox.Clear();

                page.FirstNameHeader.Click(); // ascending
                var namesAsc = page
                    .FirstNameCells.Select(e => e.Text)
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .ToList();
                Assert.Equal(namesAsc.Order(), namesAsc);

                page.FirstNameHeader.Click(); // descending
                var namesDesc = page
                    .FirstNameCells.Select(e => e.Text)
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .ToList();
                Assert.Equal(namesDesc.OrderDescending(), namesDesc);
            }
        );
    }
}
