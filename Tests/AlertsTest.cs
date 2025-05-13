public class AlertsTest : BaseTest
{

    [Trait("Category", "DemoQA")]
    [Trait("Component", "Alerts")]
    [Trait("TestCase", "TC07")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "JavaScriptAlert")]
    [Trait("Level", "PopupHandling")]
    [Fact]
    public void TC07_VerifyAlertHandlingFunctionality()
    {
        PerformTest(() =>
        {
            var page = new AlertsPage(driver);

            page.NavigateTo();

            // Step 1: Simple Alert
            page.ClickSimpleAlert();
            page.WaitForAlert();
            var simpleAlert = page.SwitchToAlert();
            Assert.Equal("You clicked a button", page.GetAlertText());
            page.AcceptAlert();

            // Step 2: Timed Alert (5s)
            page.ClickTimedAlert();
            page.WaitForAlert();
            var timedAlert = page.SwitchToAlert();
            Assert.Equal("This alert appeared after 5 seconds", page.GetAlertText());
            page.AcceptAlert();

            // Step 3: Confirm Alert (Accept)
            page.ClickConfirmButton();
            page.WaitForAlert();

            var confirmAlert = page.SwitchToAlert();
            Assert.Equal("Do you confirm action?", page.GetAlertText());
            page.AcceptAlert();
            Assert.Contains("Ok", page.GetConfirmResultText());

            // Step 4: Confirm Alert (Dismiss)
            page.ClickConfirmButton();
            page.WaitForAlert();
            page.DismissAlert();
            Assert.Contains("Cancel", page.GetConfirmResultText());

            page.ClickPromptButton();
            page.WaitForAlert();
            var alert = page.SwitchToAlert();
            page.TypeToAlert(alert, "KhangVN3");
            alert.Accept();

            Assert.Contains("KhangVN3", page.GetPromptResult());

        });
    }

}
