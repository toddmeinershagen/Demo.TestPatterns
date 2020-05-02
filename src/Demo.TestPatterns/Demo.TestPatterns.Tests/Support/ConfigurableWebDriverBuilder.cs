using System;
using OpenQA.Selenium;

class ConfigurableWebDriverBuilder<TWebDriver> : IWebDriverBuilder
    where TWebDriver:IWebDriver, new()
{
    private readonly Action<TWebDriver> _configure;
    
    public ConfigurableWebDriverBuilder(Action<TWebDriver> configure)
    {
        _configure = configure;
    }

    public IWebDriver Build()
    {
        var driver = new TWebDriver();
        _configure(driver);
        return driver;
    }
}