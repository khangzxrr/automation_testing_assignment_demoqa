using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class WebElement
{
    public IWebElement source { get; private set; }

    private WebDriverWait wait;

    public WebElement(IWebElement source, WebDriverWait wait)
    {
        this.source = source;
        this.wait = wait;
    }

    public void Click() => source.Click();

    public void Clear() => source.Clear();

    public void Type(string text) => source.SendKeys(text);

    public void SelectByValue(string value)
    {
        SelectElement selectElement = new SelectElement(source);
        selectElement.SelectByValue(value);
    }

    public string Text => source.Text;
}

