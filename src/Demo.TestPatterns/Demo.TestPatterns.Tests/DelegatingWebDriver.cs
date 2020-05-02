using System;
using System.Collections.ObjectModel;
using System.Reflection;
using OpenQA.Selenium;

public abstract class DelegatingWebDriver : IWebDriver
{
    private void HandleAction(MethodBase methodInfo, Action action)
    {
        if (InnerWebDriver == null)
        {
            throw new ArgumentNullException(paramName: nameof(InnerWebDriver));
        }
        
        HandleAction(methodInfo, () => {
            action();
            return true;
        });
    }

    protected abstract T HandleAction<T>(MethodBase methodInfo, Func<T> function);

    public string Url 
    {
        get { return InnerWebDriver.Url; }
        set { InnerWebDriver.Url = value; }
    }

    public string Title=> InnerWebDriver.Title;

    public string PageSource => InnerWebDriver.PageSource;

    public string CurrentWindowHandle => InnerWebDriver.CurrentWindowHandle;

    public ReadOnlyCollection<string> WindowHandles => InnerWebDriver.WindowHandles;

    public void Close()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        HandleAction(methodInfo, () => InnerWebDriver.Close());
    }

    public void Dispose()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        HandleAction(methodInfo, () => InnerWebDriver.Dispose());
    }

    public IWebElement FindElement(By by)
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        return HandleAction(methodInfo, () => InnerWebDriver.FindElement(by));
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        return HandleAction(methodInfo, () => InnerWebDriver.FindElements(by));
    }

    public IOptions Manage()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        return HandleAction(methodInfo, () => InnerWebDriver.Manage());
    }

    public INavigation Navigate()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        return HandleAction(methodInfo, () => InnerWebDriver.Navigate());
    }

    public void Quit()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        HandleAction(methodInfo, () => InnerWebDriver.Quit());
    }

    public ITargetLocator SwitchTo()
    {
        var methodInfo = MethodBase.GetCurrentMethod();
        return HandleAction(methodInfo, () => InnerWebDriver.SwitchTo());
    }

    public IWebDriver InnerWebDriver { get; set;}
}
