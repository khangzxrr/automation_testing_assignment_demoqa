public class ModelDialogsTest : BaseTest
{

    [Trait("Category", "DemoQA")]
    [Trait("Component", "ModalDialogs")]
    [Trait("TestCase", "TC13")]
    [Trait("Type", "UIInteraction")]
    [Trait("Element", "Modal")]
    [Trait("Level", "PopupValidation")]
    [Fact]
    public void TC13_VerifyModalDialogsDisplayAndClose()
    {
        var testname = nameof(TC13_VerifyModalDialogsDisplayAndClose);

        PerformTest(testname, () =>
        {
            var page = new ModalDialogsPage(driver);
            page.NavigateTo();

            // Step 1: Open small modal and close via X
            page.OpenSmallModal();
            Assert.True(page.SmallModalCloseX.Displayed);
            page.CloseSmallModalX();

            // Step 2: Open small modal and close via button
            page.OpenSmallModal();
            Assert.True(page.SmallModalCloseButton.Displayed);
            page.CloseSmallModalButton();

            // Step 3: Open large modal
            page.OpenLargeModal();
            Assert.True(page.IsLargeModalVisible());

            // Step 4: Try clicking overlay (should NOT close modal)
            page.ClickModalOverlay();
            Assert.True(page.IsLargeModalVisible()); // still open

        });
    }
}
