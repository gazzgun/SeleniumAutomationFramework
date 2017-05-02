using SeleniumAutomationFramework.Drivers;
using SeleniumAutomationFramework.PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects.PageFactory
{
    public static class Pages
    {
        public static T GetPage<T>()where T : new()
        {
            var page = new T();
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(SeleniumDriver.Instance,page);
            return page;
        }
        #region Pages

        public static HomePage HomePage
        {
            get { return GetPage<HomePage>(); }
        }
        public static CreateCustomerPage CreateCustomerPage
        {
            get { return GetPage<CreateCustomerPage>(); }
        }
    public static ErrorPage ErrorPage
        {
            get { return GetPage<ErrorPage>(); }
        }
        public static ErrorPageSignIn ErrorPageSignIn
        {
            get { return GetPage<ErrorPageSignIn>(); }
        }

        #endregion
    }
}
