using OpenQA.Selenium;

public class ElementLocators
{
    public class TC01_VerifyStudentRegistration
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
        public static By DOB_XPath2 = By.XPath("//div[@class='react-datepicker__input-container']//input");

        // Element: DoB Month select
        public static By DOB_Month_Select_XPath1 = By.XPath("//div[@id='dateOfBirth']//select[@class='react-datepicker__month-select']");

        // Element: DoB Year select
        public static By DOB_Year_Select_XPath1 = By.XPath("//div[@id='dateOfBirth']//select[@class='react-datepicker__year-select']");

        // Element: DoB Day 21 select
        public static By DOB_Day_21_XPath1 = By.XPath("//div[@id='dateOfBirth']//div[@class='react-datepicker__day react-datepicker__day--021']");



        // Element: Subjects input
        public static By Subjects_Id = By.Id("subjectsInput");
        public static By Subjects_CSS1 = By.CssSelector("input#subjectsInput");
        public static By Subjects_CSS2 = By.CssSelector(".subjects-auto-complete__indicator-separator");
        public static By Subjects_XPath1 = By.XPath("//input[@id='subjectsInput']");
        public static By Subjects_XPath2 = By.XPath("//div[contains(@class,'subjects-auto-complete')]//input");

        // Element: English subject dropdown element
        public static By English_Subject_XPath1 = By.XPath("//div[@id='subjectsContainer']//div[contains(@id, 'react-select-2') and text() = 'English']");

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
        public static By State_Selectable_XPath1(string state) => By.XPath($"//div[@id='state']//div[text() = '{state}' and contains(@id, 'react-select-3')]");

        // Element: City dropdown
        public static By City_Id = By.Id("city");
        public static By City_CSS1 = By.CssSelector("input#react-select-4-input");
        public static By City_CSS2 = By.CssSelector("div#city input");
        public static By City_XPath1 = By.XPath("//input[@id='react-select-4-input']");
        public static By City_XPath2 = By.XPath("//div[@id='city']//input");

        // Element City [take parameter] dropdown item
        public static By City_Selectable_XPath1(string city) => By.XPath($"//div[@id='city']//div[text() = '{city}' and contains(@id, 'react-select-4')]");

        // Element: Submit button
        public static By Submit_Id = By.Id("submit");
        public static By Submit_CSS1 = By.CssSelector("button#submit");
        public static By Submit_CSS2 = By.CssSelector("button.btn-primary");
        public static By Submit_XPath1 = By.XPath("//button[@id='submit']");
        public static By Submit_XPath2 = By.XPath("//button[text()='Submit']");

        // Element modal student name value
        public static By modalName_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Name']/following-sibling::td");

        // Element modal student email value
        public static By modalEmail_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Student Email']/following-sibling::td");

        // Element modal student gender value
        public static By modalGender_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Gender']/following-sibling::td");

        // Element modal mobile value
        public static By modalMobile_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Mobile']/following-sibling::td");

        // Element modal dob value
        public static By modalDob_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Date of Birth']/following-sibling::td");

        // Element modal subjects value
        public static By modalSubjects_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Subjects']/following-sibling::td");

        // Element modal hobbies value
        public static By modalHobbies_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Hobbies']/following-sibling::td");

        // Element modal Picture value
        public static By modalPicture_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Picture']/following-sibling::td");

