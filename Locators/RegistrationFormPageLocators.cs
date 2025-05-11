using OpenQA.Selenium;

public static class RegistrationFormPageLocators
{
    // Element: First Name input
    // ID: Preferred for stability
    public static By FirstName_Id = By.Id("firstName");

    // CSS Selectors
    public static By FirstName_CSS1 = By.CssSelector("input#firstName");
    public static By FirstName_CSS2 = By.CssSelector("input[placeholder='First Name']");

    // XPath Expressions
    public static By FirstName_XPath1 = By.XPath("//input[@id='firstName']");
    public static By FirstName_XPath2 = By.XPath("//input[@placeholder='First Name']");

    // Element: Last Name input
    public static By LastName_Id = By.Id("lastName");
    public static By LastName_CSS1 = By.CssSelector("input#lastName");
    public static By LastName_CSS2 = By.CssSelector("input[placeholder='Last Name']");
    public static By LastName_XPath1 = By.XPath("//input[@id='lastName']");
    public static By LastName_XPath2 = By.XPath("//input[@placeholder='Last Name']");

    // Element: Email input
    public static By Email_Id = By.Id("userEmail");
    public static By Email_CSS1 = By.CssSelector("input#userEmail");
    public static By Email_CSS2 = By.CssSelector("input[placeholder='name@example.com']");
    public static By Email_XPath1 = By.XPath("//input[@id='userEmail']");
    public static By Email_XPath2 = By.XPath("//input[@placeholder='name@example.com']");

    // Element: Gender radio buttons
    // Note: Gender options have unique IDs
    public static By GenderMale_Id = By.Id("gender-radio-1");
    public static By GenderFemale_Id = By.Id("gender-radio-2");
    public static By GenderOther_Id = By.Id("gender-radio-3");

    public static By GenderMale_CSS1 = By.CssSelector("input#gender-radio-1");
    public static By GenderMale_CSS2 = By.CssSelector("label[for='gender-radio-1']");

    public static By GenderMale_XPath1 = By.XPath("//input[@id='gender-radio-1']");
    public static By GenderMale_XPath2 = By.XPath("//label[@for='gender-radio-1']");

    public static By GenderFemale_XPath1 = By.XPath("//label[@for='gender-radio-2']");

    public static By GenderOther_XPath1 = By.XPath("//label[@for='gender-radio-3']");

    // Element: Mobile Number input
    public static By Mobile_Id = By.Id("userNumber");
    public static By Mobile_CSS1 = By.CssSelector("input#userNumber");
    public static By Mobile_CSS2 = By.CssSelector("input[placeholder='Mobile Number']");
    public static By Mobile_XPath1 = By.XPath("//input[@id='userNumber']");
    public static By Mobile_XPath2 = By.XPath("//input[@placeholder='Mobile Number']");

    // Element: Date of Birth input
    public static By DOB_Id = By.Id("dateOfBirthInput");
    public static By DOB_CSS1 = By.CssSelector("input#dateOfBirthInput");
    public static By DOB_CSS2 = By.CssSelector("div.react-datepicker__input-container > input");
    public static By DOB_XPath1 = By.XPath("//input[@id='dateOfBirthInput']");
    public static By DOB_XPath2 = By.XPath(
        "//div[@class='react-datepicker__input-container']//input"
    );

    // Element: DoB Month select
    public static By DOB_Month_Select_XPath1 = By.XPath(
        "//div[@id='dateOfBirth']//select[@class='react-datepicker__month-select']"
    );

    // Element: DoB Year select
    public static By DOB_Year_Select_XPath1 = By.XPath(
        "//div[@id='dateOfBirth']//select[@class='react-datepicker__year-select']"
    );

    // Element: DoB Day select
    public static By DOB_Day_By_Value_XPath1(int day) =>
        By.XPath(
            $"//div[@id='dateOfBirth']//div[@class='react-datepicker__day react-datepicker__day--{day:000}']"
        );

    // Element: Subjects input
    public static By Subjects_Id = By.Id("subjectsInput");
    public static By Subjects_CSS1 = By.CssSelector("input#subjectsInput");
    public static By Subjects_CSS2 = By.CssSelector(".subjects-auto-complete__indicator-separator");
    public static By Subjects_XPath1 = By.XPath("//input[@id='subjectsInput']");
    public static By Subjects_XPath2 = By.XPath(
        "//div[contains(@class,'subjects-auto-complete')]//input"
    );

