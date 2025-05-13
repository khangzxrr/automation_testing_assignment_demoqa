# DemoQA Selenium Automation Test Suite (xUnit + POM)

This project is a comprehensive UI automation test suite built using **Selenium WebDriver**, **xUnit**, and the **Page Object Model (POM)** design pattern to validate functionality across multiple interactive components on [https://demoqa.com](https://demoqa.com).

---

## ✅ Technologies Used

- C# with .NET
- xUnit for test execution
- Selenium WebDriver (v4.32.0)
- Page Object Model (POM)
- WebDriverWait / ExpectedConditions
- Traits and InlineData for structured test metadata

---

## 🧱 Project Structure

```
.
├── Locators/
│   └── *.cs                # Centralized selectors per page (e.g., SliderPageLocators.cs)
├── Pages/
│   └── *.cs                # Page object classes (e.g., SliderPage.cs)
├── Tests/
│   └── *.cs                # xUnit test files (e.g., SliderTest.cs)
```

---

## 🧪 Test Cases Covered

| TC ID | Test Description                                | URL Segment          |
|-------|--------------------------------------------------|-----------------------|
| TC01  | Student Registration Form Submission             | /automation-practice-form |
| TC02  | Validation for Empty Required Fields             | /automation-practice-form |
| TC03  | Email Field HTML5 Validation                     | /automation-practice-form |
| TC04  | Dynamic Properties and Button Timing             | /dynamic-properties |
| TC05  | Drag and Drop Functionality                      | /droppable           |
| TC06  | Web Table CRUD Operations                        | /webtables           |
| TC07  | Alert Handling (Simple, Timed, Confirm)          | /alerts              |
| TC08  | Frame Navigation and Content Validation          | /frames              |
| TC09  | Book Store Login, Search and Collection          | /books               |
| TC10  | Slider Movement and Boundary Values              | /slider              |
| TC11  | Progress Bar Start, Stop and Reset               | /progress-bar        |
| TC12  | Date Picker Calendar Interactions                | /date-picker         |
| TC13  | Modal Dialog Open and Close                      | /modal-dialogs       |
| TC14  | Accordion Expand/Collapse Verification           | /accordian           |
| TC15  | Auto-Complete (Single and Multi Input)           | /auto-complete       |

---

## 🚀 How to Run Tests

1. **Install Dependencies**
   Ensure `.NET SDK` and `Selenium.WebDriver` packages are installed.

2. **Execute via CLI**
   ```bash
   dotnet test
   ```

---

## 📌 Notes

- Traits (`[Trait("Category", "DemoQA")]`, etc.) are used for test filtering and classification.
- All tests follow **strict POM abstraction**: test files never interact with WebDriver directly.
- Tests include assertions for visibility, formatting, animation timing, and user interactions.

---

© 2025 DemoQA Automation | Authored by Khang Võ
