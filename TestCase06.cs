using OpenQA.Selenium.Support.UI;

public partial class TestCase
{

    [Trait("Category", "DemoQA")]
    [Trait("Component", "WebTables")]
    [Trait("TestCase", "TC06")]
    [Trait("Type", "CRUD")]
    [Trait("Element", "TableRow")]
    [Trait("Level", "Functional")]
    [Theory]
    [InlineData("John", "Doe", "john.doe@example.com", "30", "80000", "QA", "90000")]
    [InlineData("Alice", "Smith", "alice.smith@example.com", "28", "75000", "HR", "82000")]
    public void TC06_VerifyWebTableCRUDOperations(
        string firstName,
        string lastName,
        string email,
        string age,
        string initialSalary,
        string department,
        string updatedSalary)
    {
        driver.Url = "https://demoqa.com/webtables";

        // Step 1: Add record
        AddRecords(firstName, lastName, email, age, initialSalary, department);

        // Step 2: Search for record
        var searchBox = driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.SearchBox_Id);
        searchBox.Clear();
        searchBox.SendKeys(firstName);
        wait.Until(d => d.FindElements(ElementLocators.TC06_VerifyWebTableCRUD.TableRows_XPath1).Count > 0);

        var cells = driver.FindElements(ElementLocators.TC06_VerifyWebTableCRUD.TableCells_XPath1);
        Assert.Contains(firstName, cells[0].Text);
        Assert.Contains(lastName, cells[1].Text);
        Assert.Contains(email, cells[3].Text);

        // Step 3: Edit salary
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.EditButton_XPath1).Click();
        var salaryInput = driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.Salary_Id);
        salaryInput.Clear();
        salaryInput.SendKeys(updatedSalary);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.SubmitButton_Id).Click();

        searchBox.Clear();
        searchBox.SendKeys(firstName);
        var updatedCells = driver.FindElements(ElementLocators.TC06_VerifyWebTableCRUD.TableCells_XPath1);
        Assert.Contains(updatedSalary, updatedCells[4].Text);

        // Step 4: Delete record
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.DeleteButton_XPath1).Click();
        searchBox.Clear();
        searchBox.SendKeys(firstName);
        Assert.Empty(driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.TableBody_XPath1).Text.Trim());

        searchBox.Clear();

        // Step 5: Verify pagination
        SeleniumHelpers.ScrollIntoView(driver, wait, ElementLocators.TC06_VerifyWebTableCRUD.TablePagination_CSS1);
        var paginationSelect = driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.TablePagination_CSS1);
        var selectElement = new SelectElement(paginationSelect);
        selectElement.SelectByValue("5");
        Assert.Equal("5", selectElement.SelectedOption.GetAttribute("value"));

        // Step 6: Test sorting
        var header = driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.FirstNameHeader_XPath1);
        header.Click(); // Ascending sort

        var firstNamesAsc = driver.FindElements(ElementLocators.TC06_VerifyWebTableCRUD.FirstCell_XPath1)
                                  .Select(e => e.Text)
                                  .Where(t => !string.IsNullOrWhiteSpace(t))
                                  .ToList();
        Assert.Equal(firstNamesAsc.Order(), firstNamesAsc);

        header.Click(); // Descending sort

        var firstNamesDesc = driver.FindElements(ElementLocators.TC06_VerifyWebTableCRUD.FirstCell_XPath1)
                                   .Select(e => e.Text)
                                   .Where(t => !string.IsNullOrWhiteSpace(t))
                                   .ToList();
        Assert.Equal(firstNamesDesc.OrderDescending(), firstNamesDesc);
    }

    private void AddRecords(string firstName, string lastName, string email, string age, string salary, string department)
    {
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.AddButton_Id).Click();
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.FirstName_Id).SendKeys(firstName);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.LastName_Id).SendKeys(lastName);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.Email_Id).SendKeys(email);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.Age_Id).SendKeys(age);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.Salary_Id).SendKeys(salary);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.Department_Id).SendKeys(department);
        driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.SubmitButton_Id).Click();
    }

}