        // Element modal Address value
        public static By modalAddress_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'Address']/following-sibling::td");

        // Element modal State and City value
        public static By modalStateAndCity_XPath1 = By.XPath("//table[.//tr[th[1][normalize-space(.)='Label'] and th[2][normalize-space(.)='Values']]]//td[text() = 'State and City']/following-sibling::td");
    }

    public class TC02_VerifyValidationMessages : TC01_VerifyStudentRegistration
    {
    }

    public class TC03_VerifyEmailValidation
    {
        // Email field
        public static By Email_Id = By.Id("userEmail");
        public static By Email_CSS1 = By.CssSelector("input#userEmail");
        public static By Email_CSS2 = By.CssSelector("input[placeholder='name@example.com']");
        public static By Email_XPath1 = By.XPath("//input[@id='userEmail']");
        public static By Email_XPath2 = By.XPath("//input[contains(@placeholder,'@example.com')]");

        // Submit Button
        public static By Submit_Id = By.Id("submit");
        public static By Submit_CSS1 = By.CssSelector("button#submit");
        public static By Submit_CSS2 = By.CssSelector("button.btn.btn-primary");
        public static By Submit_XPath1 = By.XPath("//button[@id='submit']");
        public static By Submit_XPath2 = By.XPath("//button[text()='Submit']");

        // Email error (validation)
        public static By EmailError_CSS1 = By.CssSelector("input:invalid#userEmail");
        public static By EmailError_CSS2 = By.CssSelector("input#userEmail:invalid");
        public static By EmailError_XPath1 = By.XPath("//input[@id='userEmail' and @type='email' and not(@value)]");
        public static By EmailError_XPath2 = By.XPath("//input[contains(@class, 'form-control') and @type='email' and not(@value)]");
    }

    public class TC04_VerifyDynamicButtonStates
    {

        // Element: Enable After Button
        // ID: Preferred for stability
        public static By EnableAfter_Id = By.Id("enableAfter");

        // CSS Selectors
        public static By EnableAfter_CSS1 = By.CssSelector("#enableAfter");
        public static By EnableAfter_CSS2 = By.CssSelector("button#enableAfter");

        // XPath Expressions
        public static By EnableAfter_XPath1 = By.XPath("//button[@id='enableAfter']");
        public static By EnableAfter_XPath2 = By.XPath("//button[text()='Will enable 5 seconds']");

        // Element: Color Change Button
        public static By ColorChange_Id = By.Id("colorChange");

        public static By ColorChange_CSS1 = By.CssSelector("#colorChange");
        public static By ColorChange_CSS2 = By.CssSelector("button#colorChange");

        public static By ColorChange_XPath1 = By.XPath("//button[@id='colorChange']");
        public static By ColorChange_XPath2 = By.XPath("//button[text()='Color Change']");

        // Element: Visible After Button
        public static By VisibleAfter_Id = By.Id("visibleAfter");

        public static By VisibleAfter_CSS1 = By.CssSelector("#visibleAfter");
        public static By VisibleAfter_CSS2 = By.CssSelector("button#visibleAfter");

        public static By VisibleAfter_XPath1 = By.XPath("//button[@id='visibleAfter']");
        public static By VisibleAfter_XPath2 = By.XPath("//button[text()='Visible After 5 Seconds']");

        // Comments:
        // - These elements are dynamic and change state after a delay.
        // - Use explicit waits (WebDriverWait) to handle synchronization.
        // - ID selectors are preferred for their uniqueness and stability.
        // - CSS and XPath selectors provide alternative strategies.
    }

    public class TC05_VerifyDragAndDropScenarios
    {
        // Tab: Simple
        public static By SimpleTab_Id = By.Id("droppableExample-tab-simple");
        public static By SimpleTab_CSS1 = By.CssSelector("#droppableExample-tab-simple");
        public static By SimpleTab_CSS2 = By.CssSelector("a#droppableExample-tab-simple");
        public static By SimpleTab_XPath1 = By.XPath("//a[@id='droppableExample-tab-simple']");
        public static By SimpleTab_XPath2 = By.XPath("//a[text()='Simple']");

        // Tab: Accept
        public static By AcceptTab_Id = By.Id("droppableExample-tab-accept");
        public static By Acceptable_Id = By.Id("acceptable");
        public static By NotAcceptable_Id = By.Id("notAcceptable");
        public static By Accept_Droppable_CSS1 = By.CssSelector("#acceptDropContainer #droppable");

        // Tab: Prevent Propogation
        public static By PreventPropogation_Id = By.Id("droppableExample-tab-preventPropogation");
        public static By PreventPropogation_DragBox_Id = By.Id("dragBox");
        public static By PreventPropogation_NotGreedyDroppableBox_Id = By.Id("notGreedyDropBox");
        public static By PreventPropogation_NotGreedyInnerDroppableBox_Id = By.Id("notGreedyInnerDropBox");

        public static By PreventPropogation_GreedyDroppableBox_Id = By.Id("greedyDropBox");
        public static By PreventPropogation_GreedyInnerDroppableBox_Id = By.Id("greedyDropBoxInner");

        // Tab: Revert draggable 
        public static By RevertTab_Id = By.Id("droppableExample-tab-revertable");
        public static By Revert_RevertableDragBox_Id = By.Id("revertable");
        public static By Revert_NotRevertableDragBox_Id = By.Id("notRevertable");
        public static By Revert_DroppableBox_CSS1 = By.CssSelector("#revertableDropContainer #droppable");

        // Draggable element in Simple tab
        public static By Simple_Draggable_Id = By.Id("draggable");
        public static By Simple_Draggable_CSS1 = By.CssSelector("#draggable");
        public static By Simple_Draggable_CSS2 = By.CssSelector("div#draggable");
        public static By Simple_Draggable_XPath1 = By.XPath("//div[@id='draggable']");
        public static By Simple_Draggable_XPath2 = By.XPath("//div[contains(@class,'draggable') and @id='draggable']");

        // Droppable element in Simple tab
        public static By Simple_Droppable_Id = By.Id("droppable");
        public static By Simple_Droppable_CSS1 = By.CssSelector("#droppable");
        public static By Simple_Droppable_CSS2 = By.CssSelector("div#droppable");
        public static By Simple_Droppable_XPath1 = By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']");
        public static By Simple_Droppable_XPath2 = By.XPath("//div[@id='simpleDropContainer']//div[contains(@class, 'drop-box ui-droppable')]");

        // Droppable text (for assertion)
        public static By Droppable_Text_CSS1 = By.CssSelector("#droppable p");
        public static By Droppable_Text_CSS2 = By.CssSelector("div#droppable > p");
        public static By Droppable_Text_XPath1 = By.XPath("//div[@id='droppable']/p");
        public static By Droppable_Text_XPath2 = By.XPath("//p[contains(text(),'Drop here') or contains(text(),'Dropped')]");
    }

    public class TC06_VerifyWebTableCRUD
    {

        // Button: Add New Record
        public static By AddButton_Id = By.Id("addNewRecordButton");
        public static By AddButton_CSS1 = By.CssSelector("#addNewRecordButton");
        public static By AddButton_CSS2 = By.CssSelector("button#addNewRecordButton");
        public static By AddButton_XPath1 = By.XPath("//button[@id='addNewRecordButton']");
        public static By AddButton_XPath2 = By.XPath("//button[text()='Add']");

        // Modal: Registration Form Fields
        public static By FirstName_Id = By.Id("firstName");
        public static By FirstName_CSS1 = By.CssSelector("#firstName");
        public static By FirstName_CSS2 = By.CssSelector("input[id='firstName']");
        public static By FirstName_XPath1 = By.XPath("//input[@id='firstName']");
        public static By FirstName_XPath2 = By.XPath("//input[@placeholder='First Name']");

        public static By LastName_Id = By.Id("lastName");
        public static By LastName_CSS1 = By.CssSelector("#lastName");
        public static By LastName_CSS2 = By.CssSelector("input[id='lastName']");
        public static By LastName_XPath1 = By.XPath("//input[@id='lastName']");
        public static By LastName_XPath2 = By.XPath("//input[@placeholder='Last Name']");

        public static By Email_Id = By.Id("userEmail");
        public static By Email_CSS1 = By.CssSelector("#userEmail");
        public static By Email_CSS2 = By.CssSelector("input[id='userEmail']");
        public static By Email_XPath1 = By.XPath("//input[@id='userEmail']");
        public static By Email_XPath2 = By.XPath("//div[@id='userEmail-wrapper']//input");

        public static By Age_Id = By.Id("age");
        public static By Age_CSS1 = By.CssSelector("#age");
        public static By Age_CSS2 = By.CssSelector("input[id='age']");
        public static By Age_XPath1 = By.XPath("//input[@id='age']");
        public static By Age_XPath2 = By.XPath("//div[@id='age-wrapper']//input");

        public static By Salary_Id = By.Id("salary");
        public static By Salary_CSS1 = By.CssSelector("#salary");
        public static By Salary_CSS2 = By.CssSelector("input[id='salary']");
        public static By Salary_XPath1 = By.XPath("//input[@id='salary']");
        public static By Salary_XPath2 = By.XPath("//div[@id='salary-wrapper']//input");

        public static By Department_Id = By.Id("department");
        public static By Department_CSS1 = By.CssSelector("#department");
        public static By Department_CSS2 = By.CssSelector("input[id='department']");
        public static By Department_XPath1 = By.XPath("//input[@id='department']");
        public static By Department_XPath2 = By.XPath("//div[@id='salary-wrapper']//input");

        // Button: Submit (in modal)
        public static By SubmitButton_Id = By.Id("submit");
        public static By SubmitButton_CSS1 = By.CssSelector("#submit");
        public static By SubmitButton_CSS2 = By.CssSelector("button#submit");
        public static By SubmitButton_XPath1 = By.XPath("//button[@id='submit']");
        public static By SubmitButton_XPath2 = By.XPath("//button[text()='Submit']");

        // Table: Rows
        public static By TableRows_CSS1 = By.CssSelector("div.rt-tbody div.rt-tr-group");
        public static By TableRows_CSS2 = By.CssSelector("div.rt-tr-group");
        public static By TableRows_XPath1 = By.XPath("//div[@class='rt-tbody']/div[contains(@class,'rt-tr-group')]");
        public static By TableRows_XPath2 = By.XPath("//div[contains(@class,'rt-tr-group')]");

        // Table: Body
        public static By TableBody_XPath1 = By.XPath("//div[@class='rt-tbody']");

        // Table: Pagination
        public static By TablePagination_CSS1 = By.CssSelector("select[aria-label='rows per page']");

        // Table: Cells (within a row)
        public static By TableCells_CSS1 = By.CssSelector("div.rt-td");
        public static By TableCells_CSS2 = By.CssSelector("div.rt-tr-group div.rt-td");
        public static By TableCells_XPath1 = By.XPath("//div[contains(@class,'rt-tr-group')]//div[contains(@class,'rt-td')]");
        public static By TableCells_XPath2 = By.XPath("//div[@class='rt-td']");

        // Actions: Edit and Delete Buttons (within a row)
        public static By EditButton_CSS1 = By.CssSelector("span[title='Edit']");
        public static By EditButton_CSS2 = By.CssSelector("div.action-buttons span[title='Edit']");
        public static By EditButton_XPath1 = By.XPath("//span[@title='Edit']");
        public static By EditButton_XPath2 = By.XPath("//div[@class='action-buttons']/span[@title='Edit']");

        public static By DeleteButton_CSS1 = By.CssSelector("span[title='Delete']");
        public static By DeleteButton_CSS2 = By.CssSelector("div.action-buttons span[title='Delete']");
        public static By DeleteButton_XPath1 = By.XPath("//span[@title='Delete']");
        public static By DeleteButton_XPath2 = By.XPath("//div[@class='action-buttons']/span[@title='Delete']");

        // Search Box
        public static By SearchBox_Id = By.Id("searchBox");
        public static By SearchBox_CSS1 = By.CssSelector("#searchBox");
        public static By SearchBox_CSS2 = By.CssSelector("input[id='searchBox']");
        public static By SearchBox_XPath1 = By.XPath("//input[@id='searchBox']");
        public static By SearchBox_XPath2 = By.XPath("//input[@placeholder='Type to search']");


        // table header
        public static By FirstNameHeader_XPath1 = By.XPath("//div[text() = 'First Name' and @class = 'rt-resizable-header-content']");

        // table first cell of rows 
        public static By FirstCell_XPath1 = By.XPath("//div[@role='rowgroup']//div[@role='gridcell'][1]");
    }

    public class TC07_VerifyAlertHandling
    {


        // Simple Alert Button
        public static By SimpleAlert_Id = By.Id("alertButton");
        public static By SimpleAlert_CSS1 = By.CssSelector("#alertButton");
        public static By SimpleAlert_CSS2 = By.CssSelector("button#alertButton");
        public static By SimpleAlert_XPath1 = By.XPath("//button[@id='alertButton']");
        public static By SimpleAlert_XPath2 = By.XPath("//button[text()='Click me']");

        // Timed Alert Button
        public static By TimedAlert_Id = By.Id("timerAlertButton");
        public static By TimedAlert_CSS1 = By.CssSelector("#timerAlertButton");
        public static By TimedAlert_CSS2 = By.CssSelector("button#timerAlertButton");
        public static By TimedAlert_XPath1 = By.XPath("//button[@id='timerAlertButton']");
        public static By TimedAlert_XPath2 = By.XPath("//button[text()='Click me']");

        // Confirmation Alert Button
        public static By ConfirmButton_Id = By.Id("confirmButton");
        public static By ConfirmButton_CSS1 = By.CssSelector("#confirmButton");
        public static By ConfirmButton_CSS2 = By.CssSelector("button#confirmButton");
        public static By ConfirmButton_XPath1 = By.XPath("//button[@id='confirmButton']");
        public static By ConfirmButton_XPath2 = By.XPath("//button[text()='Click me']");

        // Prompt Alert Button
        public static By PromptButton_Id = By.Id("promtButton");
        public static By PromptButton_CSS1 = By.CssSelector("#promtButton");
        public static By PromptButton_CSS2 = By.CssSelector("button#promtButton");
        public static By PromptButton_XPath1 = By.XPath("//button[@id='promtButton']");
        public static By PromptButton_XPath2 = By.XPath("//button[text()='Click me']");

        // Result Texts
        public static By ConfirmResult_Id = By.Id("confirmResult");
        public static By ConfirmResult_CSS1 = By.CssSelector("#confirmResult");
        public static By ConfirmResult_CSS2 = By.CssSelector("span#confirmResult");
        public static By ConfirmResult_XPath1 = By.XPath("//span[@id='confirmResult']");
        public static By ConfirmResult_XPath2 = By.XPath("//span[contains(text(),'You selected')]");

        public static By PromptResult_Id = By.Id("promptResult");
        public static By PromptResult_CSS1 = By.CssSelector("#promptResult");
        public static By PromptResult_CSS2 = By.CssSelector("span#promptResult");
        public static By PromptResult_XPath1 = By.XPath("//span[@id='promptResult']");
        public static By PromptResult_XPath2 = By.XPath("//span[contains(text(),'You entered')]");

        // Comments:
        // - Each alert type has a corresponding button identified by unique IDs.
        // - Result texts display the outcome of interactions with confirmation and prompt alerts.
        // - Multiple selectors (ID, CSS, XPath) are provided for flexibility in locating elements.
    }

    public class TC08_VerifyFrameNavigation
    {

        // Frame 1
        public static By Frame1_Id = By.Id("frame1");
        public static By Frame1_CSS1 = By.CssSelector("#frame1");
        public static By Frame1_CSS2 = By.CssSelector("iframe#frame1");
        public static By Frame1_XPath1 = By.XPath("//iframe[@id='frame1']");
        public static By Frame1_XPath2 = By.XPath("//iframe[contains(@src, 'sample') and @id='frame1']");

        // Frame 2
        public static By Frame2_Id = By.Id("frame2");
        public static By Frame2_CSS1 = By.CssSelector("#frame2");
        public static By Frame2_CSS2 = By.CssSelector("iframe#frame2");
        public static By Frame2_XPath1 = By.XPath("//iframe[@id='frame2']");
        public static By Frame2_XPath2 = By.XPath("//iframe[contains(@src, 'sample') and @id='frame2']");

        // Content inside frames: Heading
        public static By FrameHeading_Id = By.Id("sampleHeading");
        public static By FrameHeading_CSS1 = By.CssSelector("#sampleHeading");
        public static By FrameHeading_CSS2 = By.CssSelector("h1#sampleHeading");
        public static By FrameHeading_XPath1 = By.XPath("//h1[@id='sampleHeading']");
        public static By FrameHeading_XPath2 = By.XPath("//body/h1[@id='sampleHeading']");

        // Comments:
        // - Each frame is identified by a unique ID.
        // - The heading inside each frame also has a unique ID.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }


    public class TC09_VerifyBookStoreSearchAndCollection
    {

        // Search Box
        public static By SearchBox_Id = By.Id("searchBox");
        public static By SearchBox_CSS1 = By.CssSelector("#searchBox");
        public static By SearchBox_CSS2 = By.CssSelector("input#searchBox");
        public static By SearchBox_XPath1 = By.XPath("//input[@id='searchBox']");
        public static By SearchBox_XPath2 = By.XPath("//input[@placeholder='Type to search']");

        // Book Titles in the Table
        public static By BookTitles_CSS1 = By.CssSelector(".rt-tbody .rt-tr-group .rt-td:nth-child(2) a");
        public static By BookTitles_CSS2 = By.CssSelector("div.rt-tbody div.rt-tr-group div.rt-td:nth-child(2) a");
        public static By BookTitles_XPath1 = By.XPath("//div[@class='rt-tbody']//div[@class='rt-tr-group']//a");
        public static By BookTitles_XPath2 = By.XPath("//a[contains(@href, 'books?book=')]");

        // Book Details Page - Add to Your Collection Button
        public static By AddToCollectionButton_Id = By.Id("addNewRecordButton");
        public static By AddToCollectionButton_CSS1 = By.CssSelector("#addNewRecordButton");
        public static By AddToCollectionButton_CSS2 = By.CssSelector("button#addNewRecordButton");
        public static By AddToCollectionButton_XPath1 = By.XPath("//button[@id='addNewRecordButton']");
        public static By AddToCollectionButton_XPath2 = By.XPath("//button[text()='Add To Your Collection']");

        // Profile Page - Go to Profile Button
        public static By GoToProfileButton_CSS1 = By.CssSelector("button#gotoStore");
        public static By GoToProfileButton_CSS2 = By.CssSelector("button[onclick='goToProfile()']");
        public static By GoToProfileButton_XPath1 = By.XPath("//button[@id='gotoStore']");
        public static By GoToProfileButton_XPath2 = By.XPath("//button[text()='Go To Book Store']");

        // Profile Page - Delete All Books Button
        public static By DeleteAllBooksButton_Id = By.Id("submit");
        public static By DeleteAllBooksButton_CSS1 = By.CssSelector("#submit");
        public static By DeleteAllBooksButton_CSS2 = By.CssSelector("button#submit");
        public static By DeleteAllBooksButton_XPath1 = By.XPath("//button[@id='submit']");
        public static By DeleteAllBooksButton_XPath2 = By.XPath("//button[text()='Delete All Books']");

        public static By LoginButton_XPath1 = By.XPath("//button[text()='Login']");
        public static By Username_Id = By.Id("userName");
        public static By Password_Id = By.Id("password");
        public static By SubmitLogin_XPath1 = By.XPath("//button[@id='login']");

        public static By OKConfirmButton_XPath1 = By.Id("closeSmallModal-ok");

        // Dynamically matched book link in profile (used in test with string)
        public static By BookLinkInProfile(string bookTitle) =>
            By.XPath($"//a[text()='{bookTitle}']");

        // Comments:
        // - The search box allows users to filter books by title.
        // - Book titles are clickable links that navigate to the book's detail page.
        // - The "Add To Your Collection" button adds the selected book to the user's profile.
        // - The "Go To Book Store" button navigates back to the main book store page.
        // - The "Delete All Books" button removes all books from the user's collection.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC10_VerifySliderFunctionality
    {

        // Slider Input Element
        public static By SliderInput_CSS1 = By.CssSelector(".range-slider");
        public static By SliderInput_CSS2 = By.CssSelector("input[type='range']");
        public static By SliderInput_XPath1 = By.XPath("//input[@class='range-slider range-slider--primary']");
        public static By SliderInput_XPath2 = By.XPath("//input[@type='range']");

        // Slider Value Display
        public static By SliderValue_Id = By.Id("sliderValue");
        public static By SliderValue_CSS1 = By.CssSelector("#sliderValue");
        public static By SliderValue_CSS2 = By.CssSelector("input#sliderValue");
        public static By SliderValue_XPath1 = By.XPath("//input[@id='sliderValue']");
        public static By SliderValue_XPath2 = By.XPath("//div[@id='sliderContainer']//div[@class='col-3']/input");

        // Comments:
        // - The slider is an input element of type 'range' with id 'slider'.
        // - The current value of the slider is displayed in an input element with id 'sliderValue'.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC11_VerifyProgressBarOperations
    {

        // Start Button
        public static By StartButton_Id = By.Id("startStopButton");
        public static By StartButton_CSS1 = By.CssSelector("#startStopButton");
        public static By StartButton_CSS2 = By.CssSelector("button#startStopButton");
        public static By StartButton_XPath1 = By.XPath("//button[@id='startStopButton']");
        public static By StartButton_XPath2 = By.XPath("//button[text()='Start']");

        // Stop Button (same ID as Start Button; text changes dynamically)
        public static By StopButton_Id = By.Id("startStopButton");
        public static By StopButton_CSS1 = By.CssSelector("#startStopButton");
        public static By StopButton_CSS2 = By.CssSelector("button#startStopButton");
        public static By StopButton_XPath1 = By.XPath("//button[@id='startStopButton']");
        public static By StopButton_XPath2 = By.XPath("//button[text()='Stop']");

        // Progress Bar
        public static By ProgressBar_Id = By.Id("progressBar");
        public static By ProgressBar_CSS1 = By.CssSelector("#progressBar");
        public static By ProgressBar_CSS2 = By.CssSelector("div#progressBar");
        public static By ProgressBar_XPath1 = By.XPath("//div[@id='progressBar']");
        public static By ProgressBar_XPath2 = By.XPath("//div[contains(@class, 'progress-bar')]");

        // Progress Value (text inside the progress bar)
        public static By ProgressValue_CSS1 = By.CssSelector("#progressBar .progress-bar");
        public static By ProgressValue_CSS2 = By.CssSelector("div#progressBar > div.progress-bar");
        public static By ProgressValue_XPath1 = By.XPath("//div[@id='progressBar']/div");
        public static By ProgressValue_XPath2 = By.XPath("//div[contains(@class, 'progress-bar') and contains(text(), '%')]");

        public static By ResetButton_XPath1 = By.XPath("//button[text()='Reset']");



        // Comments:
        // - The Start and Stop buttons share the same ID; their text changes based on the current state.
        // - The progress bar's visual representation and its textual value are nested within the same element.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC12_VerifyDatePickerFunctionality
    {

        // Date Picker Input
        public static By DatePickerInput_Id = By.Id("datePickerMonthYearInput");
        public static By DatePickerInput_CSS1 = By.CssSelector("#datePickerMonthYearInput");
        public static By DatePickerInput_CSS2 = By.CssSelector("input#datePickerMonthYearInput");
        public static By DatePickerInput_XPath1 = By.XPath("//input[@id='datePickerMonthYearInput']");
        public static By DatePickerInput_XPath2 = By.XPath("//div[@class='react-datepicker__input-container']/input[@id='datePickerMonthYearInput']");

        // Date and Time Picker Input
        public static By DateTimePickerInput_Id = By.Id("dateAndTimePickerInput");
        public static By DateTimePickerInput_CSS1 = By.CssSelector("#dateAndTimePickerInput");
        public static By DateTimePickerInput_CSS2 = By.CssSelector("input#dateAndTimePickerInput");
        public static By DateTimePickerInput_XPath1 = By.XPath("//input[@id='dateAndTimePickerInput']");
        public static By DateTimePickerInput_XPath2 = By.XPath("//div[@class='react-datepicker__input-container']/input[@id='dateAndTimePickerInput']");

        // Calendar Month Select
        public static By CalendarMonthSelect_Class = By.ClassName("react-datepicker__month-dropdown-container--scroll");
        public static By CalendarMonthSelect_CSS1 = By.CssSelector(".react-datepicker__month-dropdown-container");
        public static By CalendarMonthSelect_CSS2 = By.CssSelector("div.react-datepicker__header__dropdown > .react-datepicker__month-dropdown-container--scroll");
        public static By CalendarMonthSelect_XPath1 = By.XPath("//div[@class='react-datepicker__header__dropdown react-datepicker__header__dropdown--scroll']//div[contains(@class, 'react-datepicker__month-dropdown-container')]");
        public static By CalendarMonthSelect_XPath2 = By.XPath("(//div[contains(@class, 'react-datepicker__month-dropdown')])[1]");

        // Calendar Year Select
        public static By CalendarYearSelect_CSS1 = By.CssSelector(".react-datepicker__year-dropdown-container--scroll");
        public static By CalendarYearSelect_CSS2 = By.CssSelector(".react-datepicker__header__dropdown--scroll > div.react-datepicker__year-dropdown-container");
        public static By CalendarYearSelect_XPath1 = By.XPath("//div[contains(@class,'react-datepicker__year-dropdown-container--scroll')]");
        public static By CalendarYearSelect_XPath2 = By.XPath("//div[@class='react-datepicker__year-dropdown-container react-datepicker__year-dropdown-container--scroll']");

        // Calendar Day (example for 15th day)
        public static By CalendarDay15_CSS1 = By.CssSelector(".react-datepicker__day--015");
        public static By CalendarDay15_CSS2 = By.CssSelector("div.react-datepicker__day--015");
        public static By CalendarDay15_XPath1 = By.XPath("//div[contains(@class, 'react-datepicker__day--015') and not(contains(@class, 'outside-month'))]");
        public static By CalendarDay15_XPath2 = By.XPath("//div[@class='react-datepicker__day react-datepicker__day--015']");

        // Time List Item (example for 12:00)
        public static By TimeListItem1200_CSS1 = By.CssSelector(".react-datepicker__time-list-item");
        public static By TimeListItem1200_CSS2 = By.CssSelector("li.react-datepicker__time-list-item");
        public static By TimeListItem1200_XPath1 = By.XPath("//li[contains(@class, 'react-datepicker__time-list-item') and text()='12:00']");
        public static By TimeListItem1200_XPath2 = By.XPath("//li[@class='react-datepicker__time-list-item ' and text()='12:00']");


        public static By MonthDropdown_CSS = By.CssSelector(".react-datepicker__month-select");
        public static By YearDropdown_CSS = By.CssSelector(".react-datepicker__year-select");


        public static By DayInMonth(int day) =>
                By.CssSelector($".react-datepicker__day--0{day:D2}:not(.react-datepicker__day--outside-month)");

        // Comments:
        // - The date picker inputs have unique IDs for direct access.
        // - Month and year selectors are dropdowns within the date picker pop-up.
        // - Days are selectable via specific class names corresponding to the day number.
        // - Time selections are list items within the time picker.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC13_VerifyModalDialogs
    {

        // Small Modal Button
        public static By SmallModalButton_Id = By.Id("showSmallModal");
        public static By SmallModalButton_CSS1 = By.CssSelector("#showSmallModal");
        public static By SmallModalButton_CSS2 = By.CssSelector("button#showSmallModal");
        public static By SmallModalButton_XPath1 = By.XPath("//button[@id='showSmallModal']");
        public static By SmallModalButton_XPath2 = By.XPath("//button[text()='Small modal']");

        // Large Modal Button
        public static By LargeModalButton_Id = By.Id("showLargeModal");
        public static By LargeModalButton_CSS1 = By.CssSelector("#showLargeModal");
        public static By LargeModalButton_CSS2 = By.CssSelector("button#showLargeModal");
        public static By LargeModalButton_XPath1 = By.XPath("//button[@id='showLargeModal']");
        public static By LargeModalButton_XPath2 = By.XPath("//button[text()='Large modal']");

        // Modal Title (common for both modals)
        public static By ModalTitle_Class = By.ClassName("modal-title");
        public static By ModalTitle_CSS1 = By.CssSelector(".modal-title");
        public static By ModalTitle_CSS2 = By.CssSelector(".modal-header > .modal-title");
        public static By ModalTitle_XPath1 = By.XPath("//div[@class='modal-header']//div[@class='modal-title h4']");
        public static By ModalTitle_XPath2 = By.XPath("//div[contains(@class, 'modal-title')]");

        // Modal Body (common for both modals)
        public static By ModalBody_Class = By.ClassName("modal-body");
        public static By ModalBody_CSS1 = By.CssSelector(".modal-body");
        public static By ModalBody_CSS2 = By.CssSelector("div.modal-body");
        public static By ModalBody_XPath1 = By.XPath("//div[@class='modal-body']");
        public static By ModalBody_XPath2 = By.XPath("//div[contains(@class, 'modal-body')]");

        // Close Button (common for both modals)
        public static By CloseButton_Id = By.Id("closeSmallModal");
        public static By CloseButton_CSS1 = By.CssSelector("#closeSmallModal");
        public static By CloseButton_CSS2 = By.CssSelector("button#closeSmallModal");
        public static By CloseButton_XPath1 = By.XPath("//button[@id='closeSmallModal']");
        public static By CloseButton_XPath2 = By.XPath("//button[text()='Close']");

        public static By SmallModal_Close_XPath1 = By.XPath("//div[@id='example-modal-sizes-title-sm']/following-sibling::button[contains(@class,'close')]");
        public static By SmallModal_CloseButton_Id = By.Id("closeSmallModal");

        public static By LargeModal_Content_Id = By.Id("example-modal-sizes-title-lg");
        public static By LargeModal_CloseButton_Id = By.Id("closeLargeModal");

        public static By ModalOverlay_CSS = By.CssSelector(".modal-backdrop");

        // Comments:
        // - The Small and Large Modal buttons have unique IDs for direct access.
        // - Modal titles and bodies share common class names, allowing for reusable selectors.
        // - The Close button for the small modal has a unique ID; ensure to verify the ID for the large modal's close button as it might differ.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC14_VerifyAccordionSections
    {

        // Section 1 Heading
        public static By Section1Heading_Id = By.Id("section1Heading");
        public static By Section1Heading_CSS1 = By.CssSelector("#section1Heading");
        public static By Section1Heading_CSS2 = By.CssSelector("div#section1Heading");
        public static By Section1Heading_XPath1 = By.XPath("//div[@id='section1Heading']");
        public static By Section1Heading_XPath2 = By.XPath("//div[text()='What is Lorem Ipsum?']");

        // Section 1 Content
        public static By Section1Content_Id = By.Id("section1Content");
        public static By Section1Content_CSS1 = By.CssSelector("#section1Content");
        public static By Section1Content_CSS2 = By.CssSelector("div#section1Content");
        public static By Section1Content_XPath1 = By.XPath("//div[@id='section1Content']");
        public static By Section1Content_XPath2 = By.XPath("//div[@id='section1Content']/p");

        // Section 2 Heading
        public static By Section2Heading_Id = By.Id("section2Heading");
        public static By Section2Heading_CSS1 = By.CssSelector("#section2Heading");
        public static By Section2Heading_CSS2 = By.CssSelector("div#section2Heading");
        public static By Section2Heading_XPath1 = By.XPath("//div[@id='section2Heading']");
        public static By Section2Heading_XPath2 = By.XPath("//div[text()='Where does it come from?']");

        // Section 2 Content
        public static By Section2Content_Id = By.Id("section2Content");
        public static By Section2Content_CSS1 = By.CssSelector("#section2Content");
        public static By Section2Content_CSS2 = By.CssSelector("div#section2Content");
        public static By Section2Content_XPath1 = By.XPath("//div[@id='section2Content']");
        public static By Section2Content_XPath2 = By.XPath("//div[@id='section2Content']/p");

        // Section 3 Heading
        public static By Section3Heading_Id = By.Id("section3Heading");
        public static By Section3Heading_CSS1 = By.CssSelector("#section3Heading");
        public static By Section3Heading_CSS2 = By.CssSelector("div#section3Heading");
        public static By Section3Heading_XPath1 = By.XPath("//div[@id='section3Heading']");
        public static By Section3Heading_XPath2 = By.XPath("//div[text()='Why do we use it?']");

        // Section 3 Content
        public static By Section3Content_Id = By.Id("section3Content");
        public static By Section3Content_CSS1 = By.CssSelector("#section3Content");
        public static By Section3Content_CSS2 = By.CssSelector("div#section3Content");
        public static By Section3Content_XPath1 = By.XPath("//div[@id='section3Content']");
        public static By Section3Content_XPath2 = By.XPath("//div[@id='section3Content']/p");

        public static By Section3Collapse_XPath1 = By.XPath("//div[@id='section3Content']/parent::div");

        // Comments:
        // - Each accordion section has a unique heading and content identified by unique IDs.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

    public class TC15_VerifyAutoCompleteFunctionality
    {

        // Multiple Color Input Field
        public static By MultipleColorInput_Id = By.Id("autoCompleteMultipleInput");
        public static By MultipleColorInput_CSS1 = By.CssSelector("#autoCompleteMultipleInput");
        public static By MultipleColorInput_CSS2 = By.CssSelector("input#autoCompleteMultipleInput");
        public static By MultipleColorInput_XPath1 = By.XPath("//input[@id='autoCompleteMultipleInput']");
        public static By MultipleColorInput_XPath2 = By.XPath("//div[@id='autoCompleteMultipleContainer']//input");

        // Multiple Color Selected Values
        public static By MultipleColorSelected_CSS1 = By.CssSelector(".auto-complete__multi-value__label");
        public static By MultipleColorSelected_CSS2 = By.CssSelector("div.auto-complete__multi-value__label");
        public static By MultipleColorSelected_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__multi-value__label')]");
        public static By MultipleColorSelected_XPath2 = By.XPath("//div[@id='autoCompleteMultipleContainer']//div[contains(@class, 'auto-complete__multi-value__label')]");

        // Single Color Input Field
        public static By SingleColorInput_Id = By.Id("autoCompleteSingleInput");
        public static By SingleColorInput_CSS1 = By.CssSelector("#autoCompleteSingleInput");
        public static By SingleColorInput_CSS2 = By.CssSelector("input#autoCompleteSingleInput");
        public static By SingleColorInput_XPath1 = By.XPath("//input[@id='autoCompleteSingleInput']");
        public static By SingleColorInput_XPath2 = By.XPath("//div[@id='autoCompleteSingleContainer']//input");

        public static By SingleColorValue_XPath1 = By.XPath("//div[contains(@class,'auto-complete__single-value')]");

        // Single Color Selected Value
        public static By SingleColorSelected_CSS1 = By.CssSelector(".auto-complete__single-value");
        public static By SingleColorSelected_CSS2 = By.CssSelector("div.auto-complete__single-value");
        public static By SingleColorSelected_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__single-value')]");
        public static By SingleColorSelected_XPath2 = By.XPath("//div[@id='autoCompleteSingleContainer']//div[contains(@class, 'auto-complete__single-value')]");

        // Auto-Complete Suggestions
        public static By AutoCompleteOptions_CSS1 = By.CssSelector(".auto-complete__option");
        public static By AutoCompleteOptions_CSS2 = By.CssSelector("div.auto-complete__option");
        public static By AutoCompleteOptions_XPath1 = By.XPath("//div[contains(@class, 'auto-complete__option')]");
        public static By AutoCompleteOptions_XPath2 = By.XPath("//div[@class='auto-complete__menu']//div[contains(@class, 'auto-complete__option')]");

        public static By MultiColorInput_Id = By.Id("autoCompleteMultipleInput");
        public static By AutoCompleteOption_CSS = By.CssSelector(".auto-complete__option");
        public static By MultiColorTags_CSS = By.CssSelector(".auto-complete__multi-value__label");
        public static By RemoveButton_CSS = By.CssSelector(".auto-complete__multi-value__remove");


        // Comments:
        // - The multiple and single color input fields have unique IDs for direct access.
        // - Selected values are displayed within elements having specific class names.
        // - Auto-complete suggestions appear as div elements with identifiable class names.
        // - Multiple selector strategies (ID, CSS, XPath) are provided for flexibility.
    }

}

