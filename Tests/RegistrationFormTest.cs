[Collection("TestCollection")]
public class RegistrationFormTest : BaseTest
{
    public RegistrationFormTest(GlobalTestFixture fixture)
        : base(fixture.ExtentReportFixture) { }

    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "FormSubmission")]
    [Trait("TestCase", "TC01")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "StudentRegistrationForm")]
    [Trait("Level", "EndToEnd")]
    [MemberData(nameof(DataLoader.ValidUsers), MemberType = typeof(DataLoader))]
    public void TC01_VerifyUserCanSuccessfullySubmitStudentRegistrationFormWithValidData(
        string firstName,
        string lastName,
        string email,
        string gender,
        string mobile,
        int dobDay,
        int dobMonth,
        int dobYear,
        string imageName,
        string subjects,
        string hobbies,
        string address,
        string state,
        string city
    )
    {
        var testname = nameof(
            TC01_VerifyUserCanSuccessfullySubmitStudentRegistrationFormWithValidData
        );

        PerformTest(
            testname,
            (UnifiedLog log) =>
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageName);

                var page = new RegistrationFormPage(driver, log);

                page.NavigateTo();

                page.WaitForPageReady();

                page.EnterFirstName(firstName);

                page.EnterLastName(lastName);

                page.EnterEmail(email);

                page.SelectGender(gender);

                page.EnterMobile(mobile);

                page.EnterDoB(dobDay, dobMonth, dobYear);

                page.EnterSubjects(subjects);

                page.SelectHobbies(hobbies);

                page.EnterImage(imagePath);

                page.EnterAddress(address);

                page.SelectState(state);

                page.SelectCity(city);

                page.ClickSubmit();

                page.WaitForModalPopup();

                Assert.Contains(firstName + " " + lastName, page.GetModalFullname());

                Assert.Contains(email, page.GetModalEmail());

                Assert.Contains(gender, page.GetModalGender());

                Assert.Contains(mobile, page.GetModalMobile());

                Assert.Contains(FormatDate(dobDay, dobMonth, dobYear), page.GetDoB());

                Assert.Contains(Path.GetFileName(imagePath), page.GetModalImage());

                Assert.Contains(subjects, page.GetModalSubjects());

                Assert.Contains(hobbies, page.GetModalHobbies());

                Assert.Contains(state, page.GetModalStateAndCity());

                Assert.Contains(city, page.GetModalStateAndCity());
            }
        );
    }

    public string FormatDate(int day, int month, int year)
    {
        var date = new DateTime(year, ++month, day); //month must increase because this site is suck

        Console.WriteLine($"{day} {month} {year}");

        return date.ToString("dd MMMM,yyyy");
    }
}
