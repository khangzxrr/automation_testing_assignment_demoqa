using OpenQA.Selenium;

public class RegistrationFormPage : BasePage
{
    public RegistrationFormPage(IWebDriver driver)
        : base(driver) { }

    private readonly string url = "https://demoqa.com/automation-practice-form";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public void EnterFirstName(string firstName) =>
        Type(RegistrationFormPageLocators.FirstName_Id, firstName);

    public void EnterLastName(string lastName) =>
        Type(RegistrationFormPageLocators.LastName_Id, lastName);

    public void EnterEmail(string email) => Type(RegistrationFormPageLocators.Email_Id, email);

    public void SelectGender(string gender)
    {
        By genderLocator = gender.ToLower().Trim() switch
        {
            "Male" => RegistrationFormPageLocators.GenderMale_XPath2,
            "Female" => RegistrationFormPageLocators.GenderFemale_XPath1,
            "Other" => RegistrationFormPageLocators.GenderOther_XPath1,
            _ => throw new InvalidSelectOptionException("Invalid gender"),
        };

        Click(genderLocator);
    }

    public void EnterMobile(string mobile) =>
        Type(RegistrationFormPageLocators.Mobile_XPath2, mobile);

    public void EnterDoB(int day, int month, int year)
    {
        Click(RegistrationFormPageLocators.DOB_Id);

        SelectByValue(RegistrationFormPageLocators.DOB_Month_Select_XPath1, month.ToString());

        SelectByValue(RegistrationFormPageLocators.DOB_Year_Select_XPath1, year.ToString());

        Click(RegistrationFormPageLocators.DOB_Day_By_Value_XPath1(day));
    }

    public void EnterSubjects(string subjects) =>
        Type(RegistrationFormPageLocators.Subjects_XPath1, subjects);

    public void EnterImage(string imagePath) =>
        Type(RegistrationFormPageLocators.UploadPicture_XPath1, imagePath);

    public void SelectHobbies(string hobbies)
    {
        if (hobbies.ToLower().Contains("Sports"))
        {
            Click(RegistrationFormPageLocators.HobbySports_XPath2);
        }
    }

    public void EnterAddress(string address) =>
        Type(RegistrationFormPageLocators.Address_XPath1, address);

    public void SelectState(string state)
    {
        Click(RegistrationFormPageLocators.State_Id);

        var stateLocator = RegistrationFormPageLocators.State_Selectable_XPath1(state);
        Click(stateLocator);
    }

    public void SelectCity(string city)
    {
        Click(RegistrationFormPageLocators.City_Id);

        var ciyLocator = RegistrationFormPageLocators.City_Selectable_XPath1(city);
        Click(ciyLocator);
    }

    public void ClickSubmit() => Click(RegistrationFormPageLocators.Submit_XPath1);
}
