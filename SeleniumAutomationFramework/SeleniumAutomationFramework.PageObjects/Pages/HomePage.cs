using SeleniumAutomationFramework.Common.Selenium.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumAutomationFramework.Common.Helpers;
using SeleniumAutomationFramework.Drivers;

namespace SeleniumAutomationFramework.PageObjects.Pages
{
    public class HomePage : BasePage
    {
        #region Properties

        protected override string PageName
        {
            get { return "Home Page"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }
        //edit title
        protected override string Title
        {
            get { return " "; }
        }

        #endregion

        

        #region Elements
        [FindsBy(How = How.CssSelector,Using = ".home-tab.icon-Home")]
        private IWebElement homePageIcon { get; set; }
        private IWebElement salesOrderOpenLink { get; set; }
        [FindsBy(How = How.Id,Using = "createNewEntityLink")]
        private IWebElement createNewEntry { get; set; }
        [FindsBy(How = How.LinkText,Using = "Customers")]
        private IWebElement customerLink { get; set; }
        [FindsBy(How = How.CssSelector,Using = "[title ='QAWorks']")]
        private IWebElement QAWorksTitle { get; set; }



        #endregion


        #region Methods
        public void ClickCustomer()
        {
            SeleniumHelper.Wait(1);
            if(SeleniumHelper.IsDisplayed(customerLink))
                SeleniumHelper.Click(customerLink);
            SeleniumHelper.Click(createNewEntry);
        }
        public Boolean ConfirmNewCustomerCreation(String customerName)
        {
            Boolean result = false;
            if (QAWorksTitle.Text.Equals(customerName))
            {
                result = true;
            }
            return result;
        }
        public Boolean ConfirmCustomer(String customerID)
        {
            Boolean result = false;
            if (SeleniumHelper.IsElementPresent(By.LinkText(customerID)))
            {
                result = true; 
            }
            return result;
        }

        [FindsBy(How = How.LinkText, Using = "Restart")]
        private IWebElement retrestartLink { get; set; }
        [FindsBy(How = How.LinkText,Using = "Sign in again")]
        private IWebElement signInAgainLink { get; set; }
        public void RestartSession()
        {
            SeleniumHelper.Click(retrestartLink);
            SeleniumHelper.Click(signInAgainLink);

        }

        public void SelectCustomerById(string customerID)
        {
            SeleniumHelper.Wait(1);
            SeleniumHelper.Click(customerLink);
            IWebElement customerToDelete = SeleniumDriver.Instance.FindElement
               (By.LinkText(customerID));
                //(By.CssSelector("[title = 'Open record \"" + customerID + "\" in a new window']"));
            SeleniumHelper.Click(customerToDelete);
        }

        #endregion

    }
}
