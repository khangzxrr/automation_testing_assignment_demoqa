using System.Globalization;
using OpenQA.Selenium.Support.UI;

public partial class TestCase
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "DatePicker")]
    [Trait("TestCase", "TC12")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "CalendarInput")]
    [Trait("Level", "InputSelection")]
    public void TC12_VerifyDatePickerSelections()
    {
        driver.Url = "https://demoqa.com/date-picker";

        // Step 1: Select current date
        var input = driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.DatePickerInput_Id);
        input.Click();

        var today = DateTime.Today;
        var todayStr = today.ToString("MM/dd/yyyy");

        driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.DayInMonth(today.Day)).Click();
        Assert.Equal(todayStr, input.GetAttribute("value"));

        // Step 2: Select future date
        input.Click();
        var future = today.AddDays(30);
        SetDateByDropdown(future);
        Assert.Equal(future.ToString("MM/dd/yyyy"), input.GetAttribute("value"));

        // Step 3: Select past date
        input.Click();
        var past = today.AddDays(-30);
        SetDateByDropdown(past);
        Assert.Equal(past.ToString("MM/dd/yyyy"), input.GetAttribute("value"));

        // Step 4 & 5: Format verification
        string dateText = input.GetAttribute("value");
        bool isValidFormat = DateTime.TryParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        Assert.True(isValidFormat, $"Expected MM/dd/yyyy format but got: {dateText}");
    }

    private void SetDateByDropdown(DateTime date)
    {
        var monthSelect = new SelectElement(driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.MonthDropdown_CSS));
        var yearSelect = new SelectElement(driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.YearDropdown_CSS));

        monthSelect.SelectByValue((date.Month - 1).ToString()); // Month is 0-indexed in picker
        yearSelect.SelectByValue(date.Year.ToString());

        driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.DayInMonth(date.Day)).Click();
    }
}
