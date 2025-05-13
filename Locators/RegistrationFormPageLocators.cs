using OpenQA.Selenium;

public static class RegistrationFormPageLocators
{
    public static By FirstName_Id = By.Id("firstName");

    public static By LastName_Id = By.Id("lastName");

    public static By Email_Id = By.Id("userEmail");

    public static By GenderMale_XPath2 = By.XPath("//label[@for='gender-radio-1']");

    public static By GenderFemale_XPath1 = By.XPath("//label[@for='gender-radio-2']");

    public static By GenderOther_XPath1 = By.XPath("//label[@for='gender-radio-3']");

    public static By Mobile_XPath2 = By.XPath("//input[@placeholder='Mobile Number']");

    public static By DOB_Id = By.Id("dateOfBirthInput");

    public static By DOB_Month_Select_XPath1 = By.XPath(
        "//div[@id='dateOfBirth']//select[@class='react-datepicker__month-select']"
    );

    public static By DOB_Year_Select_XPath1 = By.XPath(
        "//div[@id='dateOfBirth']//select[@class='react-datepicker__year-select']"
    );

    public static By DOB_Day_By_Value_XPath1(int day) =>
        By.XPath(
            $"//div[@id='dateOfBirth']//div[@class='react-datepicker__day react-datepicker__day--{day:000}']"
        );

    // Element: Subjects input
    public static By Subjects_XPath1 = By.XPath("//input[@id='subjectsInput']");

    // Element: English subject dropdown element
    public static By Subject_DropDown_Item_XPath1(string subject) => By.XPath(
        $"//div[@id='subjectsContainer']//div[contains(@id, 'react-select-2') and text() = '{subject}']"
    );

    public static By HobbySports_XPath1 = By.XPath("//label[@for='hobbies-checkbox-1']");
    public static By HobbyReading_XPath1 = By.XPath("//label[@for='hobbies-checkbox-2']");
    public static By HobbyMusic_XPath1 = By.XPath("//label[@for='hobbies-checkbox-3']");

    public static By UploadPicture_XPath1 = By.XPath("//input[@id='uploadPicture']");

    public static By Address_XPath1 = By.XPath("//textarea[@id='currentAddress']");

    public static By State_Id = By.Id("state");

    public static By State_Selectable_XPath1(string state) =>
        By.XPath(
            $"//div[@id='state']//div[text() = '{state}' and contains(@id, 'react-select-3')]"
        );

    public static By City_Id = By.Id("city");

    public static By City_Selectable_XPath1(string city) =>
        By.XPath($"//div[@id='city']//div[text() = '{city}' and contains(@id, 'react-select-4')]");

    public static By Submit_XPath1 = By.XPath("//button[@id='submit']");

    public static By modalName_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Name']/following-sibling::td"
    );

    public static By modalEmail_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Email']/following-sibling::td"
    );

    public static By modalGender_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Gender']/following-sibling::td"
    );

    public static By modalMobile_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Mobile']/following-sibling::td"
    );

    // Element modal dob value
    public static By modalDob_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Date of Birth']/following-sibling::td"
    );

    public static By modalSubjects_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Subjects']/following-sibling::td"
    );

    public static By modalHobbies_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Hobbies']/following-sibling::td"
    );

    public static By modalPicture_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Picture']/following-sibling::td"
    );

    public static By modalAddress_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Address']/following-sibling::td"
    );

    public static By modalStateAndCity_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'State and City']/following-sibling::td"
    );
}
