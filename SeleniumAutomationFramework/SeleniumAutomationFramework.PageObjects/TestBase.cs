using SeleniumAutomationFramework.Drivers;
using SeleniumAutomationFramework.PageObjects.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public static void TearDown()
        {
            SeleniumDriver.Close();
        }
    }
}
