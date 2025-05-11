using OpenQA.Selenium.Interactions;

public partial class TestCase
{

    [Fact]
    [Trait("Category", "DemoQA")]
    [Trait("Component", "Droppable")]
    [Trait("TestCase", "TC05")]
    [Trait("Type", "UIInteraction")]
    [Trait("Action", "DragAndDrop")]
    [Trait("Level", "Functional")]
    public void TC05_VerifyDragAndDropFunctionality()
    {
        driver.Url = "https://demoqa.com/droppable";
        var actions = new Actions(driver);

        // --- Step 1: Simple Tab ---
        driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.SimpleTab_XPath1).Click();
        var draggable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Simple_Draggable_Id);
        var droppable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Simple_Droppable_Id);

        actions.DragAndDrop(draggable, droppable).Perform();
        var droppedText = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Droppable_Text_XPath1).Text;
        Assert.Equal("Dropped!", droppedText);

        // --- Step 2: Accept Tab ---
        driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.AcceptTab_Id).Click();

        var acceptable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Acceptable_Id);
        var notAcceptable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.NotAcceptable_Id);
        var acceptTarget = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Accept_Droppable_CSS1);

        actions.DragAndDrop(notAcceptable, acceptTarget).Perform();

        wait.Until(d =>
        {
            var notAcceptable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.NotAcceptable_Id);
            var acceptTarget = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Accept_Droppable_CSS1);

            return notAcceptable.Location.X >= acceptTarget.Location.X;
        });

        var textAfterInvalidDrop = acceptTarget.Text;
        Assert.Equal("Drop here", textAfterInvalidDrop); // should not accept

        actions.DragAndDrop(acceptable, acceptTarget).Perform();

        wait.Until(d =>
        {
            var acceptable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Acceptable_Id);
            var acceptTarget = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Accept_Droppable_CSS1);

            return acceptable.Location.X >= acceptTarget.Location.X;
        });

        var textAfterValidDrop = acceptTarget.Text;
        Assert.Equal("Dropped!", textAfterValidDrop);

        // --- Step 3: Prevent Propagation ---
        driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_Id).Click();
        var dragBox = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_DragBox_Id);
        var outerDrop = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_NotGreedyDroppableBox_Id);
        var innerDrop = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_NotGreedyInnerDroppableBox_Id);

        actions.DragAndDrop(dragBox, innerDrop).Perform();
        var innerText = innerDrop.Text;
        var outerText = outerDrop.Text;
        Assert.Equal("Dropped!", innerText);
        Assert.Equal("Dropped!\nDropped!", outerText); // outer text shouldn't change

        var greedyOuter = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_GreedyDroppableBox_Id);
        var greedyInner = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_GreedyInnerDroppableBox_Id);

        SeleniumHelpers.ScrollIntoView(driver, wait, ElementLocators.TC05_VerifyDragAndDropScenarios.PreventPropogation_Id);

        actions.DragAndDrop(dragBox, greedyInner).Perform();
        var greedyInnerText = greedyInner.Text;
        var greedyOuterText = greedyOuter.Text;
        Assert.Equal("Dropped!", greedyInnerText);
        Assert.Equal("Outer droppable\nDropped!", greedyOuterText); // both should change

        // --- Step 4: Revert/Not Revert Tab ---
        driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.RevertTab_Id).Click();
        var revertable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Revert_RevertableDragBox_Id);
        var notRevertable = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Revert_NotRevertableDragBox_Id);
        var revertTarget = driver.FindElement(ElementLocators.TC05_VerifyDragAndDropScenarios.Revert_DroppableBox_CSS1);

        var revertableLocationBefore = revertable.Location;
        actions.DragAndDrop(revertable, revertTarget).Perform();
        Thread.Sleep(1000);

        var revertableLocationAfter = revertable.Location;
        Assert.Equal(revertableLocationBefore, revertableLocationAfter); // it should revert

        var notRevertableLocationBefore = notRevertable.Location;
        actions.DragAndDrop(notRevertable, revertTarget).Perform();
        Thread.Sleep(1000); // brief wait

        var notRevertableLocationAfter = notRevertable.Location;
        Assert.NotEqual(notRevertableLocationBefore, notRevertableLocationAfter); // should not revert
    }
}
