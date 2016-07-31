using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.Drivers
{
    public static class SeleniumDriver
    {
        #region Properties
        public static IWebDriver WebDriver;

        public static string LocalBrowser { get; set; }
        public static string BaseUrl { get; set; }

        #endregion

        public static IWebDriver Instance
        {
            get { return WebDriver ?? (WebDriver = CreateDriver()); }
        }


        public static IWebDriver CreateDriver()
        {
            switch (LocalBrowser.ToLower())
            {
                case "chrome":
                    WebDriver = new ChromeDriver(@"C:\Users\Gary\Documents\QAWorks\Drivers\");
                    break;
                case "firefox":
                    WebDriver = new FirefoxDriver();
                    break;
                case "ie":
                    WebDriver = new InternetExplorerDriver();
                    break;
                default:
                    WebDriver = new FirefoxDriver();
                    break;
            }
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            WebDriver.Manage().Window.Maximize();


            return WebDriver;
        }

        public static void Goto(string url)
        {
            Instance.Url = url != null && url.Trim() == "//" ? BaseUrl : BaseUrl + url;
        }
        
        public static void Close()
        {
            if (WebDriver == null) return;
            Instance.Quit();
            WebDriver = null;
        }
    }
}
