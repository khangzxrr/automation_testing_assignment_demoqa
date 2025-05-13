using OpenQA.Selenium;

public static class WebTableCrudPageLocators
{
    public static By AddButton_Id = By.Id("addNewRecordButton");

    public static By FirstName_Id = By.Id("firstName");

    public static By LastName_Id = By.Id("lastName");

    public static By Email_Id = By.Id("userEmail");

    public static By Age_Id = By.Id("age");

    public static By Salary_Id = By.Id("salary");

    public static By Department_Id = By.Id("department");

    // Button: Submit (in modal)
    public static By SubmitButton_Id = By.Id("submit");

    // Table: Rows
    public static By TableRows_XPath1 = By.XPath(
        "//div[@class='rt-tbody']/div[contains(@class,'rt-tr-group')]"
    );
    // Table: Body
    public static By TableBody_XPath1 = By.XPath("//div[@class='rt-tbody']");

    // Table: Pagination
    public static By TablePagination_CSS1 = By.CssSelector(
        "select[aria-label='rows per page']"
    );

    // Table: Cells (within a row)
    public static By TableCells_XPath1 = By.XPath(
        "//div[contains(@class,'rt-tr-group')]//div[contains(@class,'rt-td')]"
    );

    // Actions: Edit and Delete Buttons (within a row)
    public static By EditButton_CSS2 = By.CssSelector("div.action-buttons span[title='Edit']");
    public static By EditButton_XPath1 = By.XPath("//span[@title='Edit']");

    public static By DeleteButton_XPath1 = By.XPath("//span[@title='Delete']");

    // Search Box
    public static By SearchBox_Id = By.Id("searchBox");

    // table header
    public static By FirstNameHeader_XPath1 = By.XPath(
        "//div[text() = 'First Name' and @class = 'rt-resizable-header-content']"
    );

    // table first cell of rows
    public static By FirstCell_XPath1 = By.XPath(
        "//div[@role='rowgroup']//div[@role='gridcell'][1]"
    );

}
