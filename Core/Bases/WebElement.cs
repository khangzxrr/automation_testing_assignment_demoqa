using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class WebElement
{
    public IWebElement source { get; private set; }
    public IWebDriver driver { get; private set; }
    public By locator { get; private set; }

    private WebDriverWait wait;

    public WebElement(IWebDriver driver, IWebElement source, WebDriverWait wait, By locator)
    {
        this.driver = driver;
        this.source = source;
        this.wait = wait;
        this.locator = locator;
    }

    public void Click()
    {
        ScrollIntoViewAndClick();
    }

    public void Clear() => source.Clear();

    public void Type(string text)
    {
        ScrollIntoView();
        source.SendKeys(text);
    }

    public void SelectByValue(string value)
    {
        ScrollIntoView();
        SelectElement selectElement = new SelectElement(source);
        selectElement.SelectByValue(value);
    }

    public void SelectByText(string text)
    {
        ScrollIntoView();
        SelectElement selectElement = new SelectElement(source);
        selectElement.SelectByText(text);
    }

    public void ScrollIntoViewAndClick()
    {
        ScrollIntoView();
        source.Click();
    }

    public void ScrollIntoView()
    {
        ExecuteScript("arguments[0].scrollIntoView({ behavior: 'auto', block: 'center', inline: 'nearest'});");
    }

    public void ExecuteScript(string script)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript(script, source);
    }

    public T ExecuteScript<T>(string script)
    {
        return (T)((IJavaScriptExecutor)driver).ExecuteScript(script, source);
    }

    public bool IsValid() => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].checkValidity();", source);

    public string GetClass() => source.GetAttribute("class");

    public string GetCssValue(string css) => source.GetCssValue(css);

    public string Text => source.Text;

    public bool Enabled => source.Enabled;

    public bool Displayed => source.Displayed;

    public string GetAttribute(string property) => source.GetAttribute(property);



}

