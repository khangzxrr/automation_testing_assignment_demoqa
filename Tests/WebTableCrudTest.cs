
public class WebTableCrudTest : BaseTest
{
    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "WebTables")]
    [Trait("TestCase", "TC06")]
    [Trait("Type", "CRUD")]
    [Trait("Element", "TableRow")]
    [Trait("Level", "Functional")]
    [InlineData("John", "Doe", "john.doe@example.com", "30", "80000", "QA", "90000")]
    [InlineData("Alice", "Smith", "alice.smith@example.com", "28", "75000", "HR", "82000")]
    public void TC06_VerifyWebTableCRUDOperations(string first, string last, string email, string age, string initialSalary, string department, string updatedSalary)
    {
        var page = new WebTableCrudPage(driver);

        page.NavigateTo();

        AddRecord(page, first, last, email, age, initialSalary, department);

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
        var namesAsc = page.FirstNameCells.Select(e => e.Text).Where(t => !string.IsNullOrWhiteSpace(t)).ToList();
        Assert.Equal(namesAsc.Order(), namesAsc);

        page.FirstNameHeader.Click(); // descending
        var namesDesc = page.FirstNameCells.Select(e => e.Text).Where(t => !string.IsNullOrWhiteSpace(t)).ToList();
        Assert.Equal(namesDesc.OrderDescending(), namesDesc);
    }

    private void AddRecord(WebTableCrudPage page, string first, string last, string email, string age, string salary, string department)
    {
        page.AddButton.Click();
        page.EnterFirstName(first);
        page.EnterLastName(last);
        page.EnterEmail(email);
        page.EnterAge(age);
        page.EnterSalary(salary);
        page.EnterDepartment(department);
        page.SubmitButton.Click();
    }
}
