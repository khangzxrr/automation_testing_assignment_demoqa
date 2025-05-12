using OpenQA.Selenium;

public static class DroppablePageLocators
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
    public static By Simple_Draggable_CSS1 = By.CssSelector("#draggable");
    public static By Simple_Draggable_CSS2 = By.CssSelector("div#draggable");
    public static By Simple_Draggable_XPath1 = By.XPath("//div[@id='draggable']");
    public static By Simple_Draggable_XPath2 = By.XPath(
        "//div[contains(@class,'draggable') and @id='draggable']"
    );

    // Droppable element in Simple tab
    public static By Simple_Droppable_Id = By.Id("droppable");
    public static By Simple_Droppable_CSS1 = By.CssSelector("#droppable");
    public static By Simple_Droppable_CSS2 = By.CssSelector("div#droppable");
    public static By Simple_Droppable_XPath1 = By.XPath(
        "//div[@id='simpleDropContainer']//div[@id='droppable']"
    );
    public static By Simple_Droppable_XPath2 = By.XPath(
        "//div[@id='simpleDropContainer']//div[contains(@class, 'drop-box ui-droppable')]"
    );

    // Droppable text (for assertion)
    public static By Droppable_Text_CSS1 = By.CssSelector("#droppable p");
    public static By Droppable_Text_CSS2 = By.CssSelector("div#droppable > p");
    public static By Droppable_Text_XPath1 = By.XPath("//div[@id='droppable']/p");
    public static By Droppable_Text_XPath2 = By.XPath(
        "//p[contains(text(),'Drop here') or contains(text(),'Dropped')]"
    );

}
