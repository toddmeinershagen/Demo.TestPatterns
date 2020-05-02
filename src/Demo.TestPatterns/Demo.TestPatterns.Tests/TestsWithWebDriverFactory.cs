using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

[TestFixture]
public class TestsWithWebDriverFactory
{
    [Test]
    public void test_with_decorative_web_driver()
    {
        using (var driver = WebDriverFactory.Create<ChromeDriver>(new ConsoleDelegatingWebDriver()))
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            var searchTextBox = wait.Until(x => x.FindElement(By.Name("q")));
            searchTextBox.Clear();
            searchTextBox.SendKeys("Test");
            searchTextBox.Submit();
        }
    }
}
