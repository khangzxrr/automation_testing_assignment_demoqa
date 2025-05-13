public class DroppableTest : BaseTest
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
        var page = new DroppablePage(driver);

        page.NavigateTo();

        // --- Step 1: Simple Tab ---
        page.simpleTab.Click();

        page.PerformSimpleDragAndDrop();

        Assert.Equal("Dropped!", page.droppableText.Text);

        // --- Step 2: Accept Tab ---
        page.acceptTab.Click();

        page.PerformDragAndDropNotAcceptTableToTarget();
        page.waitUntilNotAcceptedDraggableReachTarget();

        Assert.Equal("Drop here", page.acceptedDroppable.Text); // should not accept

        page.PerformDragAndDropAcceptableToTarget();
        page.waitUntilAcceptedDraggableReachTarget();

        Assert.Equal("Dropped!", page.acceptedDroppable.Text);

        // --- Step 3: Prevent Propagation ---
        page.preventPropogationTab.Click();

        page.PerformDragAndDropDragBoxToInnerDrop();

        Assert.Equal("Dropped!", page.innerDrop.Text);
        Assert.Equal("Dropped!\nDropped!", page.outerDrop.Text); // outer text shouldn't change

        page.preventPropogationTab.ScrollIntoView();

        page.PerformDragAndDropDragBoxToGreedyInner();

        Assert.Equal("Dropped!", page.greedyInner.Text);
        Assert.Equal("Outer droppable\nDropped!", page.greedyOuter.Text); // both should change

        // --- Step 4: Revert/Not Revert Tab ---
        page.revertTab.Click();


        var revertableLocationBefore = page.revertable.source.Location;

        page.PerformDragAndDropRevertable();
        Thread.Sleep(1000);

        Assert.Equal(revertableLocationBefore, page.revertable.source.Location); // it should revert

        var notRevertableLocationBefore = page.notRevertable.source.Location;

        page.PerformDragAndDropNotRevertable();
        Thread.Sleep(1000); // brief wait

        Assert.NotEqual(notRevertableLocationBefore, page.notRevertable.source.Location); // should not revert
    }

}
