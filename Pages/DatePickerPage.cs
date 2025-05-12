using System.Globalization;
using OpenQA.Selenium;

public class DatePickerPage : BasePage
{
    public DatePickerPage(IWebDriver driver) : base(driver)
    {
    }

    private readonly string url = "https://demoqa.com/date-picker";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement DateInput => Find(DatePickerPageLocators.DatePickerInput_Id);
    public WebElement MonthDropdown => Find(DatePickerPageLocators.MonthDropdown_CSS);
    public WebElement YearDropdown => Find(DatePickerPageLocators.YearDropdown_CSS);

    public void OpenDatePicker() => DateInput.Click();

    public void SelectDay(int day)
    {
        var dayElement = Find(DatePickerPageLocators.DayInMonth(day));
        dayElement.Click();
    }

    public void SelectMonthYear(DateTime date)
    {
        MonthDropdown.SelectByText(date.ToString("MMMM", CultureInfo.InvariantCulture));
        YearDropdown.SelectByText(date.Year.ToString());
    }

    public string GetSelectedDate() => DateInput.GetAttribute("value");

    public bool IsValidDateFormat(string format)
    {
        string value = GetSelectedDate();
        return DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
}
