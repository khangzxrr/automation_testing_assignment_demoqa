using OpenQA.Selenium;

public static class WebTableCrudPageLocators
{
    // Button: Add New Record
    public static By AddButton_Id = By.Id("addNewRecordButton");
    public static By AddButton_CSS1 = By.CssSelector("#addNewRecordButton");
    public static By AddButton_CSS2 = By.CssSelector("button#addNewRecordButton");
    public static By AddButton_XPath1 = By.XPath("//button[@id='addNewRecordButton']");
    public static By AddButton_XPath2 = By.XPath("//button[text()='Add']");

    // Modal: Registration Form Fields
    public static By FirstName_Id = By.Id("firstName");
    public static By FirstName_CSS1 = By.CssSelector("#firstName");
    public static By FirstName_CSS2 = By.CssSelector("input[id='firstName']");
    public static By FirstName_XPath1 = By.XPath("//input[@id='firstName']");
    public static By FirstName_XPath2 = By.XPath("//input[@placeholder='First Name']");

    public static By LastName_Id = By.Id("lastName");
    public static By LastName_CSS1 = By.CssSelector("#lastName");
    public static By LastName_CSS2 = By.CssSelector("input[id='lastName']");
    public static By LastName_XPath1 = By.XPath("//input[@id='lastName']");
    public static By LastName_XPath2 = By.XPath("//input[@placeholder='Last Name']");

    public static By Email_Id = By.Id("userEmail");
    public static By Email_CSS1 = By.CssSelector("#userEmail");
    public static By Email_CSS2 = By.CssSelector("input[id='userEmail']");
    public static By Email_XPath1 = By.XPath("//input[@id='userEmail']");
    public static By Email_XPath2 = By.XPath("//div[@id='userEmail-wrapper']//input");

    public static By Age_Id = By.Id("age");
    public static By Age_CSS1 = By.CssSelector("#age");
    public static By Age_CSS2 = By.CssSelector("input[id='age']");
    public static By Age_XPath1 = By.XPath("//input[@id='age']");
    public static By Age_XPath2 = By.XPath("//div[@id='age-wrapper']//input");

    public static By Salary_Id = By.Id("salary");
    public static By Salary_CSS1 = By.CssSelector("#salary");
    public static By Salary_CSS2 = By.CssSelector("input[id='salary']");
    public static By Salary_XPath1 = By.XPath("//input[@id='salary']");
    public static By Salary_XPath2 = By.XPath("//div[@id='salary-wrapper']//input");

    public static By Department_Id = By.Id("department");
    public static By Department_CSS1 = By.CssSelector("#department");
    public static By Department_CSS2 = By.CssSelector("input[id='department']");
    public static By Department_XPath1 = By.XPath("//input[@id='department']");
    public static By Department_XPath2 = By.XPath("//div[@id='salary-wrapper']//input");

    // Button: Submit (in modal)
    public static By SubmitButton_Id = By.Id("submit");
    public static By SubmitButton_CSS1 = By.CssSelector("#submit");
    public static By SubmitButton_CSS2 = By.CssSelector("button#submit");
    public static By SubmitButton_XPath1 = By.XPath("//button[@id='submit']");
    public static By SubmitButton_XPath2 = By.XPath("//button[text()='Submit']");

    // Table: Rows
    public static By TableRows_CSS1 = By.CssSelector("div.rt-tbody div.rt-tr-group");
    public static By TableRows_CSS2 = By.CssSelector("div.rt-tr-group");
    public static By TableRows_XPath1 = By.XPath(
        "//div[@class='rt-tbody']/div[contains(@class,'rt-tr-group')]"
    );
    public static By TableRows_XPath2 = By.XPath("//div[contains(@class,'rt-tr-group')]");

    // Table: Body
    public static By TableBody_XPath1 = By.XPath("//div[@class='rt-tbody']");

    // Table: Pagination
    public static By TablePagination_CSS1 = By.CssSelector(
        "select[aria-label='rows per page']"
    );

    // Table: Cells (within a row)
    public static By TableCells_CSS1 = By.CssSelector("div.rt-td");
    public static By TableCells_CSS2 = By.CssSelector("div.rt-tr-group div.rt-td");
    public static By TableCells_XPath1 = By.XPath(
        "//div[contains(@class,'rt-tr-group')]//div[contains(@class,'rt-td')]"
    );
    public static By TableCells_XPath2 = By.XPath("//div[@class='rt-td']");

    // Actions: Edit and Delete Buttons (within a row)
    public static By EditButton_CSS1 = By.CssSelector("span[title='Edit']");
    public static By EditButton_CSS2 = By.CssSelector("div.action-buttons span[title='Edit']");
    public static By EditButton_XPath1 = By.XPath("//span[@title='Edit']");
    public static By EditButton_XPath2 = By.XPath(
        "//div[@class='action-buttons']/span[@title='Edit']"
    );

    public static By DeleteButton_CSS1 = By.CssSelector("span[title='Delete']");
    public static By DeleteButton_CSS2 = By.CssSelector(
        "div.action-buttons span[title='Delete']"
    );
    public static By DeleteButton_XPath1 = By.XPath("//span[@title='Delete']");
    public static By DeleteButton_XPath2 = By.XPath(
        "//div[@class='action-buttons']/span[@title='Delete']"
    );

    // Search Box
    public static By SearchBox_Id = By.Id("searchBox");
    public static By SearchBox_CSS1 = By.CssSelector("#searchBox");
    public static By SearchBox_CSS2 = By.CssSelector("input[id='searchBox']");
    public static By SearchBox_XPath1 = By.XPath("//input[@id='searchBox']");
    public static By SearchBox_XPath2 = By.XPath("//input[@placeholder='Type to search']");

    // table header
    public static By FirstNameHeader_XPath1 = By.XPath(
        "//div[text() = 'First Name' and @class = 'rt-resizable-header-content']"
    );

    // table first cell of rows
    public static By FirstCell_XPath1 = By.XPath(
        "//div[@role='rowgroup']//div[@role='gridcell'][1]"
    );

}
