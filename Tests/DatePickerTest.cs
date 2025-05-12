public class DatePickerTest : BaseTest
{
    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "DatePicker")]
    [Trait("TestCase", "TC12")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "Calendar")]
    public void TC12_VerifyDatePickerSelections()
    {
        var page = new DatePickerPage(driver);

        page.NavigateTo();

        // Step 1: Select today's date
        var today = DateTime.Now;
        page.OpenDatePicker();
        page.SelectDay(today.Day);
        Assert.True(page.IsValidDateFormat("MM/dd/yyyy"));

        // Step 2: Select future date
        var future = today.AddMonths(2).AddDays(10);
        page.OpenDatePicker();
        page.SelectMonthYear(future);
        page.SelectDay(future.Day);
        Assert.Contains(future.Year.ToString(), page.GetSelectedDate());

        // Step 3: Select past date
        var past = today.AddYears(-1).AddMonths(-1);
        page.OpenDatePicker();
        page.SelectMonthYear(past);
        page.SelectDay(past.Day);
        Assert.Contains(past.Year.ToString(), page.GetSelectedDate());
    }
}
