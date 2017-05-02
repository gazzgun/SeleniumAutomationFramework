using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;

public class ErrorPageSignIn : BasePage
{
    protected override string PageName => throw new NotImplementedException();

    protected override string RelativeUrl => throw new NotImplementedException();

    protected override string Title => throw new NotImplementedException();

    private Dictionary<string, string> data;
    private IWebDriver driver;
    private int timeout = 15;

    private readonly string pageLoadedText = "Thank you for using Microsoft Dynamics NAV";

    private readonly string pageUrl = "/NAV/WebClient/SignOut.aspx?dc=0&company=CRONUS%20International%20Ltd";

    [FindsBy(How = How.CssSelector, Using = "a[href='http://go.microsoft.com/FwLink/?LinkID=617571']")]
    [CacheLookup]
    private IWebElement privacy;

    [FindsBy(How = How.Id, Using = "ctl00_PHM_SignInAgainLink")]
    [CacheLookup]
    private IWebElement signInAgain;

    public ErrorPageSignIn()
        : this(default(IWebDriver), new Dictionary<string, string>(), 15)
    {
    }

    public ErrorPageSignIn(IWebDriver driver)
        : this(driver, new Dictionary<string, string>(), 15)
    {
    }

    public ErrorPageSignIn(IWebDriver driver, Dictionary<string, string> data)
        : this(driver, data, 15)
    {
    }

    public ErrorPageSignIn(IWebDriver driver, Dictionary<string, string> data, int timeout)
    {
        this.driver = driver;
        this.data = data;
        this.timeout = timeout;
    }

   

    /// <summary>
    /// Click on Privacy Link.
    /// </summary>
    /// <returns>The ErrorPageSignIn class instance.</returns>
    public ErrorPageSignIn ClickPrivacyLink() 
    {
        privacy.Click();
        return this;
    }

    /// <summary>
    /// Click on Sign In Again Link.
    /// </summary>
    /// <returns>The ErrorPageSignIn class instance.</returns>
    public ErrorPageSignIn ClickSignInAgainLink() 
    {
        signInAgain.Click();
        return this;
    }

    /// <summary>
    /// Verify that the page loaded completely.
    /// </summary>
    /// <returns>The ErrorPageSignIn class instance.</returns>
    public ErrorPageSignIn VerifyPageLoaded() 
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
    /// <returns>The ErrorPageSignIn class instance.</returns>
    public ErrorPageSignIn VerifyPageUrl() 
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
        {
            return d.Url.Contains(pageUrl);
        });
        return this;
    }
}
