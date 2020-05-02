using System;
using System.Threading;
using OpenQA.Selenium;

public class WebDriverFactory
{
    public static ThreadLocal<IWebDriver> Driver;

    public static IWebDriver Create<TWebDriver>() 
        where TWebDriver:IWebDriver, new()
    {
        return Create<TWebDriver>(new NoOpDelegatingWebDriver());
    }

    public static IWebDriver Create<TWebDriver>(DelegatingWebDriver delegatingWebDriver)
        where TWebDriver:IWebDriver, new()
    {
        var innerWebDriver = CreateWebDriver(() => new TWebDriver());
        delegatingWebDriver.InnerWebDriver = innerWebDriver;

        return delegatingWebDriver;
    }

    public static IWebDriver CreateWith<TWebDriver>(Action<TWebDriver> configure) 
        where TWebDriver:IWebDriver, new()
    {
        return CreateWith<TWebDriver>(configure, new NoOpDelegatingWebDriver());    
    }

    public static IWebDriver CreateWith<TWebDriver>(Action<TWebDriver> configure, DelegatingWebDriver delegatingWebDriver)
        where TWebDriver : IWebDriver, new()
    {
        var innerWebDriver = CreateWith(new ConfigurableWebDriverBuilder<TWebDriver>(configure));
        delegatingWebDriver.InnerWebDriver = innerWebDriver;

        return delegatingWebDriver;
    }

    public static IWebDriver CreateWith(IWebDriverBuilder builder)
    {
        return CreateWith(builder, new NoOpDelegatingWebDriver());
    }

    public static IWebDriver CreateWith(IWebDriverBuilder builder, DelegatingWebDriver delegatingWebDriver)
    {
        var innerWebDriver = CreateWebDriver(() => builder.Build());
        delegatingWebDriver.InnerWebDriver = innerWebDriver;

        return delegatingWebDriver;
    }

    private static IWebDriver CreateWebDriver(Func<IWebDriver> factory)
    {
        if (Driver?.Value == null)
            Driver = new ThreadLocal<IWebDriver>(() => factory());

        return Driver.Value;
    }
}
