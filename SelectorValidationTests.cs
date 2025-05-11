using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;


namespace DemoQATests.Tests
{
    public class SelectorValidationTests : IDisposable
    {
        private IWebDriver driver;

        public SelectorValidationTests()
        {
            //love manual 
            //adjust this before run or use your own driver
            var service = FirefoxDriverService.CreateDefaultService("/usr/bin/geckodriver");


            driver = new FirefoxDriver(service);

        }

        // [Theory]
        // [InlineData("https://demoqa.com/automation-practice-form", typeof(ElementLocators.TC01_VerifyStudentRegistration))]
        // [InlineData("https://demoqa.com/dynamic-properties", typeof(ElementLocators.TC04_VerifyDynamicButtonStates))]
        // [InlineData("https://demoqa.com/droppable", typeof(ElementLocators.TC05_VerifyDragAndDropScenarios))]
        // [InlineData("https://demoqa.com/webtables", typeof(ElementLocators.TC06_VerifyWebTableCRUD))]
        // [InlineData("https://demoqa.com/alerts", typeof(ElementLocators.TC07_VerifyAlertHandling))]
        // we cannot automatic verifying this way when facing iframe, temporary disable it
        // [InlineData("https://demoqa.com/frames", typeof(ElementLocators.TC08_VerifyFrameNavigation))]
        //
        // we cannot automatic verifying this way when facing multiple step, temporary disable it
        // [InlineData("https://demoqa.com/books", typeof(ElementLocators.TC09_VerifyBookStoreSearchAndCollection))]
        // [InlineData("https://demoqa.com/slider", typeof(ElementLocators.TC10_VerifySliderFunctionality))]
        //
        //
        // we cannot automatic verifying this way when facing multiple step, temporary disable it
        // [InlineData("https://demoqa.com/progress-bar", typeof(ElementLocators.TC11_VerifyProgressBarOperations))]
        // [InlineData("https://demoqa.com/date-picker", typeof(ElementLocators.TC12_VerifyDatePickerFunctionality))]
        // [InlineData("https://demoqa.com/modal-dialogs", typeof(ElementLocators.TC13_VerifyModalDialogs))]
        // [InlineData("https://demoqa.com/accordian", typeof(ElementLocators.TC14_VerifyAccordionSections))]
        //
        // we cannot automatic verifying this way when facing multiple step, teemporary disable it
        // [InlineData("https://demoqa.com/auto-complete", typeof(ElementLocators.TC15_VerifyAutoCompleteFunctionality))]
        public void AllSelectors_ShouldBeLocated(string url, Type locatorClassType)
        {
            driver.Navigate().GoToUrl(url);
            var fields = locatorClassType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            if (locatorClassType == typeof(ElementLocators.TC04_VerifyDynamicButtonStates))
            {
                driver.FindElement(ElementLocators.TC04_VerifyDynamicButtonStates.ColorChange_CSS1).Click();
                Thread.Sleep(6000);
            }
            if (locatorClassType == typeof(ElementLocators.TC06_VerifyWebTableCRUD))
            {
                var element = driver.FindElement(ElementLocators.TC06_VerifyWebTableCRUD.AddButton_CSS1);
                element.Click();
            }
            else if (locatorClassType == typeof(ElementLocators.TC07_VerifyAlertHandling))
            {
                driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.ConfirmButton_Id).Click();
                Thread.Sleep(100);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();


                driver.FindElement(ElementLocators.TC07_VerifyAlertHandling.PromptButton_Id).Click();
                Thread.Sleep(100);
                alert = driver.SwitchTo().Alert();
                alert.SendKeys("test");
                alert.Accept();
            }
            else if (locatorClassType == typeof(ElementLocators.TC12_VerifyDatePickerFunctionality))
            {
                driver.FindElement(ElementLocators.TC12_VerifyDatePickerFunctionality.DateTimePickerInput_Id).Click();
            }
            else if (locatorClassType == typeof(ElementLocators.TC13_VerifyModalDialogs))
            {
                driver.FindElement(ElementLocators.TC13_VerifyModalDialogs.SmallModalButton_CSS1).Click();
            }


            foreach (var field in fields)
            {
                var locator = (By)field.GetValue(null);
                try
                {
                    var element = driver.FindElement(locator);
                    Assert.NotNull(element);
                }
                catch (NoSuchElementException)
                {
                    throw new Exception($"Selector failed: {field.Name} in {locatorClassType.Name} on {url}");
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
