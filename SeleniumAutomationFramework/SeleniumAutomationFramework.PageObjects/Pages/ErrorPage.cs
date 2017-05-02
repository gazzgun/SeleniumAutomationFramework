using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;

public class ErrorPage : BasePage
{

    protected override string PageName => throw new NotImplementedException();

    protected override string RelativeUrl => throw new NotImplementedException();

    protected override string Title => throw new NotImplementedException();

    private Dictionary<string, string> data;
    private IWebDriver driver;
    private int timeout = 15;

    private readonly string pageLoadedText = "&lt;div&gt;&lt;p&gt;The page is not working properly because the browser prevents scripts from running";

    private readonly string pageUrl = "/NAV/WebClient/?company=CRONUS%20International%20Ltd";

    [FindsBy(How = How.CssSelector, Using = "button.icon-NextStep-after")]
    [CacheLookup]
    private IWebElement restart;

    public ErrorPage()
        : this(default(IWebDriver), new Dictionary<string, string>(), 15)
    {
    }

    public ErrorPage(IWebDriver driver)
        : this(driver, new Dictionary<string, string>(), 15)
    {
    }

    public ErrorPage(IWebDriver driver, Dictionary<string, string> data)
        : this(driver, data, 15)
    {
    }

    public ErrorPage(IWebDriver driver, Dictionary<string, string> data, int timeout)
    {
        this.driver = driver;
        this.data = data;
        this.timeout = timeout;
    }

   

    /// <summary>
    /// Click on Restart Button.
    /// </summary>
    /// <returns>The ErrorPage class instance.</returns>
    public ErrorPage ClickRestartButton() 
    {
        restart.Click();
        return this;
    }

    /// <summary>
    /// Submit the form to target page.
    /// </summary>
    /// <returns>The ErrorPage class instance.</returns>
    public ErrorPage Submit() 
    {
        ClickRestartButton();
        return this;
    }

    /// <summary>
    /// Verify that the page loaded completely.
    /// </summary>
    /// <returns>The ErrorPage class instance.</returns>
    public ErrorPage VerifyPageLoaded() 
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
        {
            return d.PageSource.Contains(pageLoadedText);
        });
        return this;
    }

    /// <summary>
    /// Verify that current page URL matches the expected URL.
    /// </summary>
    /// <returns>The ErrorPage class instance.</returns>
    public ErrorPage VerifyPageUrl() 
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
        {
            return d.Url.Contains(pageUrl);
        });
        return this;
    }

    
}
