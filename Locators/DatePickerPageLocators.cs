using OpenQA.Selenium;

public static class DatePickerPageLocators
{


    // Date Picker Input
    public static By DatePickerInput_Id = By.Id("datePickerMonthYearInput");

    // Date and Time Picker Input


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
