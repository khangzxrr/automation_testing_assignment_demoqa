using OpenQA.Selenium;

public class WebTableCrudPage : BasePage
{
    public WebTableCrudPage(IWebDriver driver) : base(driver) { }

    private readonly string url = "https://demoqa.com/webtables";
    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement AddButton => Find(WebTableCrudPageLocators.AddButton_Id);
    public WebElement FirstNameInput => Find(WebTableCrudPageLocators.FirstName_Id);
    public WebElement LastNameInput => Find(WebTableCrudPageLocators.LastName_Id);
    public WebElement EmailInput => Find(WebTableCrudPageLocators.Email_Id);
    public WebElement AgeInput => Find(WebTableCrudPageLocators.Age_Id);
    public WebElement SalaryInput => Find(WebTableCrudPageLocators.Salary_Id);
    public WebElement DepartmentInput => Find(WebTableCrudPageLocators.Department_Id);
    public WebElement SubmitButton => Find(WebTableCrudPageLocators.SubmitButton_Id);

    public WebElement SearchBox => Find(WebTableCrudPageLocators.SearchBox_Id);
    public List<WebElement> TableRows => Finds(WebTableCrudPageLocators.TableRows_XPath1);
    public List<WebElement> TableCells => Finds(WebTableCrudPageLocators.TableCells_XPath1);
    public WebElement EditButton => Find(WebTableCrudPageLocators.EditButton_XPath1);
    public WebElement DeleteButton => Find(WebTableCrudPageLocators.DeleteButton_XPath1);
    public WebElement TableBody => Find(WebTableCrudPageLocators.TableBody_XPath1);
    public WebElement PaginationSelect => Find(WebTableCrudPageLocators.TablePagination_CSS1);
    public WebElement FirstNameHeader => Find(WebTableCrudPageLocators.FirstNameHeader_XPath1);
    public List<WebElement> FirstNameCells => Finds(WebTableCrudPageLocators.FirstCell_XPath1);

    public void WaitUntilRowCountNotEmpty() => wait.Until(d => TableRows.Count > 0);

    public void EnterFirstName(string firstName) => FirstNameInput.Type(firstName);
    public void EnterLastName(string lastName) => LastNameInput.Type(lastName);
    public void EnterEmail(string email) => EmailInput.Type(email);
    public void EnterAge(string age) => AgeInput.Type(age);
    public void EnterSalary(string salary) => SalaryInput.Type(salary);
    public void EnterDepartment(string department) => DepartmentInput.Type(department);
    public void SearchByFirstName(string firstName)
    {
        SearchBox.Clear();
        SearchBox.Type(firstName);
    }

    public void updatedSalary(string salary)
    {
        EditButton.Click();
        SalaryInput.Clear();
        EnterSalary(salary);
        SubmitButton.Click();
    }

    public void setPaginationTo(string pageSize)
    {
        PaginationSelect.Click();
        PaginationSelect.SelectByValue(pageSize);
    }


}
