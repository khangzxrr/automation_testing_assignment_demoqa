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
        "5",
        "2000",
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
        "5",
        "2000",
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
        string dobMonth,
        string dobYear,
        string imageName,
        string subjects,
        string hobbies,
        string address,
        string state,
        string city
    )
    {
        string imagePath = Directory.GetCurrentDirectory() + "/" + imageName;

        // Assert.Equal(firstName + " " + lastName, modalName);
        // Assert.Equal(email, modalEmail);
        // Assert.Equal(gender, modalGender);
        // Assert.Equal(mobile, modalMobile);
        // Assert.Contains(dobYear, modalDob);
        // Assert.Equal(subjects, modalSubjects);
        // Assert.Equal(hobbies, modalHobbies);
        // Assert.Equal(imageName, modalPicture);
        // Assert.Equal(address, modalAddress);
        // Assert.Contains(state, modalStateAndCity);
        // Assert.Contains(city, modalStateAndCity);
    }
}
