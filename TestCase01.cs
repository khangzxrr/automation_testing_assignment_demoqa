using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public partial class TestCase
{


    [Theory]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "StudentRegistrationForm")]
    [InlineData(
        "firstName", "lastName", "khangzxrr@gmail.com", "Male", "0919092211",
        "5", "2000", "sample.jpg", "English", "Sports", "159 xa lo ha noi", "NCR", "Delhi")]
    [InlineData(
        "firstName2", "lastName2", "khangzxrr2@gmail.com", "Male", "0919092233",
        "5", "2000", "sample.jpg", "English", "Sports", "159 xa lo ha noi", "Uttar Pradesh", "Agra")]
    public void
        TC01_VerifyUserCanSuccessfullySubmitStudentRegistrationFormWithValidData(
        string firstName, string lastName, string email, string gender, string mobile,
        string dobMonth, string dobYear, string imageName, string subjects,
        string hobbies, string address, string state, string city)
    {
        string imagePath = Directory.GetCurrentDirectory() + "/" + imageName;

        driver.Url = "https://demoqa.com/automation-practice-form";

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.FirstName_Id).SendKeys(firstName);
        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.LastName_Id).SendKeys(lastName);
        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.Email_Id).SendKeys(email);

        if (gender == "Male")
        {
            driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.GenderMale_CSS2).Click();
        }
        else if (gender == "Female")
        {

            driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.GenderFemale_XPath1).Click();
        }
        else
        {
            driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.GenderOther_XPath1).Click();
        }


        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.Mobile_XPath2).SendKeys(mobile);

        SeleniumHelpers.ScrollIntoViewAndClick(
            driver,
            wait,
            ElementLocators.TC01_VerifyStudentRegistration.DOB_Id
        );

        var dobMonthElement = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.DOB_Month_Select_XPath1);
        SelectElement monthSelect = new SelectElement(dobMonthElement);
        monthSelect.SelectByValue(dobMonth);

        var dobYearElement = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.DOB_Year_Select_XPath1);
        SelectElement yearSelect = new SelectElement(dobYearElement);
        yearSelect.SelectByValue(dobYear);

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.DOB_Day_21_XPath1).Click();

        var subjectElement = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.Subjects_XPath1);
        subjectElement.SendKeys(subjects);

        wait.Until(ExpectedConditions.ElementIsVisible(ElementLocators.TC01_VerifyStudentRegistration.English_Subject_XPath1));
        subjectElement.SendKeys(Keys.Enter);

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.UploadPicture_XPath1).SendKeys(imagePath);

        if (hobbies.Contains("Sports"))
        {
            driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.HobbySports_XPath2).Click();
        }


        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.Address_XPath1).SendKeys(address);

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.State_Id).Click();

        SeleniumHelpers.ScrollIntoViewAndClick(
            driver,
            wait,
            ElementLocators.TC01_VerifyStudentRegistration.State_Selectable_XPath1(state)
        );

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.City_Id).Click();


        SeleniumHelpers.ScrollIntoViewAndClick(
                    driver,
                    wait,
                    ElementLocators.TC01_VerifyStudentRegistration.City_Selectable_XPath1(city)
        );

        driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.Submit_XPath1).Click();

        var modalName = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalName_XPath1).Text;
        var modalEmail = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalEmail_XPath1).Text;
        var modalGender = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalGender_XPath1).Text;
        var modalMobile = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalMobile_XPath1).Text;
        var modalDob = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalDob_XPath1).Text;
        var modalSubjects = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalSubjects_XPath1).Text;
        var modalHobbies = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalHobbies_XPath1).Text;
        var modalPicture = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalPicture_XPath1).Text;
        var modalAddress = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalAddress_XPath1).Text;
        var modalStateAndCity = driver.FindElement(ElementLocators.TC01_VerifyStudentRegistration.modalStateAndCity_XPath1).Text;

        Assert.Equal(firstName + " " + lastName, modalName);
        Assert.Equal(email, modalEmail);
        Assert.Equal(gender, modalGender);
        Assert.Equal(mobile, modalMobile);
        Assert.Contains(dobYear, modalDob);
        Assert.Equal(subjects, modalSubjects);
        Assert.Equal(hobbies, modalHobbies);
        Assert.Equal(imageName, modalPicture);
        Assert.Equal(address, modalAddress);
        Assert.Contains(state, modalStateAndCity);
        Assert.Contains(city, modalStateAndCity);
    }

}
