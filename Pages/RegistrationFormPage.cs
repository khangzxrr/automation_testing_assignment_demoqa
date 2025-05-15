using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class RegistrationFormPage : BasePage
{
    public RegistrationFormPage(IWebDriver driver)
        : base(driver) { }

    private readonly string url = "https://demoqa.com/automation-practice-form";

    public WebElement modalName => Find(RegistrationFormPageLocators.modalName_XPath1);

    public WebElement modalEmail => Find(RegistrationFormPageLocators.modalEmail_XPath1);

    public WebElement modalGender => Find(RegistrationFormPageLocators.modalGender_XPath1);

    public WebElement modalMobile => Find(RegistrationFormPageLocators.modalMobile_XPath1);

    public WebElement modalDob => Find(RegistrationFormPageLocators.modalDob_XPath1);

    public WebElement modalSubjects => Find(RegistrationFormPageLocators.modalSubjects_XPath1);

    public WebElement modalHobbies => Find(RegistrationFormPageLocators.modalHobbies_XPath1);

    public WebElement modalImage => Find(RegistrationFormPageLocators.modalPicture_XPath1);

    public WebElement modalAddress => Find(RegistrationFormPageLocators.modalAddress_XPath1);

    public WebElement modalStateAndCity => Find(RegistrationFormPageLocators.modalStateAndCity_XPath1);

    public WebElement FirstName => Find(RegistrationFormPageLocators.FirstName_Id);

    public WebElement LastName => Find(RegistrationFormPageLocators.LastName_Id);

    public WebElement Email => Find(RegistrationFormPageLocators.Email_Id);

    public WebElement GenderMale => Find(RegistrationFormPageLocators.GenderMale_XPath2);
    public WebElement GenderFeMale => Find(RegistrationFormPageLocators.GenderFemale_XPath1);
    public WebElement GenderOther => Find(RegistrationFormPageLocators.GenderOther_XPath1);

    public WebElement Mobile => Find(RegistrationFormPageLocators.Mobile_XPath2);

    public WebElement DobInput => Find(RegistrationFormPageLocators.DOB_Id);
    public WebElement DobMonthSelect => Find(RegistrationFormPageLocators.DOB_Month_Select_XPath1);
    public WebElement DobYearSelect => Find(RegistrationFormPageLocators.DOB_Year_Select_XPath1);
    public WebElement DobDaySelect(int day) => Find(RegistrationFormPageLocators.DOB_Day_By_Value_XPath1(day));

    public WebElement SubjectInput => Find(RegistrationFormPageLocators.Subjects_XPath1);
    public WebElement SubjectDropdownItem(string subject) => Find(RegistrationFormPageLocators.Subject_DropDown_Item_XPath1(subject));

    public WebElement Image => Find(RegistrationFormPageLocators.UploadPicture_XPath1);

    public WebElement SportHobby => Find(RegistrationFormPageLocators.HobbySports_XPath1);
    public WebElement ReadingHobby => Find(RegistrationFormPageLocators.HobbyReading_XPath1);
    public WebElement MusicHobby => Find(RegistrationFormPageLocators.HobbyMusic_XPath1);

    public WebElement Address => Find(RegistrationFormPageLocators.Address_XPath1);

    public WebElement StateInput => Find(RegistrationFormPageLocators.State_Id);
    public WebElement StateDropDownItem(string state) => Find(RegistrationFormPageLocators.State_Selectable_XPath1(state));

    public WebElement CityInput => Find(RegistrationFormPageLocators.City_Id);
    public WebElement CityDropDownItem(string city) => Find(RegistrationFormPageLocators.City_Selectable_XPath1(city));

    public WebElement Submit => Find(RegistrationFormPageLocators.Submit_XPath1);

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public string GetModalFullname() => modalName.Text;

    public string GetModalEmail() => modalEmail.Text;

    public string GetModalGender() => modalGender.Text;

    public string GetModalMobile() => modalMobile.Text;

    public string GetDoB() => modalDob.Text;

    public string GetModalImage() => modalImage.Text;

    public string GetModalSubjects() => modalSubjects.Text;

    public string GetModalHobbies() => modalHobbies.Text;

    public string GetModalStateAndCity() => modalStateAndCity.Text;

    public void EnterFirstName(string firstName) => FirstName.Type(firstName);

    public void EnterLastName(string lastName) => LastName.Type(lastName);

    public void EnterEmail(string email) => Email.Type(email);

    public void SelectGender(string gender)
    {
        switch (gender)
        {
            case "Male":
                GenderMale.Click();
                break;
            case "Female":
                GenderFeMale.Click();
                break;
            case "Other":
                GenderOther.Click();
                break;
            default:
                throw new InvalidSelectOptionException("Invalid gender");
        }
    }

    public void EnterMobile(string mobile) => Mobile.Type(mobile);

    public void EnterDoB(int day, int month, int year)
    {
        DobInput.Click();

        DobMonthSelect.SelectByValue(month.ToString());

        DobYearSelect.SelectByValue(year.ToString());

        DobDaySelect(day).Click();
    }

    public void EnterSubjects(string subjects)
    {
        foreach (var subject in subjects.Split(' '))
        {
            EnterSingleSubject(subject.Trim());
        }
    }

    public void EnterSingleSubject(string subject)
    {
        SubjectInput.Type(subject);
        SubjectDropdownItem(subject).Click();
    }

    public void EnterImage(string imagePath) => Image.Type(imagePath);

    public void SelectHobbies(string hobbies)
    {
        if (hobbies.ToLower().Contains("sports"))
        {
            SportHobby.Click();
        }

        if (hobbies.ToLower().Contains("reading"))
        {
            ReadingHobby.Click();
        }

        if (hobbies.ToLower().Contains("music"))
        {
            MusicHobby.Click();
        }
    }

    public void EnterAddress(string address)
    {
        Address.Type(address);
    }

    public void SelectState(string state)
    {
        StateInput.Click();

        StateDropDownItem(state).Click();
    }

    public void SelectCity(string city)
    {
        CityInput.Click();

        CityDropDownItem(city).Click();
    }

    public void ClickSubmit() => Submit.Click();

    public void WaitForModalPopup() => wait.Until(ExpectedConditions.ElementIsVisible(RegistrationFormPageLocators.modalTitle_Id));

}