    // Element: English subject dropdown element
    public static By English_Subject_XPath1 = By.XPath(
        "//div[@id='subjectsContainer']//div[contains(@id, 'react-select-2') and text() = 'English']"
    );

    // Element: Hobbies checkboxes
    public static By HobbySports_Id = By.Id("hobbies-checkbox-1");
    public static By HobbyReading_Id = By.Id("hobbies-checkbox-2");
    public static By HobbyMusic_Id = By.Id("hobbies-checkbox-3");

    public static By HobbySports_CSS1 = By.CssSelector("input#hobbies-checkbox-1");
    public static By HobbySports_CSS2 = By.CssSelector("label[for='hobbies-checkbox-1']");

    public static By HobbySports_XPath1 = By.XPath("//input[@id='hobbies-checkbox-1']");
    public static By HobbySports_XPath2 = By.XPath("//label[@for='hobbies-checkbox-1']");

    // Element: Picture upload
    public static By UploadPicture_Id = By.Id("uploadPicture");
    public static By UploadPicture_CSS1 = By.CssSelector("input#uploadPicture");
    public static By UploadPicture_CSS2 = By.CssSelector("input[type='file']");
    public static By UploadPicture_XPath1 = By.XPath("//input[@id='uploadPicture']");
    public static By UploadPicture_XPath2 = By.XPath("//input[@type='file']");

    // Element: Current Address textarea
    public static By Address_Id = By.Id("currentAddress");
    public static By Address_CSS1 = By.CssSelector("textarea#currentAddress");
    public static By Address_CSS2 = By.CssSelector("textarea[placeholder='Current Address']");
    public static By Address_XPath1 = By.XPath("//textarea[@id='currentAddress']");
    public static By Address_XPath2 = By.XPath("//textarea[@placeholder='Current Address']");

    // Element: State dropdown
    public static By State_Id = By.Id("state");
    public static By State_CSS1 = By.CssSelector("input#react-select-3-input");
    public static By State_CSS2 = By.CssSelector("div#state input");
    public static By State_XPath1 = By.XPath("//input[@id='react-select-3-input']");
    public static By State_XPath2 = By.XPath("//div[@id='state']//input");

    // Element: State NCR dropdown item
    public static By State_Selectable_XPath1(string state) =>
        By.XPath(
            $"//div[@id='state']//div[text() = '{state}' and contains(@id, 'react-select-3')]"
        );

    // Element: City dropdown
    public static By City_Id = By.Id("city");
    public static By City_CSS1 = By.CssSelector("input#react-select-4-input");
    public static By City_CSS2 = By.CssSelector("div#city input");
    public static By City_XPath1 = By.XPath("//input[@id='react-select-4-input']");
    public static By City_XPath2 = By.XPath("//div[@id='city']//input");

    // Element City [take parameter] dropdown item
    public static By City_Selectable_XPath1(string city) =>
        By.XPath($"//div[@id='city']//div[text() = '{city}' and contains(@id, 'react-select-4')]");

    // Element: Submit button
    public static By Submit_Id = By.Id("submit");
    public static By Submit_CSS1 = By.CssSelector("button#submit");
    public static By Submit_CSS2 = By.CssSelector("button.btn-primary");
    public static By Submit_XPath1 = By.XPath("//button[@id='submit']");
    public static By Submit_XPath2 = By.XPath("//button[text()='Submit']");

    // Element modal student name value
    public static By modalName_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Name']/following-sibling::td"
    );

    // Element modal student email value
    public static By modalEmail_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Email']/following-sibling::td"
    );

    // Element modal student gender value
    public static By modalGender_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Gender']/following-sibling::td"
    );

    // Element modal mobile value
    public static By modalMobile_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Mobile']/following-sibling::td"
    );

    // Element modal dob value
    public static By modalDob_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Date of Birth']/following-sibling::td"
    );

    // Element modal subjects value
    public static By modalSubjects_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Subjects']/following-sibling::td"
    );

    // Element modal hobbies value
    public static By modalHobbies_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Hobbies']/following-sibling::td"
    );

    // Element modal Picture value
    public static By modalPicture_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Picture']/following-sibling::td"
    );

    // Element modal Address value
    public static By modalAddress_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Address']/following-sibling::td"
    );

    // Element modal State and City value
    public static By modalStateAndCity_XPath1 = By.XPath(
        "//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'State and City']/following-sibling::td"
    );
}
