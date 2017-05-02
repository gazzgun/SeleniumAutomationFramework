using OpenQA.Selenium.Support.PageObjects;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.PageObjects;
using SeleniumAutomationFramework.PageObjects.PageFactory;
using SeleniumAutomationFramework.PageObjects.Sikuli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutomationFramework.Specs.Hooks
{
    [Binding]
    public class BeforeAfterScenario
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            HomePageSikuli.CreateSession();
            TestBase.TestSetup();
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            TestBase.ChromeDelay();
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            TestBase.TearDown();
        }
    }
}
