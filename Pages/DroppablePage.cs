using OpenQA.Selenium;

public class DroppablePage : BasePage
{
    public DroppablePage(IWebDriver driver, UnifiedLog log)
        : base(driver, log) { }

    private readonly string url = "https://demoqa.com/droppable";

    public void NavigateTo() => driver.Navigate().GoToUrl(url);

    public WebElement simpleTab => Find(DroppablePageLocators.SimpleTab_XPath1);

    public WebElement draggable => Find(DroppablePageLocators.Simple_Draggable_Id);

    public WebElement droppable => Find(DroppablePageLocators.Simple_Droppable_Id);

    public WebElement droppableText => Find(DroppablePageLocators.Droppable_Text_XPath1);

    public void PerformSimpleDragAndDrop() => DragAndDrop(draggable, droppable);

    public WebElement acceptTab => Find(DroppablePageLocators.AcceptTab_Id);

    public WebElement acceptedDraggable => Find(DroppablePageLocators.Acceptable_Id);

    public WebElement notAcceptedDraggable => Find(DroppablePageLocators.NotAcceptable_Id);

    public WebElement acceptedDroppable => Find(DroppablePageLocators.Accept_Droppable_CSS1);

    public void PerformDragAndDropNotAcceptTableToTarget() =>
        actions.DragAndDrop(notAcceptedDraggable.source, acceptedDroppable.source).Perform();

    public void PerformDragAndDropAcceptableToTarget() =>
        actions.DragAndDrop(acceptedDraggable.source, acceptedDroppable.source).Perform();

    public void waitUntilNotAcceptedDraggableReachTarget() =>
        wait.Until(d =>
        {
            return notAcceptedDraggable.source.Location.X >= acceptedDroppable.source.Location.X;
        });

    public void waitUntilAcceptedDraggableReachTarget() =>
        wait.Until(d =>
        {
            return acceptedDraggable.source.Location.X >= acceptedDroppable.source.Location.X;
        });

    public WebElement preventPropogationTab => Find(DroppablePageLocators.PreventPropogation_Id);
    public WebElement dragBox => Find(DroppablePageLocators.PreventPropogation_DragBox_Id);
    public WebElement outerDrop =>
        Find(DroppablePageLocators.PreventPropogation_NotGreedyDroppableBox_Id);
    public WebElement innerDrop =>
        Find(DroppablePageLocators.PreventPropogation_NotGreedyInnerDroppableBox_Id);

    public void PerformDragAndDropDragBoxToInnerDrop()
    {
        innerDrop.ScrollIntoView();
        actions.DragAndDrop(dragBox.source, innerDrop.source).Perform();
    }

    public WebElement greedyOuter =>
        Find(DroppablePageLocators.PreventPropogation_GreedyDroppableBox_Id);
    public WebElement greedyInner =>
        Find(DroppablePageLocators.PreventPropogation_GreedyInnerDroppableBox_Id);

    public void PerformDragAndDropDragBoxToGreedyInner()
    {
        greedyInner.ScrollIntoView();
        actions.DragAndDrop(dragBox.source, greedyInner.source).Perform();
    }


    public WebElement revertTab => Find(DroppablePageLocators.RevertTab_Id);
    public WebElement revertable => Find(DroppablePageLocators.Revert_RevertableDragBox_Id);
    public WebElement notRevertable => Find(DroppablePageLocators.Revert_NotRevertableDragBox_Id);
    public WebElement revertTarget => Find(DroppablePageLocators.Revert_DroppableBox_CSS1);

    public void PerformDragAndDropRevertable()
    {
        revertTarget.ScrollIntoView();
        actions.DragAndDrop(revertable.source, revertTarget.source).Perform();
    }


    public void PerformDragAndDropNotRevertable()
    {

        revertTarget.ScrollIntoView();
        actions.DragAndDrop(notRevertable.source, revertTarget.source).Perform();
    }
}
