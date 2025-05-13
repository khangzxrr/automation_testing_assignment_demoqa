public class RegistrationFormTest : BaseTest
{
    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "StudentRegistrationForm")]
    [InlineData(
        "firstName",
        "lastName",
        "khangzxrr@gmail.com",
        "Male",
        "0919092211",
          21,
          6,
        2000,
        "sample.jpg",
        "English",
        "Sports",
        "159 xa lo ha noi",
        "NCR",
        "Delhi"
    )]
    [InlineData(
        "firstName2",
        "lastName2",
        "khangzxrr2@gmail.com",
        "Male",
        "0919092233",
        21,
        5,
       2000,
        "sample.jpg",
        "English",
        "Sports",
        "159 xa lo ha noi",
        "Uttar Pradesh",
        "Agra"
    )]
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
        PerformTest(() =>
        {
            string imagePath = Directory.GetCurrentDirectory() + "/" + imageName;

            var page = new RegistrationFormPage(driver);

            page.NavigateTo();

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

            Assert.True(page.IsModalDisplayCorrectInfo(
                  firstName,
                  lastName,
                  email,
                  gender,
                  mobile,
                  dobDay,
                  dobMonth,
                  dobYear,
                  imageName,
                  subjects,
                  hobbies,
                  address,
                  state,
                  city
            ));

        });

    }



}
