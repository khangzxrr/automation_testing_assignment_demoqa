using OpenQA.Selenium;

public static class DroppablePageLocators
{
    // Tab: Simple
    public static By SimpleTab_XPath1 = By.XPath("//a[@id='droppableExample-tab-simple']");

    // Tab: Accept
    public static By AcceptTab_Id = By.Id("droppableExample-tab-accept");
    public static By Acceptable_Id = By.Id("acceptable");
    public static By NotAcceptable_Id = By.Id("notAcceptable");
    public static By Accept_Droppable_CSS1 = By.CssSelector("#acceptDropContainer #droppable");

    // Tab: Prevent Propogation
    public static By PreventPropogation_Id = By.Id("droppableExample-tab-preventPropogation");
    public static By PreventPropogation_DragBox_Id = By.Id("dragBox");
    public static By PreventPropogation_NotGreedyDroppableBox_Id = By.Id("notGreedyDropBox");
    public static By PreventPropogation_NotGreedyInnerDroppableBox_Id = By.Id(
        "notGreedyInnerDropBox"
    );

    public static By PreventPropogation_GreedyDroppableBox_Id = By.Id("greedyDropBox");
    public static By PreventPropogation_GreedyInnerDroppableBox_Id = By.Id(
        "greedyDropBoxInner"
    );

    // Tab: Revert draggable
    public static By RevertTab_Id = By.Id("droppableExample-tab-revertable");
    public static By Revert_RevertableDragBox_Id = By.Id("revertable");
    public static By Revert_NotRevertableDragBox_Id = By.Id("notRevertable");
    public static By Revert_DroppableBox_CSS1 = By.CssSelector(
        "#revertableDropContainer #droppable"
    );

    // Draggable element in Simple tab
    public static By Simple_Draggable_Id = By.Id("draggable");

    // Droppable element in Simple tab
    public static By Simple_Droppable_Id = By.Id("droppable");
    // Droppable text (for assertion)
    public static By Droppable_Text_XPath1 = By.XPath("//div[@id='droppable']/p");

}
