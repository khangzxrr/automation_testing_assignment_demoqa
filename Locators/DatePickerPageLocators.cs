using OpenQA.Selenium;

public static class DatePickerPageLocators
{


    // Date Picker Input
    public static By DatePickerInput_Id = By.Id("datePickerMonthYearInput");
    public static By DatePickerInput_CSS1 = By.CssSelector("#datePickerMonthYearInput");
    public static By DatePickerInput_CSS2 = By.CssSelector("input#datePickerMonthYearInput");
    public static By DatePickerInput_XPath1 = By.XPath(
        "//input[@id='datePickerMonthYearInput']"
    );
    public static By DatePickerInput_XPath2 = By.XPath(
        "//div[@class='react-datepicker__input-container']/input[@id='datePickerMonthYearInput']"
    );

    // Date and Time Picker Input
    public static By DateTimePickerInput_Id = By.Id("dateAndTimePickerInput");
    public static By DateTimePickerInput_CSS1 = By.CssSelector("#dateAndTimePickerInput");
    public static By DateTimePickerInput_CSS2 = By.CssSelector("input#dateAndTimePickerInput");
    public static By DateTimePickerInput_XPath1 = By.XPath(
        "//input[@id='dateAndTimePickerInput']"
    );
    public static By DateTimePickerInput_XPath2 = By.XPath(
        "//div[@class='react-datepicker__input-container']/input[@id='dateAndTimePickerInput']"
    );

    // Calendar Month Select
    public static By CalendarMonthSelect_Class = By.ClassName(
        "react-datepicker__month-dropdown-container--scroll"
    );
    public static By CalendarMonthSelect_CSS1 = By.CssSelector(
        ".react-datepicker__month-dropdown-container"
    );
    public static By CalendarMonthSelect_CSS2 = By.CssSelector(
        "div.react-datepicker__header__dropdown > .react-datepicker__month-dropdown-container--scroll"
    );
    public static By CalendarMonthSelect_XPath1 = By.XPath(
        "//div[@class='react-datepicker__header__dropdown react-datepicker__header__dropdown--scroll']//div[contains(@class, 'react-datepicker__month-dropdown-container')]"
    );
    public static By CalendarMonthSelect_XPath2 = By.XPath(
        "(//div[contains(@class, 'react-datepicker__month-dropdown')])[1]"
    );

    // Calendar Year Select
    public static By CalendarYearSelect_CSS1 = By.CssSelector(
        ".react-datepicker__year-dropdown-container--scroll"
    );
    public static By CalendarYearSelect_CSS2 = By.CssSelector(
        ".react-datepicker__header__dropdown--scroll > div.react-datepicker__year-dropdown-container"
    );
    public static By CalendarYearSelect_XPath1 = By.XPath(
        "//div[contains(@class,'react-datepicker__year-dropdown-container--scroll')]"
    );
    public static By CalendarYearSelect_XPath2 = By.XPath(
        "//div[@class='react-datepicker__year-dropdown-container react-datepicker__year-dropdown-container--scroll']"
    );

    // Calendar Day (example for 15th day)
    public static By CalendarDay15_CSS1 = By.CssSelector(".react-datepicker__day--015");
    public static By CalendarDay15_CSS2 = By.CssSelector("div.react-datepicker__day--015");
    public static By CalendarDay15_XPath1 = By.XPath(
        "//div[contains(@class, 'react-datepicker__day--015') and not(contains(@class, 'outside-month'))]"
    );
    public static By CalendarDay15_XPath2 = By.XPath(
        "//div[@class='react-datepicker__day react-datepicker__day--015']"
    );

    // Time List Item (example for 12:00)
    public static By TimeListItem1200_CSS1 = By.CssSelector(
        ".react-datepicker__time-list-item"
    );
    public static By TimeListItem1200_CSS2 = By.CssSelector(
        "li.react-datepicker__time-list-item"
    );
    public static By TimeListItem1200_XPath1 = By.XPath(
        "//li[contains(@class, 'react-datepicker__time-list-item') and text()='12:00']"
    );
    public static By TimeListItem1200_XPath2 = By.XPath(
        "//li[@class='react-datepicker__time-list-item ' and text()='12:00']"
    );

    public static By MonthDropdown_CSS = By.CssSelector(".react-datepicker__month-select");
    public static By YearDropdown_CSS = By.CssSelector(".react-datepicker__year-select");

    public static By DayInMonth(int day) =>
        By.CssSelector(
            $".react-datepicker__day--0{day:D2}:not(.react-datepicker__day--outside-month)"
        );

    // Comments:
    // - The date picker inputs have unique IDs for direct access.
    // - Month and year selectors are dropdowns within the date picker pop-up.
    // - Days are selectable via specific class names corresponding to the day number.
    // - Time selections are list items within the time picker.
    // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
}
