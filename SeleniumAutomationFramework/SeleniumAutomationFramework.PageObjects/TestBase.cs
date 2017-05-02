using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.Drivers;
using SeleniumAutomationFramework.PageObjects.Configuration;
using SeleniumAutomationFramework.PageObjects.Sikuli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects
{
  public  class TestBase
    {
        public static void TestSetup()
        {
            SeleniumDriver.LocalBrowser = ApplicationSettings.GetLocalBrowser;
            SeleniumDriver.BaseUrl = ApplicationSettings.GetEnvironmentBaseUrl();

            if (SeleniumDriver.WebDriver == null)
            {
                SeleniumDriver.CreateDriver();
            }
            PageFactory.Pages.HomePage.Goto();
            HomePageSikuli.RestartSession();

        }

        public static void TearDown()
        {
            //SeleniumDriver.Instance.Manage().Cookies.DeleteAllCookies();
            SeleniumDriver.Instance.Close();
            SeleniumDriver.WebDriver = null;
        }
        public static void ChromeDelay()
        {
            if (SeleniumDriver.LocalBrowser.Equals("chrome"))
                Thread.Sleep(1000);
        }
    }
}
